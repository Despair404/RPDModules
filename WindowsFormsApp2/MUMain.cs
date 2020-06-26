using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using RPDModule;

namespace RPDModule
{
    public partial class MUMain : MetroFramework.Forms.MetroForm
    {
        public MUMain(Main main)
        {

            InitializeComponent();
            User.UserEventHandler = new User.UserChanged(getUser);
            DB = new DBWorker(conModule);
            this.main = main;
            getRPDInfo();
            getWorksFromRPD();
            string sql = "SELECT * FROM modTemplateType ORDER BY Name";
            using (SqlConnection con = new SqlConnection(conModule))
            {
                SqlDataAdapter adap = new SqlDataAdapter(sql, con);
                DataSet works = new DataSet();
                adap.Fill(works);
                colType.DataSource = works.Tables[0];
                colType.DisplayMember = "Name";
                colType.ValueMember = "ID";
                colType.DataPropertyName = "ID";

            }
            checkStruct();
            check = true;
            isClose = true;
      


        }
        Main main;
        IntPtr RPDHWnd;

        DBWorker DB;

        bool isClose;

        string discipline;
        string plan;
        int DisciplineID = 0;

        List<IntPtr> titleChildren = new List<IntPtr>();

        string conRPD = ConfigurationManager.ConnectionStrings["RPDConnection"].ConnectionString;
        string conModule = ConfigurationManager.ConnectionStrings["ModuleConnection"].ConnectionString;

        

        DataSet WorkTypes = new DataSet(); // Работы в данной дисциплине

        bool check = false;
        /// <summary>
        /// Получает информацию о выбранной дисциплине. 
        /// </summary>
        private void getRPDInfo()
        {
            try
            {
                RPDHWnd = getRPDHWnd();
                if (RPDHWnd.ToInt32() == 0)
                    throw new Exception("Редактируемая рабочая программа не найдена. Пожалуйста, запустите ПО \"РПД\" и откройте рабочую программу, методические указания которой нужно редактировать, а затем выберите пункт меню \"Обновить\"");
                if (RPDHWnd.ToInt32() != 0)
                {
                    IntPtr titleHWnd = getTitle();
                    titleChildren.Clear();
                    getTitleChildren(titleHWnd);
                    discipline = getDisciplineName();
                    plan = getPlaneName();
                    lbPlan.Text = plan;
                    lbDiscipline.Text = discipline;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void checkStruct ()
        {
            int counter = 0;
            using (SqlConnection con = new SqlConnection(conModule))
            {
                string sql = "SELECT * FROM modStruct WHERE DisciplineID=" + DisciplineID;
                con.Open();
                SqlCommand command = new SqlCommand(sql, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    counter++;
                }
                reader.Close();
            }
            if (counter > 0)
                getStructFromDB();
            else
                fillWorkTable();
        }
        private void getStructFromDB()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM modStruct INNER JOIN modTemplates ON modStruct.TemplateID = modTemplates.ID WHERE modStruct.DisciplineID = " + DisciplineID;
            using (SqlConnection con = new SqlConnection(conModule))
            {
                SqlDataAdapter ad = new SqlDataAdapter(sql, con);
                
                ad.Fill(dt);
            }
            dgvMUStruct.Rows.Clear();
            check = false;
            foreach (var row in dt.Rows)
            {
                dgvMUStruct.Rows.Add();
            }
            for (int i = 0; i < dt.Rows.Count;i++)
            {
                    dgvMUStruct.Rows[i].Cells[0].Value = dt.Rows[i][6];
                    DataGridViewComboBoxCell combo = (DataGridViewComboBoxCell)dgvMUStruct.Rows[i].Cells[1];
                    string sql2 = "SELECT * from modTemplates WHERE TypeID = " + dt.Rows[i][6];
                    DataTable works = DB.getDataSet(sql2).Tables[0];
                    combo.DataSource = works;
                    combo.DisplayMember = "Name";
                    combo.ValueMember = "ID";
                    combo.Value = dt.Rows[i][3];

                }
                check = true;
                dgvMUStruct.ClearSelection();
            }
    

        private void getWorksFromRPD()
        {
            
                SqlConnection connection = new SqlConnection(conRPD);
            try
            {
                connection.Open();
                string sql = "SELECT Код FROM Планы WHERE ИмяФайла='" + plan + "'";

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                int id = 0;
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader.GetValue(0));
                }
                reader.Close();
                DisciplineID = RPDScaner.getDisciplineID(discipline, id);
                sql = "SELECT * FROM СправочникВидыРабот WHERE Код= ANY(SELECT DISTINCT КодВидаРаботы FROM ПланыНовыеЧасы where КодОбъекта=" + DisciplineID + ")";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                WorkTypes.Clear();
                adapter.Fill(WorkTypes);

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        /// <summary>
        /// Заполняет таблицу структуры МУ. 
        /// </summary>
        private void fillWorkTable ()
        {
            dgvMUStruct.Rows.Clear();
            check = false;
            List<int> worksid = findWorks();
            foreach (var i in worksid)
            {
                dgvMUStruct.Rows.Add();
            }
            for (int i = 0; i < worksid.Count; i++)
            {
                dgvMUStruct.Rows[i].Cells[0].Value = worksid[i];
                DataGridViewComboBoxCell combo = (DataGridViewComboBoxCell)dgvMUStruct.Rows[i].Cells[1];
                string sql = "SELECT * from modTemplates WHERE TypeID = " + worksid[i];
                DataTable works = DB.getDataSet(sql).Tables[0];
                combo.DataSource = works;
                combo.DisplayMember = "Name";
                combo.ValueMember = "ID";
                if (works.Rows.Count > 0)
                    combo.Value = works.Rows[0][0];

            }
            check = true;
           dgvMUStruct.ClearSelection();
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

        /// <summary>
        /// Получает хэндл главного окна программы РПД
        /// </summary>
        /// <returns></returns>
        private IntPtr getRPDHWnd()
        {
            IntPtr target = IntPtr.Zero;
            WinAPI.EnumWindows((hWnd, lParam) =>
            {
                if (WinAPI.IsWindowVisible(hWnd) && WinAPI.GetWindowTextLength(hWnd) != 0)
                {
                    string title = WinAPI.GetWindowText(hWnd);
                    if (title.Contains("РПД :"))
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
        /// <summary>
        /// Получает название дисциплины. 
        /// </summary>
        /// <returns></returns>
        private string getDisciplineName()
        {
            return WinAPI.GetControlText(titleChildren[2]);
        }
        /// <summary>
        /// Получает название плана. 
        /// </summary>
        /// <returns></returns>
        private string getPlaneName()
        {
            return WinAPI.GetControlText(titleChildren[11]);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            getRPDInfo();
            getWorksFromRPD();
            checkStruct();
            tbDescription.Text = "";
            tbPreview.Text = "";
        }

        private void btnCreateText_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            for (int i=0;i< dgvMUStruct.Rows.Count;i++)
            {
                ids.Add(Convert.ToInt32(dgvMUStruct.Rows[i].Cells[1].Value));
            }
            string MU = "";
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(conModule))
            {

                connection.Open();
                string sql = "SELECT * FROM modTemplates";
                SqlDataAdapter a = new SqlDataAdapter(sql, connection);
                a.Fill(ds);
            }
            foreach (int i in ids)
            {
                if (i != 0) { 
                DataRow rows = ds.Tables[0].Select("ID = " + i).First();
                MU += rows[2] + "\r\n";
            }
            }
            tbPreview.Text = MU;
        }
        private void AddTemplateType(string name)
        {
            string sqlExpression = "mod_InsertTemplateType";

            using (SqlConnection connection = new SqlConnection(conModule))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = name
                };
                command.Parameters.Add(nameParam);


                var result = command.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Формирует список ID работ, которые выполняются в рамках выбранной дисциплины.
        /// </summary>
        /// <returns>Список ID-ков работ</returns>
        private List<int> findWorks ()
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml("a.xml");
            for (int i=0; i<WorkTypes.Tables[0].Rows.Count;i++)
            {
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    int wtID = Convert.ToInt32(WorkTypes.Tables[0].Rows[i][0]);
                    int dtID = Convert.ToInt32(item[0]);
                    if ( wtID == dtID)
                    {
                        if (!Convert.ToBoolean(item[2]))
                        {
                            WorkTypes.Tables[0].Rows.Remove(WorkTypes.Tables[0].Rows[i]);
                        }
                        break;
                    }
                }
            }
            List<int> worksId = new List<int>();
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(conModule))
            {
                connection.Open();
                string sql = "SELECT * FROM modTemplateType";
                SqlDataAdapter a = new SqlDataAdapter(sql, connection);
                a.Fill(ds);
                ds.Tables[0].PrimaryKey = new DataColumn[] {ds.Tables[0].Columns[0] };
                for (int i=0; i<WorkTypes.Tables[0].Rows.Count; i++)
                {
                    string work = WorkTypes.Tables[0].Rows[i][1].ToString();
                    for (int j=0; j<ds.Tables[0].Rows.Count; j++)
                    {
                        string exWorks = ds.Tables[0].Rows[j][1].ToString();
                        int id = Convert.ToInt32(ds.Tables[0].Rows[j][0]);
                        if (exWorks == work)
                        {
                            worksId.Add(id);
                            
                            break;
                        }
                    }
                }

            }
            return worksId;
        }


        private void dgvMUStruct_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (((DataGridView)sender).IsCurrentCellDirty) ((DataGridView)sender).CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvMUStruct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (check)
            {
                if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                    int rindex = dgvMUStruct.CurrentCell.RowIndex;
                    DataGridViewComboBoxCell combo = (DataGridViewComboBoxCell)dgvMUStruct.Rows[rindex].Cells[1];
                    string sql = "SELECT * FROM modTemplates WHERE TypeID=" + dgvMUStruct.Rows[rindex].Cells[0].Value;
                    using (SqlConnection con = new SqlConnection(conModule))
                    {
                        SqlDataAdapter adap = new SqlDataAdapter(sql, con);
                        DataSet works = new DataSet();
                        adap.Fill(works);
                        combo.DataSource = works.Tables[0];
                        combo.DisplayMember = "Name";
                        combo.ValueMember = "ID";

                    }
                }
                if (e.ColumnIndex == 1 && e.RowIndex >= 0 /*&& dgvMUStruct.Rows[dgvMUStruct.CurrentCell.RowIndex].Cells[1].Value != null*/)
                {
                    int rindex = dgvMUStruct.CurrentCell.RowIndex;
                    string sql = "SELECT * FROM modTemplates"; /*WHERE ID=" + dgvMUStruct.Rows[rindex].Cells[1].Value;*/
                    using (SqlConnection con = new SqlConnection(conModule))
                    {
                        SqlDataAdapter adap = new SqlDataAdapter(sql, con);
                        DataSet works = new DataSet();
                        adap.Fill(works);
                        DataRow rows = works.Tables[0].Select("ID = " + dgvMUStruct.Rows[rindex].Cells[1].Value).First();
                        tbDescription.Text = rows[2].ToString();
                    }
                }
                if (e.RowIndex > -1)
                {
                    DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dgvMUStruct.Rows[e.RowIndex].Cells[0];
                    if (cb.Value != null)
                    {
                        dgvMUStruct.Invalidate();
                    }
                }
            }
        }


        private void dgvMUStruct_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox combo = e.Control as ComboBox;
            if (combo != null)
            {
                combo.SelectedIndexChanged -=
                    new EventHandler(ComboBox_SelectedIndexChanged);

                combo.SelectedIndexChanged +=
                    new EventHandler(ComboBox_SelectedIndexChanged);
            }
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rindex = dgvMUStruct.CurrentCell.RowIndex;
            DataGridViewComboBoxCell combo = (DataGridViewComboBoxCell)dgvMUStruct.Rows[rindex].Cells[1];
            string sql = "SELECT Description FROM modTemplates WHERE ID="+ dgvMUStruct.Rows[rindex].Cells[1].Value;
            using (SqlConnection con = new SqlConnection(conModule))
            {
                //SqlDataAdapter adap = new SqlDataAdapter(sql, con);
                //DataSet works = new DataSet();
                //adap.Fill(works);
                //textBox1.Text = works.Tables[0].Rows[]
                //    SqlCommand command = new SqlCommand(sql, con);
                //SqlDataReader reader = command.ExecuteReader();
                //object id = 0;
                //while (reader.Read())
                //{
                //    textBox1.Text = reader.GetValue(0).ToString();
                //}
                //reader.Close();
            }

        }

        private void dgvMUStruct_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            IntPtr MUHWnd = getMUWindow();
            if (MUHWnd.ToInt32() == 0)
            {
                MessageBox.Show("Поле методических указаний ПО \"РПД\" не найдено. Пожалуйста, откройте нужную рабочую программу в ПО \"РПД\" и вкладку методических указаний.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            WinAPI.SendMessage(MUHWnd, Convert.ToInt32(WinAPI.GetWindow_Cmd.WM_SETTEXT), 0, tbPreview.Text);

        }


        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;
        private void dgvMUStruct_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {

                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = dgvMUStruct.DoDragDrop(
                    dgvMUStruct.Rows[rowIndexFromMouseDown],
                    DragDropEffects.Move);
                }
            }
        }

        private void dgvMUStruct_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = dgvMUStruct.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                    dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void dgvMUStruct_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dgvMUStruct_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = dgvMUStruct.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop = dgvMUStruct.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
           
            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {
                DataGridViewRow rowToMove = e.Data.GetData(
                    typeof(DataGridViewRow)) as DataGridViewRow;
                if (rowIndexOfItemUnderMouseToDrop < 0)
                {
                    return;
                }
                if(rowIndexOfItemUnderMouseToDrop >= dgvMUStruct.Rows.Count-1)
                {
                    return;
                }
                dgvMUStruct.Rows.RemoveAt(rowIndexFromMouseDown);
                dgvMUStruct.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMUStruct.SelectedRows.Count == 1 && dgvMUStruct.CurrentRow.Index != dgvMUStruct.NewRowIndex)
            {
                int delet = dgvMUStruct.SelectedCells[0].RowIndex;
                dgvMUStruct.Rows.RemoveAt(delet);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите элемент для удаления!");
            }
        }


        private void менеджерШаблоновToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MUManager mUManager = new MUManager();
            mUManager.Show();
        }

        private void dgvMUStruct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvMUStruct.CurrentRow.Cells[1].Value);
            string sql = "SELECT Description FROM modTemplates WHERE modTemplates.ID = " + id;
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(conModule))
            {
                connection.Open();
                SqlDataAdapter a = new SqlDataAdapter(sql, connection);
                a.Fill(dataTable);
            }
            if (dataTable.Rows.Count > 0)
            tbDescription.Text = dataTable.Rows[0][0].ToString();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MUSettings mUSettings = new MUSettings();
            mUSettings.Show();
        }

        private void типыШаблоновToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TemplatesType tm = new TemplatesType();
            tm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            isClose = false;
            main.Visible = true;
            this.Close();
        }


        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = RPDModule.Properties.Resources.icons8_сортировать_справа_налево_30__1_;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = RPDModule.Properties.Resources.icons8_сортировать_справа_налево_30;
        }

        private void шаблоныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MUManager manager = new MUManager();
            manager.Show();
        }

        private void сброситьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите созданную структуру на значение по умолчанию?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                fillWorkTable();
            }
        }


        private void MUMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isClose)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите закрыть программу? Не сохраненные данные будут утеряны.", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = false;
                    main.Close();
                }
                else
                    e.Cancel = true;
            }
            
        }


        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DB.performQuery("DELETE FROM modStruct WHERE DisciplineID=" + DisciplineID);
            for (int i=0; i< dgvMUStruct.Rows.Count; i++)
            {
                if (dgvMUStruct.Rows[i].Cells[1].Value != null)
                {


                    string sqlExpression = "mod_InsertStruct";
                    using (SqlConnection connection = new SqlConnection(conModule))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter DisciplineID = new SqlParameter
                        {
                            ParameterName = "@DisciplineID",
                            Value = this.DisciplineID
                        };
                        SqlParameter TemplateID = new SqlParameter
                        {
                            ParameterName = "@TemplateID",
                            Value = dgvMUStruct.Rows[i].Cells[1].Value
                        };

                        command.Parameters.Add(DisciplineID);
                        command.Parameters.Add(TemplateID);
                        /*var result = */command.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Структура текста методических указаний для дисциплины \"" + discipline + "\" сохранена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "help.chm");

        }

        private void MUMain_KeyPress(object sender, KeyPressEventArgs e)
        {
       
        }

        private void ааToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        }
        private void getUser()
        {
            ааToolStripMenuItem.Text = User.firstname + " " + User.patronymic;
            ааToolStripMenuItem.Image = Properties.Resources.icons8_пользователь_30;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            dgvMUStruct.ClearSelection();
        }

    }
}
