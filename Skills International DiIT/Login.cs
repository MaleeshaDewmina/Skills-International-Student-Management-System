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

namespace Skills_International_DiIT
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        static string connection = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=SkillsInternational;Integrated Security=True";
        SqlConnection con = new SqlConnection(connection);

        string username, password;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true || txtpassword.Text == "")
            {
                txtpassword.PasswordChar = '\0';
            }
            if (checkBox1.Checked == false || txtpassword.Text == "")
            {
                txtpassword.PasswordChar = '*';
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value = progressBar1.Value + 5;

            }
            else
            {
                timer1.Enabled = false;
                Registration x = new Registration();
                x.Show();
                this.Hide();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure, Do you really want to Exit?", "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
               Application.Exit();
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();
            txtusername.Focus();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                username = txtusername.Text;
                password = txtpassword.Text;

                string Query = "SELECT * from Logins where username ='" + username + "' and password='" + password + "'";
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                SqlDataAdapter MyAdapter = new SqlDataAdapter();
                MyAdapter.SelectCommand = cmd;
                DataTable dtable = new DataTable();
                MyAdapter.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    timer1.Start();
                    MessageBox.Show("Login sucessfull!");

                }
                else
                {
                    MessageBox.Show("Invalid Login credentials, please check Username and Password and try again.", "Invalid Login Details", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtusername.Text = "";
                    txtpassword.Text = "";
                }
            }
        }
    }
}
