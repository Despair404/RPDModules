namespace WindowsFormsApp2
{
    partial class MUManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvTemplates = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cbType = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tbSearchName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemplates)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTemplates
            // 
            this.dgvTemplates.AllowUserToAddRows = false;
            this.dgvTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTemplates.Location = new System.Drawing.Point(23, 109);
            this.dgvTemplates.Name = "dgvTemplates";
            this.dgvTemplates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTemplates.Size = new System.Drawing.Size(520, 279);
            this.dgvTemplates.TabIndex = 0;
            this.dgvTemplates.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTemplates_CellClick);
            this.dgvTemplates.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTemplates_CellContentClick);
            this.dgvTemplates.SelectionChanged += new System.EventHandler(this.dgvTemplates_SelectionChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(569, 423);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 28);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(569, 109);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(523, 279);
            this.tbDescription.TabIndex = 2;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(294, 423);
            this.tbName.Multiline = true;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(249, 28);
            this.tbName.TabIndex = 4;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 400);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(95, 19);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Тип шаблона:";
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.ItemHeight = 23;
            this.cbType.Location = new System.Drawing.Point(23, 422);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(255, 29);
            this.cbType.TabIndex = 6;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(294, 400);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(131, 19);
            this.metroLabel2.TabIndex = 7;
            this.metroLabel2.Text = "Название шаблона:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(80, 80);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(169, 23);
            this.textBox3.TabIndex = 8;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // tbSearchName
            // 
            this.tbSearchName.Location = new System.Drawing.Point(364, 80);
            this.tbSearchName.Multiline = true;
            this.tbSearchName.Name = "tbSearchName";
            this.tbSearchName.Size = new System.Drawing.Size(169, 23);
            this.tbSearchName.TabIndex = 9;
            this.tbSearchName.TextChanged += new System.EventHandler(this.tbSearchName_TextChanged);
            // 
            // MUManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 479);
            this.Controls.Add(this.tbSearchName);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvTemplates);
            this.Name = "MUManager";
            this.Text = "Шаблоны МУ";
            this.Load += new System.EventHandler(this.MUManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemplates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTemplates;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbName;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox cbType;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox tbSearchName;
    }
}