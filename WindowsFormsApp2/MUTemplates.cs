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

namespace RPDModule
{
    public partial class MUTemplates : MetroFramework.Forms.MetroForm
    {
        public MUTemplates()
        {
            InitializeComponent();
         

        }
        string conModule = ConfigurationManager.ConnectionStrings["ModuleConnection"].ConnectionString;
        private void btnAddTemplate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(metroComboBox1.SelectedValue);
            if (tbName.Text == "")
            {
                MessageBox.Show("Пожалуйста, введите название шаблона!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tbDescription.Text == "")
            {
                MessageBox.Show("Пожалуйста, введите текст шаблона!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbDescription.Focus();
                return;
            }
            string sql = "INSERT INTO modTemplates (Name, Description, TypeID) VALUES (@name, @description, @typeId)";
            using (SqlConnection connection = new SqlConnection(conModule))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlParameter nameParam = new SqlParameter("@name", tbName.Text);
                command.Parameters.Add(nameParam);

                SqlParameter descriptionParam = new SqlParameter("@description", tbDescription.Text);
                command.Parameters.Add(descriptionParam);

                SqlParameter typeIdParam = new SqlParameter("@typeId", metroComboBox1.SelectedValue);
                command.Parameters.Add(typeIdParam);

                int num = command.ExecuteNonQuery();
                MessageBox.Show("Шаблон добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            tbDescription.Text = "";
            tbName.Text = "";
        }

        private void dTemplates_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM modTemplateType ORDER BY Name";
            using (SqlConnection connection = new SqlConnection(conModule))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                metroComboBox1.DataSource = ds.Tables[0];
                metroComboBox1.DisplayMember = "Name";
                metroComboBox1.ValueMember = "ID";
            }
        }
    }
}
