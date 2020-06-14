namespace WindowsFormsApp2
{
    partial class FOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FOS));
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage4 = new MetroFramework.Controls.MetroTabPage();
            this.CountOfTicketsTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.GenerateTicketsButton = new MetroFramework.Controls.MetroButton();
            this.CountOfPracticeQuestionComboBox = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.CountOfTeoreticQuestionComboBox = new MetroFramework.Controls.MetroComboBox();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.QuestionTypeComboBox = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.DeleteQuestionButton = new MetroFramework.Controls.MetroButton();
            this.AddQuestionTextBox = new MetroFramework.Controls.MetroTextBox();
            this.ChooseQuestionCheckedList = new System.Windows.Forms.CheckedListBox();
            this.AddNewQuestionButton = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.CompetenceChooseComboBox = new MetroFramework.Controls.MetroComboBox();
            this.switchLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.DisciplineLabel = new MetroFramework.Controls.MetroLabel();
            this.PlanLabel = new MetroFramework.Controls.MetroLabel();
            this.RepairQuestionButton = new MetroFramework.Controls.MetroButton();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage4.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.metroTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage4);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Location = new System.Drawing.Point(9, 63);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 3;
            this.metroTabControl1.Size = new System.Drawing.Size(958, 430);
            this.metroTabControl1.TabIndex = 16;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(950, 391);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Оценочные средства";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.Controls.Add(this.CountOfTicketsTextBox);
            this.metroTabPage4.Controls.Add(this.metroLabel9);
            this.metroTabPage4.Controls.Add(this.GenerateTicketsButton);
            this.metroTabPage4.Controls.Add(this.CountOfPracticeQuestionComboBox);
            this.metroTabPage4.Controls.Add(this.metroLabel7);
            this.metroTabPage4.Controls.Add(this.metroLabel6);
            this.metroTabPage4.Controls.Add(this.CountOfTeoreticQuestionComboBox);
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Size = new System.Drawing.Size(950, 391);
            this.metroTabPage4.TabIndex = 3;
            this.metroTabPage4.Text = "Генератор билетов";
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            // 
            // CountOfTicketsTextBox
            // 
            this.CountOfTicketsTextBox.Location = new System.Drawing.Point(241, 9);
            this.CountOfTicketsTextBox.Name = "CountOfTicketsTextBox";
            this.CountOfTicketsTextBox.Size = new System.Drawing.Size(232, 23);
            this.CountOfTicketsTextBox.TabIndex = 9;
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(0, 13);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(133, 19);
            this.metroLabel9.TabIndex = 8;
            this.metroLabel9.Text = "Количество билетов";
            // 
            // GenerateTicketsButton
            // 
            this.GenerateTicketsButton.Location = new System.Drawing.Point(241, 108);
            this.GenerateTicketsButton.Name = "GenerateTicketsButton";
            this.GenerateTicketsButton.Size = new System.Drawing.Size(232, 23);
            this.GenerateTicketsButton.TabIndex = 6;
            this.GenerateTicketsButton.Text = "Перейти к шапке билета";
            this.GenerateTicketsButton.Click += new System.EventHandler(this.GenerateTicketsButton_Click);
            // 
            // CountOfPracticeQuestionComboBox
            // 
            this.CountOfPracticeQuestionComboBox.FormattingEnabled = true;
            this.CountOfPracticeQuestionComboBox.ItemHeight = 23;
            this.CountOfPracticeQuestionComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.CountOfPracticeQuestionComboBox.Location = new System.Drawing.Point(241, 73);
            this.CountOfPracticeQuestionComboBox.Name = "CountOfPracticeQuestionComboBox";
            this.CountOfPracticeQuestionComboBox.Size = new System.Drawing.Size(232, 29);
            this.CountOfPracticeQuestionComboBox.TabIndex = 5;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(0, 83);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(229, 19);
            this.metroLabel7.TabIndex = 4;
            this.metroLabel7.Text = "Количество практических вопросов";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(0, 48);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(235, 19);
            this.metroLabel6.TabIndex = 3;
            this.metroLabel6.Text = "Количество теоретических вопросов";
            // 
            // CountOfTeoreticQuestionComboBox
            // 
            this.CountOfTeoreticQuestionComboBox.FormattingEnabled = true;
            this.CountOfTeoreticQuestionComboBox.ItemHeight = 23;
            this.CountOfTeoreticQuestionComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.CountOfTeoreticQuestionComboBox.Location = new System.Drawing.Point(241, 38);
            this.CountOfTeoreticQuestionComboBox.Name = "CountOfTeoreticQuestionComboBox";
            this.CountOfTeoreticQuestionComboBox.Size = new System.Drawing.Size(232, 29);
            this.CountOfTeoreticQuestionComboBox.TabIndex = 2;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.pictureBox1);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(950, 391);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Тесты";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(950, 382);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.RepairQuestionButton);
            this.metroTabPage2.Controls.Add(this.metroButton2);
            this.metroTabPage2.Controls.Add(this.metroButton1);
            this.metroTabPage2.Controls.Add(this.QuestionTypeComboBox);
            this.metroTabPage2.Controls.Add(this.metroLabel8);
            this.metroTabPage2.Controls.Add(this.DeleteQuestionButton);
            this.metroTabPage2.Controls.Add(this.AddQuestionTextBox);
            this.metroTabPage2.Controls.Add(this.ChooseQuestionCheckedList);
            this.metroTabPage2.Controls.Add(this.AddNewQuestionButton);
            this.metroTabPage2.Controls.Add(this.metroLabel3);
            this.metroTabPage2.Controls.Add(this.CompetenceChooseComboBox);
            this.metroTabPage2.Controls.Add(this.switchLabel);
            this.metroTabPage2.Controls.Add(this.metroLabel1);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(950, 391);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Вопросы";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(776, 212);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(174, 29);
            this.metroButton2.TabIndex = 19;
            this.metroButton2.Text = "Обновить список вопросов";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(180, 223);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(127, 18);
            this.metroButton1.TabIndex = 18;
            this.metroButton1.Text = "metroButton1";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // QuestionTypeComboBox
            // 
            this.QuestionTypeComboBox.FormattingEnabled = true;
            this.QuestionTypeComboBox.ItemHeight = 23;
            this.QuestionTypeComboBox.Items.AddRange(new object[] {
            "Практ.",
            "Теор."});
            this.QuestionTypeComboBox.Location = new System.Drawing.Point(471, 355);
            this.QuestionTypeComboBox.Name = "QuestionTypeComboBox";
            this.QuestionTypeComboBox.Size = new System.Drawing.Size(193, 29);
            this.QuestionTypeComboBox.TabIndex = 17;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(377, 360);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(88, 19);
            this.metroLabel8.TabIndex = 16;
            this.metroLabel8.Text = "Тип вопроса";
            // 
            // DeleteQuestionButton
            // 
            this.DeleteQuestionButton.Location = new System.Drawing.Point(0, 212);
            this.DeleteQuestionButton.Name = "DeleteQuestionButton";
            this.DeleteQuestionButton.Size = new System.Drawing.Size(174, 29);
            this.DeleteQuestionButton.TabIndex = 15;
            this.DeleteQuestionButton.Text = "Удалить вопрос";
            this.DeleteQuestionButton.Click += new System.EventHandler(this.DeleteQuestionButton_Click);
            // 
            // AddQuestionTextBox
            // 
            this.AddQuestionTextBox.Location = new System.Drawing.Point(0, 266);
            this.AddQuestionTextBox.Multiline = true;
            this.AddQuestionTextBox.Name = "AddQuestionTextBox";
            this.AddQuestionTextBox.Size = new System.Drawing.Size(950, 83);
            this.AddQuestionTextBox.TabIndex = 14;
            // 
            // ChooseQuestionCheckedList
            // 
            this.ChooseQuestionCheckedList.ColumnWidth = 920;
            this.ChooseQuestionCheckedList.FormattingEnabled = true;
            this.ChooseQuestionCheckedList.HorizontalScrollbar = true;
            this.ChooseQuestionCheckedList.Location = new System.Drawing.Point(0, 22);
            this.ChooseQuestionCheckedList.Name = "ChooseQuestionCheckedList";
            this.ChooseQuestionCheckedList.ScrollAlwaysVisible = true;
            this.ChooseQuestionCheckedList.Size = new System.Drawing.Size(950, 184);
            this.ChooseQuestionCheckedList.TabIndex = 13;
            this.ChooseQuestionCheckedList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ChooseQuestionCheckedList_ItemCheck);
            // 
            // AddNewQuestionButton
            // 
            this.AddNewQuestionButton.Location = new System.Drawing.Point(776, 355);
            this.AddNewQuestionButton.Name = "AddNewQuestionButton";
            this.AddNewQuestionButton.Size = new System.Drawing.Size(174, 29);
            this.AddNewQuestionButton.TabIndex = 12;
            this.AddNewQuestionButton.Text = "Добавить вопрос";
            this.AddNewQuestionButton.Click += new System.EventHandler(this.AddNewQuestionButton_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(0, 360);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(147, 19);
            this.metroLabel3.TabIndex = 11;
            this.metroLabel3.Text = "Компетенция вопроса";
            // 
            // CompetenceChooseComboBox
            // 
            this.CompetenceChooseComboBox.FormattingEnabled = true;
            this.CompetenceChooseComboBox.ItemHeight = 23;
            this.CompetenceChooseComboBox.Location = new System.Drawing.Point(153, 355);
            this.CompetenceChooseComboBox.Name = "CompetenceChooseComboBox";
            this.CompetenceChooseComboBox.Size = new System.Drawing.Size(193, 29);
            this.CompetenceChooseComboBox.TabIndex = 10;
            // 
            // switchLabel
            // 
            this.switchLabel.AutoSize = true;
            this.switchLabel.Location = new System.Drawing.Point(0, 244);
            this.switchLabel.Name = "switchLabel";
            this.switchLabel.Size = new System.Drawing.Size(149, 19);
            this.switchLabel.TabIndex = 3;
            this.switchLabel.Text = "Добавление вопросов";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(173, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Выбор вопросов для ФОС";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(308, 31);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(89, 19);
            this.metroLabel4.TabIndex = 17;
            this.metroLabel4.Text = "Дисциплина:";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(665, 31);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(43, 19);
            this.metroLabel5.TabIndex = 18;
            this.metroLabel5.Text = "План:";
            // 
            // DisciplineLabel
            // 
            this.DisciplineLabel.AutoSize = true;
            this.DisciplineLabel.Location = new System.Drawing.Point(403, 31);
            this.DisciplineLabel.Name = "DisciplineLabel";
            this.DisciplineLabel.Size = new System.Drawing.Size(30, 19);
            this.DisciplineLabel.TabIndex = 19;
            this.DisciplineLabel.Text = "дис";
            // 
            // PlanLabel
            // 
            this.PlanLabel.AutoSize = true;
            this.PlanLabel.Location = new System.Drawing.Point(714, 31);
            this.PlanLabel.Name = "PlanLabel";
            this.PlanLabel.Size = new System.Drawing.Size(39, 19);
            this.PlanLabel.TabIndex = 20;
            this.PlanLabel.Text = "план";
            // 
            // RepairQuestionButton
            // 
            this.RepairQuestionButton.Location = new System.Drawing.Point(596, 212);
            this.RepairQuestionButton.Name = "RepairQuestionButton";
            this.RepairQuestionButton.Size = new System.Drawing.Size(174, 29);
            this.RepairQuestionButton.TabIndex = 20;
            this.RepairQuestionButton.Text = "Редактировать вопрос";
            this.RepairQuestionButton.Click += new System.EventHandler(this.RepairQuestionButton_Click);
            // 
            // FOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 503);
            this.Controls.Add(this.PlanLabel);
            this.Controls.Add(this.DisciplineLabel);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "FOS";
            this.Text = "Фонд оценочных средств";
            this.Load += new System.EventHandler(this.FOS_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage4.ResumeLayout(false);
            this.metroTabPage4.PerformLayout();
            this.metroTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTextBox AddQuestionTextBox;
        private System.Windows.Forms.CheckedListBox ChooseQuestionCheckedList;
        private MetroFramework.Controls.MetroButton AddNewQuestionButton;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox CompetenceChooseComboBox;
        private MetroFramework.Controls.MetroLabel switchLabel;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton DeleteQuestionButton;
        private MetroFramework.Controls.MetroLabel DisciplineLabel;
        private MetroFramework.Controls.MetroLabel PlanLabel;
        private MetroFramework.Controls.MetroTabPage metroTabPage4;
        private MetroFramework.Controls.MetroComboBox CountOfPracticeQuestionComboBox;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroComboBox CountOfTeoreticQuestionComboBox;
        private MetroFramework.Controls.MetroComboBox QuestionTypeComboBox;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox CountOfTicketsTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroButton GenerateTicketsButton;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton RepairQuestionButton;
    }
}