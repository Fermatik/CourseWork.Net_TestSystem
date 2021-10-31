
namespace TestServer
{
    partial class UpdateUserGroups
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxIsAdmin = new System.Windows.Forms.CheckBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonRemoveGroup = new System.Windows.Forms.Button();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.buttonAddGroup = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.dataGridViewOtherGroups = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewUsersGroups = new System.Windows.Forms.DataGridView();
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOtherGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsersGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkBoxIsAdmin);
            this.panel1.Controls.Add(this.textBoxLastName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.buttonRemoveGroup);
            this.panel1.Controls.Add(this.textBoxFirstName);
            this.panel1.Controls.Add(this.buttonAddGroup);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxId);
            this.panel1.Controls.Add(this.dataGridViewOtherGroups);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dataGridViewUsersGroups);
            this.panel1.Location = new System.Drawing.Point(12, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 387);
            this.panel1.TabIndex = 3;
            // 
            // checkBoxIsAdmin
            // 
            this.checkBoxIsAdmin.AutoSize = true;
            this.checkBoxIsAdmin.Enabled = false;
            this.checkBoxIsAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxIsAdmin.Location = new System.Drawing.Point(15, 149);
            this.checkBoxIsAdmin.Name = "checkBoxIsAdmin";
            this.checkBoxIsAdmin.Size = new System.Drawing.Size(90, 21);
            this.checkBoxIsAdmin.TabIndex = 12;
            this.checkBoxIsAdmin.Text = "is admin";
            this.checkBoxIsAdmin.UseVisualStyleBackColor = true;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Enabled = false;
            this.textBoxLastName.Location = new System.Drawing.Point(15, 121);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(205, 22);
            this.textBoxLastName.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Last name:";
            // 
            // buttonRemoveGroup
            // 
            this.buttonRemoveGroup.Enabled = false;
            this.buttonRemoveGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRemoveGroup.ForeColor = System.Drawing.Color.Red;
            this.buttonRemoveGroup.Location = new System.Drawing.Point(627, 189);
            this.buttonRemoveGroup.Name = "buttonRemoveGroup";
            this.buttonRemoveGroup.Size = new System.Drawing.Size(126, 23);
            this.buttonRemoveGroup.TabIndex = 9;
            this.buttonRemoveGroup.Text = "⟱";
            this.buttonRemoveGroup.UseCompatibleTextRendering = true;
            this.buttonRemoveGroup.UseVisualStyleBackColor = true;
            this.buttonRemoveGroup.Click += new System.EventHandler(this.buttonRemoveGroup_Click);
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Enabled = false;
            this.textBoxFirstName.Location = new System.Drawing.Point(15, 75);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(205, 22);
            this.textBoxFirstName.TabIndex = 4;
            // 
            // buttonAddGroup
            // 
            this.buttonAddGroup.Enabled = false;
            this.buttonAddGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddGroup.ForeColor = System.Drawing.Color.Green;
            this.buttonAddGroup.Location = new System.Drawing.Point(759, 189);
            this.buttonAddGroup.Name = "buttonAddGroup";
            this.buttonAddGroup.Size = new System.Drawing.Size(126, 23);
            this.buttonAddGroup.TabIndex = 8;
            this.buttonAddGroup.Text = "⟰";
            this.buttonAddGroup.UseCompatibleTextRendering = true;
            this.buttonAddGroup.UseVisualStyleBackColor = true;
            this.buttonAddGroup.Click += new System.EventHandler(this.buttonAddGroup_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "First name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(238, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Other groips:";
            // 
            // textBoxId
            // 
            this.textBoxId.Enabled = false;
            this.textBoxId.Location = new System.Drawing.Point(15, 30);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(205, 22);
            this.textBoxId.TabIndex = 2;
            // 
            // dataGridViewOtherGroups
            // 
            this.dataGridViewOtherGroups.AllowUserToAddRows = false;
            this.dataGridViewOtherGroups.AllowUserToDeleteRows = false;
            this.dataGridViewOtherGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOtherGroups.Location = new System.Drawing.Point(237, 218);
            this.dataGridViewOtherGroups.Name = "dataGridViewOtherGroups";
            this.dataGridViewOtherGroups.ReadOnly = true;
            this.dataGridViewOtherGroups.RowHeadersWidth = 51;
            this.dataGridViewOtherGroups.RowTemplate.Height = 24;
            this.dataGridViewOtherGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOtherGroups.Size = new System.Drawing.Size(648, 150);
            this.dataGridViewOtherGroups.TabIndex = 6;
            this.dataGridViewOtherGroups.SelectionChanged += new System.EventHandler(this.dataGridViewOtherGroups_SelectionChanged);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(234, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Users groups:";
            // 
            // dataGridViewUsersGroups
            // 
            this.dataGridViewUsersGroups.AllowUserToAddRows = false;
            this.dataGridViewUsersGroups.AllowUserToDeleteRows = false;
            this.dataGridViewUsersGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsersGroups.Location = new System.Drawing.Point(237, 30);
            this.dataGridViewUsersGroups.Name = "dataGridViewUsersGroups";
            this.dataGridViewUsersGroups.ReadOnly = true;
            this.dataGridViewUsersGroups.RowHeadersWidth = 51;
            this.dataGridViewUsersGroups.RowTemplate.Height = 24;
            this.dataGridViewUsersGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsersGroups.Size = new System.Drawing.Size(648, 150);
            this.dataGridViewUsersGroups.TabIndex = 3;
            this.dataGridViewUsersGroups.SelectionChanged += new System.EventHandler(this.dataGridViewUsersGroups_SelectionChanged);
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(12, 12);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(903, 24);
            this.comboBoxUsers.TabIndex = 4;
            this.comboBoxUsers.SelectedIndexChanged += new System.EventHandler(this.comboBoxUsers_SelectedIndexChanged);
            // 
            // UpdateUserGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 450);
            this.Controls.Add(this.comboBoxUsers);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateUserGroups";
            this.Text = "Update user group(s)";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOtherGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsersGroups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonRemoveGroup;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Button buttonAddGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.DataGridView dataGridViewOtherGroups;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewUsersGroups;
        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.CheckBox checkBoxIsAdmin;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label label5;
    }
}