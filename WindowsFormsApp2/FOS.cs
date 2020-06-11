using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace WindowsFormsApp2
{
    public partial class FOS : MetroFramework.Forms.MetroForm
    {
        List<string> competences = new List<string>();
        SqlConnection sql;
        IntPtr RPDHWnd;
        List<IntPtr> titleChildren = new List<IntPtr>();
        string discipline;
        string plane;
        List<string> theory = new List<string>();
        List<string> practice = new List<string>();
        public FOS()
        {
            InitializeComponent();
        }
        public async void GetCompetence()
        {
            competences.Clear();
            int id = 0;
            int idDiscipline = 0;
            string a = @"Data Source=DESKTOP-2KLBEO1\SQLEXPRESS;Initial Catalog=plany;Integrated Security=True";
            sql = new SqlConnection(a);
            await sql.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand PlaneCode = new SqlCommand("SELECT Код FROM Планы WHERE ИмяФайла='" + plane + "'", sql);
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
            string a = @"Data Source=DESKTOP-2KLBEO1\SQLEXPRESS;Initial Catalog=plany;Integrated Security=True";
            sql = new SqlConnection(a);
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
        }
        private void AddNewQuestionButton_Click(object sender, EventArgs e)
        {
            if(QuestionTypeComboBox.SelectedIndex == -1)
                MessageBox.Show("Пожалуйста, выберите тип вопроса", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (AddQuestionTextBox.Text == "")
                MessageBox.Show("Пожалуйста, введите формулировку вопроса", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (CompetenceChooseComboBox.SelectedIndex == -1)
                    MessageBox.Show("Пожалуйста, выберите компетенцию, к которой относится вопрос", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    // Создаем и открывает соединение с MS SQL Server
                    string a = @"Data Source=DESKTOP-2KLBEO1\SQLEXPRESS;Initial Catalog=plany;Integrated Security=True";
                    sql = new SqlConnection(a);
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
                    GetQuestions();
                }
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
                //string a = WinAPI.GetControlText(child);
                //WinAPI.SendMessage(child, Convert.ToInt32(WinAPI.GetWindow_Cmd.WM_SETTEXT), 0, a + textBox1.Text);
                //WinAPI.SetForegroundWindow(child[7]);
                //var win = WinAPI.FindWindowsWithText("MenuStrip");
                //foreach (var i in win)
                //{
                //    listBox1.Items.Add(i);
                //}
            }
            else MessageBox.Show("Окно методических указаний не найдено.");
            return child;
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

        private void FOS_Load(object sender, EventArgs e)
        {
            RPDHWnd = getRPDHWnd();
            if (RPDHWnd.ToInt32() != 0)
            {
                IntPtr titleHWnd = getTitle();
                getTitleChildren(titleHWnd);
                discipline = getDisciplineName();
                plane = getPlaneName();
                DisciplineLabel.Text = discipline;
                PlanLabel.Text = plane;
            }
            GetCompetence();
            GetQuestions();
        }

        private void DeleteQuestionButton_Click(object sender, EventArgs e)
        {
            string a = @"Data Source=DESKTOP-2KLBEO1\SQLEXPRESS;Initial Catalog=plany;Integrated Security=True";
            sql = new SqlConnection(a);
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
                string a = @"Data Source=DESKTOP-2KLBEO1\SQLEXPRESS;Initial Catalog=plany;Integrated Security=True";
                sql = new SqlConnection(a);
                sql.Open();
                string up = "UPDATE Questions SET Active='False' WHERE QuestionID=" + ChooseQuestionCheckedList.SelectedValue;
                SqlCommand Ins = new SqlCommand(up, sql);
                Ins.ExecuteNonQuery();
            }
            else
            {
                string a = @"Data Source=DESKTOP-2KLBEO1\SQLEXPRESS;Initial Catalog=plany;Integrated Security=True";
                sql = new SqlConnection(a);
                sql.Open();
                string up = "UPDATE Questions SET Active='True' WHERE QuestionID=" + ChooseQuestionCheckedList.SelectedValue;
                SqlCommand Ins = new SqlCommand(up, sql);
                Ins.ExecuteNonQuery();
            }
        }

        private void GenerateTicketsButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string a = @"Data Source=DESKTOP-2KLBEO1\SQLEXPRESS;Initial Catalog=plany;Integrated Security=True";
            sql = new SqlConnection(a);
            sql.Open();
            SqlDataReader sqlReader = null;
            SqlCommand PlaneCode = new SqlCommand("SELECT QuestionText FROM Questions WHERE QuestionType='Теор.' AND Active = 'True' AND DisciplinesName='" + discipline +"'", sql);
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
            int TableRow = Convert.ToInt32(CountOfTeoreticQuestionComboBox.SelectedItem) + Convert.ToInt32(CountOfPracticeQuestionComboBox.SelectedItem);           
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            Document doc = app.Documents.Add(Visible: true);
            Range r = doc.Range();
            for (int i = 1; i <= Convert.ToInt32(CountOfTicketsTextBox.Text); i++)
            {         
                r.InsertAfter("Экзаменационный билет № " + i+"\n");
                Table tb;  /* Если не получится объявить так, то объяви через: public static Table tb;  */
                tb = doc.Tables.Add(doc.Paragraphs[doc.Paragraphs.Count].Range, TableRow + 2 , 1); /* В паметрах указывается: 1.Место,где она начинается; 2.Кол-во строк; 3.Кол-во столбцов  */
                tb.Borders.Enable = 1;//Делаем границы видимыми
                int rowcounter = 3;
                tb.Cell(1, 0).Range.Text = "Дальневосточный государственный университет путей сообщения";
                tb.Cell(1, 0).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                tb.Cell(1, 0).Range.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tb.Cell(1, 0).Range.Font.Name = "Times New Roman";
                tb.Cell(1, 0).Range.Font.Size = 10;
                tb.Cell(2, 0).Split(1, 3);
                tb.Cell(2, 1).Range.Text = "";
                tb.Cell(2, 2).Range.Text = "";
                tb.Cell(2, 3).Range.Text = "";
                for (int j = 0; j < Convert.ToInt32(CountOfTeoreticQuestionComboBox.Text); j++)
                {                                  
                    tb.Cell(rowcounter,0).Range.Text = theory[random.Next(0, theory.Count)].ToString();
                    tb.Cell(rowcounter, 0).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    tb.Cell(rowcounter, 0).Range.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    tb.Cell(rowcounter, 0).Range.Font.Name = "Times New Roman";
                    tb.Cell(rowcounter, 0).Range.Font.Size = 10;
                    rowcounter++;
                }
                for (int j = 0; j < Convert.ToInt32(CountOfPracticeQuestionComboBox.Text); j++)
                {
                    tb.Cell(rowcounter, 0).Range.Text = practice[random.Next(0, theory.Count)].ToString();
                    tb.Cell(rowcounter, 0).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    tb.Cell(rowcounter, 0).Range.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    tb.Cell(rowcounter, 0).Range.Font.Name = "Times New Roman";
                    tb.Cell(rowcounter, 0).Range.Font.Size = 10;
                    rowcounter++;
                }                
                r.InsertAfter("\n");
            }
            doc.Save();
            doc.Close();
            app.Quit();
            MessageBox.Show("Билеты сгенерированы", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string a = @"Data Source=DESKTOP-2KLBEO1\SQLEXPRESS;Initial Catalog=plany;Integrated Security=True";
            sql = new SqlConnection(a);
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

        private void ChooseQuestionCheckedList_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < ChooseQuestionCheckedList.Items.Count; i++)
            {
                ChooseQuestionCheckedList.SetSelected(i, false);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            GetQuestions();
        }
    }
}
