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
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0ET4QFE\\SQLEXPRESS; Integrated Security=True; Database=LibraryManagementDB");

        private void btnSave_Click(object sender, EventArgs e)
        {
            //string.IsNullOrWhiteSpace checks for null and white space
             
            if (string.IsNullOrWhiteSpace(txtBooksname.Text) || string.IsNullOrWhiteSpace(txtPagecount.Text) || string.IsNullOrWhiteSpace(cboAuthor.Text)  || string.IsNullOrWhiteSpace (cboBooktype.Text) || string.IsNullOrWhiteSpace (dateTimePicker1.Text) || string.IsNullOrWhiteSpace (txtPublication.Text) || string.IsNullOrWhiteSpace (txtQuantity.Text))
            {
                MessageBox.Show("Please fill up all the details.", "Notification: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                insertbook();
            }
        }
        private void insertbook()
        {
            con.Open(); // db connection is opened here 
            string query = "Insert into BookDetails (BookName, Pagecount, AuthorId, TypeId, PurchasedDate, Publication, Quantity) values('" + txtBooksname.Text.Trim() + "', '" + txtPagecount.Text.Trim() + "','" + cboAuthor.SelectedValue + "','" + cboBooktype.SelectedValue + "','" + dateTimePicker1.Text.Trim() + "','" + txtPublication.Text.Trim() + "','" + txtQuantity.Text.Trim() + "')";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Book added successfully!", "Notification:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }

        private void cboAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fillcomboboxauthor();

        }

        private DataTable Fillcomboboxauthor()
        {
            con.Open();
            string query = "Select Id,AuthorName from Authors";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter asd = new SqlDataAdapter(cmd);
            asd.Fill(dt);
            con.Close();
            return dt;
        }
        private DataTable Fillcombotype()
        {
            con.Open();
            string query = "Select Id,BookType from BookType";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter asd = new SqlDataAdapter(cmd);
            asd.Fill(dt);
            con.Close();
            return dt;
        }

        private void AddBooks_Load(object sender, EventArgs e)
        {
             //Fills combobox of author
            DataTable dt = Fillcomboboxauthor();
            cboAuthor.DataSource = dt;
            foreach (DataRow dr in dt.Rows)
            {
                cboAuthor.DisplayMember = "AuthorName";
                cboAuthor.ValueMember = "Id";
            }

            //Fills combobox of booktype
            DataTable da = Fillcombotype();
            cboBooktype.DataSource = da;
            foreach (DataRow dr in da.Rows)
            { 
                cboBooktype.DisplayMember = "BookType";
                cboBooktype.ValueMember = "Id";
            }
        }

        private void cboBooktype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
