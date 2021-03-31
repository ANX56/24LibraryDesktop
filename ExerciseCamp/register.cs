using MySql.Data.MySqlClient;
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
    public partial class register : Form
    {
        connection con = new connection();

        public register()
        {
            InitializeComponent();
        }

        string genid()
        {
            con.Open();
            string id = "";
            string sql = "SELECT UserID from user WHERE UserID LIKE 'UM%' order by UserID desc LIMIT 1";
            DataSet ds = con.ExecuteDataSet(sql);
            string newId = ds.Tables[0].Rows[0]["UserID"].ToString().Substring(2, 3);
            int tambah = Convert.ToInt32(newId) + 1;
            if(tambah.ToString().Length == 1)
            {
                id = "UM00" + tambah.ToString();
            }
            else if (tambah.ToString().Length == 2)
            {
                id = "UM0" + tambah.ToString();
            }
            else if (tambah.ToString().Length == 3)
            {
                id = "UM" + tambah.ToString();
            }
            return id;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtName.Text == "" || txtEmail.Text == "" || txtPassword.Text == "" || txtPhone.Text == "" || txtAddress.Text == "")
                {
                    MessageBox.Show("All Field must be Filled", "information");
                }
                else
                {
                    con.Open();
                    string id = genid();
                    string gender;
                    if (rdbMale.Checked)
                    {
                        gender = "Male";
                    }
                    else 
                    {
                        gender = "Female";
                    }
                    string q = "INSERT INTO user VALUES ('"+id+"','"+txtEmail.Text+"','"+txtPassword.Text + "','" + txtName.Text + "','"+gender+"','"+txtPhone.Text + "','"+txtAddress.Text + "','Member')";
                    con.ExecuteReader(q);
                    MessageBox.Show("Register Successful");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured : " + ex.Message);
            }
        }
    }
}
