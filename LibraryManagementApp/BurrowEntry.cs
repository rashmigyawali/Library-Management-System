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
    public partial class BurrowEntry : Form
    {
        public BurrowEntry()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0ET4QFE\\SQLEXPRESS; Integrated Security=True; Database=LibraryManagementDB");

        private void BurrowEntry_Load(object sender, EventArgs e)
        {
            
        }

        public DataTable fillcomboboxbook()
        {
            
            {
                con.Open();
                string sql = "select Id, BookName from BookDetails where Quantity>0";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public int getbookid(string name)
        {
            
            {
                con.Open();
                Int32 i = 0;
                string sql = "select Id from BookDetails where bookname='" + name + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                try
                {
                    i = (Int32)cmd.ExecuteScalar();
                    return i;
                }
                catch (Exception)
                {

                    return 1;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public int insertintoborrow(int studentid, int bookid, string takendate, string deadline)
        {
            
            {
                
                string sql = "insert into Borrow(studentsid, bookid, takendate, deadline) " +
                             "values(" + studentid + "," + bookid + ",'" + takendate + "','" + deadline + "')";
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

        public DataTable getallstudent()
        {
            con.Open();
            string sql = "select Id, StudentName, Gender, Faculty, Section, Birthdate, Address, PhoneNo from Student_Details";
            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        int studentid = 0;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public int quantitymanage(string bookname, int taken_return)
        {
            
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
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
            try

            {

                if (txtStudentname.Text.Trim() == "")
                {
                    MessageBox.Show("Please select book and student");
                }

                else
                {
                    int insertborrow = insertintoborrow(studentid, 3, dateTimePickertakendate.Text, dateTimePickerreturndate.Text);
                    if (insertborrow > 0)
                    {
                        quantitymanage("Hard Times", -1);
                        MessageBox.Show("Book Entried");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            clearfield();
        }
        int bookid = 0;
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bookid = Convert.ToInt32(this.dataGridView2.CurrentRow.Cells[0].Value);
        }
        private void clearfield()
        {
            txtStudentname.Text = "";
            fillcomboboxbook();
            dateTimePickertakendate.Text = "2000-02-12";
            dateTimePickerreturndate.Text = "2000-02-12";
        }

        private void txtStudentname_TextChanged(object sender, EventArgs e)
        {

        }

        private void BurrowEntry_Load_1(object sender, EventArgs e)
        {
            DataTable dt = getallstudent();
            dataGridView1.DataSource = dt;
            dataGridView2.DataSource = fillcomboboxbook();
            dateTimePickerreturndate.Value = dateTimePickertakendate.Value.AddDays(15);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtStudentname.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            studentid = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void dateTimePickertakendate_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerreturndate.Value = dateTimePickertakendate.Value.AddDays(15);
        }
    }
    
}



