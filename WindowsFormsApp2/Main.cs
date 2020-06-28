using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPDModule
{
    public partial class Main : MetroFramework.Forms.MetroForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnMU_Click(object sender, EventArgs e)
        {
            MUMain mu = new MUMain(this);
            mu.Show();
            this.Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnFOS_Click(object sender, EventArgs e)
        {
            FOS fos = new FOS(this);
            fos.Show();
            this.Hide();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
           Admin admin = new Admin();
            admin.Show();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            Login login = new Login(true);
            login.Show();
        }
    }
}
