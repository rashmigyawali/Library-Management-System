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
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void ReturnBook_Load(object sender, EventArgs e)
        {
            DataTable dt = fillgridview();
            dataGridView1.DataSource = dt;
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0ET4QFE\\SQLEXPRESS; Integrated Security=True; Database=LibraryManagementDB");

        public DataTable fillgridview()
        {
            
            {
                con.Open();
                string sql = "select bo.id, s.studentname, b.bookname, bo.takendate as " + "[Taken Date], bo.Deadline from borrow bo " +
                            "inner join student_details s on s.id = bo.StudentsId " +
                            "inner join bookdetails b on b.Id = bo.BookId " +
                            "where bo.returneddate is null";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        int id = 0;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public int bookreturned(string time, int id)
        {
             
            
                string sql = "Update Borrow set ReturnedDate ='" + time + "'where id = " + id + "";
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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            
        }

        public int quantitymanage(string bookname, int taken_return)
        
            {
                string sql = "update BookDetails set Quantity = quantity + " + taken_return + "where bookname ='" + bookname + "'";
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
        
        
        private void txtFine_MouseClick(object sender, MouseEventArgs e)
        {
            DateTime sdt = dateTimePicker1.Value.Date;
            DateTime edt = dateTimePicker2.Value.Date;
            TimeSpan ts = edt - sdt;
            int days = ts.Days;
            int fine = 0;
            if (days > 0)
            {
                fine = days * 30;
            }
            txtFine.Text = fine.ToString(); 
        }
        private void clearfield()
        {
            txtBookname.Text = "";
            txtStudentname.Text = "";
            txtFine.Text = "";
            fillgridview();
            dateTimePicker3.Text = "2000-02-12";
            dateTimePicker1.Text = "2000-02-12";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearfield();
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtStudentname.Text.Trim() == "")
                {
                    MessageBox.Show("Please click the datagridview twice");
                }
                else
                {
                    DateTime sdt = dateTimePicker3.Value.Date;
                    DateTime edt = dateTimePicker2.Value.Date;
                    TimeSpan ts = edt - sdt;
                    int days = ts.Days;
                    if (days >= 0)
                    {
                        int bookreturn = bookreturned(dateTimePicker2.Text, id);
                        if (bookreturn > 0)
                        {
                            quantitymanage(txtBookname.Text, 1);
                            MessageBox.Show("Book Returned To Library");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid Returned date");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtStudentname.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            id = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);
            txtBookname.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker3.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}



