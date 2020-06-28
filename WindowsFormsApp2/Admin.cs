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
    public partial class Admin : MetroFramework.Forms.MetroForm
    {
        public Admin()
        {
            InitializeComponent();
            string sql = "SELECT ID AS ID, Login AS Логин, LastName As Фамилия, FirstName AS Имя, Patronymic AS Отчество, isAdmin AS Админ, addTemplate AS ДобШабл, deleteTemplate AS УдалШабл, editTemplate AS РедШабл, Password AS Пароль, editFOS AS РедФОС, editQuestions AS РедВопросов FROM modUsers ORDER BY Lastname";
            SqlConnection connection = new SqlConnection(conModule);
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                ds = new DataSet();
                adapter.Fill(ds, "modUsers");
                //dgvUsers.DataSource = ds.Tables[0];
                var bindingSource = new BindingSource(ds, "modUsers");
                dgvUsers.DataSource = bindingSource;
                dgvUsers.Columns["ID"].Visible = false;

            dgvUsers.Columns["Пароль"].Visible = false;
            dgvUsers.Columns["ДобШабл"].Width = 60;
            dgvUsers.Columns["УдалШабл"].Width = 65;
            dgvUsers.Columns["РедШабл"].Width = 60;

            dgvUsers.Columns["Админ"].Width = 60;
            dgvUsers.Columns["РедФОС"].Width = 60;
            dgvUsers.Columns["РедВопросов"].Width = 80;

        }
        DataSet ds;
        SqlDataAdapter adapter;
        string conModule = ConfigurationManager.ConnectionStrings["ModuleConnection"].ConnectionString;


       

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {


                int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["ID"].Value);
                string sql = "UPDATE modUsers SET Password = '" + User.getHash(txtNewPassword.Text) + "' WHERE ID=" + id;
                using (SqlConnection connection = new SqlConnection(conModule))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Пароль пользователя " + dgvUsers.CurrentRow.Cells["Логин"].Value + " успешно изменен.");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder cmdbl = new SqlCommandBuilder(adapter);
            adapter.Update(ds, "modUsers");
            MessageBox.Show("Изменения успешно сохранены!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 1 && dgvUsers.CurrentRow.Index != dgvUsers.NewRowIndex)
            {
                
                    int delet = dgvUsers.CurrentRow.Index;
                dgvUsers.Rows.RemoveAt(delet);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите элемент для удаления!");
            }
        }

        private void dgvUsers_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["Пароль"].Value = User.getHash("12345");
            e.Row.Cells["ДобШабл"].Value = false;
            e.Row.Cells["УдалШабл"].Value = false;
            e.Row.Cells["РедШабл"].Value = false;

        }
    }
}
