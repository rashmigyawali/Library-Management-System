namespace LibraryManagementApp
{
    partial class ViewStudents
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpSearchstudents = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchstudents = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grpSearchstudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSearchstudents
            // 
            this.grpSearchstudents.Controls.Add(this.btnSearch);
            this.grpSearchstudents.Controls.Add(this.txtSearchstudents);
            this.grpSearchstudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSearchstudents.Location = new System.Drawing.Point(12, 12);
            this.grpSearchstudents.Name = "grpSearchstudents";
            this.grpSearchstudents.Size = new System.Drawing.Size(584, 197);
            this.grpSearchstudents.TabIndex = 0;
            this.grpSearchstudents.TabStop = false;
            this.grpSearchstudents.Text = "Search Students";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(395, 125);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(118, 49);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchstudents
            // 
            this.txtSearchstudents.Location = new System.Drawing.Point(63, 70);
            this.txtSearchstudents.Name = "txtSearchstudents";
            this.txtSearchstudents.Size = new System.Drawing.Size(287, 36);
            this.txtSearchstudents.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 226);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1065, 421);
            this.dataGridView1.TabIndex = 1;
            // 
            // ViewStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1095, 659);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.grpSearchstudents);
            this.Name = "ViewStudents";
            this.Text = "ViewStudents";
            this.Load += new System.EventHandler(this.ViewStudents_Load);
            this.grpSearchstudents.ResumeLayout(false);
            this.grpSearchstudents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSearchstudents;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchstudents;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}