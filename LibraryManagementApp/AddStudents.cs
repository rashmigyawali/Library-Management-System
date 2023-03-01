using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryManagementApp
{
    public partial class AddStudents : Form
    {
        public AddStudents()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0ET4QFE\\SQLEXPRESS; Integrated Security=True; Database=LibraryManagementDB");

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtStudentsname.Text == "" || cboGender.Text == "" ||  cboFaculty.Text ==  "" || txtSection.Text == "" || txtBirthdate.Text == "" || 
                txtAddress.Text == "" || txtPhonenumber.Text == "")
            {
                MessageBox.Show("Please fill up all the details.", "Notification: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                insertstudent();
            }
        }
        private void insertstudent()
        {
            con.Open();
            string query = "Insert into Student_Details (StudentName, Gender, Faculty, Section, Birthdate, Address, PhoneNo) " +
                "values('" + txtStudentsname.Text.Trim() + "', '" + cboGender.Text.Trim() + "','" + cboFaculty.Text.Trim() + "','" + txtSection.Text.Trim() + "'," +
                "'" + txtBirthdate.Text.Trim() + "','" + txtAddress.Text.Trim() + "','" + txtPhonenumber.Text.Trim() + "')";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Student added successfully!", "Notification:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AddStudents_Load(object sender, EventArgs e)
        {

        }

        private void cboGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtBirthdate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
