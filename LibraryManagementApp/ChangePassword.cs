using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementApp
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNewpassword.Text.Trim()=="" || txtCurrentpassword.Text.Trim()=="" || txtConfirmpassword.Text.Trim()=="")
            {
                MessageBox.Show("Please fill all box", "field empty");
            }
            else
            {
                if (txtNewpassword.Text.Trim()!=txtConfirmpassword.Text.Trim())
                {
                    MessageBox.Show("Password donot match", "Invalid match");
                }
                else if(txtCurrentpassword.Text.Trim()==txtNewpassword.Text.Trim())
                {
                    MessageBox.Show("Current password and new password is same", "Invalid");
                }
                else
                {
                    DataTable dt = getdata(Hashing( txtCurrentpassword.Text.Trim()));
                    if (dt.Rows.Count>0)
                    {
                        int update = updatepassword(Hashing(txtConfirmpassword.Text));
                        if (update>0)
                        {
                            MessageBox.Show("password changed", "Successfully");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Current password donot match", "invalid");
                    }
                }
            }
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        public string Hashing(string input)
        {
            SHA1CryptoServiceProvider SHA1 = new SHA1CryptoServiceProvider();
            byte[] password_bytes = Encoding.ASCII.GetBytes(input);
            byte[] encrypted_bytes = SHA1.ComputeHash(password_bytes);
            return Convert.ToBase64String(encrypted_bytes);
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0ET4QFE\\SQLEXPRESS; Integrated Security=True; Database=LibraryManagementDB");
        public DataTable getdata( string password)
        {
            con.Open();
            string sql = "select * from login where password = '"+password+"'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int updatepassword(string password)
        {
            string sql = "Update login set password = '" + password + "' where id=1 ";
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {

                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        private void txtNewpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
