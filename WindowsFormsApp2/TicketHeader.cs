using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Word;

namespace RPDModule
{
    public partial class TicketHeader : MetroFramework.Forms.MetroForm
    {
        List<string> theoryPerm = new List<string>();
        List<string> practicePerm = new List<string>();
        int caseSwitch = 1;
        int temp;
        Table tb;  /* Если не получится объявить так, то объяви через: public static Table tb;  */
        List<string> theory = new List<string>();
        List<string> practice = new List<string>();
        string conMod = ConfigurationManager.ConnectionStrings["ModuleConnection"].ConnectionString;
        SqlConnection sql;
        string discipline;
        int CountOfTickets;
        int CountOfTheoryQuestions;
        int CountOfPracticeQuestion;
        string daddy;
        string majorcode;
        string majorname;
        string departament;
        public TicketHeader(string dis, int COT, int COTQ, int COPQ, string Daddy, string MajorCode, string MajorName, string Departament)
        {
            InitializeComponent();
            discipline = dis;
            CountOfTickets = COT;
            CountOfTheoryQuestions = COTQ;
            CountOfPracticeQuestion = COPQ;
            daddy = Daddy;
            majorcode = MajorCode;
            majorname = MajorName;
            departament = Departament;
        }
        public void GetStyle(int i, int j)
        {
            tb.Cell(i, j).Range.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tb.Cell(i, j).Range.Font.Name = "Times New Roman";
            tb.Cell(i, j).Range.Font.Size = 10;
            tb.Cell(i, j).Range.Paragraphs.LineSpacing = 8.5f;
            tb.Cell(i, j).Range.Paragraphs.LineUnitAfter = 0.4f;
            tb.Cell(i, j).Range.Paragraphs.LineUnitBefore = 0.4f;
        }
        private void TicketHeader_Load(object sender, EventArgs e)
        {
            for (int i =2020; i<2035;i++)
            {
                AcademicYearComboBox.Items.Add(i+"-"+(i+1));
            }
            DisciplineNameTextBox.Text = discipline;
            DisciplineNameTextBox.Enabled = false;
            DepartamentTextBox.Text = departament;
            DepartamentTextBox.Enabled = false;
            MajorCode.Text = majorcode;
            MajorCode.Enabled = false;
            MajorName.Text = majorname;
            MajorName.Enabled = false;
            DaddyTextBox.Text = daddy;
            DaddyTextBox.Enabled = false;
            TicketsProgressBar.Visible = true;
            TicketsProgressBar.Minimum = 0;
            TicketsProgressBar.Maximum = CountOfTickets;
            TicketsProgressBar.Value = 0;
            TicketsProgressBar.Step = 1;
        }

        private void GenerateTicketsButton_Click(object sender, EventArgs e)
        {
            int k;
            Random random = new Random();
            sql = new SqlConnection(conMod);
            sql.Open();
            SqlDataReader sqlReader = null;
            SqlCommand PlaneCode = new SqlCommand("SELECT QuestionText, QuestionType, Competence FROM Questions WHERE QuestionType='Теор.' AND Active = 'True' AND DisciplinesName='" + discipline + "'", sql);
            try
            {
                sqlReader = PlaneCode.ExecuteReader();
                while (sqlReader.Read())
                {
                    theory.Add(sqlReader["QuestionText"].ToString()+" ("+sqlReader["Competence"].ToString()+")");
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
            PlaneCode = new SqlCommand("SELECT QuestionText, Competence FROM Questions WHERE QuestionType='Практ.' AND Active = 'True' AND DisciplinesName='" + discipline + "'", sql);
            try
            {
                sqlReader = PlaneCode.ExecuteReader();
                while (sqlReader.Read())
                {
                    practice.Add(sqlReader["QuestionText"].ToString() + " (" + sqlReader["Competence"].ToString() + ")");
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
            for (int p=0;p<theory.Count;p++)
            {
                theoryPerm.Add(theory[p]);
            }
            for (int p = 0; p < practice.Count; p++)
            {
                practicePerm.Add(practice[p]);
            }
            int TableRow = CountOfTheoryQuestions+CountOfPracticeQuestion;
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            Document doc = app.Documents.Add(Visible: true);
            doc.Paragraphs.LeftIndent = 37f;
            Range r = doc.Range();           
            for (int i = 1; i <= CountOfTickets; i++)
            {
                tb = doc.Tables.Add(doc.Paragraphs[doc.Paragraphs.Count].Range, TableRow + 2, 1); /* В паметрах указывается: 1.Место,где она начинается; 2.Кол-во строк; 3.Кол-во столбцов  */              
                tb.Borders.Enable = 1;//Делаем границы видимыми
                tb.Rows.HeadingFormat = -1;
                int rowcounter = 3;
                tb.Cell(1, 0).Width = 498.5f;
                tb.Cell(1, 0).HeightRule = WdRowHeightRule.wdRowHeightExactly;
                tb.Cell(1, 0).Height = 12f;
                tb.Cell(1, 0).Range.Text = "Дальневосточный государственный университет путей сообщения";
                tb.Cell(1, 0).Range.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tb.Cell(1, 0).Range.Font.Name = "Times New Roman";
                tb.Cell(1, 0).Range.Font.Size = 10;
                tb.Cell(2, 0).Split(1, 3);
                // ячейка первая из 3
                tb.Cell(2, 1).Width = 147.7f;
                tb.Cell(2, 1).Range.InsertAfter ("Кафедра \""+ DepartamentTextBox.Text +  "\"\n");
                tb.Cell(2, 1).Range.InsertAfter(SemesterComboBox.Text + "-й семестр"+"\n");
                tb.Cell(2, 1).Range.InsertAfter(AcademicYearComboBox.Text + " учебный год");
                GetStyle(2, 1);
                // ячейка вторая из 3
                tb.Cell(2, 2).Width = 206.3f;
                tb.Cell(2, 2).Range.InsertAfter("ЭКЗАМЕНАЦИОННЫЙ БИЛЕТ № " + i + "\n");
                tb.Cell(2, 2).Range.InsertAfter("по дисциплине \"" + DisciplineNameTextBox.Text + "\""+"\n" + " для студентов специальности "+ MajorCode.Text+ "\n\"" + MajorName.Text+"\"");
                GetStyle(2, 2);
                // ячейка третья из 3
                tb.Cell(2, 3).Width = 144.5f;
                tb.Cell(2, 3).Range.InsertAfter("\"Утверждаю\""+"\n" + "Заведующий кафедрой" + "\n" + DaddyTextBox.Text +"\n" + "\"___\" __________ 20___г.");
                tb.Cell(2, 3).Range.InsertAfter("\n" + "\n");
                GetStyle(2, 3);
                tb.Cell(2, 3).Range.Paragraphs.LineSpacing = 8.5f;
                tb.Cell(2, 3).Range.Paragraphs.LineUnitAfter = 0.3f;
                tb.Cell(2, 3).Range.Paragraphs.LineUnitBefore = 0.3f;
                k = 1;
                for (int j = 0; j < CountOfTheoryQuestions; j++)
                {
                    if (theory.Count == 0)
                    {
                        for (int p = 0; p < theoryPerm.Count; p++)
                        {
                            theory.Add(theoryPerm[p]);
                        }
                    }
                    switch (caseSwitch)
                    {
                        case 1:
                            tb.Cell(rowcounter, 0).Width = 498.5f;

                            temp = random.Next(0, theory.Count/2);
                            tb.Cell(rowcounter, 0).Range.Text = k + ". " + theory[temp].ToString();
                            theory.RemoveAt(temp);
                            tb.Cell(rowcounter, 0).Range.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                            tb.Cell(rowcounter, 0).Range.Font.Name = "Times New Roman";
                            tb.Cell(rowcounter, 0).Range.Font.Size = 10;
                            tb.Cell(rowcounter, 0).Range.Paragraphs.LineSpacing = 8.5f;
                            tb.Cell(rowcounter, 0).Range.Paragraphs.LineUnitAfter = 0.3f;
                            tb.Cell(rowcounter, 0).Range.Paragraphs.LineUnitBefore = 0.3f;
                            rowcounter++;
                            k++;
                            caseSwitch = 2;
                            break;
                        case 2:
                            tb.Cell(rowcounter, 0).Width = 498.5f;
                            temp = random.Next(theory.Count / 2, theory.Count);
                            tb.Cell(rowcounter, 0).Range.Text = k + ". " + theory[temp].ToString();
                            theory.RemoveAt(temp);
                            tb.Cell(rowcounter, 0).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            tb.Cell(rowcounter, 0).Range.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                            tb.Cell(rowcounter, 0).Range.Font.Name = "Times New Roman";
                            tb.Cell(rowcounter, 0).Range.Font.Size = 10;
                            tb.Cell(rowcounter, 0).Range.Paragraphs.LineSpacing = 8.5f;
                            tb.Cell(rowcounter, 0).Range.Paragraphs.LineUnitAfter = 0.3f;
                            tb.Cell(rowcounter, 0).Range.Paragraphs.LineUnitBefore = 0.3f;
                            rowcounter++;
                            k++;
                            caseSwitch = 1;
                            break;
                    }          
                }
                if (CountOfPracticeQuestion!=0)
                {
                    for (int j = 0; j < CountOfPracticeQuestion; j++)
                    {
                        if (practice.Count == 0)
                            for (int p = 0; p < practicePerm.Count; p++)
                            {
                                practice.Add(practicePerm[p]);
                            }
                        switch (caseSwitch)
                        {
                            case 1:
                                tb.Cell(rowcounter, 0).Width = 498.5f;
                                temp = random.Next(0, practice.Count / 2);
                                tb.Cell(rowcounter, 0).Range.Text = k + ". " + practice[temp].ToString();
                                practice.RemoveAt(temp);
                                tb.Cell(rowcounter, 0).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                tb.Cell(rowcounter, 0).Range.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                                tb.Cell(rowcounter, 0).Range.Font.Name = "Times New Roman";
                                tb.Cell(rowcounter, 0).Range.Font.Size = 10;
                                tb.Cell(rowcounter, 0).Range.Paragraphs.LineSpacing = 8.5f;
                                tb.Cell(rowcounter, 0).Range.Paragraphs.LineUnitAfter = 0.3f;
                                tb.Cell(rowcounter, 0).Range.Paragraphs.LineUnitBefore = 0.3f;
                                rowcounter++;
                                k++;
                                caseSwitch = 2;
                                break;
                            case 2:
                                tb.Cell(rowcounter, 0).Width = 498.5f;
                                temp = random.Next(practice.Count / 2, practice.Count);
                                tb.Cell(rowcounter, 0).Range.Text = k + ". " + practice[temp].ToString();
                                practice.RemoveAt(temp);
                                tb.Cell(rowcounter, 0).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                tb.Cell(rowcounter, 0).Range.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                                tb.Cell(rowcounter, 0).Range.Font.Name = "Times New Roman";
                                tb.Cell(rowcounter, 0).Range.Font.Size = 10;
                                tb.Cell(rowcounter, 0).Range.Paragraphs.LineSpacing = 8.5f;
                                tb.Cell(rowcounter, 0).Range.Paragraphs.LineUnitAfter = 0.3f;
                                tb.Cell(rowcounter, 0).Range.Paragraphs.LineUnitBefore = 0.3f;
                                rowcounter++;
                                k++;
                                caseSwitch = 1;
                                break;
                        }
                    }
                }
                r.InsertAfter("\n");
                TicketsProgressBar.PerformStep();
            }
            doc.Save();
            doc.Close();
            app.Quit();
            MessageBox.Show("Билеты сгенерированы", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EditDesciplineNameButton_Click(object sender, EventArgs e)
        {
           DialogResult result = MessageBox.Show("Наименование дисциплины взято из РПД, Вы уверены, что хотите изменить наименование дисциплины?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DisciplineNameTextBox.Enabled = true;
            }
        }

        private void DepartamentEditButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Наименование кафедры взято из РПД, Вы уверены, что хотите изменить наименование кафедры?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DepartamentTextBox.Enabled = true;
            }
        }

        private void MajorCodeEditButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Код специальности взят из РПД, Вы уверены, что хотите изменить код специальности?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                MajorCode.Enabled = true;
            }
        }

        private void MajorNameEditNumber_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Наименование специальности взято из РПД, Вы уверены, что хотите изменить наименование специальности?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                MajorName.Enabled = true;
            }
        }

        private void DaddyEditButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Фамилия и инициалы взяты из РПД, Вы уверены, что хотите изменить фамилию и инициалы?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DaddyTextBox.Enabled = true;
            }
        }
    }
}
