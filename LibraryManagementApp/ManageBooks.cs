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
    public partial class ManageBooks : Form
    {
        public ManageBooks()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0ET4QFE\\SQLEXPRESS; Integrated Security=True; Database=LibraryManagementDB");

        private void ManageBooks_Load(object sender, EventArgs e)
        {
            dataGridView4.DataSource = choosebook();
            fillcomboboxauthor();
            fillcomboboxbooktype();
        }

        public DataTable choosebook()
        {
            con.Open();
            string sql = " Select Id, BookName, PageCount, AuthorId, TypeId, PurchasedDate, Publication, Quantity from BookDetails";
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
            Id = Convert.ToInt32(this.dataGridView4.CurrentRow.Cells[0].Value);
            txtBooksname1.Text = this.dataGridView4.CurrentRow.Cells[1].Value.ToString();
            txtPagecount1.Text = this.dataGridView4.CurrentRow.Cells[2].Value.ToString();
            cboAuthor1.Text = this.dataGridView4.CurrentRow.Cells[3].Value.ToString();
            cboBooktype1.Text = this.dataGridView4.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker2.Text = this.dataGridView4.CurrentRow.Cells[5].Value.ToString();
            txtPublication1.Text = this.dataGridView4.CurrentRow.Cells[6].Value.ToString();
            txtQuantity1.Text = this.dataGridView4.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnUpdate2_Click(object sender, EventArgs e)
        {
            if (txtQuantity1.Text.Trim() == "" || txtPublication1.Text.Trim() == "" || txtPagecount1.Text.Trim() == "" || txtBooksname1.Text.Trim() == "")
            {
                MessageBox.Show("Please fill all fields", "Field Empty");
            }
            else
            {
                int invalid = 0;
                int pagecount = 0;
                int quantity = 0;
                try
                {
                     quantity = Convert.ToInt32(txtQuantity1.Text);
                    pagecount = Convert.ToInt32(txtPagecount1.Text);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Please fill with correct format", "Invalid quantity or pagecount");
                    invalid = 1;
                }

                if (invalid !=1)
                {
                    
                    string query = "update bookdetails set bookname='"+txtBooksname1.Text+"', pagecount= "+pagecount+", authorid = "+cboAuthor1.SelectedValue+",typeid="+cboBooktype1.SelectedValue+", purchaseddate='"+dateTimePicker2.Text+"',publication ='"+txtPublication1.Text+"', quantity = "+quantity+" where id="+Id+"" ;
                    
                    SqlCommand cmd = new SqlCommand(query, con);
                    try
                    {
                        con.Open();
                         cmd.ExecuteNonQuery();
                        MessageBox.Show("Book details updated successfully", "successful");

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
        public void fillcomboboxauthor()
        {
            DataTable dt = authorselect();
            cboAuthor1.DataSource = dt;
            foreach (DataRow dr in dt.Rows)
            {
                cboAuthor1.DisplayMember = "AuthorName";
                cboAuthor1.ValueMember = "Id";
            }
        }
        public DataTable authorselect()
        {
            con.Open();
            string sql = "select * from authors";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public void fillcomboboxbooktype()
        {
            DataTable dt = booktypeselect();
            cboBooktype1.DataSource = dt;
            foreach (DataRow dr in dt.Rows)
            {
                cboBooktype1.DisplayMember = "booktype";
                cboBooktype1.ValueMember = "Id";
            }
        }
        public DataTable booktypeselect()
        {
            con.Open();
            string sql = "select * from booktype";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = Convert.ToInt32(this.dataGridView4.CurrentRow.Cells[0].Value);
            txtBooksname1.Text = this.dataGridView4.CurrentRow.Cells[1].Value.ToString();
            txtPagecount1.Text = this.dataGridView4.CurrentRow.Cells[2].Value.ToString();
            cboAuthor1.Text = this.dataGridView4.CurrentRow.Cells[3].Value.ToString();
            cboBooktype1.Text = this.dataGridView4.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker2.Text = this.dataGridView4.CurrentRow.Cells[5].Value.ToString();
            txtPublication1.Text = this.dataGridView4.CurrentRow.Cells[6].Value.ToString();
            txtQuantity1.Text = this.dataGridView4.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (Id!=0)
            {
                int update = deleteborrow(Id);
                if (update>0)
                {
                    deletebook(Id);
                    MessageBox.Show("book records successfully deleted", "Successfull");
                }
                
            }
        }
        public int deletebook(int bookid)
        {
            
                string sql = "delete from bookdetails where id = " + bookid + "";
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

        public int deleteborrow(int id)
        {
            string sql = "delete from borrow where bookid = "+id+"";
            SqlCommand cmd = new SqlCommand(sql,con);
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
