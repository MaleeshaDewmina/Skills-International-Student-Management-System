using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skills_International_DiIT
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }

        int regNo;

        static string connection = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=SkillsInternational;Integrated Security=True";
        SqlConnection con = new SqlConnection(connection);

        private void View_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'skillsInternationalDataSet.Registration' table. You can move, or remove it, as needed.
            this.registrationTableAdapter.Fill(this.skillsInternationalDataSet.Registration);

        }

        private void Search_button_Click(object sender, EventArgs e)
        {
            con.Open();
            int regNo = int.Parse(Type_the_ID_txt.Text);

            SqlDataAdapter da = new SqlDataAdapter
                ("select * from Registration where regNo = '" + regNo + "'", con);
            DataTable dt = new DataTable();
            int count = da.Fill(dt);
            if (count > 0)
            {
                dataGridView1.DataSource = dt;
                MessageBox.Show("Data Found");
            }
            else
            {
                MessageBox.Show("data not found");
            }
            con.Close();
        }

        private void View_button_Click(object sender, EventArgs e)
        {
            fillData();
        }

        private void fillData()
        {
            con.Open();
            SqlDataAdapter dadt = new SqlDataAdapter("select * from Registration", con);
            DataTable dtb1 = new DataTable();
            dadt.Fill(dtb1);
            dataGridView1.DataSource = dtb1;
            con.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Registration x = new Registration();
            x.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login x = new Login();
            x.Show();
            this.Hide();
        }

        private void Delete_button_Click(object sender, EventArgs e)
        {
            regNo = int.Parse(Type_the_ID_txt.Text);

            con.Open();

            string delete = "delete from Registration where regNo = '" + regNo + "'";
            if (MessageBox.Show("Are you sure to delete?", "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
                SqlCommand cmd = new SqlCommand(delete, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully removed");
            }
        }
    }
    
}
