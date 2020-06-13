namespace WindowsFormsApp2
{
    partial class MUMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шаблоныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавлениеШаблонаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInsert = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvMUStruct = new System.Windows.Forms.DataGridView();
            this.colType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lbPlan = new MetroFramework.Controls.MetroLabel();
            this.lbDiscipline = new MetroFramework.Controls.MetroLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.менеджерШаблоновToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMUStruct)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(995, 24);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.шаблоныToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // шаблоныToolStripMenuItem
            // 
            this.шаблоныToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавлениеШаблонаToolStripMenuItem,
            this.менеджерШаблоновToolStripMenuItem});
            this.шаблоныToolStripMenuItem.Name = "шаблоныToolStripMenuItem";
            this.шаблоныToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.шаблоныToolStripMenuItem.Text = "Шаблоны";
            // 
            // добавлениеШаблонаToolStripMenuItem
            // 
            this.добавлениеШаблонаToolStripMenuItem.Name = "добавлениеШаблонаToolStripMenuItem";
            this.добавлениеШаблонаToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.добавлениеШаблонаToolStripMenuItem.Text = "Добавление шаблона";
            this.добавлениеШаблонаToolStripMenuItem.Click += new System.EventHandler(this.добавлениеШаблонаToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(937, 686);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 28;
            this.btnInsert.Text = "Вставить";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(530, 164);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(489, 251);
            this.textBox1.TabIndex = 27;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dgvMUStruct
            // 
            this.dgvMUStruct.AllowDrop = true;
            this.dgvMUStruct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMUStruct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colType,
            this.colName});
            this.dgvMUStruct.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvMUStruct.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvMUStruct.Location = new System.Drawing.Point(20, 164);
            this.dgvMUStruct.MultiSelect = false;
            this.dgvMUStruct.Name = "dgvMUStruct";
            this.dgvMUStruct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMUStruct.Size = new System.Drawing.Size(493, 251);
            this.dgvMUStruct.TabIndex = 26;
            this.dgvMUStruct.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMUStruct_CellValueChanged);
            this.dgvMUStruct.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvMUStruct_CurrentCellDirtyStateChanged);
            this.dgvMUStruct.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvMUStruct_DataError);
            this.dgvMUStruct.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvMUStruct_EditingControlShowing);
            this.dgvMUStruct.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvMUStruct_DragDrop);
            this.dgvMUStruct.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvMUStruct_DragOver);
            this.dgvMUStruct.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvMUStruct_MouseDown);
            this.dgvMUStruct.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvMUStruct_MouseMove);
            // 
            // colType
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.colType.DefaultCellStyle = dataGridViewCellStyle2;
            this.colType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.colType.HeaderText = "Тип шаблона";
            this.colType.Name = "colType";
            this.colType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colType.Width = 200;
            // 
            // colName
            // 
            this.colName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.colName.HeaderText = "Имя шаблона";
            this.colName.Name = "colName";
            this.colName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colName.Width = 250;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(20, 127);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(86, 19);
            this.metroLabel1.TabIndex = 29;
            this.metroLabel1.Text = "Дисциплина";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(20, 93);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(40, 19);
            this.metroLabel2.TabIndex = 30;
            this.metroLabel2.Text = "План";
            // 
            // lbPlan
            // 
            this.lbPlan.AutoSize = true;
            this.lbPlan.Location = new System.Drawing.Point(138, 93);
            this.lbPlan.Name = "lbPlan";
            this.lbPlan.Size = new System.Drawing.Size(39, 19);
            this.lbPlan.TabIndex = 31;
            this.lbPlan.Text = "-----";
            // 
            // lbDiscipline
            // 
            this.lbDiscipline.AutoSize = true;
            this.lbDiscipline.Location = new System.Drawing.Point(138, 127);
            this.lbDiscipline.Name = "lbDiscipline";
            this.lbDiscipline.Size = new System.Drawing.Size(39, 19);
            this.lbDiscipline.TabIndex = 32;
            this.lbDiscipline.Text = "-----";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(438, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "Обновить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(16, 450);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(1003, 230);
            this.textBox2.TabIndex = 34;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 421);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 23);
            this.button2.TabIndex = 36;
            this.button2.Text = "Задать структуру";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(317, 422);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 37;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(412, 423);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 38;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // менеджерШаблоновToolStripMenuItem
            // 
            this.менеджерШаблоновToolStripMenuItem.Name = "менеджерШаблоновToolStripMenuItem";
            this.менеджерШаблоновToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.менеджерШаблоновToolStripMenuItem.Text = "Менеджер шаблонов";
            this.менеджерШаблоновToolStripMenuItem.Click += new System.EventHandler(this.менеджерШаблоновToolStripMenuItem_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 732);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbDiscipline);
            this.Controls.Add(this.lbPlan);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgvMUStruct);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form3";
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.DropShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Методические указания";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMUStruct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шаблоныToolStripMenuItem;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgvMUStruct;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lbPlan;
        private MetroFramework.Controls.MetroLabel lbDiscipline;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавлениеШаблонаToolStripMenuItem;
        private System.Windows.Forms.DataGridViewComboBoxColumn colType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ToolStripMenuItem менеджерШаблоновToolStripMenuItem;
    }
}