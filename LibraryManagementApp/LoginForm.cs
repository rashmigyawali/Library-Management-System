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
using System.Security.Cryptography;

namespace LibraryManagementApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }


        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (txtUsername.Text == null || txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your username.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtPassword.Text == null || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataTable dt = Login(Hashing(txtPassword.Text));
                if (dt.Rows.Count>0)
                {
                    MainForm main = new MainForm();
                    main.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Please enter the correct Username or Password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
            }


        }
        private DataTable Login(string password)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-0ET4QFE\\SQLEXPRESS; Integrated Security=True; Database=LibraryManagementDB");
            var sql = " Select * from Login where Username= '" + txtUsername.Text + "'and Password ='" + txtPassword.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter SAD = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            SAD.Fill(dt);
            return dt;
        }

        private string Hashing(string input)
        {
            SHA1CryptoServiceProvider SHA1 = new SHA1CryptoServiceProvider();
            byte[] password_bytes = Encoding.ASCII.GetBytes(input);
            byte[] encrypted_bytes = SHA1.ComputeHash(password_bytes);
            return Convert.ToBase64String(encrypted_bytes);
        }
        


            private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
