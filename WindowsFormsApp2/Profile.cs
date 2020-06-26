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

namespace RPDModule
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }
        string conModule = ConfigurationManager.ConnectionStrings["ModuleConnection"].ConnectionString;


        private void metroButton1_Click(object sender, EventArgs e)
        {
            string sqlExpression = "mod_InsertUser";
            using (SqlConnection connection = new SqlConnection(conModule))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter login = new SqlParameter
                {
                    ParameterName = "@login",
                    Value = textBox1.Text
                };
                SqlParameter password = new SqlParameter
                {
                    ParameterName = "@password",
                    Value = User.getHash(textBox2.Text)
                };
                SqlParameter lastname = new SqlParameter
                {
                    ParameterName = "@lastname",
                    Value = textBox3.Text
                };
                SqlParameter firstname = new SqlParameter
                {
                    ParameterName = "@firstname",
                    Value = textBox4.Text
                };
                SqlParameter patronymic = new SqlParameter
                {
                    ParameterName = "@patronymic",
                    Value = textBox5.Text
                };
                command.Parameters.Add(login);
                command.Parameters.Add(password);
                command.Parameters.Add(lastname);
                command.Parameters.Add(firstname);
                command.Parameters.Add(patronymic);
                var result = command.ExecuteNonQuery();
                MessageBox.Show("добавлено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
