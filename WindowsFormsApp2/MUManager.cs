﻿using System;
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
    public partial class MUManager : MetroFramework.Forms.MetroForm
    {
        public MUManager()
        {
            InitializeComponent();
            if (!User.add)
            {
                btnAddTemplate.Enabled = false;
            }
            if (!User.delete)
            {
                btnDelete.Enabled = false;
            }
            if (!User.edit)
            {
                btnSave.Enabled = false;
            }
        }
        string conModule = ConfigurationManager.ConnectionStrings["ModuleConnection"].ConnectionString;
        
        private void MUManager_Load(object sender, EventArgs e)
        {
            fillTable();
            string sql = "SELECT * FROM modTemplateType ORDER BY Name";
            using (SqlConnection con = new SqlConnection(conModule))
            {
                SqlDataAdapter adap = new SqlDataAdapter(sql, con);
                DataSet works = new DataSet();
                adap.Fill(works);
                cbType.DataSource = works.Tables[0];
                cbType.DisplayMember = "Name";
                cbType.ValueMember = "ID";

            }

        }
        private void fillTable ()
        {
            string sql = "SELECT modTemplates.ID AS ID, modTemplateType.Name AS Тип, modTemplates.Name AS Название FROM modTemplateType INNER JOIN modTemplates ON modTemplateType.ID = modTemplates.TypeID";
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(conModule))
            {
                connection.Open();
                SqlDataAdapter a = new SqlDataAdapter(sql, connection);
                
                a.Fill(dt);
            }
       
            dgvTemplates.DataSource = dt;
            dgvTemplates.Columns[0].Visible = false;
            dgvTemplates.Columns[1].ReadOnly = true;
            dgvTemplates.Columns[2].ReadOnly = true;
            dgvTemplates.Columns[1].Width = 230;
            dgvTemplates.Columns[2].Width = 230;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            (dgvTemplates.DataSource as DataTable).DefaultView.RowFilter = String.Format("Тип LIKE '%" + textBox3.Text + "%'");
        }


        private void dgvTemplates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvTemplates.CurrentRow.Cells[0].Value);
            string sql = "SELECT * FROM  modTemplateType INNER JOIN modTemplates ON modTemplateType.ID = modTemplates.TypeID WHERE modTemplates.ID = " + id;
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(conModule))
            {
                connection.Open();
                SqlDataAdapter a = new SqlDataAdapter(sql, connection);
                a.Fill(dataTable);
            }
            tbName.Text = dataTable.Rows[0][4].ToString();
            tbDescription.Text = dataTable.Rows[0][5].ToString();
            cbType.SelectedValue = dataTable.Rows[0][0];
        }

        private void tbSearchName_TextChanged(object sender, EventArgs e)
        {
            (dgvTemplates.DataSource as DataTable).DefaultView.RowFilter = String.Format("Название LIKE '%" + tbSearchName.Text + "%'");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sqlExpression = "mod_UpdateTemplate";
            using (SqlConnection connection = new SqlConnection(conModule))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = tbName.Text
                };
                SqlParameter descriptionParam = new SqlParameter
                {
                    ParameterName = "@description",
                    Value = tbDescription.Text
                };
                SqlParameter typeIDParam = new SqlParameter
                {
                    ParameterName = "@typeID",
                    Value = cbType.SelectedValue
                };
                SqlParameter IDParam = new SqlParameter
                {
                    ParameterName = "@ID",
                    Value = dgvTemplates.CurrentRow.Cells[0].Value
                };
                command.Parameters.Add(nameParam);
                command.Parameters.Add(descriptionParam);
                command.Parameters.Add(typeIDParam);
                command.Parameters.Add(IDParam);
                var result = command.ExecuteNonQuery();
                MessageBox.Show("Шаблон изменен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillTable();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Вы уверены, что хотите удалить шаблон?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                string sqlExpression = "mod_DeleteTemplate";
                using (SqlConnection connection = new SqlConnection(conModule))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter idParam = new SqlParameter
                    {
                        ParameterName = "@id",
                        Value = dgvTemplates.CurrentRow.Cells[0].Value
                    };

                    command.Parameters.Add(idParam);
                    var result = command.ExecuteNonQuery();
                    MessageBox.Show("Шаблон удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillTable();
                }

               
            }
        }

        private void AddTemplate_Click(object sender, EventArgs e)
        {
            MUTemplates manager = new MUTemplates();
            manager.Show();
        }
    }
}
