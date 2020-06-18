using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;

namespace RPDModule
{
    public partial class TemplatesType : MetroFramework.Forms.MetroForm
    {
        public TemplatesType()
        {
            InitializeComponent();
            getTypes();
        }
        string conModule = ConfigurationManager.ConnectionStrings["ModuleConnection"].ConnectionString;

        private void getTypes ()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(conModule);
            try
            {
                connection.Open();

                string sql = "SELECT * FROM modTemplateType ORDER BY Name";
                
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(dt);

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            
            dgvTemplateTypes.DataSource = dt;
            dgvTemplateTypes.Columns[0].Visible = true;
        }

    }
}
