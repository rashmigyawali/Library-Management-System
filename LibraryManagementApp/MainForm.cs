using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm view = new LoginForm();
            view.Show();
            this.Hide();
        }

        private void addStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudents view = new AddStudents();
            view.Show();
        }

        private void addBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBooks view = new AddBooks();
            view.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword view = new ChangePassword();
            view.Show();
            this.Hide();
        }

        private void bookWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStudents view = new ViewStudents();
            view.Show();
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBooks view = new ViewBooks();
            view.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void burrowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageBooks view = new ManageBooks();
            view.Show();

        }

        private void manageStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageStudents view = new ManageStudents();
            view.Show();
        }

        private void allBooksRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YearwiseReport view = new YearwiseReport();
            view.Show();
        }

        private void allStudentsRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookwiseReport view = new BookwiseReport();
            view.Show();
        }

        private void reportAProblemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentwiseReport view = new StudentwiseReport();
            view.Show();
        }

        private void bookEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BurrowEntry view = new BurrowEntry();
            view.Show();
        }

        private void extendDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtendDueDate due = new ExtendDueDate();
            due.Show();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBook view = new ReturnBook();
            view.Show();
        }
    }
}

