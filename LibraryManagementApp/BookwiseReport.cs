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
    public partial class BookwiseReport : Form
    {
        public BookwiseReport()
        {
            InitializeComponent();
        }

        private void Bookwise_Load(object sender, EventArgs e)
        {

        }

        public DataTable Bookwisereport (string firstdate, string lastdate)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-0ET4QFE\\SQLEXPRESS; Integrated Security=True; Database=LibraryManagementDB");
            {
                string sql = "Bookwisereport";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Firstdate", firstdate);
                cmd.Parameters.AddWithValue("@Lastdate", lastdate);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Bookwisereport(dateTimePicker1.Text, dateTimePicker2.Text);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
