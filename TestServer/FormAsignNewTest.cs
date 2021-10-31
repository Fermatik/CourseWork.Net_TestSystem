using DAL;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestServer
{
    public partial class FormAsignNewTest : Form
    {
        IGenericRepository<User> repoUsers;
        IGenericRepository<Group> repoGroups;
        IGenericRepository<Test> repoTests;
        IGenericRepository<TestUser> repoTestUsers;
        public Test currentTest;
        List<Test> tests;

        List<User> users;
        List<Group> groups;

        public FormAsignNewTest(Test currentTest, IGenericRepository<Group> repoGroups, IGenericRepository<User> repoUsers, IGenericRepository<Test> repoTests, IGenericRepository<TestUser> repoTestUsers)
        {
            InitializeComponent();
            this.repoGroups = repoGroups;
            this.repoUsers = repoUsers;
            this.repoTests = repoTests;
            this.repoTestUsers = repoTestUsers;
            this.currentTest = currentTest;

            tests = repoTests.GetAllData().ToList();
            users = repoUsers.GetAllData().ToList();
            groups = repoGroups.GetAllData().ToList();

            comboBoxTests.DataSource = tests;
            comboBoxTests.SelectedItem = currentTest;

            InitDataGridView();

        }

        private void InitDataGridView()
        {
            if (this.radioButtonUser.Checked == true)
            {
                labelDataGridView.Text = "Select user:";
                dataGridView.DataSource = users;
                dataGridView.Columns["Login"].Visible = false;
                dataGridView.Columns["Password"].Visible = false;
                dataGridView.Columns["Groups"].Visible = false;
                dataGridView.Columns["TestUsers"].Visible = false;
                dataGridView.ClearSelection();
                return;
            }
            
            if (this.radioButtonGroup.Checked == true)
            {
                labelDataGridView.Text = "Select group:";
                dataGridView.DataSource = groups;
                dataGridView.Columns["Users"].Visible = false;
                dataGridView.ClearSelection();
            }
            else 
            {
                dataGridView.DataSource = null;
                labelDataGridView.Text = "";
            }

        }


        private void comboBoxTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTest = tests[comboBoxTests.SelectedIndex];
            textBoxId.Text = currentTest.Id.ToString();
            textBoxAuthor.Text = currentTest.Author;
            textBoxTitle.Text = currentTest.Title;
            textBoxDescription.Text = currentTest.Description;
            textBoxInfo.Text = currentTest.Info;
            textBoxPercent.Text = currentTest.Percent.ToString();
            
        }

        private void radioButtonUser_CheckedChanged(object sender, EventArgs e)
        {
            InitDataGridView();
        }

        private void radioButtonGroup_CheckedChanged(object sender, EventArgs e)
        {
            InitDataGridView();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
                buttonAsign.Enabled = true;
            else
                buttonAsign.Enabled = false;
            
        }

        private void buttonAsign_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;            

            if (this.radioButtonUser.Checked)
            {
                for (int i = 0; i < dataGridView.SelectedRows.Count; i++)
                {
                    int index = dataGridView.SelectedRows[i].Index;
                    TestUser newTestUser = new TestUser() 
                    {
                        Date = now,
                        User = users[index],
                        Test = currentTest,
                        ResultPoints=null,
                        ResultTest=null
                    };
                    repoTestUsers.Add(newTestUser);
                }
                return;
            }
            
            if (this.radioButtonGroup.Checked)
            {
                for (int i = 0; i < dataGridView.SelectedRows.Count; i++)
                {
                    int index = dataGridView.SelectedRows[i].Index;
                    var allUser = repoUsers.GetAllData().ToList();

                    foreach (var user in allUser)
                    {
                        if (user.Groups.Contains(groups[index]))
                        {
                            TestUser newTestUser = new TestUser()
                            {
                                Date = now,
                                User = user,
                                Test = currentTest,
                                ResultPoints = null,
                                ResultTest = null
                            };
                            repoTestUsers.Add(newTestUser);
                        }
                    }
                }
            }
        }
    }
}
