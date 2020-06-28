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
    public partial class Profile : MetroFramework.Forms.MetroForm
    {
        public Profile()
        {
            InitializeComponent();
            txtFirstName.Text = User.firstname;
            txtLastName.Text = User.lastname;
            txtPatronymic.Text = User.patronymic;
            lbLogin.Text = User.login;

        }
        string conModule = ConfigurationManager.ConnectionStrings["ModuleConnection"].ConnectionString;

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sqlExpression = "mod_UpdateUserFIO";
            using (SqlConnection connection = new SqlConnection(conModule))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter id = new SqlParameter
                {
                    ParameterName = "@ID",
                    Value = User.ID
                };
                SqlParameter lastname = new SqlParameter
                {
                    ParameterName = "@lastname",
                    Value = txtLastName.Text
                };
                SqlParameter firstname = new SqlParameter
                {
                    ParameterName = "@firstname",
                    Value = txtFirstName.Text
                };
                SqlParameter patronymic = new SqlParameter
                {
                    ParameterName = "@patronymic",
                    Value = txtPatronymic.Text
                };
                command.Parameters.Add(id);
                command.Parameters.Add(lastname);
                command.Parameters.Add(firstname);
                command.Parameters.Add(patronymic);
                var result = command.ExecuteNonQuery();
                MessageBox.Show("Изменения сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                User.lastname = txtLastName.Text;
                User.firstname = txtFirstName.Text;
                User.patronymic = txtPatronymic.Text;

                User.UserEventHandler();
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text == "")
            {
                MessageBox.Show("Пожалуйста, введите старый пароль!");
                return;
            }
            if (txtNewPassword.Text == "")
            {
                MessageBox.Show("Пожалуйста, введите новый пароль!");
                return;
            }
            if (txtNewPasswordConfirm.Text == "")
            {
                MessageBox.Show("Пожалуйста, введите подтверждение нового пароля!");
                return;
            }
            if (txtNewPassword.Text != txtNewPasswordConfirm.Text)
            {
                MessageBox.Show("Новый пароль и его подтверждение не совпадают. ");
                return;
            }
            if (User.getHash(txtOldPassword.Text) != User.password)
            {
                MessageBox.Show("Введен неверный старый пароль.");
                return;
            }
            else
            {
                User.password = txtNewPassword.Text;

                string sqlExpression = "mod_UpdateUserPassword";
                using (SqlConnection connection = new SqlConnection(conModule))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter id = new SqlParameter
                    {
                        ParameterName = "@ID",
                        Value = User.ID
                    };
                    SqlParameter password = new SqlParameter
                    {
                        ParameterName = "@password",
                        Value = User.getHash(txtNewPassword.Text)
                    };
                    command.Parameters.Add(id);
                    command.Parameters.Add(password);
                    var result = command.ExecuteNonQuery();
                    MessageBox.Show("Пароль успешно изменен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            User.refreshUser();
            User.UserEventHandler();
            this.Close();
        }
    }
}
