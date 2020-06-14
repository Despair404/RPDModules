using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace WindowsFormsApp2
{
    public partial class FOS : MetroFramework.Forms.MetroForm
    {
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
        public FOS()
        {
            InitializeComponent();
        }
        string conRPD = ConfigurationManager.ConnectionStrings["RPDConnection"].ConnectionString;
        string conMod = ConfigurationManager.ConnectionStrings["ModuleConnection"].ConnectionString;
        public async void GetCompetence()
        {
            competences.Clear();
            int id = 0;
            int idDiscipline = 0;
            sql = new SqlConnection(conRPD);
            await sql.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand PlaneCode = new SqlCommand("SELECT Код FROM Планы WHERE ИмяФайла='" + plan + "'", sql);
            try
            {
                sqlReader = await PlaneCode.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    id = Convert.ToInt32(sqlReader["Код"]);
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
            SqlCommand DisciplineCode = new SqlCommand("SELECT * FROM ПланыСтроки WHERE Дисциплина='" + discipline + "' AND КодПлана=" + id, sql);
            try
            {
                sqlReader = await DisciplineCode.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    idDiscipline = Convert.ToInt32(sqlReader["Код"]);
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
            string competence = "SELECT * FROM ПланыКомпетенции WHERE Код= ANY(  SELECT КодКомпетенции FROM ПланыКомпетенцииДисциплины WHERE КодСтроки=" + idDiscipline + ")";
            SqlDataAdapter adapter = new SqlDataAdapter(competence, sql);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            CompetenceChooseComboBox.DataSource = ds.Tables[0];
            CompetenceChooseComboBox.DisplayMember = "ШифрКомпетенции";
            CompetenceChooseComboBox.ValueMember = "Код";
            CompetenceChooseComboBox.SelectedItem = null;
            for (int i = 0; i<ds.Tables[0].Rows.Count;i++)
            {
                competences.Add(ds.Tables[0].Rows[i][3].ToString());
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
                for (int i=0;i<ds.Tables[0].Rows.Count;i++)
                {
                    if (Convert.ToBoolean(ds.Tables[0].Rows[i][4]) == true)
                        ChooseQuestionCheckedList.SetItemChecked(i, true);
                    else
                        ChooseQuestionCheckedList.SetItemChecked(i, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            for (int i = 0; i < ChooseQuestionCheckedList.Items.Count; i++)
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
        }

        private void DeleteQuestionButton_Click(object sender, EventArgs e)
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
            if (Convert.ToInt32(CountOfTeoreticQuestionComboBox.Text)>theory.Count)
            {
                MessageBox.Show("Количество теоретических вопросов на один билет превышает количество теоретических вопросов в БД", "Внимание",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (Convert.ToInt32(CountOfPracticeQuestionComboBox.Text) > practice.Count)
                {
                    MessageBox.Show("Количество практических вопросов на один билет превышает количество практических вопросов в БД", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TicketHeader tickets = new TicketHeader(discipline, Convert.ToInt32(CountOfTicketsTextBox.Text), Convert.ToInt32(CountOfTeoreticQuestionComboBox.Text), Convert.ToInt32(CountOfPracticeQuestionComboBox.Text), getZavK(), getMajorCode(), getMajorName(), getDepartament());
                    tickets.Show();
                }
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            sql = new SqlConnection(conMod);
            SqlDataReader sqlReader = null;
            sql.Open();
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            Document doc = app.Documents.Add(Visible: true);
            Range r = doc.Range();
            r.InsertAfter("Примерный перечень вопросов" + "\n");
            for (int i = 0; i < competences.Count; i++)
            {
                SqlCommand Questions = new SqlCommand("SELECT * FROM Questions WHERE DisciplinesName='" + discipline + "' AND Active='True' AND Competence='" + competences[i].ToString()+ "'", sql);
                try
                {
                    int k = 1;
                    sqlReader = Questions.ExecuteReader();
                    r.InsertAfter("Компетенция: " + competences[i].ToString() + "\n");
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
            doc.Save();
            doc.Close();
            app.Quit();
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
            SqlCommand QuestionRepair = new SqlCommand("SELECT * FROM Questions WHERE DisciplinesName='" + discipline + "' AND QuestionID="+ ChooseQuestionCheckedList.SelectedValue, sql);
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
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
            AddNewQuestionButton.Text = "Сохранить вопрос";
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            
        }

        private void UpdateListButton_Click(object sender, EventArgs e)
        {
            WorkListBox.Items.Clear();
            try
            {
                RPDHWnd = getRPDHWnd();
                if (RPDHWnd.ToInt32() == 0)
                    throw new Exception("Редактируемая рабочая программа не найдена. Пожалуйста, запустите ПО РПД и откройте рабочую программу, методические указания которой нужно редактировать.");
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
                        List<string> works = new List<string>() ;
                        for (int i=0; i< dt.Rows.Count; i++)
                        {
                            works.Add(dt.Rows[i][1].ToString());
                        }
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
    }
}
