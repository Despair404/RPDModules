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

namespace WindowsFormsApp2
{
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        public Form3()
        {
            InitializeComponent();

        }
        IntPtr RPDHWnd;
        string discipline;
        string plan;
        List<IntPtr> titleChildren = new List<IntPtr>();
        string conRPD = ConfigurationManager.ConnectionStrings["RPDConnection"].ConnectionString;
        string conModule = ConfigurationManager.ConnectionStrings["ModuleConnection"].ConnectionString;
        DataSet WorkTypes = new DataSet();

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                RPDHWnd = getRPDHWnd();
                if (RPDHWnd.ToInt32() == 0)
                    throw new Exception("Редактируемая рабочая программа не найдена. Пожалуйста, запустите ПО РПД и откройте рабочую программу, методические указания которой нужно редактировать.");
                if (RPDHWnd.ToInt32() != 0)
                {
                    IntPtr titleHWnd = getTitle();
                    getTitleChildren(titleHWnd);
                    discipline = getDisciplineName();
                    plan = getPlaneName();
                    lbPlan.Text = plan;
                    lbDiscipline.Text = discipline;



                    SqlConnection connection = new SqlConnection(conRPD);
                    try
                    {
                        connection.Open();
                        string sql = "SELECT Код FROM Планы WHERE ИмяФайла='" + plan + "'";




                        SqlCommand command = new SqlCommand(sql, connection);
                        SqlDataReader reader = command.ExecuteReader();
                        object id = 0;
                        while (reader.Read())
                        {
                            id = reader.GetValue(0);
                        }
                        reader.Close();
                        sql = "SELECT * FROM ПланыСтроки WHERE Дисциплина='" + discipline + "' AND КодПлана=" + id;
                        command = new SqlCommand(sql, connection);
                        reader = command.ExecuteReader();
                        object idD = 0;
                        while (reader.Read())
                        {
                            idD = reader.GetValue(0);
                        }

                        sql = "SELECT * FROM СправочникВидыРабот WHERE Код= ANY(SELECT DISTINCT КодВидаРаботы FROM ПланыНовыеЧасы where КодОбъекта=" + idD + ")";
                        reader.Close();

                        SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                        adapter.Fill(WorkTypes);

                        sql = "SELECT * FROM modTemplateType ORDER BY Name";
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

                        //sql = "SELECT * FROM modTemplates";
                        //using (SqlConnection con = new SqlConnection(conModule))
                        //{
                        //    SqlDataAdapter adap = new SqlDataAdapter(sql, con);
                        //    DataSet works = new DataSet();
                        //    adap.Fill(works);
                        //    colName.DataSource = works.Tables[0];
                        //    colName.DisplayMember = "Name";
                        //    colName.ValueMember = "ID";
                        //    colName.DataPropertyName = "ID";

                        //}

                        List<int> worksid = findWorks();
                        foreach (var i in worksid)
                        {
                            dgvMUStruct.Rows.Add();
                        }
                        for (int i = 0; i < worksid.Count; i++)
                        {
                            dgvMUStruct.Rows[i].Cells[0].Value = worksid[i];
                            //using (SqlConnection con = new SqlConnection(conModule))
                            //{
                            //    sql = "SELECT * from modTempleates WHERE TypeID = " + worksid[i];
                            //    SqlDataAdapter adap = new SqlDataAdapter(sql, con);
                            //    DataSet works = new DataSet();
                            //    adap.Fill(works);
                                //dgvMUStruct.Rows[i].Cells[0].
                                //colName.DataSource = works.Tables[0];
                                //colName.DisplayMember = "Name";
                                //colName.ValueMember = "ID";
                                //colName.DataPropertyName = "ID";

                            //}

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
        
        private string getDisciplineName()
        {
            return WinAPI.GetControlText(titleChildren[2]);
        }
        private string getPlaneName()
        {
            return WinAPI.GetControlText(titleChildren[11]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MUManager mu = new MUManager();
            //mu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
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
            textBox2.Text = MU;
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

        private List<int> findWorks ()
        {
            List<int> worksId = new List<int>();
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(conModule))
            {
                connection.Open();
                string sql = "SELECT * FROM modTemplateType";
                SqlDataAdapter a = new SqlDataAdapter(sql, connection);
                a.Fill(ds);
                ds.Tables[0].PrimaryKey = new DataColumn[] {ds.Tables[0].Columns[0] };
                string ab = WorkTypes.Tables[0].Rows[0][1].ToString();
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
            if (e.ColumnIndex == 0 && e.RowIndex >=0)
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
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                int rindex = dgvMUStruct.CurrentCell.RowIndex;
                string sql = "SELECT * FROM modTemplates"; /*WHERE ID=" + dgvMUStruct.Rows[rindex].Cells[1].Value;*/
                using (SqlConnection con = new SqlConnection(conModule))
                {
                    SqlDataAdapter adap = new SqlDataAdapter(sql, con);
                    DataSet works = new DataSet();
                    adap.Fill(works);
                    DataRow rows = works.Tables[0].Select("ID = " + dgvMUStruct.Rows[rindex].Cells[1].Value).First();
                    textBox1.Text = rows[2].ToString();
                }
            }
            if (e.RowIndex >-1)
            {
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dgvMUStruct.Rows[e.RowIndex].Cells[0];
                if (cb.Value != null)
                {
                    dgvMUStruct.Invalidate();
                }
            }
        }

        private void добавлениеШаблонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dTemplates dTemplates = new dTemplates();
            dTemplates.Show();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            IntPtr MUHWnd = getMUWindow();
            //string a = WinAPI.GetControlText(child);
            WinAPI.SendMessage(MUHWnd, Convert.ToInt32(WinAPI.GetWindow_Cmd.WM_SETTEXT), 0, textBox2.Text);

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
            if (dgvMUStruct.SelectedRows.Count == 1)
            {
                int delet = dgvMUStruct.SelectedCells[0].RowIndex;
                dgvMUStruct.Rows.RemoveAt(delet);
            }
        }
    }
}
