namespace WindowsFormsApp2
{
    partial class TicketHeader
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
            this.DepartamentTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.MajorCode = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.MajorName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.DisciplineNameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.SemesterComboBox = new MetroFramework.Controls.MetroComboBox();
            this.AcademicYearComboBox = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.GenerateTicketsButton = new System.Windows.Forms.Button();
            this.EditDesciplineNameButton = new System.Windows.Forms.Button();
            this.DepartamentEditButton = new System.Windows.Forms.Button();
            this.MajorCodeEditButton = new System.Windows.Forms.Button();
            this.MajorNameEditNumber = new System.Windows.Forms.Button();
            this.DaddyTextBox = new MetroFramework.Controls.MetroTextBox();
            this.DaddyEditButton = new System.Windows.Forms.Button();
            this.TicketsProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.SuspendLayout();
            // 
            // DepartamentTextBox
            // 
            this.DepartamentTextBox.Location = new System.Drawing.Point(221, 63);
            this.DepartamentTextBox.Name = "DepartamentTextBox";
            this.DepartamentTextBox.Size = new System.Drawing.Size(526, 23);
            this.DepartamentTextBox.TabIndex = 0;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 65);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(61, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Кафедра";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 97);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(60, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Семестр";
            // 
            // MajorCode
            // 
            this.MajorCode.Location = new System.Drawing.Point(221, 191);
            this.MajorCode.Name = "MajorCode";
            this.MajorCode.Size = new System.Drawing.Size(526, 23);
            this.MajorCode.TabIndex = 7;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(23, 192);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(127, 19);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Код специальности";
            // 
            // MajorName
            // 
            this.MajorName.Location = new System.Drawing.Point(221, 220);
            this.MajorName.Name = "MajorName";
            this.MajorName.Size = new System.Drawing.Size(526, 23);
            this.MajorName.TabIndex = 11;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(23, 221);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(164, 19);
            this.metroLabel5.TabIndex = 10;
            this.metroLabel5.Text = "Название специальности";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(23, 164);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(86, 19);
            this.metroLabel6.TabIndex = 9;
            this.metroLabel6.Text = "Дисциплина";
            // 
            // DisciplineNameTextBox
            // 
            this.DisciplineNameTextBox.Location = new System.Drawing.Point(221, 162);
            this.DisciplineNameTextBox.Name = "DisciplineNameTextBox";
            this.DisciplineNameTextBox.Size = new System.Drawing.Size(526, 23);
            this.DisciplineNameTextBox.TabIndex = 8;
            // 
            // SemesterComboBox
            // 
            this.SemesterComboBox.FormattingEnabled = true;
            this.SemesterComboBox.ItemHeight = 23;
            this.SemesterComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.SemesterComboBox.Location = new System.Drawing.Point(221, 92);
            this.SemesterComboBox.Name = "SemesterComboBox";
            this.SemesterComboBox.Size = new System.Drawing.Size(121, 29);
            this.SemesterComboBox.TabIndex = 16;
            // 
            // AcademicYearComboBox
            // 
            this.AcademicYearComboBox.FormattingEnabled = true;
            this.AcademicYearComboBox.ItemHeight = 23;
            this.AcademicYearComboBox.Location = new System.Drawing.Point(221, 127);
            this.AcademicYearComboBox.Name = "AcademicYearComboBox";
            this.AcademicYearComboBox.Size = new System.Drawing.Size(121, 29);
            this.AcademicYearComboBox.TabIndex = 18;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(23, 132);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(88, 19);
            this.metroLabel4.TabIndex = 17;
            this.metroLabel4.Text = "Учебный год";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(23, 254);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(98, 19);
            this.metroLabel7.TabIndex = 19;
            this.metroLabel7.Text = "Зав. кафедрой";
            // 
            // GenerateTicketsButton
            // 
            this.GenerateTicketsButton.Location = new System.Drawing.Point(571, 278);
            this.GenerateTicketsButton.Name = "GenerateTicketsButton";
            this.GenerateTicketsButton.Size = new System.Drawing.Size(206, 23);
            this.GenerateTicketsButton.TabIndex = 25;
            this.GenerateTicketsButton.Text = "Сгенерировать билеты";
            this.GenerateTicketsButton.UseVisualStyleBackColor = true;
            this.GenerateTicketsButton.Click += new System.EventHandler(this.GenerateTicketsButton_Click);
            // 
            // EditDesciplineNameButton
            // 
            this.EditDesciplineNameButton.BackgroundImage = global::WindowsFormsApp2.Properties.Resources._1486504369_change_edit_options_pencil_settings_tools_write_81307;
            this.EditDesciplineNameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditDesciplineNameButton.Location = new System.Drawing.Point(753, 162);
            this.EditDesciplineNameButton.Name = "EditDesciplineNameButton";
            this.EditDesciplineNameButton.Size = new System.Drawing.Size(24, 23);
            this.EditDesciplineNameButton.TabIndex = 24;
            this.EditDesciplineNameButton.UseVisualStyleBackColor = true;
            this.EditDesciplineNameButton.Click += new System.EventHandler(this.EditDesciplineNameButton_Click);
            // 
            // DepartamentEditButton
            // 
            this.DepartamentEditButton.BackgroundImage = global::WindowsFormsApp2.Properties.Resources._1486504369_change_edit_options_pencil_settings_tools_write_81307;
            this.DepartamentEditButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DepartamentEditButton.Location = new System.Drawing.Point(753, 63);
            this.DepartamentEditButton.Name = "DepartamentEditButton";
            this.DepartamentEditButton.Size = new System.Drawing.Size(24, 23);
            this.DepartamentEditButton.TabIndex = 26;
            this.DepartamentEditButton.UseVisualStyleBackColor = true;
            this.DepartamentEditButton.Click += new System.EventHandler(this.DepartamentEditButton_Click);
            // 
            // MajorCodeEditButton
            // 
            this.MajorCodeEditButton.BackgroundImage = global::WindowsFormsApp2.Properties.Resources._1486504369_change_edit_options_pencil_settings_tools_write_81307;
            this.MajorCodeEditButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MajorCodeEditButton.Location = new System.Drawing.Point(753, 191);
            this.MajorCodeEditButton.Name = "MajorCodeEditButton";
            this.MajorCodeEditButton.Size = new System.Drawing.Size(24, 23);
            this.MajorCodeEditButton.TabIndex = 27;
            this.MajorCodeEditButton.UseVisualStyleBackColor = true;
            this.MajorCodeEditButton.Click += new System.EventHandler(this.MajorCodeEditButton_Click);
            // 
            // MajorNameEditNumber
            // 
            this.MajorNameEditNumber.BackgroundImage = global::WindowsFormsApp2.Properties.Resources._1486504369_change_edit_options_pencil_settings_tools_write_81307;
            this.MajorNameEditNumber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MajorNameEditNumber.Location = new System.Drawing.Point(753, 220);
            this.MajorNameEditNumber.Name = "MajorNameEditNumber";
            this.MajorNameEditNumber.Size = new System.Drawing.Size(24, 23);
            this.MajorNameEditNumber.TabIndex = 28;
            this.MajorNameEditNumber.UseVisualStyleBackColor = true;
            this.MajorNameEditNumber.Click += new System.EventHandler(this.MajorNameEditNumber_Click);
            // 
            // DaddyTextBox
            // 
            this.DaddyTextBox.Location = new System.Drawing.Point(221, 249);
            this.DaddyTextBox.Name = "DaddyTextBox";
            this.DaddyTextBox.Size = new System.Drawing.Size(526, 23);
            this.DaddyTextBox.TabIndex = 29;
            // 
            // DaddyEditButton
            // 
            this.DaddyEditButton.BackgroundImage = global::WindowsFormsApp2.Properties.Resources._1486504369_change_edit_options_pencil_settings_tools_write_81307;
            this.DaddyEditButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DaddyEditButton.Location = new System.Drawing.Point(753, 249);
            this.DaddyEditButton.Name = "DaddyEditButton";
            this.DaddyEditButton.Size = new System.Drawing.Size(24, 23);
            this.DaddyEditButton.TabIndex = 30;
            this.DaddyEditButton.UseVisualStyleBackColor = true;
            this.DaddyEditButton.Click += new System.EventHandler(this.DaddyEditButton_Click);
            // 
            // TicketsProgressBar
            // 
            this.TicketsProgressBar.Location = new System.Drawing.Point(23, 278);
            this.TicketsProgressBar.Name = "TicketsProgressBar";
            this.TicketsProgressBar.Size = new System.Drawing.Size(542, 23);
            this.TicketsProgressBar.TabIndex = 31;
            // 
            // TicketHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 310);
            this.Controls.Add(this.TicketsProgressBar);
            this.Controls.Add(this.DaddyEditButton);
            this.Controls.Add(this.DaddyTextBox);
            this.Controls.Add(this.MajorNameEditNumber);
            this.Controls.Add(this.MajorCodeEditButton);
            this.Controls.Add(this.DepartamentEditButton);
            this.Controls.Add(this.GenerateTicketsButton);
            this.Controls.Add(this.EditDesciplineNameButton);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.AcademicYearComboBox);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.SemesterComboBox);
            this.Controls.Add(this.MajorName);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.DisciplineNameTextBox);
            this.Controls.Add(this.MajorCode);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.DepartamentTextBox);
            this.Name = "TicketHeader";
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.DropShadow;
            this.Text = "Шапка билета";
            this.Load += new System.EventHandler(this.TicketHeader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox DepartamentTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox MajorCode;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox MajorName;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox DisciplineNameTextBox;
        private MetroFramework.Controls.MetroComboBox SemesterComboBox;
        private MetroFramework.Controls.MetroComboBox AcademicYearComboBox;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private System.Windows.Forms.Button EditDesciplineNameButton;
        private System.Windows.Forms.Button GenerateTicketsButton;
        private System.Windows.Forms.Button DepartamentEditButton;
        private System.Windows.Forms.Button MajorCodeEditButton;
        private System.Windows.Forms.Button MajorNameEditNumber;
        private MetroFramework.Controls.MetroTextBox DaddyTextBox;
        private System.Windows.Forms.Button DaddyEditButton;
        private MetroFramework.Controls.MetroProgressBar TicketsProgressBar;
    }
}