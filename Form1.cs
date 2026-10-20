using System.Xml.Linq;
using System.Data;

namespace BaobabRidgeWildlife
{
    public partial class Form1 : Form
    {


        //Creates a collection animals that holds multiple animal records and stores a new animal every time it is added.
        private List<Animal> animals = new List<Animal>();
        public Form1()
        {
            InitializeComponent();

            animals = FileStore.LoadAnimals(out int skippedLines, out string error);

            dgvDisplay.DataSource = null;
            dgvDisplay.DataSource = animals;

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error);
            }
            if (skippedLines > 0)
            {
                MessageBox.Show(skippedLines + " invalid animal records were skipped.");
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }
        //Check whether the Animal id uses uppercase WR- and four digits.
        private bool IsValidAnimalID(string animalID)
        {
            if (string.IsNullOrWhiteSpace(animalID))
            {
                return false;
            }
            if (animalID != animalID.Trim())
            {
                return false;
            }
            if (animalID.Length != 7)
            {
                return false;
            }
            if (!animalID.StartsWith("WR-"))
            {
                return false;
            }


            for (int i = 3; i < 7; i++)
            {
                if (animalID[i] < '0' || animalID[i] > '9')
                {
                    return false;
                }
            }

            return true;




        }

        //Checks whether the animal's name is valid and no longer than 30 characters
        private bool IsValidName(string name)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            if (name != name.Trim())
            {
                return false;
            }
            if (name.Length > 30)
            {
                return false;
            }
            if (name.Contains('|'))
            {
                return false;
            }
            return true;


        }
        //Checks whether the animal's species is valid and no longer than 30 characters.
        private bool IsValidSpecies(string species)
        {

            if (string.IsNullOrWhiteSpace(species))
            {
                return false;
            }
            if (species != species.Trim())
            {
                return false;
            }
            if (species.Length > 30)
            {
                return false;
            }
            if (species.Contains('|'))
            {
                return false;
            }

            return true;



        }

        //Checks whether Age is a whole number from 0 to 100
        private bool TryParseAge(string ageText, out int age)
        {
            age = 0;

            if (!int.TryParse(ageText, out age)) //attempt to convert text into an integer, if conversion fail return false
            {
                return false;
            }
            if (age < 0 || age > 100)// checks if the number is below 0 or above 100
            {
                return false;
            }
            return true;  //Age is valid




        }

        //checks whether recovery scire is a whole number from 0 t0 100 

        private bool TryParseRecoveryScore(string scoreText, out int score)
        {
            score = 0;
            if (!int.TryParse(scoreText, out score))
            {

                return false;
            }
            if (score < 0 || score > 100)
            {
                return false;
            }

            return true;


        }

        //Classification method
        private string GetAnimalStatus(int recoveryScore)
        {
            if (recoveryScore >= 0 && recoveryScore <= 19)
            {
                return "Critical";
            }
            else if (recoveryScore >= 20 && recoveryScore <= 39)
            {
                return "Serious";
            }
            else if (recoveryScore >= 40 && recoveryScore <= 59)
            {
                return "Stable";
            }
            else if (recoveryScore >= 60 && recoveryScore <= 79)
            {
                return "Recovering";
            }
            else if (recoveryScore >= 80 && recoveryScore <= 100)
            {
                return "Release-Ready";
            }
            else
            {
                return "Invalid score";
            }


        }
        private string GetHousingUnit(int recoveryScore)
        {
            if (recoveryScore >= 0 && recoveryScore <= 19)
            {
                return "Intensive Care Unit";
            }
            else if (recoveryScore >= 20 && recoveryScore <= 39)
            {
                return "High-Dependency Ward";
            }
            else if (recoveryScore >= 40 && recoveryScore <= 59)
            {
                return "Recovery Ward";
            }
            else if (recoveryScore >= 60 && recoveryScore <= 79)
            {
                return "Outdoor Enclosure";
            }
            else if (recoveryScore >= 80 && recoveryScore <= 100)
            {
                return "Pre-Release Camp";
            }
            else
            {
                return "Invalid Score";
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string animalID = txtAnimalID.Text;
            string name = txtName.Text;
            string species = txtSpecies.Text;
            string ageText = txtAge.Text;
            string recoveryScoreText = txtRecoveryScore.Text;

            if (!IsValidAnimalID(animalID))
            {
                MessageBox.Show("Please enter a valid Animal ID, eg WR-1001.");
                return;

            }
            if (!IsValidName(name))
            {
                MessageBox.Show("Please enter a valid animal name.");
                return;
            }
            if (!IsValidSpecies(species))
            {
                MessageBox.Show("Please enter a valid animal species.");
                return;
            }

            int age;

            if (!TryParseAge(ageText, out age))
            {
                MessageBox.Show("Age must be a whole number, between 0 and 100.");
                return;
            }

            int recoveryScore;

            if (!TryParseRecoveryScore(recoveryScoreText, out recoveryScore))
            {
                MessageBox.Show("Recovery Score must be a whole number, between 0 and 100.");
                return;
            }
            

            //checks if Animal ID already exists

            foreach (Animal existingAnimal in animals)
            {
                if (existingAnimal.AnimalID == animalID)
                {
                    MessageBox.Show("This Animal ID already exists");
                    return;
                }

            }

            string status = GetAnimalStatus(recoveryScore);
            string housingUnit = GetHousingUnit(recoveryScore);

            //Create a new animal
            Animal newAnimal = new Animal
            {
                AnimalID = animalID,
                Name = name,
                Species = species,
                Age = age,
                RecoveryScore = recoveryScore,
                Status = status,
                HousingUnit = housingUnit
            };

            string error;
            bool saved = FileStore.AppendAnimal(newAnimal, out error);

            if (!saved)
            {
                MessageBox.Show(error);
                return;
            }


            //add animal to the list
            animals.Add(newAnimal);

            //Display the animals in data grid view
            dgvDisplay.DataSource = null;
            dgvDisplay.DataSource = animals;

            txtAnimalID.Clear();
            txtName.Clear();
            txtSpecies.Clear();
            txtAge.Clear();
            txtRecoveryScore.Clear();
            txtAnimalID.Focus();


            MessageBox.Show("Animal added successfully!");


        }

        //Clear all textboxes
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAnimalID.Clear();
            txtName.Clear();
            txtSpecies.Clear();
            txtAge.Clear();
            txtRecoveryScore.Clear();

            txtAnimalID.Focus(); //laces the cursor in the Animal ID textbox, ready for the next entry

        }

        private void lblRecoveryScore_Click(object sender, EventArgs e)
        {

        }

        private void dgvDisplay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }



}
