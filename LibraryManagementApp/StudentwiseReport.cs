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
    public partial class StudentwiseReport : Form
    {
        public StudentwiseReport()
        {
            InitializeComponent();
        }

        private void Studentwise_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = studentwise();
        }

        public DataTable studentwise()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-0ET4QFE\\SQLEXPRESS; Integrated Security=True; Database=LibraryManagementDB");
            {
                string sql = "StudentwiseReport";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter asd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                asd.Fill(dt);
                return dt;
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
