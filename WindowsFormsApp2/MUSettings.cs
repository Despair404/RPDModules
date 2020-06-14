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


        private void fillListBox ()
        {
            string sql = "SELECT * FROM СправочникВидыРабот";
            DataTable dt = new DataTable();
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
                    RPDModule.Properties.Settings.Default.Works.Rows.Add(row);
                }
                reader.Close();
                for(int i=0;i<dt.Rows.Count; i++)
                {
                    checkedListBox1.Items.Add(dt.Rows[i][1], Convert.ToBoolean(dt.Rows[i][2]));
                }
                //SqlDataAdapter a = new SqlDataAdapter(sql, connection);
                //a.Fill(ds);
            }
        }
           
    }
}
