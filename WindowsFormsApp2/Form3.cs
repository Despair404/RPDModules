using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;
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

namespace WindowsFormsApp2
{
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        public Form3()
        {
            InitializeComponent();
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

 




        private void фОСToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }

        private void мУToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }

        private void справочникиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void шаблоныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dTemplates templates = new dTemplates();
            templates.Show();
        }
    }
}
