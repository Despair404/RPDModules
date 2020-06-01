﻿using System;
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
    public partial class dTemplates : Form
    {
        public dTemplates()
        {
            InitializeComponent();
        }
        private void btnAddTemplate_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.;Initial Catalog=RPDModule;Integrated Security=True";
            int id = Convert.ToInt32(metroComboBox1.SelectedValue);
            string sql = "INSERT INTO modTemplates (Name, Description, TypeID) VALUES (@name, @description, @typeId)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlParameter nameParam = new SqlParameter("@name", metroTextBox1.Text);
                command.Parameters.Add(nameParam);

                SqlParameter descriptionParam = new SqlParameter("@description", metroTextBox2.Text);
                command.Parameters.Add(descriptionParam);

                SqlParameter typeIdParam = new SqlParameter("@typeId", metroComboBox1.SelectedValue);
                command.Parameters.Add(typeIdParam);

                int num = command.ExecuteNonQuery();
                MessageBox.Show("Добавлено " + num + " записей.");

            }
        }

        private void dTemplates_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.;Initial Catalog=RPDModule;Integrated Security=True";
            string sql = "SELECT * FROM modTemplateType";
            using (SqlConnection connection = new SqlConnection(connectionString))
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
