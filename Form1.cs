using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

// Update feature branch — work in progress.

namespace BaobabRidgeWildlife
{
    public partial class Form1 : Form
    {
        // Cached list of animals currently displayed in the grid.
        private List<Animal> _animals = new List<Animal>();

        // The AnimalID currently being edited, or null if the form is in Add mode.
        private string _editingId = null;

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
        // Public so Add, Update, Delete and Summary can all call it after writing.
        public void RefreshGrid()
        {
            try
            {
                _animals = AnimalRepository.Load(out int skipped);
                dgvAnimals.DataSource = null;              // break binding to avoid duplicates
                dgvAnimals.DataSource = _animals;          // rebind
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
    }
}