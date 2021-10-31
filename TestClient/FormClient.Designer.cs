
namespace TestClient
{
    partial class FormClient
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
            this.dataGridViewResultTest = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGetTested = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.dataGridViewResultTestUser = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultTestUser)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewResultTest
            // 
            this.dataGridViewResultTest.AllowUserToAddRows = false;
            this.dataGridViewResultTest.AllowUserToDeleteRows = false;
            this.dataGridViewResultTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResultTest.Location = new System.Drawing.Point(15, 29);
            this.dataGridViewResultTest.MultiSelect = false;
            this.dataGridViewResultTest.Name = "dataGridViewResultTest";
            this.dataGridViewResultTest.ReadOnly = true;
            this.dataGridViewResultTest.RowHeadersWidth = 51;
            this.dataGridViewResultTest.RowTemplate.Height = 24;
            this.dataGridViewResultTest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewResultTest.Size = new System.Drawing.Size(900, 150);
            this.dataGridViewResultTest.TabIndex = 0;
            this.dataGridViewResultTest.SelectionChanged += new System.EventHandler(this.dataGridViewTestUsers_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "New test for user:";
            // 
            // buttonGetTested
            // 
            this.buttonGetTested.Enabled = false;
            this.buttonGetTested.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGetTested.ForeColor = System.Drawing.Color.Blue;
            this.buttonGetTested.Location = new System.Drawing.Point(699, 185);
            this.buttonGetTested.Name = "buttonGetTested";
            this.buttonGetTested.Size = new System.Drawing.Size(216, 32);
            this.buttonGetTested.TabIndex = 2;
            this.buttonGetTested.Text = "Get tested";
            this.buttonGetTested.UseVisualStyleBackColor = true;
            this.buttonGetTested.Click += new System.EventHandler(this.buttonGetTested_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRefresh.ForeColor = System.Drawing.Color.Green;
            this.buttonRefresh.Location = new System.Drawing.Point(477, 185);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(216, 32);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // dataGridViewResultTestUser
            // 
            this.dataGridViewResultTestUser.AllowUserToAddRows = false;
            this.dataGridViewResultTestUser.AllowUserToDeleteRows = false;
            this.dataGridViewResultTestUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResultTestUser.Location = new System.Drawing.Point(15, 223);
            this.dataGridViewResultTestUser.MultiSelect = false;
            this.dataGridViewResultTestUser.Name = "dataGridViewResultTestUser";
            this.dataGridViewResultTestUser.ReadOnly = true;
            this.dataGridViewResultTestUser.RowHeadersWidth = 51;
            this.dataGridViewResultTestUser.RowTemplate.Height = 24;
            this.dataGridViewResultTestUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewResultTestUser.Size = new System.Drawing.Size(900, 150);
            this.dataGridViewResultTestUser.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Result test:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 401);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(927, 26);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 18);
            this.toolStripProgressBar.Visible = false;
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 427);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewResultTestUser);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonGetTested);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewResultTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormClient";
            this.Text = "TestClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClient_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultTestUser)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewResultTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGetTested;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.DataGridView dataGridViewResultTestUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
    }
}

