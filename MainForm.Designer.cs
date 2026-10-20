namespace BaobabRidge
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblSpecies = new System.Windows.Forms.Label();
            this.txtSpecies = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearchId = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.gbAnimals = new System.Windows.Forms.GroupBox();
            this.dgvAnimals = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSummary = new System.Windows.Forms.Button();
            this.gbSummary = new System.Windows.Forms.GroupBox();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.gbDetails.SuspendLayout();
            this.gbAnimals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimals)).BeginInit();
            this.gbSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDetails
            // 
            this.gbDetails.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbDetails.Controls.Add(this.lblId);
            this.gbDetails.Controls.Add(this.txtId);
            this.gbDetails.Controls.Add(this.lblName);
            this.gbDetails.Controls.Add(this.txtName);
            this.gbDetails.Controls.Add(this.lblSpecies);
            this.gbDetails.Controls.Add(this.txtSpecies);
            this.gbDetails.Controls.Add(this.lblAge);
            this.gbDetails.Controls.Add(this.txtAge);
            this.gbDetails.Controls.Add(this.lblScore);
            this.gbDetails.Controls.Add(this.txtScore);
            this.gbDetails.Controls.Add(this.lblSearch);
            this.gbDetails.Controls.Add(this.txtSearchId);
            this.gbDetails.Controls.Add(this.btnSearch);
            this.gbDetails.Controls.Add(this.btnClear);
            this.gbDetails.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetails.Location = new System.Drawing.Point(20, 20);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(1060, 207);
            this.gbDetails.TabIndex = 0;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Animal Details";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(20, 41);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(77, 16);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Animal ID:";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.SystemColors.Info;
            this.txtId.Location = new System.Drawing.Point(130, 29);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(200, 34);
            this.txtId.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(20, 84);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 16);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Info;
            this.txtName.Location = new System.Drawing.Point(130, 74);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 34);
            this.txtName.TabIndex = 3;
            // 
            // lblSpecies
            // 
            this.lblSpecies.AutoSize = true;
            this.lblSpecies.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecies.Location = new System.Drawing.Point(20, 128);
            this.lblSpecies.Name = "lblSpecies";
            this.lblSpecies.Size = new System.Drawing.Size(68, 16);
            this.lblSpecies.TabIndex = 4;
            this.lblSpecies.Text = "Species:";
            // 
            // txtSpecies
            // 
            this.txtSpecies.BackColor = System.Drawing.SystemColors.Info;
            this.txtSpecies.Location = new System.Drawing.Point(130, 118);
            this.txtSpecies.Name = "txtSpecies";
            this.txtSpecies.Size = new System.Drawing.Size(200, 34);
            this.txtSpecies.TabIndex = 5;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.Location = new System.Drawing.Point(392, 39);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(92, 16);
            this.lblAge.TabIndex = 6;
            this.lblAge.Text = "Age (years):";
            // 
            // txtAge
            // 
            this.txtAge.BackColor = System.Drawing.SystemColors.Info;
            this.txtAge.Location = new System.Drawing.Point(490, 29);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(80, 34);
            this.txtAge.TabIndex = 7;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(361, 74);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(123, 16);
            this.lblScore.TabIndex = 8;
            this.lblScore.Text = "Recovery Score:";
            // 
            // txtScore
            // 
            this.txtScore.BackColor = System.Drawing.SystemColors.Info;
            this.txtScore.Location = new System.Drawing.Point(490, 64);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(80, 34);
            this.txtScore.TabIndex = 9;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(615, 41);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(79, 16);
            this.lblSearch.TabIndex = 10;
            this.lblSearch.Text = "Search ID:";
            // 
            // txtSearchId
            // 
            this.txtSearchId.BackColor = System.Drawing.SystemColors.Info;
            this.txtSearchId.Location = new System.Drawing.Point(700, 29);
            this.txtSearchId.Name = "txtSearchId";
            this.txtSearchId.Size = new System.Drawing.Size(140, 34);
            this.txtSearchId.TabIndex = 11;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(891, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Info;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(32, 601);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 32);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Info;
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(478, 607);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 32);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(458, 169);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 32);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // gbAnimals
            // 
            this.gbAnimals.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbAnimals.Controls.Add(this.dgvAnimals);
            this.gbAnimals.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAnimals.Location = new System.Drawing.Point(20, 254);
            this.gbAnimals.Name = "gbAnimals";
            this.gbAnimals.Size = new System.Drawing.Size(1060, 341);
            this.gbAnimals.TabIndex = 1;
            this.gbAnimals.TabStop = false;
            this.gbAnimals.Text = "Animals in Care";
            // 
            // dgvAnimals
            // 
            this.dgvAnimals.AllowUserToAddRows = false;
            this.dgvAnimals.AllowUserToDeleteRows = false;
            this.dgvAnimals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnimals.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvAnimals.ColumnHeadersHeight = 29;
            this.dgvAnimals.Location = new System.Drawing.Point(12, 22);
            this.dgvAnimals.MultiSelect = false;
            this.dgvAnimals.Name = "dgvAnimals";
            this.dgvAnimals.ReadOnly = true;
            this.dgvAnimals.RowHeadersVisible = false;
            this.dgvAnimals.RowHeadersWidth = 51;
            this.dgvAnimals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnimals.Size = new System.Drawing.Size(1036, 334);
            this.dgvAnimals.TabIndex = 0;
            this.dgvAnimals.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAnimals_CellClick);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Info;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(911, 605);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(143, 32);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSummary
            // 
            this.btnSummary.BackColor = System.Drawing.SystemColors.Info;
            this.btnSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSummary.Location = new System.Drawing.Point(1351, 605);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(150, 34);
            this.btnSummary.TabIndex = 3;
            this.btnSummary.Text = "Generate Summary";
            this.btnSummary.UseVisualStyleBackColor = false;
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);
            // 
            // gbSummary
            // 
            this.gbSummary.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbSummary.Controls.Add(this.txtSummary);
            this.gbSummary.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSummary.Location = new System.Drawing.Point(1102, 20);
            this.gbSummary.Name = "gbSummary";
            this.gbSummary.Size = new System.Drawing.Size(559, 574);
            this.gbSummary.TabIndex = 2;
            this.gbSummary.TabStop = false;
            this.gbSummary.Text = "Summary Report";
            // 
            // txtSummary
            // 
            this.txtSummary.BackColor = System.Drawing.SystemColors.Info;
            this.txtSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSummary.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtSummary.Location = new System.Drawing.Point(3, 30);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.ReadOnly = true;
            this.txtSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSummary.Size = new System.Drawing.Size(553, 541);
            this.txtSummary.TabIndex = 0;
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1730, 860);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.gbAnimals);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSummary);
            this.Controls.Add(this.gbSummary);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSave);
            this.Name = "MainForm";
            this.Text = "Baobab Ridge Wildlife Rehabilitation Records System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            this.gbAnimals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimals)).EndInit();
            this.gbSummary.ResumeLayout(false);
            this.gbSummary.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblSpecies;
        private System.Windows.Forms.TextBox txtSpecies;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearchId;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox gbAnimals;
        private System.Windows.Forms.DataGridView dgvAnimals;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSummary;
        private System.Windows.Forms.GroupBox gbSummary;
        private System.Windows.Forms.TextBox txtSummary;
    }
}
