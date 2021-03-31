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
    public partial class change_password : Form
    {
        connection con = new connection();

        public change_password()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string q = "SELECT Password FROM user WHERE Email = '" + session.Email + "'";
                DataSet ds = con.ExecuteDataSet(q);
                string pass = ds.Tables[0].Rows[0]["Password"].ToString();
                if(txtOld.Text != pass)
                {
                    MessageBox.Show("The old password you have entered is incorrect", "information");
                }
                else if(txtNew.Text != txtConfirm.Text)
                {
                    MessageBox.Show("Confirm password must be same with new password", "information");
                }
                else
                {
                    string qu = "UPDATE user SET Password = '" + txtNew.Text + "' WHERE Email = '" + session.Email + "'";
                    con.ExecuteReader(qu);
                    MessageBox.Show("Password changed", "information");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured : " + ex.Message);
            }
        }
    }
}
