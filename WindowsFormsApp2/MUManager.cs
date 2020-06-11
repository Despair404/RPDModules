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

namespace WindowsFormsApp2
{
    public partial class MUManager : MetroFramework.Forms.MetroForm
    {
        public MUManager()
        {
            InitializeComponent();
        }

        private void MUManager_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.;Initial Catalog=plany;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                string sql = "SELECT * FROM СправочникВидыРабот";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                for (int i=0; i<ds.Tables[0].Rows.Count; i++)
                {
                   
                    checkedListBox1.Items.Add(ds.Tables[0].Rows[i][1]);
                    checkedListBox1.SetItemChecked(i , true);
                }


                //SqlCommand command = new SqlCommand(sql, connection);
                //SqlDataReader reader = command.ExecuteReader();
                //object id = 0;
                //while (reader.Read())
                //{
                //    id = reader.GetValue(0);
                //}
                //reader.Close();
                //sql = "SELECT * FROM ПланыСтроки WHERE Дисциплина='" + discipline + "' AND КодПлана=" + id;
                //command = new SqlCommand(sql, connection);
                //reader = command.ExecuteReader();
                //object idD = 0;
                //while (reader.Read())
                //{
                //    idD = reader.GetValue(0);
                //}

                //sql = "SELECT * FROM СправочникВидыРабот WHERE Код= ANY(SELECT DISTINCT КодВидаРаботы FROM ПланыНовыеЧасы where КодОбъекта=" + idD + ")";
                //reader.Close();

                //SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                //DataSet ds = new DataSet();
                //adapter.Fill(ds);
                //colType.DataSource = ds.Tables[0];
                //colType.DisplayMember = "Название";
                //colType.ValueMember = "Код";


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
}
