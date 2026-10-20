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
            dgvDisplay = new DataGridView();
            lblName = new Label();
            lblSpecies = new Label();
            lblAge = new Label();
            lblRecoveryScore = new Label();
            txtRecoveryScore = new TextBox();
            txtAge = new TextBox();
            txtSpecies = new TextBox();
            txtName = new TextBox();
            txtAnimalID = new TextBox();
            btnAdd = new Button();
            btnClear = new Button();
            groupBox1 = new GroupBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDisplay).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvDisplay
            // 
            dgvDisplay.BackgroundColor = SystemColors.ActiveBorder;
            dgvDisplay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDisplay.Location = new Point(51, 283);
            dgvDisplay.Name = "dgvDisplay";
            dgvDisplay.ReadOnly = true;
            dgvDisplay.RowHeadersWidth = 51;
            dgvDisplay.Size = new Size(688, 239);
            dgvDisplay.TabIndex = 0;
            dgvDisplay.CellContentClick += dgvDisplay_CellContentClick;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(80, 99);
            lblName.Name = "lblName";
            lblName.Size = new Size(52, 20);
            lblName.TabIndex = 2;
            lblName.Text = "Name:";
            // 
            // lblSpecies
            // 
            lblSpecies.AutoSize = true;
            lblSpecies.Location = new Point(70, 161);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new Size(62, 20);
            lblSpecies.TabIndex = 3;
            lblSpecies.Text = "Species:";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(500, 49);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(39, 20);
            lblAge.TabIndex = 4;
            lblAge.Text = "Age:";
            // 
            // lblRecoveryScore
            // 
            lblRecoveryScore.AutoSize = true;
            lblRecoveryScore.Location = new Point(436, 99);
            lblRecoveryScore.Name = "lblRecoveryScore";
            lblRecoveryScore.Size = new Size(113, 20);
            lblRecoveryScore.TabIndex = 5;
            lblRecoveryScore.Text = "Recovery Score:";
            lblRecoveryScore.Click += lblRecoveryScore_Click;
            // 
            // txtRecoveryScore
            // 
            txtRecoveryScore.AcceptsReturn = true;
            txtRecoveryScore.Location = new Point(576, 99);
            txtRecoveryScore.Name = "txtRecoveryScore";
            txtRecoveryScore.Size = new Size(214, 27);
            txtRecoveryScore.TabIndex = 6;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(576, 45);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(214, 27);
            txtAge.TabIndex = 7;
            // 
            // txtSpecies
            // 
            txtSpecies.Location = new Point(163, 161);
            txtSpecies.Name = "txtSpecies";
            txtSpecies.Size = new Size(214, 27);
            txtSpecies.TabIndex = 8;
            // 
            // txtName
            // 
            txtName.Location = new Point(163, 99);
            txtName.Name = "txtName";
            txtName.Size = new Size(214, 27);
            txtName.TabIndex = 9;
            // 
            // txtAnimalID
            // 
            txtAnimalID.Location = new Point(163, 45);
            txtAnimalID.Name = "txtAnimalID";
            txtAnimalID.Size = new Size(214, 27);
            txtAnimalID.TabIndex = 10;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(543, 200);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 29);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Add Animal";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(704, 200);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 29);
            btnClear.TabIndex = 12;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(lblName);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(lblSpecies);
            groupBox1.Controls.Add(txtRecoveryScore);
            groupBox1.Controls.Add(txtAge);
            groupBox1.Controls.Add(txtSpecies);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(txtAnimalID);
            groupBox1.Controls.Add(lblAge);
            groupBox1.Controls.Add(lblRecoveryScore);
            groupBox1.Location = new Point(51, 29);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(832, 235);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 45);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 2;
            label1.Text = "Animal ID:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 550);
            Controls.Add(groupBox1);
            Controls.Add(dgvDisplay);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDisplay).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvDisplay;
        private Label lblName;
        private Label lblSpecies;
        private Label lblAge;
        private Label lblRecoveryScore;
        private TextBox txtRecoveryScore;
        private TextBox txtAge;
        private TextBox txtSpecies;
        private TextBox txtName;
        private TextBox txtAnimalID;
        private Button btnAdd;
        private Button btnClear;
        private GroupBox groupBox1;
        private Label label1;
    }
}
