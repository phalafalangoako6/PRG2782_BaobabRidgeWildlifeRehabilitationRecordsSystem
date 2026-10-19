namespace BaobabRidgeWildlife
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvAnimals = new DataGridView();
            colAnimalID = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colSpecies = new DataGridViewTextBoxColumn();
            colAge = new DataGridViewTextBoxColumn();
            colScore = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colHousing = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvAnimals).BeginInit();
            SuspendLayout();
            // 
            // dgvAnimals
            // 
            dgvAnimals.AllowUserToAddRows = false;
            dgvAnimals.AllowUserToDeleteRows = false;
            dgvAnimals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnimals.Columns.AddRange(new DataGridViewColumn[] { colAnimalID, colName, colSpecies, colAge, colScore, colStatus, colHousing });
            dgvAnimals.Location = new Point(-9, 7);
            dgvAnimals.MultiSelect = false;
            dgvAnimals.Name = "dgvAnimals";
            dgvAnimals.ReadOnly = true;
            dgvAnimals.RowHeadersVisible = false;
            dgvAnimals.RowHeadersWidth = 51;
            dgvAnimals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimals.Size = new Size(811, 431);
            dgvAnimals.TabIndex = 0;
            dgvAnimals.CellContentClick += dgvAnimals_CellContentClick;
            // 
            // colAnimalID
            // 
            colAnimalID.HeaderText = "Animal ID";
            colAnimalID.MinimumWidth = 6;
            colAnimalID.Name = "colAnimalID";
            colAnimalID.ReadOnly = true;
            colAnimalID.Width = 125;
            // 
            // colName
            // 
            colName.HeaderText = "Name";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 125;
            // 
            // colSpecies
            // 
            colSpecies.HeaderText = "Species";
            colSpecies.MinimumWidth = 6;
            colSpecies.Name = "colSpecies";
            colSpecies.ReadOnly = true;
            colSpecies.Width = 125;
            // 
            // colAge
            // 
            colAge.HeaderText = "Age";
            colAge.MinimumWidth = 6;
            colAge.Name = "colAge";
            colAge.ReadOnly = true;
            colAge.Width = 125;
            // 
            // colScore
            // 
            colScore.HeaderText = "Recovery Score";
            colScore.MinimumWidth = 6;
            colScore.Name = "colScore";
            colScore.ReadOnly = true;
            colScore.Width = 125;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.Width = 125;
            // 
            // colHousing
            // 
            colHousing.HeaderText = "Housing Unit";
            colHousing.MinimumWidth = 6;
            colHousing.Name = "colHousing";
            colHousing.ReadOnly = true;
            colHousing.Width = 125;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvAnimals);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAnimals).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvAnimals;
        private DataGridViewTextBoxColumn colAnimalID;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colSpecies;
        private DataGridViewTextBoxColumn colAge;
        private DataGridViewTextBoxColumn colScore;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colHousing;
    }
}
