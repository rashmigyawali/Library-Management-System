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

namespace LibraryManagementApp
{
    public partial class ManageStudents : Form
    {
        public ManageStudents()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0ET4QFE\\SQLEXPRESS; Integrated Security=True; Database=LibraryManagementDB");

        private void ManageStudents_Load(object sender, EventArgs e)
        {
            dataGridView3.DataSource = choosestudent();
        }
        public DataTable choosestudent()
        {
            con.Open();
            string sql = " Select Id, StudentName, Gender, Faculty, Section, Birthdate, Address, PhoneNo from Student_Details";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        int Id = 0;
        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = Convert.ToInt32(this.dataGridView3.CurrentRow.Cells[0].Value);
            txtStudentsname1.Text = this.dataGridView3.CurrentRow.Cells[1].Value.ToString();
            cboGender1.Text = this.dataGridView3.CurrentRow.Cells[2].Value.ToString();
            cboFaculty1.Text = this.dataGridView3.CurrentRow.Cells[3].Value.ToString();
            txtSection1.Text = this.dataGridView3.CurrentRow.Cells[4].Value.ToString();
            txtBirthdate1.Text = this.dataGridView3.CurrentRow.Cells[5].Value.ToString();
            txtAddress1.Text = this.dataGridView3.CurrentRow.Cells[6].Value.ToString();
            txtPhonenumber1.Text = this.dataGridView3.CurrentRow.Cells[7].Value.ToString();
        }

        public int updatestudent(int id, string studentname, string gender, string faculty, string section, string birthdate, string address, string phoneno )
        {
            
            
            string sql = "Update Student_Details set StudentName = '" + studentname +"', Gender = '" + gender + "', Faculty = '" + faculty + "', Section = '" + section + "', Birthdate = '" + birthdate + "', Address = '" + address + "', PhoneNo = '" + phoneno + "' where Id = " + id + "; ";
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtStudentsname1.Text.Trim() == "")
                {
                    MessageBox.Show("Please input all the details.");
                }
                else
                {
                    int update = updatestudent(Id, txtStudentsname1.Text, cboGender1.Text, cboFaculty1.Text, txtSection1.Text, txtBirthdate1.Text, txtAddress1.Text, txtPhonenumber1.Text);
                    if (update>0)
                    {
                        MessageBox.Show("Student details successfully updated!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }


        public int deletestudent(int id)
        {
            
            string sql = string.Empty;
            sql = "Delete from Student_Details  where Id = " + id + " ";
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStudentsname1.Text.Trim() == "")
                {
                    MessageBox.Show("Please Select A Student");
                }

                else
                {
                    DataTable dt = check(Id);
                    if (dt.Rows.Count > 0)
                    {
                        int borrowdelete = deleteborrow(Id);
                        if (borrowdelete > 0)
                        {
                            int delete = deletestudent(Id);
                            if (delete > 0)
                            {
                                MessageBox.Show("Student Record Successfully Deleted");
                            }
                        }

                      
                    }

                    else if (dt.Rows.Count == 0)
                    {
                        int delete = deletestudent(Id);
                        if( delete > 0)
                        {
                            MessageBox.Show("Student Record Successfully Deleted");
                        }
                    }

                    else
                    {
                        MessageBox.Show("201 Error");
                    }
                   
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        

        public DataTable check(int id)
        {
            {
                con.Open();
                string sql = string.Empty;
                sql = "Select * from Borrow where Id = " + id + "";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public int deleteborrow(int id)
        {
            
            {
                
                
                string sql = "Delete from Borrow where Id = " + id + "";
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
        }
    }


    
    
}
