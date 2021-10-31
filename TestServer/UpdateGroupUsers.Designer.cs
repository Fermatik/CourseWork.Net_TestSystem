
namespace TestServer
{
    partial class UpdateGroupUsers
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRemoveUser = new System.Windows.Forms.Button();
            this.textBoxNameGroup = new System.Windows.Forms.TextBox();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxIdGroup = new System.Windows.Forms.TextBox();
            this.dataGridViewOtherUsers = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewGroupUsers = new System.Windows.Forms.DataGridView();
            this.comboBoxGroups = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOtherUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroupUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonRemoveUser);
            this.panel1.Controls.Add(this.textBoxNameGroup);
            this.panel1.Controls.Add(this.buttonAddUser);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxIdGroup);
            this.panel1.Controls.Add(this.dataGridViewOtherUsers);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dataGridViewGroupUsers);
            this.panel1.Location = new System.Drawing.Point(12, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 387);
            this.panel1.TabIndex = 1;
            // 
            // buttonRemoveUser
            // 
            this.buttonRemoveUser.Enabled = false;
            this.buttonRemoveUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRemoveUser.ForeColor = System.Drawing.Color.Red;
            this.buttonRemoveUser.Location = new System.Drawing.Point(627, 189);
            this.buttonRemoveUser.Name = "buttonRemoveUser";
            this.buttonRemoveUser.Size = new System.Drawing.Size(126, 23);
            this.buttonRemoveUser.TabIndex = 9;
            this.buttonRemoveUser.Text = "⟱";
            this.buttonRemoveUser.UseCompatibleTextRendering = true;
            this.buttonRemoveUser.UseVisualStyleBackColor = true;
            this.buttonRemoveUser.Click += new System.EventHandler(this.buttonRemoveUser_Click);
            // 
            // textBoxNameGroup
            // 
            this.textBoxNameGroup.Enabled = false;
            this.textBoxNameGroup.Location = new System.Drawing.Point(15, 75);
            this.textBoxNameGroup.Name = "textBoxNameGroup";
            this.textBoxNameGroup.Size = new System.Drawing.Size(205, 22);
            this.textBoxNameGroup.TabIndex = 4;
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Enabled = false;
            this.buttonAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddUser.ForeColor = System.Drawing.Color.Green;
            this.buttonAddUser.Location = new System.Drawing.Point(759, 189);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(126, 23);
            this.buttonAddUser.TabIndex = 8;
            this.buttonAddUser.Text = "⟰";
            this.buttonAddUser.UseCompatibleTextRendering = true;
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(238, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Other users:";
            // 
            // textBoxIdGroup
            // 
            this.textBoxIdGroup.Enabled = false;
            this.textBoxIdGroup.Location = new System.Drawing.Point(15, 30);
            this.textBoxIdGroup.Name = "textBoxIdGroup";
            this.textBoxIdGroup.Size = new System.Drawing.Size(205, 22);
            this.textBoxIdGroup.TabIndex = 2;
            // 
            // dataGridViewOtherUsers
            // 
            this.dataGridViewOtherUsers.AllowUserToAddRows = false;
            this.dataGridViewOtherUsers.AllowUserToDeleteRows = false;
            this.dataGridViewOtherUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOtherUsers.Location = new System.Drawing.Point(237, 218);
            this.dataGridViewOtherUsers.Name = "dataGridViewOtherUsers";
            this.dataGridViewOtherUsers.ReadOnly = true;
            this.dataGridViewOtherUsers.RowHeadersWidth = 51;
            this.dataGridViewOtherUsers.RowTemplate.Height = 24;
            this.dataGridViewOtherUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOtherUsers.Size = new System.Drawing.Size(648, 150);
            this.dataGridViewOtherUsers.TabIndex = 6;
            this.dataGridViewOtherUsers.SelectionChanged += new System.EventHandler(this.dataGridViewOtherUsers_SelectionChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(234, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Group users:";
            // 
            // dataGridViewGroupUsers
            // 
            this.dataGridViewGroupUsers.AllowUserToAddRows = false;
            this.dataGridViewGroupUsers.AllowUserToDeleteRows = false;
            this.dataGridViewGroupUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroupUsers.Location = new System.Drawing.Point(237, 30);
            this.dataGridViewGroupUsers.Name = "dataGridViewGroupUsers";
            this.dataGridViewGroupUsers.ReadOnly = true;
            this.dataGridViewGroupUsers.RowHeadersWidth = 51;
            this.dataGridViewGroupUsers.RowTemplate.Height = 24;
            this.dataGridViewGroupUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGroupUsers.Size = new System.Drawing.Size(648, 150);
            this.dataGridViewGroupUsers.TabIndex = 3;
            this.dataGridViewGroupUsers.SelectionChanged += new System.EventHandler(this.dataGridViewGroupUsers_SelectionChanged);
            // 
            // comboBoxGroups
            // 
            this.comboBoxGroups.FormattingEnabled = true;
            this.comboBoxGroups.Location = new System.Drawing.Point(12, 12);
            this.comboBoxGroups.Name = "comboBoxGroups";
            this.comboBoxGroups.Size = new System.Drawing.Size(903, 24);
            this.comboBoxGroups.TabIndex = 2;
            this.comboBoxGroups.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroups_SelectedIndexChanged);
            // 
            // UpdateGroupUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 449);
            this.Controls.Add(this.comboBoxGroups);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateGroupUsers";
            this.Text = "Update group user(s)";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOtherUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroupUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxNameGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIdGroup;
        private System.Windows.Forms.ComboBox comboBoxGroups;
        private System.Windows.Forms.DataGridView dataGridViewGroupUsers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewOtherUsers;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Button buttonRemoveUser;
    }
}