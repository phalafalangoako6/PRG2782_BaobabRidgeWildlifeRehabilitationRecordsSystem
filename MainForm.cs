using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaobabRidge
{
    public partial class MainForm : Form
    {
        private List<Animal> _animals = new List<Animal>();
        private Animal _editing = null; // non-null while in edit mode

        public MainForm()
        {
            InitializeComponent();
        }

       

       
        /// Loads data from disk and refreshes the grid on startup.
       
        private void MainForm_Load(object sender, EventArgs e)
        {
            ConfigureGrid();
            LoadFromDisk();
            SetAddMode();
        }

        
        /// Configures the DataGridView: read-only, full-row select, exact columns.
      
        private void ConfigureGrid()
        {
            dgvAnimals.ReadOnly = true;
            dgvAnimals.AllowUserToAddRows = false;
            dgvAnimals.AllowUserToDeleteRows = false;
            dgvAnimals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimals.MultiSelect = false;
            dgvAnimals.AutoGenerateColumns = false;
            dgvAnimals.Columns.Clear();

            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Animal ID", DataPropertyName = "AnimalID" });
            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Name", DataPropertyName = "Name" });
            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Species", DataPropertyName = "Species" });
            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Age", DataPropertyName = "Age" });
            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Recovery Score", DataPropertyName = "RecoveryScore" });
            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Status", DataPropertyName = "Status" });
            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Housing Unit", DataPropertyName = "HousingUnit" });

            dgvAnimals.CellClick += DgvAnimals_CellClick;
        }

        
        /// Loads animals from disk, reports skipped lines, refreshes grid.
      
        private void LoadFromDisk()
        {
            _animals = FileStore.LoadAnimals(out int skipped, out string error);
            if (error != null)
                MessageBox.Show(error, "File error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (skipped > 0)
                MessageBox.Show($"{skipped} malformed line(s) were skipped while loading.",
                    "Load", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshGrid();
        }

     
        /// Rebuilds the grid from the in-memory list, preserving file order.
    
        private void RefreshGrid()
        {
            dgvAnimals.DataSource = null;
            dgvAnimals.DataSource = _animals.ToList();
        }

        // Form mode helpers

        /// Puts the form into Add mode: ID editable, Add enabled, Save disabled, boxes cleared.
       
        private void SetAddMode()
        {
            _editing = null;
            txtId.ReadOnly = false;
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            ClearInputs();
        }

       
        /// Puts the form into Edit mode for the given animal.
       
        private void SetEditMode(Animal a)
        {
            _editing = a;
            txtId.Text = a.AnimalID;
            txtName.Text = a.Name;
            txtSpecies.Text = a.Species;
            txtAge.Text = a.Age.ToString();
            txtScore.Text = a.RecoveryScore.ToString();
            txtId.ReadOnly = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
        }

        
        /// Clears all input fields.
      
        private void ClearInputs()
        {
            txtId.Clear();
            txtName.Clear();
            txtSpecies.Clear();
            txtAge.Clear();
            txtScore.Clear();
            txtId.Focus();
        }

        // ==== Add ===

    
        /// Validates inputs and appends a new animal to the file.
       
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out Animal candidate, out Control badField))
            {
                badField.Focus();
                return;
            }

            // Uniqueness check only for Add
            if (_animals.Any(a => a.AnimalID.Equals(candidate.AnimalID, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Animal ID must be unique.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Focus();
                return;
            }

            Classifier.Classify(candidate.RecoveryScore, out string status, out string unit);
            candidate.Status = status;
            candidate.HousingUnit = unit;

            if (!FileStore.AppendAnimal(candidate, out string error))
            {
                MessageBox.Show(error, "File error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _animals.Add(candidate);
            RefreshGrid();
            MessageBox.Show($"Added {candidate.AnimalID}.\nStatus: {status}\nHousing: {unit}",
                "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearInputs();
        }

        // == Update ==

      
        /// Loads the clicked row's animal into the form for editing.
       
        private void DgvAnimals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvAnimals.Rows[e.RowIndex].DataBoundItem is Animal a)
                SetEditMode(a);
        }

       
        /// Searches for an animal by exact ID (case-insensitive) and loads it for editing.
       
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearchId.Text.Trim();
            if (query.Length == 0)
            {
                MessageBox.Show("Enter an Animal ID to search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var match = _animals.FirstOrDefault(a => a.AnimalID.Equals(query, StringComparison.OrdinalIgnoreCase));
            if (match == null)
            {
                MessageBox.Show($"No animal found with ID {query.ToUpperInvariant()}.",
                    "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SetEditMode(match);
        }

       
        /// Validates and saves the edited animal, then rewrites the file.
     
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_editing == null) return;

            if (!ValidateInputs(out Animal edited, out Control badField))
            {
                badField.Focus();
                return;
            }

            // Keep the original ID; it cannot change.
            edited.AnimalID = _editing.AnimalID;

            Classifier.Classify(edited.RecoveryScore, out string status, out string unit);
            edited.Status = status;
            edited.HousingUnit = unit;

            // Replace in-memory record, then rewrite the whole file.
            int idx = _animals.FindIndex(a => a.AnimalID == _editing.AnimalID);
            if (idx < 0)
            {
                MessageBox.Show("The record could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetAddMode();
                return;
            }
            _animals[idx] = edited;

            if (!FileStore.RewriteAll(_animals, out string error))
            {
                MessageBox.Show(error, "File error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RefreshGrid();
            MessageBox.Show($"Updated {edited.AnimalID}.\nStatus: {status}\nHousing: {unit}",
                "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SetAddMode();
        }

        // =====Clear ====

      
        /// Returns the form to Add mode with empty inputs.
       
        private void btnClear_Click(object sender, EventArgs e)
        {
            SetAddMode();
        }

        // === Delete ====

       
        /// Deletes the selected animal after confirmation.
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAnimals.SelectedRows.Count == 0 ||
                !(dgvAnimals.SelectedRows[0].DataBoundItem is Animal selected))
            {
                MessageBox.Show("Please select a row to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Delete {selected.AnimalID} ({selected.Name})? This cannot be undone.",
                "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            var remaining = _animals.Where(a => a.AnimalID != selected.AnimalID).ToList();
            if (!FileStore.RewriteAll(remaining, out string error))
            {
                MessageBox.Show(error, "File error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _animals = remaining;
            RefreshGrid();

            // If the deleted animal was loaded in the form, clear it.
            if (_editing != null && _editing.AnimalID == selected.AnimalID)
                SetAddMode();
        }

        // ==== Summary ====


        /// Computes totals and per-status counts, displays them and writes summary.txt.

        
        /// Calculates totals and per-status counts, shows them on the form,
        /// and writes summary.txt in the exact required layout.
        
        private void btnSummary_Click(object sender, EventArgs e)
        {
            int total = _animals.Count;
            double avgAge = total > 0 ? _animals.Average(a => a.Age) : 0;
            double avgScore = total > 0 ? _animals.Average(a => a.RecoveryScore) : 0;

            int critical = _animals.Count(a => a.Status == "Critical");
            int serious = _animals.Count(a => a.Status == "Serious");
            int stable = _animals.Count(a => a.Status == "Stable");
            int recovering = _animals.Count(a => a.Status == "Recovering");
            int release = _animals.Count(a => a.Status == "Release-Ready");

            // Format the date exactly as requested: YYYY-MM-DD HH:MM
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            // Build the report string with exact spacing and layout
            string report =
                "BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE\r\n" +
                "ANIMAL SUMMARY REPORT\r\n" +
                $"Generated: {timestamp}\r\n" +
                "----------------------------------------\r\n" +
                $"Total animals:            {total}\r\n" +
                $"Average age (years):      {avgAge:F2}\r\n" +
                $"Average recovery score:   {avgScore:F2}\r\n" +
                "----------------------------------------\r\n" +
                "Animals per status:\r\n" +
                $"  Critical:               {critical}\r\n" +
                $"  Serious:                {serious}\r\n" +
                $"  Stable:                 {stable}\r\n" +
                $"  Recovering:             {recovering}\r\n" +
                $"  Release-Ready:          {release}\r\n";

            // Show on the form
            txtSummary.Text = report;

            // Save to summary.txt
            if (!FileStore.WriteSummary(report, out string error))
                MessageBox.Show(error, "File error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Summary saved to summary.txt.", "Summary",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==== Validation ====

        /// Validates all input fields against the rules in the brief.
        /// Returns true if valid, else false with the offending field set in badField.

        private bool ValidateInputs(out Animal animal, out Control badField)
        {
            animal = null;
            badField = null;

            string id = txtId.Text.Trim().ToUpperInvariant();
            string name = txtName.Text.Trim();
            string species = txtSpecies.Text.Trim();
            string ageText = txtAge.Text.Trim();
            string scoreText = txtScore.Text.Trim();

            if (!FileStore.IsValidId(id))
            {
                MessageBox.Show("Animal ID must be WR- followed by exactly 4 digits.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                badField = txtId; return false;
            }
            if (name.Length < 1 || name.Length > 30 || name.Contains("|"))
            {
                MessageBox.Show("Name must be 1-30 characters and must not contain '|'.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                badField = txtName; return false;
            }
            if (species.Length < 1 || species.Length > 30 || species.Contains("|"))
            {
                MessageBox.Show("Species must be 1-30 characters and must not contain '|'.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                badField = txtSpecies; return false;
            }
            if (!int.TryParse(ageText, out int age) || age < 0 || age > 100)
            {
                MessageBox.Show("Age must be a whole number between 0 and 100.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                badField = txtAge; return false;
            }
            if (!int.TryParse(scoreText, out int score) || score < 0 || score > 100)
            {
                MessageBox.Show("Recovery Score must be a whole number between 0 and 100.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                badField = txtScore; return false;
            }

            animal = new Animal
            {
                AnimalID = id,
                Name = name,
                Species = species,
                Age = age,
                RecoveryScore = score
            };
            return true;
        }
    }
}
