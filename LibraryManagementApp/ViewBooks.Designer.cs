namespace LibraryManagementApp
{
    partial class ViewBooks
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
            this.grpSearchbooks = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchbooks = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.grpSearchbooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSearchbooks
            // 
            this.grpSearchbooks.Controls.Add(this.btnSearch);
            this.grpSearchbooks.Controls.Add(this.txtSearchbooks);
            this.grpSearchbooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSearchbooks.Location = new System.Drawing.Point(18, 12);
            this.grpSearchbooks.Name = "grpSearchbooks";
            this.grpSearchbooks.Size = new System.Drawing.Size(525, 194);
            this.grpSearchbooks.TabIndex = 2;
            this.grpSearchbooks.TabStop = false;
            this.grpSearchbooks.Text = "Search Books";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(371, 130);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(118, 49);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchbooks
            // 
            this.txtSearchbooks.Location = new System.Drawing.Point(63, 70);
            this.txtSearchbooks.Name = "txtSearchbooks";
            this.txtSearchbooks.Size = new System.Drawing.Size(287, 36);
            this.txtSearchbooks.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(18, 212);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(1064, 405);
            this.dataGridView2.TabIndex = 3;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ViewBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1099, 633);
            this.Controls.Add(this.grpSearchbooks);
            this.Controls.Add(this.dataGridView2);
            this.Name = "ViewBooks";
            this.Text = "ViewBooks";
            this.Load += new System.EventHandler(this.ViewBooks_Load);
            this.grpSearchbooks.ResumeLayout(false);
            this.grpSearchbooks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSearchbooks;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchbooks;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}