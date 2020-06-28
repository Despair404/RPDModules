using System.Drawing;

namespace RPDModule
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
            this.components = new System.ComponentModel.Container();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.FOSTabPage = new MetroFramework.Controls.MetroTabPage();
            this.AddButton = new System.Windows.Forms.Button();
            this.UpdateListButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.UpButton = new System.Windows.Forms.Button();
            this.TicketsProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.cbTables = new MetroFramework.Controls.MetroComboBox();
            this.WorkListBox = new System.Windows.Forms.ListBox();
            this.QuestionTabPage = new MetroFramework.Controls.MetroTabPage();
            this.AddNewQuestionButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.QuestionTypeComboBox = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.AddQuestionTextBox = new MetroFramework.Controls.MetroTextBox();
            this.ChooseQuestionCheckedList = new System.Windows.Forms.CheckedListBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.CompetenceChooseComboBox = new MetroFramework.Controls.MetroComboBox();
            this.switchLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.TicketsTabPage = new MetroFramework.Controls.MetroTabPage();
            this.CountOfTicketsTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.GenerateTicketsButton = new MetroFramework.Controls.MetroButton();
            this.CountOfPracticeQuestionComboBox = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.CountOfTeoreticQuestionComboBox = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.DisciplineLabel = new MetroFramework.Controls.MetroLabel();
            this.PlanLabel = new MetroFramework.Controls.MetroLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.фОСToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.генерацияФОСToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактированиеТаблицToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.входToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbPassword = new MetroFramework.Components.MetroStyleManager(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.metroTabControl1.SuspendLayout();
            this.FOSTabPage.SuspendLayout();
            this.QuestionTabPage.SuspendLayout();
            this.TicketsTabPage.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.FOSTabPage);
            this.metroTabControl1.Controls.Add(this.QuestionTabPage);
            this.metroTabControl1.Controls.Add(this.TicketsTabPage);
            this.metroTabControl1.Location = new System.Drawing.Point(9, 131);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(546, 385);
            this.metroTabControl1.TabIndex = 16;
            // 
            // FOSTabPage
            // 
            this.FOSTabPage.Controls.Add(this.AddButton);
            this.FOSTabPage.Controls.Add(this.UpdateListButton);
            this.FOSTabPage.Controls.Add(this.DownButton);
            this.FOSTabPage.Controls.Add(this.deleteButton);
            this.FOSTabPage.Controls.Add(this.UpButton);
            this.FOSTabPage.Controls.Add(this.TicketsProgressBar);
            this.FOSTabPage.Controls.Add(this.metroLabel2);
            this.FOSTabPage.Controls.Add(this.cbTables);
            this.FOSTabPage.Controls.Add(this.WorkListBox);
            this.FOSTabPage.HorizontalScrollbarBarColor = true;
            this.FOSTabPage.Location = new System.Drawing.Point(4, 35);
            this.FOSTabPage.Name = "FOSTabPage";
            this.FOSTabPage.Size = new System.Drawing.Size(538, 346);
            this.FOSTabPage.TabIndex = 0;
            this.FOSTabPage.Text = "Оценочные средства";
            this.FOSTabPage.VerticalScrollbarBarColor = true;
            // 
            // AddButton
            // 
            this.AddButton.BackgroundImage = global::RPDModule.Properties.Resources.icons8_добавить_список_64;
            this.AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddButton.Location = new System.Drawing.Point(479, 136);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(30, 30);
            this.AddButton.TabIndex = 37;
            this.toolTip1.SetToolTip(this.AddButton, "Добавить таблицу");
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddTableButton_Click);
            // 
            // UpdateListButton
            // 
            this.UpdateListButton.BackgroundImage = global::RPDModule.Properties.Resources.icons8_обновить_48;
            this.UpdateListButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UpdateListButton.Location = new System.Drawing.Point(479, 172);
            this.UpdateListButton.Name = "UpdateListButton";
            this.UpdateListButton.Size = new System.Drawing.Size(30, 30);
            this.UpdateListButton.TabIndex = 36;
            this.toolTip1.SetToolTip(this.UpdateListButton, "Обновить список таблиц");
            this.UpdateListButton.UseVisualStyleBackColor = true;
            this.UpdateListButton.Click += new System.EventHandler(this.UpdateListButton_Click);
            // 
            // DownButton
            // 
            this.DownButton.BackgroundImage = global::RPDModule.Properties.Resources.icons8_вниз_48;
            this.DownButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DownButton.Location = new System.Drawing.Point(479, 81);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(30, 30);
            this.DownButton.TabIndex = 35;
            this.toolTip1.SetToolTip(this.DownButton, "Переместить вниз");
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackgroundImage = global::RPDModule.Properties.Resources.icons8_удалить_48__1_;
            this.deleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteButton.Location = new System.Drawing.Point(479, 42);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(30, 30);
            this.deleteButton.TabIndex = 34;
            this.toolTip1.SetToolTip(this.deleteButton, "Удалить таблицу");
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // UpButton
            // 
            this.UpButton.BackgroundImage = global::RPDModule.Properties.Resources.icons8_вверх_48;
            this.UpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UpButton.Location = new System.Drawing.Point(479, 3);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(30, 30);
            this.UpButton.TabIndex = 33;
            this.toolTip1.SetToolTip(this.UpButton, "Переместить вверх");
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // TicketsProgressBar
            // 
            this.TicketsProgressBar.Location = new System.Drawing.Point(0, 171);
            this.TicketsProgressBar.Name = "TicketsProgressBar";
            this.TicketsProgressBar.Size = new System.Drawing.Size(473, 29);
            this.TicketsProgressBar.TabIndex = 32;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(0, 114);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(170, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Дополнительные таблицы";
            // 
            // cbTables
            // 
            this.cbTables.FormattingEnabled = true;
            this.cbTables.ItemHeight = 23;
            this.cbTables.Location = new System.Drawing.Point(0, 136);
            this.cbTables.Name = "cbTables";
            this.cbTables.Size = new System.Drawing.Size(473, 29);
            this.cbTables.TabIndex = 3;
            // 
            // WorkListBox
            // 
            this.WorkListBox.ColumnWidth = 50;
            this.WorkListBox.FormattingEnabled = true;
            this.WorkListBox.Location = new System.Drawing.Point(0, 3);
            this.WorkListBox.Name = "WorkListBox";
            this.WorkListBox.Size = new System.Drawing.Size(473, 108);
            this.WorkListBox.TabIndex = 2;
            // 
            // QuestionTabPage
            // 
            this.QuestionTabPage.Controls.Add(this.AddNewQuestionButton);
            this.QuestionTabPage.Controls.Add(this.button3);
            this.QuestionTabPage.Controls.Add(this.button2);
            this.QuestionTabPage.Controls.Add(this.button1);
            this.QuestionTabPage.Controls.Add(this.QuestionTypeComboBox);
            this.QuestionTabPage.Controls.Add(this.metroLabel8);
            this.QuestionTabPage.Controls.Add(this.AddQuestionTextBox);
            this.QuestionTabPage.Controls.Add(this.ChooseQuestionCheckedList);
            this.QuestionTabPage.Controls.Add(this.metroLabel3);
            this.QuestionTabPage.Controls.Add(this.CompetenceChooseComboBox);
            this.QuestionTabPage.Controls.Add(this.switchLabel);
            this.QuestionTabPage.Controls.Add(this.metroLabel1);
            this.QuestionTabPage.HorizontalScrollbarBarColor = true;
            this.QuestionTabPage.Location = new System.Drawing.Point(4, 35);
            this.QuestionTabPage.Name = "QuestionTabPage";
            this.QuestionTabPage.Size = new System.Drawing.Size(538, 346);
            this.QuestionTabPage.TabIndex = 1;
            this.QuestionTabPage.Text = "Вопросы";
            this.QuestionTabPage.VerticalScrollbarBarColor = true;
            // 
            // AddNewQuestionButton
            // 
            this.AddNewQuestionButton.BackgroundImage = global::RPDModule.Properties.Resources.icons8_добавить_список_64;
            this.AddNewQuestionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddNewQuestionButton.Location = new System.Drawing.Point(480, 307);
            this.AddNewQuestionButton.Name = "AddNewQuestionButton";
            this.AddNewQuestionButton.Size = new System.Drawing.Size(36, 36);
            this.AddNewQuestionButton.TabIndex = 24;
            this.toolTip1.SetToolTip(this.AddNewQuestionButton, "Сохранить вопрос");
            this.AddNewQuestionButton.UseVisualStyleBackColor = true;
            this.AddNewQuestionButton.Click += new System.EventHandler(this.AddNewQuestionButton_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::RPDModule.Properties.Resources.icons8_редактировать_40;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(480, 64);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(36, 36);
            this.button3.TabIndex = 23;
            this.toolTip1.SetToolTip(this.button3, "Редактировать вопрос");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.RepairQuestionButton_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::RPDModule.Properties.Resources.icons8_удалить_48__1_;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(480, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(36, 36);
            this.button2.TabIndex = 22;
            this.toolTip1.SetToolTip(this.button2, "Удалить вопрос");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.DeleteQuestionButton_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::RPDModule.Properties.Resources.icons8_обновить_48;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(480, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 36);
            this.button1.TabIndex = 21;
            this.toolTip1.SetToolTip(this.button1, "Обновить список вопросов");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // QuestionTypeComboBox
            // 
            this.QuestionTypeComboBox.FormattingEnabled = true;
            this.QuestionTypeComboBox.ItemHeight = 23;
            this.QuestionTypeComboBox.Items.AddRange(new object[] {
            "Практ.",
            "Теор."});
            this.QuestionTypeComboBox.Location = new System.Drawing.Point(329, 307);
            this.QuestionTypeComboBox.Name = "QuestionTypeComboBox";
            this.QuestionTypeComboBox.Size = new System.Drawing.Size(145, 29);
            this.QuestionTypeComboBox.TabIndex = 17;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(235, 307);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(88, 19);
            this.metroLabel8.TabIndex = 16;
            this.metroLabel8.Text = "Тип вопроса";
            // 
            // AddQuestionTextBox
            // 
            this.AddQuestionTextBox.Location = new System.Drawing.Point(0, 231);
            this.AddQuestionTextBox.Multiline = true;
            this.AddQuestionTextBox.Name = "AddQuestionTextBox";
            this.AddQuestionTextBox.Size = new System.Drawing.Size(516, 70);
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
            this.ChooseQuestionCheckedList.Size = new System.Drawing.Size(474, 184);
            this.ChooseQuestionCheckedList.TabIndex = 13;
            this.ChooseQuestionCheckedList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ChooseQuestionCheckedList_ItemCheck);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(0, 307);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(91, 19);
            this.metroLabel3.TabIndex = 11;
            this.metroLabel3.Text = "Компетенция";
            // 
            // CompetenceChooseComboBox
            // 
            this.CompetenceChooseComboBox.FormattingEnabled = true;
            this.CompetenceChooseComboBox.ItemHeight = 23;
            this.CompetenceChooseComboBox.Location = new System.Drawing.Point(97, 307);
            this.CompetenceChooseComboBox.Name = "CompetenceChooseComboBox";
            this.CompetenceChooseComboBox.Size = new System.Drawing.Size(132, 29);
            this.CompetenceChooseComboBox.TabIndex = 10;
            // 
            // switchLabel
            // 
            this.switchLabel.AutoSize = true;
            this.switchLabel.Location = new System.Drawing.Point(0, 209);
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
            // TicketsTabPage
            // 
            this.TicketsTabPage.Controls.Add(this.CountOfTicketsTextBox);
            this.TicketsTabPage.Controls.Add(this.metroLabel9);
            this.TicketsTabPage.Controls.Add(this.GenerateTicketsButton);
            this.TicketsTabPage.Controls.Add(this.CountOfPracticeQuestionComboBox);
            this.TicketsTabPage.Controls.Add(this.metroLabel7);
            this.TicketsTabPage.Controls.Add(this.metroLabel6);
            this.TicketsTabPage.Controls.Add(this.CountOfTeoreticQuestionComboBox);
            this.TicketsTabPage.HorizontalScrollbarBarColor = true;
            this.TicketsTabPage.Location = new System.Drawing.Point(4, 35);
            this.TicketsTabPage.Name = "TicketsTabPage";
            this.TicketsTabPage.Size = new System.Drawing.Size(538, 346);
            this.TicketsTabPage.TabIndex = 3;
            this.TicketsTabPage.Text = "Генератор билетов";
            this.TicketsTabPage.VerticalScrollbarBarColor = true;
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
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(20, 109);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(89, 19);
            this.metroLabel4.TabIndex = 17;
            this.metroLabel4.Text = "Дисциплина:";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(20, 84);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(43, 19);
            this.metroLabel5.TabIndex = 18;
            this.metroLabel5.Text = "План:";
            // 
            // DisciplineLabel
            // 
            this.DisciplineLabel.AutoSize = true;
            this.DisciplineLabel.Location = new System.Drawing.Point(115, 109);
            this.DisciplineLabel.Name = "DisciplineLabel";
            this.DisciplineLabel.Size = new System.Drawing.Size(30, 19);
            this.DisciplineLabel.TabIndex = 19;
            this.DisciplineLabel.Text = "дис";
            // 
            // PlanLabel
            // 
            this.PlanLabel.AutoSize = true;
            this.PlanLabel.Location = new System.Drawing.Point(69, 84);
            this.PlanLabel.Name = "PlanLabel";
            this.PlanLabel.Size = new System.Drawing.Size(39, 19);
            this.PlanLabel.TabIndex = 20;
            this.PlanLabel.Text = "план";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фОСToolStripMenuItem,
            this.входToolStripMenuItem,
            this.обновитьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(522, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // фОСToolStripMenuItem
            // 
            this.фОСToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.генерацияФОСToolStripMenuItem,
            this.редактированиеТаблицToolStripMenuItem});
            this.фОСToolStripMenuItem.Name = "фОСToolStripMenuItem";
            this.фОСToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.фОСToolStripMenuItem.Text = "ФОС";
            // 
            // генерацияФОСToolStripMenuItem
            // 
            this.генерацияФОСToolStripMenuItem.Name = "генерацияФОСToolStripMenuItem";
            this.генерацияФОСToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.генерацияФОСToolStripMenuItem.Text = "Генерация ФОС";
            this.генерацияФОСToolStripMenuItem.ToolTipText = "Запустить процесс генерации ФОС";
            this.генерацияФОСToolStripMenuItem.Click += new System.EventHandler(this.генерацияФОСToolStripMenuItem_Click);
            // 
            // редактированиеТаблицToolStripMenuItem
            // 
            this.редактированиеТаблицToolStripMenuItem.Name = "редактированиеТаблицToolStripMenuItem";
            this.редактированиеТаблицToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.редактированиеТаблицToolStripMenuItem.Text = "Редактирование таблиц";
            this.редактированиеТаблицToolStripMenuItem.ToolTipText = "Открыть редактор таблиц";
            this.редактированиеТаблицToolStripMenuItem.Click += new System.EventHandler(this.редактированиеТаблицToolStripMenuItem_Click);
            // 
            // входToolStripMenuItem
            // 
            this.входToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.входToolStripMenuItem.Name = "входToolStripMenuItem";
            this.входToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.входToolStripMenuItem.Text = "Вход";
            this.входToolStripMenuItem.Click += new System.EventHandler(this.входToolStripMenuItem_Click);
            // 
            // обновитьToolStripMenuItem
            // 
            this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.обновитьToolStripMenuItem.Text = "Обновить";
            this.обновитьToolStripMenuItem.Click += new System.EventHandler(this.обновитьToolStripMenuItem_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Owner = null;
            // 
            // FOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 507);
            this.Controls.Add(this.PlanLabel);
            this.Controls.Add(this.DisciplineLabel);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FOS";
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.DropShadow;
            this.Text = "Фонд оценочных средств";
            this.Load += new System.EventHandler(this.FOS_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.FOSTabPage.ResumeLayout(false);
            this.FOSTabPage.PerformLayout();
            this.QuestionTabPage.ResumeLayout(false);
            this.QuestionTabPage.PerformLayout();
            this.TicketsTabPage.ResumeLayout(false);
            this.TicketsTabPage.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage QuestionTabPage;
        private MetroFramework.Controls.MetroTextBox AddQuestionTextBox;
        private System.Windows.Forms.CheckedListBox ChooseQuestionCheckedList;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox CompetenceChooseComboBox;
        private MetroFramework.Controls.MetroLabel switchLabel;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel DisciplineLabel;
        private MetroFramework.Controls.MetroLabel PlanLabel;
        private MetroFramework.Controls.MetroTabPage TicketsTabPage;
        private MetroFramework.Controls.MetroComboBox CountOfPracticeQuestionComboBox;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroComboBox CountOfTeoreticQuestionComboBox;
        private MetroFramework.Controls.MetroComboBox QuestionTypeComboBox;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox CountOfTicketsTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroButton GenerateTicketsButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem фОСToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem генерацияФОСToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактированиеТаблицToolStripMenuItem;
        private MetroFramework.Controls.MetroTabPage FOSTabPage;
        private MetroFramework.Controls.MetroProgressBar TicketsProgressBar;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox cbTables;
        private System.Windows.Forms.ListBox WorkListBox;
        private System.Windows.Forms.ToolStripMenuItem входToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
        private MetroFramework.Components.MetroStyleManager tbPassword;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button UpdateListButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button AddNewQuestionButton;
    }
}