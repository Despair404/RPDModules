using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace RPDModule
{
    public partial class FOSTablesEdit : MetroFramework.Forms.MetroForm
    {
        SqlConnection sql;
        System.Data.DataTable worksTables = new System.Data.DataTable();
        string conMod = ConfigurationManager.ConnectionStrings["ModuleConnection"].ConnectionString;
        SqlDataAdapter adapter;
        DataSet ds;
        bool check = false;
        public FOSTablesEdit()
        {
            InitializeComponent();
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
            check = true;
        }

        private void FOSTablesEdit_Load(object sender, EventArgs e)
        {
            getWorksTables();
        }

        private void cbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbTables_SelectedValueChanged(object sender, EventArgs e)
        {

            if (cbTables.SelectedValue != null && check)
            {
                SqlConnection sql = new SqlConnection(conMod);
                string data = "SELECT CellID As Код, Row As Строка, Col As Стобец, Text AS Текст, TableID As Таблица FROM WorksCells WHERE TableID=" + cbTables.SelectedValue;
                 adapter = new SqlDataAdapter(data, sql);
                ds = new DataSet();


                adapter.Fill(ds,"WorksCells");


                // int maxcol = (int) ds.Tables[0].Select("Col = MAX(Col)").First()[2];
                //int maxrow = (int)ds.Tables[0].Select("Row = MAX(Row)").First()[2];
                //for (int i=0; i<maxcol;i++)
                //{
                //    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();

                //    col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //    dataGridView1.Columns.Add(col);
                //}
                //for (int i=2; i<=maxrow; i++)
                //{
                //    DataRow[] row = ds.Tables[0].Select("Row = " + i);
                //    dataGridView1.Rows.Add();

                //}
                var bindingSource = new BindingSource(ds, "WorksCells");
                dataGridView1.DataSource = bindingSource;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;


            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder cmdbl = new SqlCommandBuilder(adapter);
            adapter.Update(ds, "WorksCells");
            MessageBox.Show("Изменения сохранены","Информация",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["Таблица"].Value = cbTables.SelectedValue;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1 && dataGridView1.CurrentRow.Index != dataGridView1.NewRowIndex)
            {
                int delet = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows.RemoveAt(delet);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите элемент для удаления!");
            }
        }
    }
}
