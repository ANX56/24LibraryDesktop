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
    public partial class master_book : Form
    {
        connection con = new connection();
        string stats = "insert";

        public master_book()
        {
            InitializeComponent();
        }

        string genid(string second, string third)
        {
            con.Open();
            string id = "";
            string sql = "SELECT BookID from book WHERE BookID LIKE 'BK-"+second+"-"+third+"-%' order by BookID desc LIMIT 1";
            DataSet ds = con.ExecuteDataSet(sql);
            string newId = ds.Tables[0].Rows[0].ToString().Substring(11, 2);
            int tambah = Convert.ToInt32(newId) + 1;
            if (tambah.ToString().Length == 1)
            {
                id = "BK" + second + "-" + third + "-0" + tambah.ToString();
            }
            else if (tambah.ToString().Length == 2)
            {
                id = "BK" + second + "-" + third + "-" + tambah.ToString();
            }
            return id;
        }

        private void enable()
        {
            txtName.Enabled = true;
            txtAuthor.Enabled = true;
            txtPublishedDate.Enabled = true;
            txtLocation.Enabled = true;
            txtPhoto.Enabled = true;
            txtQty.Enabled = true;
            cmbCategory.Enabled = true;
            btnPhoto.Enabled = true;
        }
        
        private void disable()
        {
            txtName.Enabled = false;
            txtAuthor.Enabled = false;
            txtPublishedDate.Enabled = false;
            txtLocation.Enabled = false;
            txtPhoto.Enabled = false;
            txtQty.Enabled = false;
            cmbCategory.Enabled = false;
            btnPhoto.Enabled = false;
        }

        private void proceed()
        {
            try
            {
                if (txtName.Text == "" || txtAuthor.Text == "" || txtPublishedDate.Text == "" || txtPhoto.Text == "" || txtQty.Text == "" || txtLocation.Text == "")
                {
                    MessageBox.Show("All Field must be Filled", "information");
                }
                else
                {
                    con.Open();
                    string s1= txtAuthor.Text.Substring(0, 1);
                    string s2 = txtAuthor.Text.Substring(txtAuthor.Text.Length - 1);
                    string second = (s1 + s2).ToUpper();
                    string third = txtPublishedDate.Value.ToString("yyyy");
                    string id = genid(second, third);
                    string q = "";
                    if (stats == "insert")
                    {
                        q = "INSERT INTO book VALUES ('" + id + "','" + txtName.Text + "','" + txtAuthor.Text + "','" + txtPublishedDate.Text + "','" + cmbCategory.Text + "','" + txtQty.Text + "','" + txtLocation.Text + "','" + txtPhoto.Text + "')";
                    }
                    else if(stats == "update")
                    {
                        q = "INSERT INTO book VALUES ('" + id + "','" + txtName.Text + "','" + txtAuthor.Text + "','" + txtPublishedDate.Text + "','" + cmbCategory.Text + "','" + txtQty.Text + "','" + txtLocation.Text + "','" + txtPhoto.Text + "')";
                    }
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

        private void load()
        {
            try
            {
                string sql = "SELECT BookID, Name, Category, Author, Qty FROM book";
                dataGridView1.DataSource = con.ExecuteDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured : " + ex.Message);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            enable();
            stats = "insert";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            proceed();
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Pick Photo";
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.DefaultExt = "jpeg";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                txtPhoto.Text = file;
                pbPhoto.Image= new Bitmap(file);
            }
        }

        private void master_book_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            enable();
            stats = "update";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }
    }
}
