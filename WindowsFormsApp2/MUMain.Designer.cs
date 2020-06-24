namespace RPDModule
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сброситьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шаблоныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типыШаблоновToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.dgvMUStruct = new System.Windows.Forms.DataGridView();
            this.colType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lbPlan = new MetroFramework.Controls.MetroLabel();
            this.tbPreview = new System.Windows.Forms.TextBox();
            this.btnCreateText = new MetroFramework.Controls.MetroButton();
            this.lbDiscipline = new MetroFramework.Controls.MetroLabel();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnInsert = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMUStruct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справочникиToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(995, 24);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обновитьToolStripMenuItem,
            this.сброситьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // обновитьToolStripMenuItem
            // 
            this.обновитьToolStripMenuItem.Image = global::RPDModule.Properties.Resources.icons8_доступные_обновления_30;
            this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.обновитьToolStripMenuItem.Text = "Обновить";
            this.обновитьToolStripMenuItem.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // сброситьToolStripMenuItem
            // 
            this.сброситьToolStripMenuItem.Image = global::RPDModule.Properties.Resources.icons8_перезагрузка_30;
            this.сброситьToolStripMenuItem.Name = "сброситьToolStripMenuItem";
            this.сброситьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.сброситьToolStripMenuItem.Text = "Сбросить";
            this.сброситьToolStripMenuItem.Click += new System.EventHandler(this.сброситьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Image = global::RPDModule.Properties.Resources.icons8_сохранить_30;
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.шаблоныToolStripMenuItem,
            this.типыШаблоновToolStripMenuItem});
            this.справочникиToolStripMenuItem.Image = global::RPDModule.Properties.Resources.icons8_журнал_30;
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // шаблоныToolStripMenuItem
            // 
            this.шаблоныToolStripMenuItem.Name = "шаблоныToolStripMenuItem";
            this.шаблоныToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.шаблоныToolStripMenuItem.Text = "Шаблоны";
            this.шаблоныToolStripMenuItem.Click += new System.EventHandler(this.шаблоныToolStripMenuItem_Click);
            // 
            // типыШаблоновToolStripMenuItem
            // 
            this.типыШаблоновToolStripMenuItem.Name = "типыШаблоновToolStripMenuItem";
            this.типыШаблоновToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.типыШаблоновToolStripMenuItem.Text = "Типы шаблонов";
            this.типыШаблоновToolStripMenuItem.Click += new System.EventHandler(this.типыШаблоновToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Image = global::RPDModule.Properties.Resources.icons8_настройки_30;
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Image = global::RPDModule.Properties.Resources.icons8_вопросительный_знак_30;
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(530, 164);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ReadOnly = true;
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(489, 251);
            this.tbDescription.TabIndex = 27;
            // 
            // dgvMUStruct
            // 
            this.dgvMUStruct.AllowDrop = true;
            this.dgvMUStruct.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvMUStruct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMUStruct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colType,
            this.colName});
            this.dgvMUStruct.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvMUStruct.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvMUStruct.Location = new System.Drawing.Point(16, 164);
            this.dgvMUStruct.MultiSelect = false;
            this.dgvMUStruct.Name = "dgvMUStruct";
            this.dgvMUStruct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMUStruct.Size = new System.Drawing.Size(493, 251);
            this.dgvMUStruct.TabIndex = 26;
            this.dgvMUStruct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMUStruct_CellClick);
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
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.colType.DefaultCellStyle = dataGridViewCellStyle5;
            this.colType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.colType.HeaderText = "Тип шаблона";
            this.colType.Name = "colType";
            this.colType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colType.Width = 200;
            // 
            // colName
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.colName.DefaultCellStyle = dataGridViewCellStyle6;
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
            // tbPreview
            // 
            this.tbPreview.Location = new System.Drawing.Point(16, 450);
            this.tbPreview.Multiline = true;
            this.tbPreview.Name = "tbPreview";
            this.tbPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbPreview.Size = new System.Drawing.Size(1003, 230);
            this.tbPreview.TabIndex = 34;
            // 
            // btnCreateText
            // 
            this.btnCreateText.Location = new System.Drawing.Point(369, 421);
            this.btnCreateText.Name = "btnCreateText";
            this.btnCreateText.Size = new System.Drawing.Size(140, 23);
            this.btnCreateText.TabIndex = 38;
            this.btnCreateText.Text = "Сгенерировать текст";
            this.btnCreateText.Click += new System.EventHandler(this.btnCreateText_Click);
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
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(16, 421);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 23);
            this.btnDelete.TabIndex = 39;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 5;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 1;
            this.toolTip1.ShowAlways = true;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(895, 686);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(124, 23);
            this.btnInsert.TabIndex = 40;
            this.btnInsert.Text = "Вставить";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::RPDModule.Properties.Resources.icons8_сортировать_справа_налево_30;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(20, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 24);
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // MUMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 732);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCreateText);
            this.Controls.Add(this.tbPreview);
            this.Controls.Add(this.lbDiscipline);
            this.Controls.Add(this.lbPlan);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.dgvMUStruct);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MUMain";
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.DropShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "    Методические указания";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MUMain_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMUStruct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шаблоныToolStripMenuItem;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.DataGridView dgvMUStruct;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lbPlan;
        private System.Windows.Forms.TextBox tbPreview;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типыШаблоновToolStripMenuItem;
        private MetroFramework.Controls.MetroButton btnCreateText;
        private MetroFramework.Controls.MetroLabel lbDiscipline;
        private MetroFramework.Controls.MetroButton btnDelete;
        private System.Windows.Forms.ToolTip toolTip1;
        private MetroFramework.Controls.MetroButton btnInsert;
        private System.Windows.Forms.DataGridViewComboBoxColumn colType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сброситьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
    }
}