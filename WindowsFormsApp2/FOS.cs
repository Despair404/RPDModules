using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;

namespace RPDModule
{
    public partial class FOS : MetroFramework.Forms.MetroForm
    {
        Table tb;  /* Если не получится объявить так, то объяви через: public static Table tb;  */
        bool check = false;
        List<string> competences = new List<string>();
        SqlConnection sql;
        IntPtr RPDHWnd;
        List<IntPtr> titleChildren = new List<IntPtr>();
        //string daddy;
        //string departament;
        //string MajorCode;
        //string MajorName;
        string discipline;
        string plan;
        List<string> theory = new List<string>();
        List<string> practice = new List<string>();

        List<string> works = new List<string>(); // Список работ текущей дисциплины 

        System.Data.DataTable worksTables = new System.Data.DataTable();

        List<int> ids = new List<int>();

        public FOS()
        {
            InitializeComponent();

        }
        string conRPD = ConfigurationManager.ConnectionStrings["RPDConnection"].ConnectionString;
        string conMod = ConfigurationManager.ConnectionStrings["ModuleConnection"].ConnectionString;
        public void UpdateWorks ()
        {
            ids.Clear();
            WorkListBox.Items.Clear();
            try
            {
                RPDHWnd = getRPDHWnd();
                if (RPDHWnd.ToInt32() == 0)
                    throw new Exception("Редактируемая рабочая программа не найдена. Пожалуйста, запустите ПО РПД и откройте рабочую программу, ФОС которой нужно сгенерировать.");
                if (RPDHWnd.ToInt32() != 0)
                {
                    IntPtr titleHWnd = getTitle();
                    titleChildren.Clear();
                    getTitleChildren(titleHWnd);
                    discipline = getDisciplineName();
                    plan = getPlaneName();
                    SqlConnection connection = new SqlConnection(conRPD);
                    try
                    {
                        connection.Open();
                        string sqlex = "SELECT Код FROM Планы WHERE ИмяФайла='" + plan + "'";

                        SqlCommand command = new SqlCommand(sqlex, connection);
                        SqlDataReader reader = command.ExecuteReader();
                        object id = 0;
                        while (reader.Read())
                        {
                            id = reader.GetValue(0);
                        }
                        reader.Close();
                        sqlex = "SELECT * FROM ПланыСтроки WHERE Дисциплина='" + discipline + "' AND КодПлана=" + id;
                        command = new SqlCommand(sqlex, connection);
                        reader = command.ExecuteReader();
                        object idD = 0;
                        while (reader.Read())
                        {
                            idD = reader.GetValue(0);
                        }
                        sqlex = "SELECT * FROM СправочникВидыРабот WHERE Код= ANY(SELECT DISTINCT КодВидаРаботы FROM ПланыНовыеЧасы where КодОбъекта=" + idD + ") AND Название IN ('Экзамен', 'Зачет', 'Зачет с оценкой', 'Курсовой проект', 'Курсовая работа')";
                        reader.Close();
                        System.Data.DataTable dt = new System.Data.DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlex, connection);
                        adapter.Fill(dt);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            works.Add(dt.Rows[i][1].ToString());
                        }
                        getStruct();

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        // закрываем подключение
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GetCompetence()
        {
            competences.Clear();
            int id = 0;
            int idDiscipline = 0;
            using (SqlConnection connection = new SqlConnection(conRPD))
            {
                connection.Open();
                SqlCommand PlaneCode = new SqlCommand("SELECT Код FROM Планы WHERE ИмяФайла='" + plan + "'", connection);
                try
                {
                    SqlDataReader sqlReader = PlaneCode.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        id = Convert.ToInt32(sqlReader["Код"]);
                    }
                    sqlReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                SqlCommand DisciplineCode = new SqlCommand("SELECT * FROM ПланыСтроки WHERE Дисциплина='" + discipline + "' AND КодПлана=" + id, connection);
                try
                {
                    SqlDataReader sqlReader = DisciplineCode.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        idDiscipline = Convert.ToInt32(sqlReader["Код"]);
                    }
                    sqlReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string competence = "SELECT * FROM ПланыКомпетенции WHERE Код= ANY(  SELECT КодКомпетенции FROM ПланыКомпетенцииДисциплины WHERE КодСтроки=" + idDiscipline + ")";
                SqlDataAdapter adapter = new SqlDataAdapter(competence, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                CompetenceChooseComboBox.DataSource = ds.Tables[0];
                CompetenceChooseComboBox.DisplayMember = "ШифрКомпетенции";
                CompetenceChooseComboBox.ValueMember = "Код";
                CompetenceChooseComboBox.SelectedItem = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    competences.Add(ds.Tables[0].Rows[i][3].ToString());
                }
            }
        }

        private void GetQuestions ()
        {
            sql = new SqlConnection(conMod);
            sql.Open();
            string competence = "SELECT * FROM Questions";
            SqlDataAdapter adapter = new SqlDataAdapter(competence, sql);
            DataSet ds = new DataSet();
            adapter.Fill(ds);           
            try
            {
                ChooseQuestionCheckedList.DataSource = ds.Tables[0];
                ChooseQuestionCheckedList.DisplayMember = "QuestionText";
                ChooseQuestionCheckedList.ValueMember = "QuestionID";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToBoolean(ds.Tables[0].Rows[i][4]) == true)
                    {
                        ChooseQuestionCheckedList.SetItemChecked(i, true);
                    }
                    else
                    {
                        ChooseQuestionCheckedList.SetItemChecked(i, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            for (int i =0;i<ChooseQuestionCheckedList.Items.Count;i++)
            {
                ChooseQuestionCheckedList.SetSelected(i, false);
            }
        }
        private void AddNewQuestionButton_Click(object sender, EventArgs e)
        {
            if (check == true)
            {
                sql = new SqlConnection(conMod);
                sql.Open();
                // Считываем данные с формы
                string text = AddQuestionTextBox.Text.ToString();
                // Заготовка Insert
                string sUpSql = "UPDATE Questions SET QuestionType =" + "'"+QuestionTypeComboBox.Text.ToString()+"'"+","+"Competence="+"'"+CompetenceChooseComboBox.Text.ToString()+"'"+","+"QuestionText="+"'"+AddQuestionTextBox.Text.ToString()+"'" + "WHERE QuestionID="+"'"+ChooseQuestionCheckedList.SelectedValue+"'";
                SqlCommand Up = new SqlCommand(sUpSql, sql);
                //Выполняем команду на вставку записи
                Up.ExecuteNonQuery();
                //Вывод сообщения
                MessageBox.Show("Вопрос обновлен", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AddNewQuestionButton.Text = "Добавить вопрос";
                switchLabel.Text = "Добавление вопросов";
                check = false;
                GetQuestions();
                GetListsOfQuestions();
                AddQuestionTextBox.Text = "";
                CompetenceChooseComboBox.SelectedIndex = -1;
                QuestionTypeComboBox.SelectedIndex = -1;
                sql.Close();
            }
            else
            {
                if (QuestionTypeComboBox.SelectedIndex == -1)
                    MessageBox.Show("Пожалуйста, выберите тип вопроса", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (AddQuestionTextBox.Text == "")
                    MessageBox.Show("Пожалуйста, введите формулировку вопроса", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (CompetenceChooseComboBox.SelectedIndex == -1)
                        MessageBox.Show("Пожалуйста, выберите компетенцию, к которой относится вопрос", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        sql = new SqlConnection(conMod);
                        sql.Open();
                        // Считываем данные с формы
                        string text = AddQuestionTextBox.Text.ToString();
                        // Заготовка Insert
                        string sInsSql = "Insert into Questions(QuestionText, DisciplinesName, Competence, QuestionType) Values (" + "'" + text + "'" + "," + "'" + discipline + "'" + "," + "'" + CompetenceChooseComboBox.Text.ToString() + "'" + "," + "'" + QuestionTypeComboBox.Text.ToString() + "'" + ")";
                        // Создаем команду
                        SqlCommand Ins = new SqlCommand(sInsSql, sql);
                        //Выполняем команду на вставку записи
                        Ins.ExecuteNonQuery();
                        //Вывод сообщения
                        MessageBox.Show("Вопрос добавлен", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (QuestionTypeComboBox.Text == "Практ.")
                            practice.Add(text);
                        else
                            theory.Add(text);
                        GetQuestions();
                    }
                }
                GetQuestions();
                sql.Close();
            }
        }
        private IntPtr getRPDHWnd()
        {
            IntPtr target = IntPtr.Zero;
            WinAPI.EnumWindows((hWnd, lParam) =>
            {
                if (WinAPI.IsWindowVisible(hWnd) && WinAPI.GetWindowTextLength(hWnd) != 0)
                {
                    string title = WinAPI.GetWindowText(hWnd);
                    if (title.Contains("РПД"))
                    {
                        target = hWnd;
                    }
                }
                return true;
            }, IntPtr.Zero);
            return target;
        }
        private IntPtr getMUWindow()
        {
            IntPtr child = IntPtr.Zero;
            if (RPDHWnd.ToInt32() != 0)
            {
                child = WinAPI.FindWindowEx(RPDHWnd, 0, null, "");
                child = WinAPI.FindWindowEx(child, 0, null, null);
                child = WinAPI.FindWindowEx(child, 0, null, null);
                child = WinAPI.FindWindowEx(child, 0, null, "МУ");
                child = WinAPI.FindWindowEx(child, 0, null, null);
                child = WinAPI.FindWindowEx(child, 0, null, null);
                child = WinAPI.FindWindowEx(child, 0, null, null);
            }
            else MessageBox.Show("Окно методических указаний не найдено.");
            return child;
        }

        public void GetListsOfQuestions ()
        {
            theory.Clear();
            practice.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand PlaneCode = new SqlCommand("SELECT QuestionText FROM Questions WHERE QuestionType='Теор.' AND Active = 'True' AND DisciplinesName='" + discipline + "'", sql);
            try
            {
                sqlReader = PlaneCode.ExecuteReader();
                while (sqlReader.Read())
                {
                    theory.Add(sqlReader["QuestionText"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
            sqlReader = null;
            PlaneCode = new SqlCommand("SELECT QuestionText FROM Questions WHERE QuestionType='Практ.' AND Active = 'True' AND DisciplinesName='" + discipline + "'", sql);
            try
            {
                sqlReader = PlaneCode.ExecuteReader();
                while (sqlReader.Read())
                {
                    practice.Add(sqlReader["QuestionText"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }
        private IntPtr getTitle()
        {
            IntPtr child = IntPtr.Zero;

            child = WinAPI.FindWindowEx(RPDHWnd, 0, null, "");
            child = WinAPI.FindWindowEx(child, 0, null, null);
            child = WinAPI.FindWindowEx(child, 0, null, null);
            child = WinAPI.FindWindowEx(child, 0, null, "Титул");
            child = WinAPI.FindWindowEx(child, 0, null, null);
            child = WinAPI.FindWindowEx(child, 0, null, null);
            return child;

        }
        private void getTitleChildren(IntPtr titleHWnd)
        {
            var lpEnumFunc = new WinAPI.EnumWindowProc(EnumChildProc);
            WinAPI.EnumChildWindows(titleHWnd, lpEnumFunc, IntPtr.Zero);
        }
        public bool EnumChildProc(IntPtr hwnd, IntPtr lParam)
        {
            titleChildren.Add(hwnd);
            return true;
        }
        private string getDisciplineName()
        {
            return WinAPI.GetControlText(titleChildren[2]);
        }
        private string getPlaneName()
        {
            return WinAPI.GetControlText(titleChildren[11]);
        }
        private string getZavK ()
        {
            return WinAPI.GetControlText(titleChildren[44]);
        }
        private string getDepartament ()
        {
            return WinAPI.GetControlText(titleChildren[7]);
        }
        private string getMajorCode()
        {
            return WinAPI.GetControlText(titleChildren[3]);
        }
        private string getMajorName()
        {
            sql = new SqlConnection(conRPD);
            sql.Open();
            string majorName="";
            SqlDataReader sqlReader = null;
            SqlCommand PlaneCode = new SqlCommand("SELECT Название FROM ООП WHERE Шифр='" + getMajorCode() + "'", sql);
            try
            {
                sqlReader = PlaneCode.ExecuteReader();
                while (sqlReader.Read())
                {
                    majorName = sqlReader["Название"].ToString();
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
            return majorName;
        }

        private void FOS_Load(object sender, EventArgs e)
        {
            RPDHWnd = getRPDHWnd();
            if (RPDHWnd.ToInt32() != 0)
            {
                IntPtr titleHWnd = getTitle();
                getTitleChildren(titleHWnd);
                discipline = getDisciplineName();
                plan = getPlaneName();
                DisciplineLabel.Text = discipline;
                PlanLabel.Text = plan;
            }
            GetCompetence();
            GetQuestions();
            GetQuestions();
            GetListsOfQuestions();
            UpdateWorks();
            TicketsProgressBar.Visible = true;
            TicketsProgressBar.Minimum = 0;
            TicketsProgressBar.Value = 0;
            TicketsProgressBar.Step = 1;
        }

        private void DeleteQuestionButton_Click(object sender, EventArgs e)
        {
            if (ChooseQuestionCheckedList.SelectedIndex == -1)
                MessageBox.Show("Пожалуйста, выберете вопрос для удаления", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                sql = new SqlConnection(conMod);
                sql.Open();
                // Заготовка Delete
                string sDelSql = "DELETE Questions WHERE QuestionID=" + ChooseQuestionCheckedList.SelectedValue;
                // Создаем команду
                SqlCommand Del = new SqlCommand(sDelSql, sql);
                //Выполняем команду на вставку записи
                Del.ExecuteNonQuery();
                GetQuestions();
            }
        }

        private void ChooseQuestionCheckedList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (ChooseQuestionCheckedList.GetItemChecked(ChooseQuestionCheckedList.SelectedIndex) == true)
            {
                sql = new SqlConnection(conMod);
                sql.Open();
                string up = "UPDATE Questions SET Active='False' WHERE QuestionID=" + ChooseQuestionCheckedList.SelectedValue;
                SqlCommand Ins = new SqlCommand(up, sql);
                Ins.ExecuteNonQuery();
                GetListsOfQuestions();
            }
            else
            {
                sql = new SqlConnection(conMod);
                sql.Open();
                string up = "UPDATE Questions SET Active='True' WHERE QuestionID=" + ChooseQuestionCheckedList.SelectedValue;
                SqlCommand Ins = new SqlCommand(up, sql);
                Ins.ExecuteNonQuery();
                GetListsOfQuestions();
            }
        }

        private void GenerateTicketsButton_Click(object sender, EventArgs e)
        {
            bool tryparse = int.TryParse(CountOfTicketsTextBox.Text, out int o);
            if (tryparse==false)
                MessageBox.Show("Пожалуйста, введите ЧИСЛО в поле \"Количество билетов\"", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (CountOfTeoreticQuestionComboBox.SelectedIndex == -1)
                    MessageBox.Show("Пожалуйста, укажите количество теоретических вопросов в билете", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (CountOfPracticeQuestionComboBox.SelectedIndex == -1)
                        MessageBox.Show("Пожалуйста, укажите количество практических вопросов в билете", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        if (Convert.ToInt32(CountOfTeoreticQuestionComboBox.Text) > theory.Count)
                        {
                            MessageBox.Show("Количество теоретических вопросов на один билет превышает количество теоретических вопросов в БД", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (Convert.ToInt32(CountOfPracticeQuestionComboBox.Text) > practice.Count)
                            {
                                MessageBox.Show("Количество практических вопросов на один билет превышает количество практических вопросов в БД", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                TicketHeader tickets = new TicketHeader(discipline, o, Convert.ToInt32(CountOfTeoreticQuestionComboBox.Text), Convert.ToInt32(CountOfPracticeQuestionComboBox.Text), getZavK(), getMajorCode(), getMajorName(), getDepartament());
                                tickets.Show();
                            }
                        }
                    }
                }
            }           
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            GetQuestions();
        }

        private void RepairQuestionButton_Click(object sender, EventArgs e)
        {
                check = true;
                switchLabel.Text = "Редактирование вопроса";
                sql = new SqlConnection(conMod);
                sql.Open();
                SqlDataReader sqlReader = null;
                SqlCommand QuestionRepair = new SqlCommand("SELECT * FROM Questions WHERE DisciplinesName='" + discipline + "' AND QuestionID=" + ChooseQuestionCheckedList.SelectedValue, sql);
                try
                {
                    sqlReader = QuestionRepair.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        AddQuestionTextBox.Text = sqlReader["QuestionText"].ToString();
                        CompetenceChooseComboBox.Text = sqlReader["Competence"].ToString();
                        QuestionTypeComboBox.Text = sqlReader["QuestionType"].ToString();
                    }
                }
                catch (Exception ex)
                {
                check = false;
                AddNewQuestionButton.Text = "Добавить вопрос";
                switchLabel.Text = "Добавленние вопроса";
                MessageBox.Show("Пожалуйста, выберите вопрос для редактирования", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();
                AddNewQuestionButton.Text = "Сохранить вопрос";
            }
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            
        }

        private void UpdateListButton_Click(object sender, EventArgs e)
        {
            UpdateWorks();
        }

        private void getWorksTables()
        {
            worksTables.Clear();
            string sql = "SELECT * FROM Works";
            using (SqlConnection connection = new SqlConnection(conMod))
            {
                connection.Open();
                SqlDataAdapter a = new SqlDataAdapter(sql, connection);
                a.Fill(worksTables);
            }
            cbTables.DataSource = worksTables;
            cbTables.ValueMember = "WorkID";
            cbTables.DisplayMember = "WorkName";
        }
        private void getStruct ()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add(new DataColumn("WorkID", Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("WorkName", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Description", Type.GetType("System.String")));
            getWorksTables();
            for (int i = 0; i < worksTables.Rows.Count; i++)
            {
                if (worksTables.Rows[i][1].ToString() == "Экзамен/зачет с оценкой")
                {
                    if (works.Contains("Экзамен") || works.Contains("Зачет с оценкой"))
                    {
                        object[] copyrow = worksTables.Rows[i].ItemArray;
                        dt.Rows.Add(copyrow);
                        continue;
                    }
                    else
                        continue;
                }
               if (worksTables.Rows[i][1].ToString() ==  "Зачёт")
                {
                    if (works.Contains("Зачет"))
                    {
                        object[] copyrow = worksTables.Rows[i].ItemArray;
                        dt.Rows.Add(copyrow);
                        continue;
                    }
                    else
                        continue;
                }
               if (worksTables.Rows[i][1].ToString() == "КП/КР" || worksTables.Rows[i][1].ToString() == "Сдача КП/КР")
                {
                    if (works.Contains("Курсовая работа") || works.Contains("Курсовой проект"))
                    {
                        object[] copyrow = worksTables.Rows[i].ItemArray;
                        dt.Rows.Add(copyrow);
                        continue;
                    }
                    else
                        continue;
                }
                object[] copyrow2 = worksTables.Rows[i].ItemArray;
                dt.Rows.Add(copyrow2);
            }
            dt.DefaultView.Sort = "WorkID ASC";
            //WorkListBox.DataSource = dt;
            //WorkListBox.ValueMember = "WorkID";
            //WorkListBox.DisplayMember = "WorkName";
            foreach (DataRow row in dt.Rows)
            {
                ids.Add(Convert.ToInt32(row[0]));
                WorkListBox.Items.Add(row[1]);
            }
        }
        private void UpButton_Click(object sender, EventArgs e)
        {
            if (WorkListBox.SelectedIndex == -1)
                MessageBox.Show("Пожалуйста, выберете элемент для перемещения", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (WorkListBox.SelectedIndex==0)
                    MessageBox.Show("Выбранный элемент находится в самой верхней позиции", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    string WorkListItem = WorkListBox.SelectedItem.ToString();
                    int WorkListIndex = WorkListBox.SelectedIndex;
                    int IDSItem = Convert.ToInt32(ids[WorkListBox.SelectedIndex].ToString());
                    int IDSIndex = ids.IndexOf(IDSItem);
                    WorkListBox.Items.Remove(WorkListItem);
                    WorkListBox.Items.Insert(WorkListIndex - 1, WorkListItem);
                    ids.Remove(IDSItem);
                    ids.Insert(IDSIndex - 1, IDSItem);
                }
            }
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            if (WorkListBox.SelectedIndex == -1)
                MessageBox.Show("Пожалуйста, выберете элемент для перемещения", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (WorkListBox.SelectedIndex == WorkListBox.Items.Count -1)
                    MessageBox.Show("Выбранный элемент находится в самой нижней позиции", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    string WorkListItem = WorkListBox.SelectedItem.ToString();
                    int WorkListIndex = WorkListBox.SelectedIndex;
                    int IDSItem = Convert.ToInt32(ids[WorkListBox.SelectedIndex].ToString());
                    int IDSIndex = ids.IndexOf(IDSItem);
                    WorkListBox.Items.Remove(WorkListItem);
                    WorkListBox.Items.Insert(WorkListIndex + 1, WorkListItem);
                    ids.Remove(IDSItem);
                    ids.Insert(IDSIndex + 1, IDSItem);
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (WorkListBox.SelectedIndex == -1)
                MessageBox.Show("Пожалуйста, выберете элемент для удаления", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {               
                    string WorkListItem = WorkListBox.SelectedItem.ToString();
                    int WorkListIndex = WorkListBox.SelectedIndex;
                    int IDSItem = Convert.ToInt32(ids[WorkListBox.SelectedIndex].ToString());
                    int IDSIndex = ids.IndexOf(IDSItem);
                    WorkListBox.Items.Remove(WorkListItem);
                    ids.Remove(IDSItem);
            }
        }

        private void AddTableButton_Click(object sender, EventArgs e)
        {
            if (cbTables.SelectedIndex==-1)
                MessageBox.Show("Пожалуйста, выберете элемент для добавления", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                WorkListBox.Items.Add(cbTables.Text);
                ids.Add(Convert.ToInt32(cbTables.SelectedValue));
            }
        }
        private void generateTable (int id, Document doc)
        {
            Range r = doc.Range();
            System.Data.DataTable dt = new System.Data.DataTable();
            string query = "SELECT * FROM WorksCells WHERE TableID=" + id;
            using (SqlConnection connection = new SqlConnection(conMod))
            {
                SqlDataAdapter a = new SqlDataAdapter(query, connection);
                a.Fill(dt);
            }
            DataRow[] rows = dt.Select("Lvl = MAX(Lvl)");
            DataRow row = rows[0];
            int max = (int)row[3];
            int countOfRows = 0;
            if (max>0)
            {
                countOfRows = (int)dt.Rows[dt.Rows.Count - 1][1] + max - 1;
            }
            else
            {
                countOfRows = (int)dt.Rows[dt.Rows.Count - 1][1];
            }
            int countOfColumns = (int)dt.Rows[dt.Rows.Count - 1][2];
            tb = doc.Tables.Add(doc.Paragraphs[doc.Paragraphs.Count].Range, countOfRows, countOfColumns);
            tb.Borders.Enable = 1;//Делаем границы видимыми
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dRow = dt.Rows[i];
                int rindex = (int)dRow[1];
                if ((int)dRow[6] > 0)
                {
                    tb.Cell((int)dRow[1], (int)dRow[2]).Merge(tb.Cell((int)dRow[6] + (int)dRow[1] - 1, (int)dRow[2]));
                }
                if ((int)dRow[7] > 0)
                {
                    tb.Cell((int)dRow[1], (int)dRow[2]).Merge(tb.Cell((int)dRow[1], (int)dRow[2] + (int)dRow[7] - 1));
                }
                if ((int)dRow[3] > 1)
                {
                    rindex = (int)dRow[1] + (int)dRow[3] - 1;
                }
                if ((int)dRow[1] > 1)
                {
                    if (max>0)
                        rindex += max-1;
                    else
                        rindex += max;
                }
                tb.Cell(rindex, (int)dRow[2]).Range.Text = dRow[4].ToString();
                tb.Cell(rindex, (int)dRow[2]).Range.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                tb.Cell(rindex, (int)dRow[2]).Range.Font.Size = 9;
                tb.Cell(rindex, (int)dRow[2]).Range.Font.Name = "Times New Roman";
                tb.Cell(rindex, (int)dRow[2]).Range.Font.Bold = 0;
                tb.Cell(rindex, (int)dRow[2]).Range.Paragraphs.LineUnitAfter = 0.5f;
                tb.Cell(rindex, (int)dRow[2]).Range.Paragraphs.LineUnitAfter = 0.4f;
                tb.Cell(rindex, (int)dRow[2]).Range.Paragraphs.LineUnitBefore = 0.4f;
                //tb.Cell((int)dRow[1], (int)dRow[2]).Range.Text = dRow[4].ToString()
            }
            if (id==5)
            {
                r.InsertAfter("\n");
                SqlConnection sql = new SqlConnection(conMod);
                SqlDataReader sqlReader = null;
                sql.Open();
                r.InsertAfter("Примерный перечень вопросов" + "\n");
                for (int j = 0; j < competences.Count; j++)
                {
                    SqlCommand Questions = new SqlCommand("SELECT * FROM Questions WHERE DisciplinesName='" + discipline + "' AND Active='True' AND Competence='" + competences[j].ToString() + "'", sql);
                    try
                    {
                        int k = 1;
                        sqlReader = Questions.ExecuteReader();
                        r.InsertAfter("Компетенция: " + competences[j].ToString() + "\n");
                        while (sqlReader.Read())
                        {
                            r.InsertAfter(k + ". " + sqlReader["QuestionText"].ToString() + "\n");
                            k++;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (sqlReader != null)
                            sqlReader.Close();
                    }
                }
                r.Font.Size = 10;
                r.Font.Bold = 0;
                r.Font.Name = "Arial";
                r.InsertAfter("\n");
            }
        }
        public string GetCompetenceForDocument()
        {
            string a = "";
            for (int i =0;i<competences.Count;i++)
            {
                if (i == competences.Count - 1)
                   a = a + competences[i] + " ";
                else
                    a= a + competences[i] + ", ";
            }
            return a;
        }
        private void metroButton3_Click(object sender, EventArgs e)
        {
            TicketsProgressBar.Maximum = ids.Count;
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            Document doc = app.Documents.Add(Visible: true);
            doc.PageSetup.BottomMargin = 56.9f;
            doc.PageSetup.LeftMargin = 64.1f;
            doc.PageSetup.TopMargin = 56.9f;
            doc.PageSetup.RightMargin = 43.2f;
            Range r = doc.Range();
            r.InsertAfter("Оценочные материалы при формировании рабочих программ дисциплин (модулей)" + "\n");
            r.InsertAfter("Направление подготовки / специальность: "+getMajorName() + "\n");
            r.InsertAfter("Профиль / специализация: " + "\n");
            r.InsertAfter("Дисциплина: " + discipline + "\n" + "\n");
            r.InsertAfter("Формируемые компетенции: " + GetCompetenceForDocument() + "\n");
            r.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            r.Font.Size = 10;
            r.Font.Name = "Arial";
            for (int i = 0; i < ids.Count; i++)
            {
                if (ids[i] == 1)
                {
                    r.InsertAfter("Показатели и критерии оценивания компетенций " + GetCompetenceForDocument() + "\n");
                }
                if (ids[i] == 2)
                {
                    r.InsertAfter("Шкалы оценивания компетенций " + GetCompetenceForDocument() + "при сдаче экзамена или зачета с оценкой" + "\n");
                }
                if (ids[i] == 3)
                {
                    r.InsertAfter("Шкалы оценивания компетенций " + GetCompetenceForDocument() + "при сдаче зачета" + "\n");
                }
                if (ids[i] == 4)
                {
                    r.InsertAfter("Шкалы оценивания компетенций " + GetCompetenceForDocument() + "при защите курсового проекта/курсовой работы" + "\n");
                }
                if (ids[i] == 5)
                {
                    r.InsertAfter("Компетенции обучающегося оцениваются следующим образом" + "\n");
                }
                if (ids[i] == 6)
                {
                    r.InsertAfter("Соответствие между бальной системой и системой оценивания по результатам тестирования устанавли-вается посредством следующей таблицы" + "\n");
                }
                if (ids[i] == 7)
                {
                    r.InsertAfter("Оценка ответа обучающегося на вопросы, задачу (задание) экзаменационного билета, зачета" + "\n");
                }
                if (ids[i] == 8)
                {
                    r.InsertAfter("Оценка ответа обучающегося при защите курсового работы/курсового проекта" + "\n");
                }
                generateTable(ids[i], doc);
                r.InsertAfter("\n");
                TicketsProgressBar.PerformStep();
            }
            doc.Save();
            doc.Close();
            app.Quit();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            RPDModule.FOSTablesEdit editor = new RPDModule.FOSTablesEdit();
            editor.Show();
        }
    }
}
