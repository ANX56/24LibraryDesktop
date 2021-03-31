using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExerciseCamp
{
    public partial class index : Form
    {
        connection con = new connection();
        string id, email, password, role;

        public static bool IsValidEmail(string InputEmail)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(InputEmail);
            if (match.Success)
                return true;
            else
                return false;
        }

        public index()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text == "" && txtPassword.Text == "")
                {
                    MessageBox.Show("Email and Password must be filled", "Information");
                }
                else if (txtEmail.Text == "")
                {
                    MessageBox.Show("Email must be filled", "Information");
                }
                else if (txtPassword.Text == "")
                {
                    MessageBox.Show("Password must be filled", "Information");
                }
                else
                {
                    if (IsValidEmail(txtEmail.Text) != true)
                    {
                        MessageBox.Show("Email Format Incorrect", "Information");
                    }
                    else
                    {
                        con.Open();
                        string query = "SELECT UserID, Email, Password, Name, Gender, Phone, Address, Role FROM user WHERE Email='" + txtEmail.Text + "' AND Password ='" + txtPassword.Text + "'";
                        MySqlDataReader row = con.ExecuteReader(query);
                        if (row.Read())
                        {
                            if (row.HasRows)
                            {
                                id = row["UserID"].ToString();
                                email = row["Email"].ToString();
                                password = row["Password"].ToString();
                                role = row["Role"].ToString();
                                session.UserID = id;
                                session.Email = email;
                                session.Password = password;
                                session.Role = role;
                                if (role == "Admin")
                                {
                                    MessageBox.Show("Login Success !");
                                    main_admin a = new main_admin();
                                    a.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Login Success !");
                                    main_member a = new main_member();
                                    a.Show();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Data not found", "Information");
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Occured : " + ex.Message, "Information");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            register a = new register();
            a.Show();
            this.Hide();
        }
    }
}
