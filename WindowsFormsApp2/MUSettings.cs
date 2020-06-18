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
using System.Xml;
using System.Drawing.Drawing2D;

namespace RPDModule
{
    public partial class MUSettings : MetroFramework.Forms.MetroForm
    {
        public MUSettings()
        {
            InitializeComponent();
            fillListBox();
        }
        string conRPD = ConfigurationManager.ConnectionStrings["RPDConnection"].ConnectionString;
        private void updateList ()
        {
            string sql = "SELECT * FROM СправочникВидыРабот";
            DataTable dt = new DataTable();
            dt.TableName = "works";
            DataColumn id = new DataColumn();
            id.DataType = System.Type.GetType("System.Int32");
            id.ColumnName = "id";
            dt.Columns.Add(id);

            DataColumn Work = new DataColumn();
            Work.DataType = System.Type.GetType("System.String");
            Work.ColumnName = "Work";
            dt.Columns.Add(Work);

            DataColumn Value = new DataColumn();
            Value.DataType = System.Type.GetType("System.String");
            Value.ColumnName = "Value";
            dt.Columns.Add(Value);

            using (SqlConnection connection = new SqlConnection(conRPD))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DataRow row = dt.NewRow();
                    row["id"] = reader.GetValue(0);
                    row["Work"] = reader.GetValue(1);
                    row["Value"] = true;
                    dt.Rows.Add(row);
                }
                reader.Close();


            }
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            ds.WriteXml("a.xml");
        }
        //private void readDataSet ()
        //{
            
        //    DataTable dt = ds.Tables[0];
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        checkedListBox1.Items.Add(row[1], Convert.ToBoolean(row[2]));
        //    }
        //}
        private void fillListBox()
        {
            //string path = @"a.xml";
            //XmlDocument XmlDoc = new XmlDocument();
            //XmlDoc = Properties.Settings.Default.xml;
            //XmlDoc.Save(path);

            checkedListBox1.Items.Clear();
            DataSet ds = new DataSet();
            ds.ReadXml("a.xml");
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                checkedListBox1.Items.Add(dt.Rows[i][1], Convert.ToBoolean(dt.Rows[i][2]));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml("a.xml");
            for (int i = 0; i< ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i][2] = checkedListBox1.GetItemCheckState(i) == CheckState.Checked ? true : false;
            }
            ds.WriteXml("a.xml");
            MessageBox.Show("Параметры успешно сохранены!", "Успех", MessageBoxButtons.OK);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите обновить список работ? Текущие настройки будут сброшены.", "Внимание!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                updateList();
                fillListBox();
            }
        }
            
    }
}
