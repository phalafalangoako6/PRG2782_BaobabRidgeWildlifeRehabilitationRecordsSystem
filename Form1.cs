using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BaobabRidgeWildlife
{
    public partial class Form1 : Form
    {
        // Cached list of animals currently displayed in the grid.
        private List<Animal> _animals = new List<Animal>();

        // The AnimalID currently being edited, or empty if the form is in Add mode.
        private string _editingId = string.Empty;

        // Initializes the form and its designer-generated controls.
        public Form1()
        {
            InitializeComponent();
        }

        // Binds each designer column to an Animal property name.
        private void ConfigureGridColumns()
        {
            dgvAnimals.AutoGenerateColumns = false;
            dgvAnimals.Columns["colAnimalID"].DataPropertyName = "AnimalID";
            dgvAnimals.Columns["colName"].DataPropertyName = "Name";
            dgvAnimals.Columns["colSpecies"].DataPropertyName = "Species";
            dgvAnimals.Columns["colAge"].DataPropertyName = "Age";
            dgvAnimals.Columns["colScore"].DataPropertyName = "RecoveryScore";
            dgvAnimals.Columns["colStatus"].DataPropertyName = "Status";
            dgvAnimals.Columns["colHousing"].DataPropertyName = "HousingUnit";
        }

        // Loads valid records from animals.txt into the grid when the form opens.
        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigureGridColumns();
            RefreshGrid();


        }

        // Reloads animals.txt and rebinds the grid without creating duplicate rows.
        public void RefreshGrid()
        {
            try
            {
                _animals = AnimalRepository.Load(out int skipped);
                dgvAnimals.DataSource = null;
                dgvAnimals.DataSource = _animals;
                if (skipped > 0)
                {
                    MessageBox.Show($"{skipped} malformed line(s) were skipped.",
                                    "Load warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                MessageBox.Show("Could not read animals.txt. " + ex.Message,
                                "File error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Puts the form into edit mode for the given animal, or Add mode when animal is null.
        private void EnterEditMode(Animal animal)
        {
            if (animal == null)
            {
                _editingId = string.Empty;
                txtAnimalID.ReadOnly = false;
                btnAdd.Enabled = true;
                btnSave.Enabled = false;
                return;
            }

            _editingId = animal.AnimalID;
            txtAnimalID.Text = animal.AnimalID;
            txtName.Text = animal.Name;
            txtSpecies.Text = animal.Species;
            txtAge.Text = animal.Age.ToString();
            txtScore.Text = animal.RecoveryScore.ToString();

            txtAnimalID.ReadOnly = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
        }

        // Empties all input boxes and returns focus to the ID box.
        private void ClearInputs()
        {
            txtAnimalID.Text = "";
            txtName.Text = "";
            txtSpecies.Text = "";
            txtAge.Text = "";
            txtScore.Text = "";
            txtAnimalID.Focus();
        }

        // Loads the clicked row's animal into the input boxes and enters edit mode.
        private void dgvAnimals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvAnimals.Rows[e.RowIndex].DataBoundItem is Animal animal)
                EnterEditMode(animal);
        }

        // Searches for an animal by exact ID (case-insensitive) and loads it for editing.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchId = txtSearchID.Text.Trim().ToUpperInvariant();
            if (searchId.Length == 0)
            {
                MessageBox.Show("Enter an Animal ID to search.", "Search");
                txtSearchID.Focus();
                return;
            }

            Animal match = null;
            foreach (Animal a in _animals)
            {
                if (a.AnimalID == searchId) { match = a; break; }
            }

            if (match == null)
            {
                MessageBox.Show($"No animal found with ID '{searchId}'.", "Search");
                return;
            }

            EnterEditMode(match);
        }

        // Leaves edit mode and returns the form to Add mode with empty boxes.
        private void btnClear_Click(object sender, EventArgs e)
        {
            EnterEditMode(null);
            ClearInputs();
        }

        // Validates edits, recalculates status/housing, and saves the record.
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_editingId == string.Empty) return;

            string name = txtName.Text.Trim();
            string species = txtSpecies.Text.Trim();
            string ageText = txtAge.Text.Trim();
            string scoreText = txtScore.Text.Trim();

            // Validation
            if (name.Length == 0 || name.Length > 30 || name.Contains("|"))
            { MessageBox.Show("Name must be 1–30 characters and cannot contain '|'.", "Validation"); txtName.Focus(); return; }

            if (species.Length == 0 || species.Length > 30 || species.Contains("|"))
            { MessageBox.Show("Species must be 1–30 characters and cannot contain '|'.", "Validation"); txtSpecies.Focus(); return; }

            if (!int.TryParse(ageText, out int age) || age < 0 || age > 100)
            { MessageBox.Show("Age must be a whole number between 0 and 100.", "Validation"); txtAge.Focus(); return; }

            if (!int.TryParse(scoreText, out int score) || score < 0 || score > 100)
            { MessageBox.Show("Recovery Score must be a whole number between 0 and 100.", "Validation"); txtScore.Focus(); return; }

            // Recalculate status and housing
            string status;
            string housing;
            if (score <= 19) { status = "Critical"; housing = "Intensive Care Unit"; }
            else if (score <= 39) { status = "Serious"; housing = "High-Dependency Ward"; }
            else if (score <= 59) { status = "Stable"; housing = "Recovery Ward"; }
            else if (score <= 79) { status = "Recovering"; housing = "Outdoor Enclosure"; }
            else { status = "Release-Ready"; housing = "Pre-Release Camp"; }

            var updated = new Animal
            {
                AnimalID = _editingId,
                Name = name,
                Species = species,
                Age = age,
                RecoveryScore = score,
                Status = status,
                HousingUnit = housing
            };

            try
            {
                AnimalRepository.UpdateRecord(_editingId, updated);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                MessageBox.Show("Could not save changes. " + ex.Message, "File error");
                return;
            }

            EnterEditMode(null);
            ClearInputs();
            RefreshGrid();
            MessageBox.Show($"Updated {updated.AnimalID} — {status}, {housing}.", "Saved");
        }
        // Deletes the animal selected in the grid after Yes/No confirmation.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 1. Check if a row is actually selected
            if (dgvAnimals.CurrentRow == null || !(dgvAnimals.CurrentRow.DataBoundItem is Animal selected))
            {
                MessageBox.Show("Select a row in the grid to delete.", "Delete");
                return;
            }

            // 2. Ask for confirmation
            var confirm = MessageBox.Show(
                $"Delete {selected.AnimalID} ({selected.Name})? This cannot be undone.",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            // 3. Try to delete from the file
            try
            {
                AnimalRepository.DeleteRecord(selected.AnimalID);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                MessageBox.Show("Could not delete record. " + ex.Message, "File error");
                return;
            }

            // 4. Clear the form if the deleted animal was currently being edited
            if (_editingId == selected.AnimalID)
            {
                EnterEditMode(null);
                ClearInputs();
            }

            // 5. Refresh the grid
            RefreshGrid();
        }

        private void btnGenerateSummary_Click(object sender, EventArgs e)
{
    try
    {
        string dataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "animals.txt");
        string summaryFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "summary.txt");

        List<Animal> parsingCollection = new List<Animal>();

        if (File.Exists(dataFilePath))
        {
            string[] rawLines = File.ReadAllLines(dataFilePath);

            foreach (string rawLine in rawLines)
            {
                if (string.IsNullOrWhiteSpace(rawLine)) continue;

                string[] fields = rawLine.Split('|');

                if (fields.Length != 7) continue;

                if (int.TryParse(fields[3].Trim(), out int parsedAge) &&
                    int.TryParse(fields[4].Trim(), out int parsedScore))
                {
                    parsingCollection.Add(new Animal
                    {
                        AnimalID = fields[0].Trim(),
                        Name = fields[1].Trim(),
                        Species = fields[2].Trim(),
                        Age = parsedAge,
                        RecoveryScore = parsedScore,
                        Status = fields[5].Trim(),
                        HousingUnit = fields[6].Trim()
                    });
                }
            }
        }

        Summary.GenerateSummaryReport(parsingCollection, summaryFilePath);

        MessageBox.Show("Summary report successfully calculated and saved to summary.txt!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    catch (IOException)
    {
        MessageBox.Show("The summary or data file is currently locked or in use by another program.", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    catch (UnauthorizedAccessException)
    {
        MessageBox.Show("Access denied. The program does not have permissions to read or write the data assets here.", "Security Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    catch (Exception ex)
    {
        MessageBox.Show($"An unexpected evaluation tracking error occurred: {ex.Message}", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
        
    }
}
