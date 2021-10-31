
namespace TestServer
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.GroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelGroups = new System.Windows.Forms.Panel();
            this.buttonUpdateGroupUsers = new System.Windows.Forms.Button();
            this.buttonEditGroup = new System.Windows.Forms.Button();
            this.buttonAddGroup = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewGroupUsers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewGroups = new System.Windows.Forms.DataGridView();
            this.panelUsers = new System.Windows.Forms.Panel();
            this.buttonUpdateUserGroups = new System.Windows.Forms.Button();
            this.buttonEditUser = new System.Windows.Forms.Button();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewUserGroups = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.panelTests = new System.Windows.Forms.Panel();
            this.buttonAsignNewTest = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.dataGridViewTestUser = new System.Windows.Forms.DataGridView();
            this.labelErrorTest = new System.Windows.Forms.Label();
            this.buttonSaveTest = new System.Windows.Forms.Button();
            this.textBoxPercent = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxCountQuestion = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxMaxPoints = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewTests = new System.Windows.Forms.DataGridView();
            this.buttonLoadTest = new System.Windows.Forms.Button();
            this.panelResults = new System.Windows.Forms.Panel();
            this.buttonShowReport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonSelectUsers = new System.Windows.Forms.RadioButton();
            this.radioButtonSelectGroups = new System.Windows.Forms.RadioButton();
            this.radioButtonSelectAll = new System.Windows.Forms.RadioButton();
            this.comboBoxSelect = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewResultTest = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelServer = new System.Windows.Forms.Panel();
            this.listBoxClients = new System.Windows.Forms.ListBox();
            this.label17 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panelGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroupUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).BeginInit();
            this.panelUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.panelTests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTests)).BeginInit();
            this.panelResults.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultTest)).BeginInit();
            this.panelServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GroupsToolStripMenuItem,
            this.UsersToolStripMenuItem,
            this.TestsToolStripMenuItem,
            this.ResultsToolStripMenuItem,
            this.serverToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1030, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // GroupsToolStripMenuItem
            // 
            this.GroupsToolStripMenuItem.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.GroupsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GroupsToolStripMenuItem.Name = "GroupsToolStripMenuItem";
            this.GroupsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.GroupsToolStripMenuItem.Text = "Groups";
            this.GroupsToolStripMenuItem.Click += new System.EventHandler(this.GroupsToolStripMenuItem_Click);
            // 
            // UsersToolStripMenuItem
            // 
            this.UsersToolStripMenuItem.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.UsersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsersToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UsersToolStripMenuItem.Name = "UsersToolStripMenuItem";
            this.UsersToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.UsersToolStripMenuItem.Text = "Users";
            this.UsersToolStripMenuItem.Click += new System.EventHandler(this.UsersToolStripMenuItem_Click);
            // 
            // TestsToolStripMenuItem
            // 
            this.TestsToolStripMenuItem.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TestsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TestsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TestsToolStripMenuItem.Name = "TestsToolStripMenuItem";
            this.TestsToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.TestsToolStripMenuItem.Text = "Tests";
            this.TestsToolStripMenuItem.Click += new System.EventHandler(this.TestsToolStripMenuItem_Click);
            // 
            // ResultsToolStripMenuItem
            // 
            this.ResultsToolStripMenuItem.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ResultsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ResultsToolStripMenuItem.Name = "ResultsToolStripMenuItem";
            this.ResultsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.ResultsToolStripMenuItem.Text = "Results";
            this.ResultsToolStripMenuItem.Click += new System.EventHandler(this.ResultsToolStripMenuItem_Click);
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.serverToolStripMenuItem.ForeColor = System.Drawing.Color.Purple;
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.serverToolStripMenuItem.Text = "Server";
            this.serverToolStripMenuItem.Click += new System.EventHandler(this.serverToolStripMenuItem_Click);
            // 
            // panelGroups
            // 
            this.panelGroups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGroups.Controls.Add(this.buttonUpdateGroupUsers);
            this.panelGroups.Controls.Add(this.buttonEditGroup);
            this.panelGroups.Controls.Add(this.buttonAddGroup);
            this.panelGroups.Controls.Add(this.label2);
            this.panelGroups.Controls.Add(this.dataGridViewGroupUsers);
            this.panelGroups.Controls.Add(this.label1);
            this.panelGroups.Controls.Add(this.dataGridViewGroups);
            this.panelGroups.Location = new System.Drawing.Point(1032, 1078);
            this.panelGroups.Name = "panelGroups";
            this.panelGroups.Size = new System.Drawing.Size(1000, 500);
            this.panelGroups.TabIndex = 1;
            // 
            // buttonUpdateGroupUsers
            // 
            this.buttonUpdateGroupUsers.BackColor = System.Drawing.Color.Blue;
            this.buttonUpdateGroupUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUpdateGroupUsers.ForeColor = System.Drawing.Color.White;
            this.buttonUpdateGroupUsers.Location = new System.Drawing.Point(733, 173);
            this.buttonUpdateGroupUsers.Name = "buttonUpdateGroupUsers";
            this.buttonUpdateGroupUsers.Size = new System.Drawing.Size(250, 32);
            this.buttonUpdateGroupUsers.TabIndex = 6;
            this.buttonUpdateGroupUsers.Text = "Update group user(s)";
            this.buttonUpdateGroupUsers.UseVisualStyleBackColor = false;
            this.buttonUpdateGroupUsers.Click += new System.EventHandler(this.buttonAddToGroupUsers_Click);
            // 
            // buttonEditGroup
            // 
            this.buttonEditGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditGroup.ForeColor = System.Drawing.Color.Blue;
            this.buttonEditGroup.Location = new System.Drawing.Point(733, 74);
            this.buttonEditGroup.Name = "buttonEditGroup";
            this.buttonEditGroup.Size = new System.Drawing.Size(250, 32);
            this.buttonEditGroup.TabIndex = 5;
            this.buttonEditGroup.Text = "Edit group";
            this.buttonEditGroup.UseVisualStyleBackColor = true;
            this.buttonEditGroup.Click += new System.EventHandler(this.buttonEditGroup_Click);
            // 
            // buttonAddGroup
            // 
            this.buttonAddGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddGroup.ForeColor = System.Drawing.Color.Green;
            this.buttonAddGroup.Location = new System.Drawing.Point(733, 36);
            this.buttonAddGroup.Name = "buttonAddGroup";
            this.buttonAddGroup.Size = new System.Drawing.Size(250, 32);
            this.buttonAddGroup.TabIndex = 4;
            this.buttonAddGroup.Text = "Add new group";
            this.buttonAddGroup.UseVisualStyleBackColor = true;
            this.buttonAddGroup.Click += new System.EventHandler(this.buttonAddGroup_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Group users:";
            // 
            // dataGridViewGroupUsers
            // 
            this.dataGridViewGroupUsers.AllowUserToAddRows = false;
            this.dataGridViewGroupUsers.AllowUserToDeleteRows = false;
            this.dataGridViewGroupUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroupUsers.Location = new System.Drawing.Point(15, 238);
            this.dataGridViewGroupUsers.Name = "dataGridViewGroupUsers";
            this.dataGridViewGroupUsers.ReadOnly = true;
            this.dataGridViewGroupUsers.RowHeadersWidth = 51;
            this.dataGridViewGroupUsers.RowTemplate.Height = 24;
            this.dataGridViewGroupUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGroupUsers.Size = new System.Drawing.Size(712, 239);
            this.dataGridViewGroupUsers.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Groups:";
            // 
            // dataGridViewGroups
            // 
            this.dataGridViewGroups.AllowUserToAddRows = false;
            this.dataGridViewGroups.AllowUserToDeleteRows = false;
            this.dataGridViewGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroups.Location = new System.Drawing.Point(15, 36);
            this.dataGridViewGroups.MultiSelect = false;
            this.dataGridViewGroups.Name = "dataGridViewGroups";
            this.dataGridViewGroups.ReadOnly = true;
            this.dataGridViewGroups.RowHeadersWidth = 51;
            this.dataGridViewGroups.RowTemplate.Height = 24;
            this.dataGridViewGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGroups.Size = new System.Drawing.Size(712, 169);
            this.dataGridViewGroups.TabIndex = 0;
            this.dataGridViewGroups.SelectionChanged += new System.EventHandler(this.dataGridViewGroups_SelectionChanged);
            // 
            // panelUsers
            // 
            this.panelUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUsers.Controls.Add(this.buttonUpdateUserGroups);
            this.panelUsers.Controls.Add(this.buttonEditUser);
            this.panelUsers.Controls.Add(this.buttonAddUser);
            this.panelUsers.Controls.Add(this.label3);
            this.panelUsers.Controls.Add(this.dataGridViewUserGroups);
            this.panelUsers.Controls.Add(this.label4);
            this.panelUsers.Controls.Add(this.dataGridViewUsers);
            this.panelUsers.Location = new System.Drawing.Point(12, 1078);
            this.panelUsers.Name = "panelUsers";
            this.panelUsers.Size = new System.Drawing.Size(1000, 500);
            this.panelUsers.TabIndex = 7;
            this.panelUsers.Paint += new System.Windows.Forms.PaintEventHandler(this.panelUsers_Paint);
            // 
            // buttonUpdateUserGroups
            // 
            this.buttonUpdateUserGroups.BackColor = System.Drawing.Color.Blue;
            this.buttonUpdateUserGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUpdateUserGroups.ForeColor = System.Drawing.Color.White;
            this.buttonUpdateUserGroups.Location = new System.Drawing.Point(733, 173);
            this.buttonUpdateUserGroups.Name = "buttonUpdateUserGroups";
            this.buttonUpdateUserGroups.Size = new System.Drawing.Size(250, 32);
            this.buttonUpdateUserGroups.TabIndex = 6;
            this.buttonUpdateUserGroups.Text = "Update user group(s)";
            this.buttonUpdateUserGroups.UseVisualStyleBackColor = false;
            this.buttonUpdateUserGroups.Click += new System.EventHandler(this.buttonUpdateUserGroups_Click);
            // 
            // buttonEditUser
            // 
            this.buttonEditUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditUser.ForeColor = System.Drawing.Color.Blue;
            this.buttonEditUser.Location = new System.Drawing.Point(733, 74);
            this.buttonEditUser.Name = "buttonEditUser";
            this.buttonEditUser.Size = new System.Drawing.Size(250, 32);
            this.buttonEditUser.TabIndex = 5;
            this.buttonEditUser.Text = "Edit user";
            this.buttonEditUser.UseVisualStyleBackColor = true;
            this.buttonEditUser.Click += new System.EventHandler(this.buttonEditUser_Click);
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddUser.ForeColor = System.Drawing.Color.Green;
            this.buttonAddUser.Location = new System.Drawing.Point(733, 36);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(250, 32);
            this.buttonAddUser.TabIndex = 4;
            this.buttonAddUser.Text = "Add new user";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "User groups:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // dataGridViewUserGroups
            // 
            this.dataGridViewUserGroups.AllowUserToAddRows = false;
            this.dataGridViewUserGroups.AllowUserToDeleteRows = false;
            this.dataGridViewUserGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUserGroups.Location = new System.Drawing.Point(15, 238);
            this.dataGridViewUserGroups.Name = "dataGridViewUserGroups";
            this.dataGridViewUserGroups.ReadOnly = true;
            this.dataGridViewUserGroups.RowHeadersWidth = 51;
            this.dataGridViewUserGroups.RowTemplate.Height = 24;
            this.dataGridViewUserGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUserGroups.Size = new System.Drawing.Size(712, 239);
            this.dataGridViewUserGroups.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Users:";
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.AllowUserToAddRows = false;
            this.dataGridViewUsers.AllowUserToDeleteRows = false;
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Location = new System.Drawing.Point(15, 36);
            this.dataGridViewUsers.MultiSelect = false;
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.ReadOnly = true;
            this.dataGridViewUsers.RowHeadersWidth = 51;
            this.dataGridViewUsers.RowTemplate.Height = 24;
            this.dataGridViewUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsers.Size = new System.Drawing.Size(712, 169);
            this.dataGridViewUsers.TabIndex = 0;
            this.dataGridViewUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsers_CellContentClick);
            this.dataGridViewUsers.SelectionChanged += new System.EventHandler(this.dataGridViewUsers_SelectionChanged);
            // 
            // panelTests
            // 
            this.panelTests.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTests.Controls.Add(this.buttonAsignNewTest);
            this.panelTests.Controls.Add(this.label15);
            this.panelTests.Controls.Add(this.dataGridViewTestUser);
            this.panelTests.Controls.Add(this.labelErrorTest);
            this.panelTests.Controls.Add(this.buttonSaveTest);
            this.panelTests.Controls.Add(this.textBoxPercent);
            this.panelTests.Controls.Add(this.label14);
            this.panelTests.Controls.Add(this.textBoxCountQuestion);
            this.panelTests.Controls.Add(this.label13);
            this.panelTests.Controls.Add(this.textBoxMaxPoints);
            this.panelTests.Controls.Add(this.label12);
            this.panelTests.Controls.Add(this.textBoxInfo);
            this.panelTests.Controls.Add(this.label11);
            this.panelTests.Controls.Add(this.textBoxDescription);
            this.panelTests.Controls.Add(this.label10);
            this.panelTests.Controls.Add(this.textBoxTitle);
            this.panelTests.Controls.Add(this.label9);
            this.panelTests.Controls.Add(this.textBoxAuthor);
            this.panelTests.Controls.Add(this.label6);
            this.panelTests.Controls.Add(this.label5);
            this.panelTests.Controls.Add(this.dataGridViewTests);
            this.panelTests.Controls.Add(this.buttonLoadTest);
            this.panelTests.Location = new System.Drawing.Point(1032, 42);
            this.panelTests.Name = "panelTests";
            this.panelTests.Size = new System.Drawing.Size(1000, 500);
            this.panelTests.TabIndex = 8;
            // 
            // buttonAsignNewTest
            // 
            this.buttonAsignNewTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAsignNewTest.ForeColor = System.Drawing.Color.Purple;
            this.buttonAsignNewTest.Location = new System.Drawing.Point(741, 238);
            this.buttonAsignNewTest.Name = "buttonAsignNewTest";
            this.buttonAsignNewTest.Size = new System.Drawing.Size(228, 32);
            this.buttonAsignNewTest.TabIndex = 28;
            this.buttonAsignNewTest.Text = "Asign a new test";
            this.buttonAsignNewTest.UseVisualStyleBackColor = true;
            this.buttonAsignNewTest.Click += new System.EventHandler(this.buttonAsignNewTest_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(327, 253);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(122, 17);
            this.label15.TabIndex = 26;
            this.label15.Text = "Asign test to user:";
            // 
            // dataGridViewTestUser
            // 
            this.dataGridViewTestUser.AllowUserToAddRows = false;
            this.dataGridViewTestUser.AllowUserToDeleteRows = false;
            this.dataGridViewTestUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTestUser.Location = new System.Drawing.Point(330, 279);
            this.dataGridViewTestUser.MultiSelect = false;
            this.dataGridViewTestUser.Name = "dataGridViewTestUser";
            this.dataGridViewTestUser.ReadOnly = true;
            this.dataGridViewTestUser.RowHeadersWidth = 51;
            this.dataGridViewTestUser.RowTemplate.Height = 24;
            this.dataGridViewTestUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTestUser.Size = new System.Drawing.Size(639, 185);
            this.dataGridViewTestUser.TabIndex = 25;
            // 
            // labelErrorTest
            // 
            this.labelErrorTest.AutoSize = true;
            this.labelErrorTest.ForeColor = System.Drawing.Color.Red;
            this.labelErrorTest.Location = new System.Drawing.Point(20, 214);
            this.labelErrorTest.Name = "labelErrorTest";
            this.labelErrorTest.Size = new System.Drawing.Size(495, 17);
            this.labelErrorTest.TabIndex = 24;
            this.labelErrorTest.Text = "The loaded test is invalid. Edit it in TestConstructor or choose a different one." +
    "";
            this.labelErrorTest.Visible = false;
            // 
            // buttonSaveTest
            // 
            this.buttonSaveTest.Enabled = false;
            this.buttonSaveTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSaveTest.ForeColor = System.Drawing.Color.Blue;
            this.buttonSaveTest.Location = new System.Drawing.Point(156, 238);
            this.buttonSaveTest.Name = "buttonSaveTest";
            this.buttonSaveTest.Size = new System.Drawing.Size(145, 32);
            this.buttonSaveTest.TabIndex = 23;
            this.buttonSaveTest.Text = "Save test";
            this.buttonSaveTest.UseVisualStyleBackColor = true;
            this.buttonSaveTest.Click += new System.EventHandler(this.buttonSaveTest_Click);
            // 
            // textBoxPercent
            // 
            this.textBoxPercent.Enabled = false;
            this.textBoxPercent.Location = new System.Drawing.Point(133, 444);
            this.textBoxPercent.Name = "textBoxPercent";
            this.textBoxPercent.Size = new System.Drawing.Size(168, 22);
            this.textBoxPercent.TabIndex = 22;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 447);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 17);
            this.label14.TabIndex = 21;
            this.label14.Text = "Percent:";
            // 
            // textBoxCountQuestion
            // 
            this.textBoxCountQuestion.Enabled = false;
            this.textBoxCountQuestion.Location = new System.Drawing.Point(133, 416);
            this.textBoxCountQuestion.Name = "textBoxCountQuestion";
            this.textBoxCountQuestion.Size = new System.Drawing.Size(168, 22);
            this.textBoxCountQuestion.TabIndex = 20;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 417);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 17);
            this.label13.TabIndex = 19;
            this.label13.Text = "Count question:";
            // 
            // textBoxMaxPoints
            // 
            this.textBoxMaxPoints.Enabled = false;
            this.textBoxMaxPoints.Location = new System.Drawing.Point(133, 388);
            this.textBoxMaxPoints.Name = "textBoxMaxPoints";
            this.textBoxMaxPoints.Size = new System.Drawing.Size(168, 22);
            this.textBoxMaxPoints.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 391);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 17);
            this.label12.TabIndex = 17;
            this.label12.Text = "Max points:";
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Enabled = false;
            this.textBoxInfo.Location = new System.Drawing.Point(133, 360);
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.Size = new System.Drawing.Size(168, 22);
            this.textBoxInfo.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 363);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 17);
            this.label11.TabIndex = 15;
            this.label11.Text = "Info:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Enabled = false;
            this.textBoxDescription.Location = new System.Drawing.Point(133, 332);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(168, 22);
            this.textBoxDescription.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 332);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 17);
            this.label10.TabIndex = 13;
            this.label10.Text = "Description:";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Enabled = false;
            this.textBoxTitle.Location = new System.Drawing.Point(133, 304);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(168, 22);
            this.textBoxTitle.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 309);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "Title:";
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Enabled = false;
            this.textBoxAuthor.Location = new System.Drawing.Point(133, 276);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(168, 22);
            this.textBoxAuthor.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Author:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tests on server:";
            // 
            // dataGridViewTests
            // 
            this.dataGridViewTests.AllowUserToAddRows = false;
            this.dataGridViewTests.AllowUserToDeleteRows = false;
            this.dataGridViewTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTests.Location = new System.Drawing.Point(15, 36);
            this.dataGridViewTests.MultiSelect = false;
            this.dataGridViewTests.Name = "dataGridViewTests";
            this.dataGridViewTests.ReadOnly = true;
            this.dataGridViewTests.RowHeadersWidth = 51;
            this.dataGridViewTests.RowTemplate.Height = 24;
            this.dataGridViewTests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTests.Size = new System.Drawing.Size(954, 169);
            this.dataGridViewTests.TabIndex = 7;
            // 
            // buttonLoadTest
            // 
            this.buttonLoadTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLoadTest.ForeColor = System.Drawing.Color.Green;
            this.buttonLoadTest.Location = new System.Drawing.Point(15, 238);
            this.buttonLoadTest.Name = "buttonLoadTest";
            this.buttonLoadTest.Size = new System.Drawing.Size(135, 32);
            this.buttonLoadTest.TabIndex = 7;
            this.buttonLoadTest.Text = "Load test";
            this.buttonLoadTest.UseVisualStyleBackColor = true;
            this.buttonLoadTest.Click += new System.EventHandler(this.buttonLoadTest_Click);
            // 
            // panelResults
            // 
            this.panelResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelResults.Controls.Add(this.buttonShowReport);
            this.panelResults.Controls.Add(this.panel1);
            this.panelResults.Controls.Add(this.comboBoxSelect);
            this.panelResults.Controls.Add(this.label8);
            this.panelResults.Controls.Add(this.dataGridViewResultTest);
            this.panelResults.Location = new System.Drawing.Point(12, 563);
            this.panelResults.Name = "panelResults";
            this.panelResults.Size = new System.Drawing.Size(1000, 500);
            this.panelResults.TabIndex = 9;
            // 
            // buttonShowReport
            // 
            this.buttonShowReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonShowReport.ForeColor = System.Drawing.Color.Red;
            this.buttonShowReport.Location = new System.Drawing.Point(750, 179);
            this.buttonShowReport.Name = "buttonShowReport";
            this.buttonShowReport.Size = new System.Drawing.Size(233, 32);
            this.buttonShowReport.TabIndex = 8;
            this.buttonShowReport.Text = "Show report";
            this.buttonShowReport.UseVisualStyleBackColor = true;
            this.buttonShowReport.Click += new System.EventHandler(this.buttonShowReport_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radioButtonSelectUsers);
            this.panel1.Controls.Add(this.radioButtonSelectGroups);
            this.panel1.Controls.Add(this.radioButtonSelectAll);
            this.panel1.Location = new System.Drawing.Point(750, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 106);
            this.panel1.TabIndex = 7;
            // 
            // radioButtonSelectUsers
            // 
            this.radioButtonSelectUsers.AutoSize = true;
            this.radioButtonSelectUsers.Location = new System.Drawing.Point(19, 42);
            this.radioButtonSelectUsers.Name = "radioButtonSelectUsers";
            this.radioButtonSelectUsers.Size = new System.Drawing.Size(98, 21);
            this.radioButtonSelectUsers.TabIndex = 5;
            this.radioButtonSelectUsers.Text = "select user";
            this.radioButtonSelectUsers.UseVisualStyleBackColor = true;
            this.radioButtonSelectUsers.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButtonSelectGroups
            // 
            this.radioButtonSelectGroups.AutoSize = true;
            this.radioButtonSelectGroups.Location = new System.Drawing.Point(19, 69);
            this.radioButtonSelectGroups.Name = "radioButtonSelectGroups";
            this.radioButtonSelectGroups.Size = new System.Drawing.Size(107, 21);
            this.radioButtonSelectGroups.TabIndex = 6;
            this.radioButtonSelectGroups.Text = "select group";
            this.radioButtonSelectGroups.UseVisualStyleBackColor = true;
            this.radioButtonSelectGroups.CheckedChanged += new System.EventHandler(this.radioButtonSelectGroup_CheckedChanged);
            // 
            // radioButtonSelectAll
            // 
            this.radioButtonSelectAll.AutoSize = true;
            this.radioButtonSelectAll.Location = new System.Drawing.Point(19, 15);
            this.radioButtonSelectAll.Name = "radioButtonSelectAll";
            this.radioButtonSelectAll.Size = new System.Drawing.Size(123, 21);
            this.radioButtonSelectAll.TabIndex = 4;
            this.radioButtonSelectAll.Text = "select all users";
            this.radioButtonSelectAll.UseVisualStyleBackColor = true;
            this.radioButtonSelectAll.CheckedChanged += new System.EventHandler(this.radioButtonSelectAll_CheckedChanged);
            // 
            // comboBoxSelect
            // 
            this.comboBoxSelect.Enabled = false;
            this.comboBoxSelect.FormattingEnabled = true;
            this.comboBoxSelect.Location = new System.Drawing.Point(750, 149);
            this.comboBoxSelect.Name = "comboBoxSelect";
            this.comboBoxSelect.Size = new System.Drawing.Size(233, 24);
            this.comboBoxSelect.TabIndex = 2;
            this.comboBoxSelect.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelect_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Results test:";
            // 
            // dataGridViewResultTest
            // 
            this.dataGridViewResultTest.AllowUserToAddRows = false;
            this.dataGridViewResultTest.AllowUserToDeleteRows = false;
            this.dataGridViewResultTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResultTest.Location = new System.Drawing.Point(15, 36);
            this.dataGridViewResultTest.MultiSelect = false;
            this.dataGridViewResultTest.Name = "dataGridViewResultTest";
            this.dataGridViewResultTest.ReadOnly = true;
            this.dataGridViewResultTest.RowHeadersWidth = 51;
            this.dataGridViewResultTest.RowTemplate.Height = 24;
            this.dataGridViewResultTest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewResultTest.Size = new System.Drawing.Size(729, 445);
            this.dataGridViewResultTest.TabIndex = 0;
            this.dataGridViewResultTest.SelectionChanged += new System.EventHandler(this.dataGridViewResultTest_SelectionChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panelServer
            // 
            this.panelServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelServer.Controls.Add(this.listBoxClients);
            this.panelServer.Controls.Add(this.label17);
            this.panelServer.Location = new System.Drawing.Point(12, 42);
            this.panelServer.Name = "panelServer";
            this.panelServer.Size = new System.Drawing.Size(1000, 500);
            this.panelServer.TabIndex = 10;
            // 
            // listBoxClients
            // 
            this.listBoxClients.FormattingEnabled = true;
            this.listBoxClients.ItemHeight = 16;
            this.listBoxClients.Location = new System.Drawing.Point(15, 36);
            this.listBoxClients.Name = "listBoxClients";
            this.listBoxClients.Size = new System.Drawing.Size(255, 436);
            this.listBoxClients.TabIndex = 2;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(98, 17);
            this.label17.TabIndex = 1;
            this.label17.Text = "Server clients:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 558);
            this.Controls.Add(this.panelServer);
            this.Controls.Add(this.panelResults);
            this.Controls.Add(this.panelTests);
            this.Controls.Add(this.panelUsers);
            this.Controls.Add(this.panelGroups);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "TestServer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelGroups.ResumeLayout(false);
            this.panelGroups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroupUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).EndInit();
            this.panelUsers.ResumeLayout(false);
            this.panelUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.panelTests.ResumeLayout(false);
            this.panelTests.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTests)).EndInit();
            this.panelResults.ResumeLayout(false);
            this.panelResults.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultTest)).EndInit();
            this.panelServer.ResumeLayout(false);
            this.panelServer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem GroupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ResultsToolStripMenuItem;
        private System.Windows.Forms.Panel panelGroups;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewGroups;
        private System.Windows.Forms.Button buttonAddGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewGroupUsers;
        private System.Windows.Forms.Button buttonUpdateGroupUsers;
        private System.Windows.Forms.Button buttonEditGroup;
        private System.Windows.Forms.Panel panelUsers;
        private System.Windows.Forms.Button buttonUpdateUserGroups;
        private System.Windows.Forms.Button buttonEditUser;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewUserGroups;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.Panel panelTests;
        private System.Windows.Forms.Panel panelResults;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridViewResultTest;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.Button buttonLoadTest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewTests;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPercent;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxCountQuestion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxMaxPoints;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonSaveTest;
        private System.Windows.Forms.Label labelErrorTest;
        private System.Windows.Forms.Button buttonAsignNewTest;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dataGridViewTestUser;
        private System.Windows.Forms.Panel panelServer;
        private System.Windows.Forms.Label label17;
        internal System.Windows.Forms.ListBox listBoxClients;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonSelectUsers;
        private System.Windows.Forms.RadioButton radioButtonSelectGroups;
        private System.Windows.Forms.RadioButton radioButtonSelectAll;
        private System.Windows.Forms.ComboBox comboBoxSelect;
        private System.Windows.Forms.Button buttonShowReport;
    }
}