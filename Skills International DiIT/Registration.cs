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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        static string connection = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=SkillsInternational;Integrated Security=True";
        SqlConnection con = new SqlConnection(connection);

        string firstName, lastName, dateOfBirth, gender, address, email, parentName, nic;
        int regNo, mobilePhone, homePhone, contactNo;

        private void btnView_Click(object sender, EventArgs e)
        {
            View x = new View();
            x.Show();
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbRegNo.ResetText();
            txtFirstName.Clear();
            txtLastName.Clear();
            dtpDOB.ResetText();
            radiobtnMale.Checked = false;
            radiobtnFemale.Checked = false;
            txtAddress.Clear();
            txtEmail.Clear();
            txtMobilePhone.Clear();
            txtHomePhone.Clear();
            txtParentName.Clear();
            txtNIC.Clear();
            txtContactNumber.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int regNo;
            if (!int.TryParse(cmbRegNo.Text, out regNo))
            {
                MessageBox.Show("Please enter a valid registration number.");
                return;
            }

            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string dateOfBirth = dtpDOB.Value.ToString("yyyy-MM-dd");
            string gender = radiobtnMale.Checked ? "Male" : "Female";
            string address = txtAddress.Text;
            string email = txtEmail.Text;

            int mobilePhone, homePhone, contactNo;
            if (!int.TryParse(txtMobilePhone.Text, out mobilePhone))
            {
                MessageBox.Show("Please enter a valid mobile phone number.");
                return;
            }

            if (!int.TryParse(txtHomePhone.Text, out homePhone))
            {
                MessageBox.Show("Please enter a valid home phone number.");
                return;
            }

            string nic = txtNIC.Text;
            string parentName = txtParentName.Text;

            if (!int.TryParse(txtContactNumber.Text, out contactNo))
            {
                MessageBox.Show("Please enter a valid contact number.");
                return;
            }

            con.Open();

            string Update = "Update Registration set regNo = '" + regNo
                + "', firstName = '" + firstName
                + "', lastName = '" + lastName
                + "', dateOfBirth = '" + dateOfBirth
                + "', gender = '" + gender
                + "', address = '" + address
                + "', email = '" + email
                + "', mobilePhone = '" + mobilePhone
                + "', homePhone = '" + homePhone
                + "', nic = '" + nic
                + "', parentName = '" + parentName
                + "', contactNo = '" + contactNo
                + "' where regNo = '" + regNo + "'";

            if (MessageBox.Show("Are you going to update?", "Update Student",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
                SqlCommand cmd = new SqlCommand(Update, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully.");
            }
            con.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int regNo;
            if (!int.TryParse(cmbRegNo.Text, out regNo))
            {
                MessageBox.Show("Please enter a valid registration number.");
                return;
            }

            con.Open();

            string delete = "delete from Registration where regNo = '" + regNo + "'";
            if (MessageBox.Show("Are you sure, Do you really want to Delete this Record?", "Delete",
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
                MessageBox.Show("Record Deleted Successfully.");
            }
        }

        private void linkLabelLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login x = new Login();
            x.Show();
            this.Hide();
        }

        private void linkLabelExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void Registration_Load(object sender, EventArgs e)
        {
            this.registrationTableAdapter.Fill(this.skillsInternationalDataSet.Registration);
        }

        private void cmbRegNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int regNo;
                if (!int.TryParse(cmbRegNo.Text, out regNo))
                {
                    MessageBox.Show("Please enter a valid registration number.");
                    return;
                }

                con.Open();
                string query = "SELECT * FROM Registration WHERE regNo = @regNo";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@regNo", regNo);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtFirstName.Text = reader["firstName"].ToString();
                    txtLastName.Text = reader["lastName"].ToString();
                    dtpDOB.Value = DateTime.Parse(reader["dateOfBirth"].ToString());
                    string gender = reader["gender"].ToString();
                    if (gender == "Male")
                    {
                        radiobtnMale.Checked = true;
                    }
                    else
                    {
                        radiobtnFemale.Checked = true;
                    }
                    txtAddress.Text = reader["address"].ToString();
                    txtEmail.Text = reader["email"].ToString();
                    txtMobilePhone.Text = reader["mobilePhone"].ToString();
                    txtHomePhone.Text = reader["homePhone"].ToString();
                    txtNIC.Text = reader["nic"].ToString();
                    txtParentName.Text = reader["parentName"].ToString();
                    txtContactNumber.Text = reader["contactNo"].ToString();
                }
                else
                {
                    MessageBox.Show("No record found for the selected Registration Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            int regNo;
            if (!int.TryParse(cmbRegNo.Text, out regNo))
            {
                MessageBox.Show("Please enter a valid registration number.");
                return;
            }

            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string dateOfBirth = dtpDOB.Value.ToString("yyyy-MM-dd");
            string gender = radiobtnMale.Checked ? "Male" : "Female";
            string address = txtAddress.Text.Trim();
            string email = txtEmail.Text.Trim();

            int mobilePhone, homePhone, contactNo;
            if (!int.TryParse(txtMobilePhone.Text, out mobilePhone))
            {
                MessageBox.Show("Please enter a valid mobile phone number.");
                return;
            }
            if (!int.TryParse(txtHomePhone.Text, out homePhone))
            {
                MessageBox.Show("Please enter a valid home phone number.");
                return;
            }
            if (!int.TryParse(txtContactNumber.Text, out contactNo))
            {
                MessageBox.Show("Please enter a valid contact number.");
                return;
            }

            string nic = txtNIC.Text.Trim();
            string parentName = txtParentName.Text.Trim();

            con.Open();

            string checkQuery = "SELECT COUNT(*) FROM Registration WHERE regNo = @regNo";
            SqlCommand checkCmd = new SqlCommand(checkQuery, con);
            checkCmd.Parameters.AddWithValue("@regNo", regNo);
            int existingRecords = (int)checkCmd.ExecuteScalar();

            if (existingRecords > 0)
            {
                MessageBox.Show("This Registration Number already exists. Please enter a unique regNo.");
                con.Close();
                return;
            }

            string insertQuery = "INSERT INTO Registration (regNo, firstName, lastName, dateOfBirth, gender, address, email, mobilePhone, homePhone, nic, parentName, contactNo) " +
                                 "VALUES (@regNo, @firstName, @lastName, @dateOfBirth, @gender, @address, @email, @mobilePhone, @homePhone, @nic, @parentName, @contactNo)";

            SqlCommand insertCmd = new SqlCommand(insertQuery, con);
            insertCmd.Parameters.AddWithValue("@regNo", regNo);
            insertCmd.Parameters.AddWithValue("@firstName", firstName);
            insertCmd.Parameters.AddWithValue("@lastName", lastName);
            insertCmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
            insertCmd.Parameters.AddWithValue("@gender", gender);
            insertCmd.Parameters.AddWithValue("@address", address);
            insertCmd.Parameters.AddWithValue("@email", email);
            insertCmd.Parameters.AddWithValue("@mobilePhone", mobilePhone);
            insertCmd.Parameters.AddWithValue("@homePhone", homePhone);
            insertCmd.Parameters.AddWithValue("@nic", nic);
            insertCmd.Parameters.AddWithValue("@parentName", parentName);
            insertCmd.Parameters.AddWithValue("@contactNo", contactNo);

            try
            {
                if (MessageBox.Show("Are you sure you want to add this new record?", "Confirmation",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    insertCmd.ExecuteNonQuery();
                    MessageBox.Show("Record Added Successfully.");
                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 2627)
                {
                    MessageBox.Show("The registration number already exists. Please enter a different regNo.");
                }
                else
                {
                    MessageBox.Show("Error occurred: " + sqlEx.Message);
                }
            }

            con.Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }
    }
}
