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
    public partial class ExtendDueDate : Form
    {
        public ExtendDueDate()
        {
            InitializeComponent();
        }

        private void ExtendDueDate_Load(object sender, EventArgs e)
        {
            DataTable dt = fillgridofextendbookdate();
            dataGridView1.DataSource = dt;
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0ET4QFE\\SQLEXPRESS; Integrated Security=True; Database=LibraryManagementDB");

        public DataTable fillgridofextendbookdate()
        {
            
            {
                con.Open();
                string sql = "select bo.id, s.studentname, b.bookname, bo.takendate as " + "[Taken Date], bo.deadline from borrow bo " +
                            "inner join student_details s on s.id = bo.StudentsId " +
                            "inner join bookdetails b on b.Id = bo.BookId " +
                            "where bo.returnedDate is null";
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
            txtStudentname.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            id = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);
            txtBookname.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker2.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker3.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        public int extendtime(string time, int id)
        {

            con.Open();
                string sql = "Update borrow set deadline ='" + time + "'where id = " + id + "";
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
            try
            {
                if (txtStudentname.Text.Trim() == "" || txtAddextensiondate.Text.Trim() == "")
                {
                    MessageBox.Show("Please double click the datagridview below and add extension days");
                }
                else
                {
                    int addextensiondate = Convert.ToInt32(txtAddextensiondate.Text);
                    dateTimePicker2.Value = dateTimePicker2.Value.AddDays(addextensiondate);
                    int extend = extendtime(dateTimePicker2.Text, id);
                    if (extend > 0)
                    {
                        MessageBox.Show("Book Extend Successfully");
                        FillGridview();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void FillGridview()
        {
            DataTable dt = fillgridofextendbookdate();
            dataGridView1.DataSource = dt;
        }

        private void Btncancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
    