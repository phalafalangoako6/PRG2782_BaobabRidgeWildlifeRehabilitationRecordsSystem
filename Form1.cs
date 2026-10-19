namespace BaobabRidgeWildlife
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dvgAnimals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
