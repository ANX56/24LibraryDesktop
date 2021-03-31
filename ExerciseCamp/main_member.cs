using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExerciseCamp
{
    public partial class main_member : Form
    {
        public main_member()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void main_member_Load(object sender, EventArgs e)
        {
            string d = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            string t = DateTime.Now.ToString("t");
            lblDate.Text = d.ToString();
            lblTime.Text = t.ToString();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index i = new index();
            i.Show();
            this.Hide();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            change_password i = new change_password();
            i.Show();
            this.Hide();
        }
    }
}
