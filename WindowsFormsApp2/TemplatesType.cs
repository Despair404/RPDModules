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
        DataSet dt;
        SqlDataAdapter adapter;

        private void getTypes ()
        {
            dt = new DataSet();
            SqlConnection connection = new SqlConnection(conModule);
            try
            {
                string sql = "SELECT * FROM modTemplateType ORDER BY Name";
                
                adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(dt, "modTemplateType");

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            var bindingSource = new BindingSource(dt, "modTemplateType");
            dgvTemplateTypes.DataSource = bindingSource;
            dgvTemplateTypes.Columns[0].Visible = false;
            dgvTemplateTypes.Columns[1].HeaderText = "Название";
            dgvTemplateTypes.Columns[1].Width = 303;
            dgvTemplateTypes.Columns[2].Visible = false;
            dgvTemplateTypes.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

        }

        private void dgvTemplateTypes_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dgvTemplateTypes.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(dgvTemplateTypes.Rows[i].Cells[2].Value) == true)
                {
                    dgvTemplateTypes.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }

        private void dgvTemplateTypes_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[2].Value = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder cmdbl = new SqlCommandBuilder(adapter);
            adapter.Update(dt, "modTemplateType");
            MessageBox.Show("Изменения успешно сохранены!","Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (dgvTemplateTypes.SelectedRows.Count == 1 && dgvTemplateTypes.CurrentRow.Index != dgvTemplateTypes.NewRowIndex)
            {
                if (Convert.ToBoolean(dgvTemplateTypes.CurrentRow.Cells[2].Value))
                {
                    MessageBox.Show("Этот тип шаблона нельзя удалить, так как он входит в структуру по умолчанию.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int delet = dgvTemplateTypes.CurrentRow.Index;
                    dgvTemplateTypes.Rows.RemoveAt(delet);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите элемент для удаления!");
            }
        }
    }
}
