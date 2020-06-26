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
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }
        string conModule = ConfigurationManager.ConnectionStrings["ModuleConnection"].ConnectionString;
        //string id, login, lastname, firstname, patronymic;
        private void metroButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conModule);
            try
            {
                if (txtLogin.Text != "" && txtPassword.Text != "")
                {

                    con.Open();
                    string query = "select * from modUsers WHERE Login ='" + txtLogin.Text + "' AND Password ='" + User.getHash(txtPassword.Text) + "'";

                    SqlCommand command = new SqlCommand(query, con);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            User.ID = Convert.ToInt32(reader["ID"]);
                            User.login = reader["Login"].ToString();
                            User.lastname = reader["LastName"].ToString();
                            User.firstname = reader["FirstName"].ToString();
                            User.patronymic = reader["Patronymic"].ToString();
                            User.add = Convert.ToBoolean(reader["addTemplate"]);
                            User.delete = Convert.ToBoolean(reader["deleteTemplate"]);
                            User.edit = Convert.ToBoolean(reader["editTemplate"]);
                        }
                        MessageBox.Show("Добро пожаловать, " + User.firstname + " " + User.patronymic+"!");
                        
                        reader.Close();
                        User.UserEventHandler();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("пользователь с такими данными не найден. Пожалуйста, проверьте правильность ввода логина и пароля.", "Неудачная попытка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                    
                   
                else
                {
                    if (txtLogin.Text == "")
                    {
                        MessageBox.Show("Пожалуйста, введите логин!");
                        txtLogin.Focus();
                    }
                    if (txtPassword.Text == "")
                    {
                        MessageBox.Show("Пожалуйста, введите пароль!");
                        txtPassword.Focus();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка соедниения с БД.", "Внимание!");
            }
        }

    }
}
