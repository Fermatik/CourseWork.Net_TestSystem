using DAL;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLibrary;

namespace TestServer
{
    public partial class FormMain : Form
    {
        
        DAL.User currentUser;
        TestLibrary.Test currentTest;
        GenericUnitOfWork work;
        IGenericRepository<DAL.Group> repoGroups;
        IGenericRepository<DAL.User> repoUsers;
        IGenericRepository<DAL.Test> repoTests;
        IGenericRepository<DAL.Question> repoQuestions;
        IGenericRepository<DAL.Answer> repoAnswers;
        IGenericRepository<DAL.TestUser> repoTestUsers;
        IGenericRepository<DAL.UserAnswer> repoUserAnswers;
        
        BindingList<DAL.Group> groups;
        BindingList<DAL.User> groupUsers;
        BindingList<DAL.User> users;
        BindingList<DAL.Group> userGroups;
        BindingList<DAL.Test> tests;
        public BindingList<DAL.TestUser> testsUserResultTest = new BindingList<DAL.TestUser>();
        
        public BindingList<User> serverClients;        

        private Thread serverThread;

        private List<Thread> clientThreads;

        private const string SERVER = "127.0.0.1";
        private const int PORT = 8080;
        TcpListener tcpListener;
        TcpClient tcpClient;
        
        public FormMain(DAL.User currentUser)
        {
            

            InitializeComponent();
            this.currentUser = currentUser;
            serverClients = new BindingList<User>();
            this.listBoxClients.DataSource = serverClients;
            work = new GenericUnitOfWork(new Context(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString));            
            repoGroups = work.Repository<DAL.Group>();
            repoUsers = work.Repository<DAL.User>();
            repoTests = work.Repository<DAL.Test>();
            repoQuestions = work.Repository<DAL.Question>();
            repoAnswers = work.Repository<DAL.Answer>();
            repoTestUsers = work.Repository<DAL.TestUser>();
            repoUserAnswers = work.Repository<DAL.UserAnswer>();

            panelUsers.Location = panelServer.Location;
            panelServer.Location = panelServer.Location;
            panelTests.Location = panelServer.Location;
            panelResults.Location = panelServer.Location;
            panelGroups.Location = panelServer.Location;

            panelGroups.Visible = false;
            panelUsers.Visible = false;
            panelTests.Visible = false;
            panelResults.Visible = false;
            panelServer.Visible = false;

            clientThreads = new List<Thread>();
            serverThread = new Thread(new ThreadStart(Listener));            
            serverThread.IsBackground = true;
            serverThread.Start();


        }

        private void Listener()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Parse(SERVER), PORT);
                tcpListener.Start();
                while (true)
                {
                    tcpClient = tcpListener.AcceptTcpClient();
                    ClientObject clientObject = new ClientObject(this, tcpClient,  tcpListener, repoUsers, repoGroups, repoTestUsers, repoTests, repoQuestions, repoAnswers, repoUserAnswers);
                    // создаем новый поток для обслуживания нового клиента
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));

                    clientThreads.Add(clientThread);

                    clientThread.Start();
                }
            }
            catch 
            {
                
            }
            finally
            {
                
            }
        }

        
        private void InitDataGridViewGroups()
        {
            groups = new BindingList<Group>(repoGroups.GetAllData().ToList());

            dataGridViewGroups.DataSource = groups;
            dataGridViewGroups.Columns["Users"].Visible = false;
        }

        private void InitDataGridViewTests()
        {
            tests = new BindingList<DAL.Test>(repoTests.GetAllData().ToList());
            
            dataGridViewTests.DataSource = tests;
            dataGridViewTests.Columns["Questions"].Visible = false;
            dataGridViewTests.Columns["TestUsers"].Visible = false;

            if (tests.Count > 0)
                buttonAsignNewTest.Enabled = true;
            else
                buttonAsignNewTest.Enabled = false;               
            
        }

        private void InitDataGridViewGroupUsers(ICollection<User> users)
        {
            if (users == null)
            {
                this.groupUsers = null;
                dataGridViewGroupUsers.DataSource = null;
            }

            else
            {
                this.groupUsers = new BindingList<User>(users.ToList());
                dataGridViewGroupUsers.DataSource = this.groupUsers;
                dataGridViewGroupUsers.Columns["Groups"].Visible = false;
                dataGridViewGroupUsers.Columns["Login"].Visible = false;
                dataGridViewGroupUsers.Columns["Password"].Visible = false;
                dataGridViewGroupUsers.Columns["TestUsers"].Visible = false;
            }


        }

        private void dataGridViewGroups_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewGroups.SelectedRows.Count > 0)
            {
                buttonEditGroup.Enabled = true;
                buttonUpdateGroupUsers.Enabled = true;
                int selectedRow = dataGridViewGroups.SelectedRows[0].Index;
                InitDataGridViewGroupUsers(this.groups[selectedRow].Users);
            }
            else
            {
                buttonUpdateGroupUsers.Enabled = false;
                buttonEditGroup.Enabled = false;
                InitDataGridViewGroupUsers(null);
            }
        }

        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            AddEditGroup formAddGroup = new AddEditGroup(null);
            formAddGroup.Text = "Add new group";
            if (formAddGroup.ShowDialog() == DialogResult.OK)
            {
                formAddGroup.currentGroup.Name = formAddGroup.textBoxName.Text.Trim();
                repoGroups.Add(formAddGroup.currentGroup);
                InitDataGridViewGroups();
                dataGridViewGroups.Rows[dataGridViewGroups.Rows.Count - 1].Selected = true;
            }
        }

        private void buttonEditGroup_Click(object sender, EventArgs e)
        {
            int selectedRows = dataGridViewGroups.SelectedRows[0].Index;
            AddEditGroup formEditGroup = new AddEditGroup(groups[selectedRows]);
            formEditGroup.Text = "Edit group"; 
            if (formEditGroup.ShowDialog() == DialogResult.OK)
            {
                formEditGroup.currentGroup.Name = formEditGroup.textBoxName.Text.Trim();
                repoGroups.Update(formEditGroup.currentGroup);
                InitDataGridViewGroups();
                dataGridViewGroups.Rows[selectedRows].Selected = true;
            }
        }

        private void InitDataGridViewUsers()
        {
            users = new BindingList<User>(repoUsers.GetAllData().ToList());

            dataGridViewUsers.DataSource = users;
            dataGridViewUsers.Columns["Groups"].Visible = false;
            dataGridViewUsers.Columns["TestUsers"].Visible = false;
            dataGridViewUsers.Columns["Login"].Visible = false;
            dataGridViewUsers.Columns["Password"].Visible = false;

        }

        private void InitDataGridViewUserGroups(ICollection<Group> groups)
        {
            if (groups == null)
            {
                this.userGroups = null;
                dataGridViewUserGroups.DataSource = null;
            }
            else
            {
                this.userGroups = new BindingList<Group>(groups.ToList());
                dataGridViewUserGroups.DataSource = this.userGroups;
                dataGridViewUserGroups.Columns["Users"].Visible = false;                
            }


        }


        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            int index = dataGridViewUsers.SelectedRows[0].Index;
            AddEditUser formAddUser = new AddEditUser(null, repoUsers);
            formAddUser.Text = "Add new user";
            if (formAddUser.ShowDialog() == DialogResult.OK)
            {
                repoUsers.Add(formAddUser.startUser);
                users.Add(formAddUser.startUser);
                dataGridViewUsers.Rows[dataGridViewUsers.Rows.Count - 1].Selected = true;
            }
        }

        private void buttonEditUser_Click(object sender, EventArgs e)
        {
            int index = dataGridViewUsers.SelectedRows[0].Index;
            AddEditUser formEditUser = new AddEditUser(users[index], repoUsers);
            formEditUser.Text = "Edit user";
            if (formEditUser.ShowDialog() == DialogResult.OK)
            {   
                repoUsers.Update(formEditUser.startUser);
                users[index] = formEditUser.startUser;
            }
        }

        private void dataGridViewUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                buttonEditUser.Enabled = true;
                int index = dataGridViewUsers.SelectedRows[0].Index;                
                InitDataGridViewUserGroups(users[index].Groups);
            }
            else
            {
                buttonEditUser.Enabled = false;
                InitDataGridViewUserGroups(null);
            }
        }

        private void buttonAddToGroupUsers_Click(object sender, EventArgs e)
        {
            int index = dataGridViewGroups.SelectedRows[0].Index;
            UpdateGroupUsers updateGroupUsers = new UpdateGroupUsers(groups[index], repoGroups, repoUsers);
            updateGroupUsers.ShowDialog();
            dataGridViewGroups.ClearSelection();
            
            if (users != null)
            {
                for (int i = 0; i < groups.Count; i++)
                {
                    if (users[i].Id == updateGroupUsers.currentGroup.Id)
                    {
                        index = i;
                        break;
                    }
                }

            }

            dataGridViewGroups.Rows[index].Selected = true;
            InitDataGridViewGroupUsers(groups[index].Users);
        }

        private void buttonUpdateUserGroups_Click(object sender, EventArgs e)
        {
            int index = dataGridViewUsers.SelectedRows[0].Index;
            UpdateUserGroups updateUserGroups = new UpdateUserGroups(users[index], repoGroups, repoUsers);
            updateUserGroups.ShowDialog();
            dataGridViewUsers.ClearSelection();

            if (users != null)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Id == updateUserGroups.currentUser.Id)
                    {
                        index = i;
                        break;
                    }
                }
            }

            dataGridViewUsers.Rows[index].Selected = true;
            InitDataGridViewGroupUsers(groups[index].Users);
        }

        private void GroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitDataGridViewGroups();
            panelGroups.Visible = true;
            panelUsers.Visible = false;
            panelTests.Visible = false;
            panelResults.Visible = false;
            panelServer.Visible = false;
        }

        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitDataGridViewUsers();
            panelGroups.Visible = false;
            panelUsers.Visible = true;
            panelTests.Visible = false;
            panelResults.Visible = false;
            panelServer.Visible = false;
        }

        private void TestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitDataGridViewTests();
            InitDataGridViewTestUser();
            panelGroups.Visible = false;
            panelUsers.Visible = false;
            panelTests.Visible = true;
            panelResults.Visible = false;
            panelServer.Visible = false;
        }

        private void ResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radioButtonSelectAll.Checked = true;
            panelGroups.Visible = false;
            panelUsers.Visible = false;
            panelTests.Visible = false;
            panelResults.Visible = true;
            panelServer.Visible = false;
        }

        private void serverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelGroups.Visible = false;
            panelUsers.Visible = false;
            panelTests.Visible = false;
            panelResults.Visible = false;
            panelServer.Visible = true;
        }

        private void buttonLoadTest_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Test files(*.test)|*.test|All files(*.*)|*.*";
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Open test file:";
            openFileDialog1.InitialDirectory = Path.GetFullPath(DirectoryAndFileTests.NameDirectoryForTests);
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            if (!ObjectAndBinary<TestLibrary.Test>.LoadFromFile(openFileDialog1.FileName, out currentTest))
            {
                MessageBox.Show($"Invalid test file format!\nFile: {openFileDialog1.FileName}\nPlease choose another file whith extensions  .test ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            textBoxAuthor.Text = currentTest.Author;
            textBoxTitle.Text = currentTest.Title;
            textBoxDescription.Text = currentTest.Description;
            textBoxInfo.Text = currentTest.InfoForTestTaker;
            textBoxMaxPoints.Text = currentTest.MaximumPoints.ToString();
            textBoxCountQuestion.Text = currentTest.CountQuestion.ToString();
            textBoxPercent.Text = (currentTest.MinimumPassingPercent * 100).ToString();

            if (currentTest.IsCorrect)
            {
                buttonSaveTest.Enabled = true;
                labelErrorTest.Visible = false;
            }
            else
            {
                buttonSaveTest.Enabled = false;
                labelErrorTest.Visible = true;
            }
        }


        private void buttonSaveTest_Click(object sender, EventArgs e)
        {
            int.TryParse(textBoxPercent.Text, out int percent);

            DAL.Test newTest = new DAL.Test()
            {
                Author = currentTest.Author,
                Title = currentTest.Title,
                Description = currentTest.Description,
                Info = currentTest.InfoForTestTaker,
                Percent = percent
            };

            

            ICollection<DAL.Question> newQuestions = new List<DAL.Question>();
            foreach (var question in currentTest.questions)
            {
                DAL.Question newQuestion = new DAL.Question()
                {
                    Text = question.Text,
                    Points = question.Points,
                    Image = question.Image
                };

                ICollection <DAL.Answer> newAnswers = new List<DAL.Answer>();
                foreach (var answer in question.answers)
                {
                    newAnswers.Add(new DAL.Answer() { Text = answer.Text, IsTrue = answer.IsTrue });
                }

                newQuestion.Answers = newAnswers;
                newQuestions.Add(newQuestion);
            }

            newTest.Questions = newQuestions;

            repoTests.Add(newTest);
            InitDataGridViewTests();
            dataGridViewTests.Rows[dataGridViewTests.Rows.Count - 1].Selected = true;

            textBoxAuthor.Text = String.Empty;
            textBoxTitle.Text = String.Empty;
            textBoxDescription.Text = String.Empty;
            textBoxInfo.Text = String.Empty;
            textBoxMaxPoints.Text = String.Empty;
            textBoxCountQuestion.Text = String.Empty;
            textBoxPercent.Text = String.Empty;

            buttonSaveTest.Enabled = false;
        }

        public void InitDataGridViewTestUser()
        {
            List<DAL.TestUser> testUsers = repoTestUsers.FindAll( x=> x.ResultPoints == null || x.ResultTest == null).ToList();
            
            dataGridViewTestUser.DataSource = testUsers;
            dataGridViewTestUser.RowHeadersVisible = false;
            dataGridViewTestUser.Columns["User"].HeaderText = "[Id User]" + Environment.NewLine + "Full name user";
            dataGridViewTestUser.Columns["Test"].HeaderText = "[Id Test]" + Environment.NewLine + "Title test";
            dataGridViewTestUser.Columns["UserAnswers"].Visible = false;
            dataGridViewTestUser.Columns["ResultTest"].Visible = false;
            dataGridViewTestUser.Columns["ResultPoints"].Visible = false;

        }

        private void buttonAsignNewTest_Click(object sender, EventArgs e)
        {
            int index = dataGridViewTests.SelectedRows[0].Index;            
            FormAsignNewTest formAsignNewTest = new FormAsignNewTest(tests[index], repoGroups, repoUsers, repoTests, repoTestUsers);

            if (formAsignNewTest.ShowDialog() == DialogResult.OK)
            {
                InitDataGridViewTestUser();
                dataGridViewTestUser.Rows[dataGridViewTestUser.Rows.Count - 1].Selected = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelUsers_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {   
            if (listBoxClients.Items.Count > 0)
            {
                e.Cancel = true;
                serverToolStripMenuItem_Click(null, null);
                MessageBox.Show("You cannot close the program with connected clients!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                foreach (var item in clientThreads)
                    item.Abort();

                tcpListener?.Stop();
                tcpClient?.Close();
                System.Windows.Forms.Application.Exit();
            }            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSelect.Items.Clear();
            this.comboBoxSelect.Enabled = true;
            var allUsers = repoUsers.GetAllData();
            foreach (var user in allUsers)
                comboBoxSelect.Items.Add(user);
            comboBoxSelect.SelectedIndex = 0;

        }

        private void radioButtonSelectGroup_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSelect.Items.Clear();
            this.comboBoxSelect.Enabled = true;

            var allGroups = repoGroups.GetAllData();
            foreach (var group in allGroups)
                comboBoxSelect.Items.Add(group);
            comboBoxSelect.SelectedIndex = 0;

        }

        private void radioButtonSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSelectAll.Checked)
            {
                comboBoxSelect.SelectedItem = null;
                comboBoxSelect.Items.Clear();
                this.comboBoxSelect.Enabled = false;
                DAL.User currentUser = null;
                InitDataGridViewResultTest(currentUser);
            }
        }

        private void comboBoxSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSelect.SelectedItem is DAL.Group)
            {
                InitDataGridViewResultTest((DAL.Group)comboBoxSelect.SelectedItem);                
            }
            else
                if (comboBoxSelect.SelectedItem is DAL.User)
                    InitDataGridViewResultTest((DAL.User)comboBoxSelect.SelectedItem);
            
        }

        private void  InitDataGridViewResultTest(DAL.Group group)
        {
            dataGridViewResultTest.DataSource = null;
            List<DAL.TestUser> testUser;

            List<DAL.TestUser> allTestUser = new List<DAL.TestUser>();

            List<User> allUser = repoUsers.GetAllData().ToList();

            foreach (var user in allUser)
            {
                foreach (var g in user.Groups)
                {
                    
                    if (g.Id == group.Id)
                    {
                        testUser = repoTestUsers.FindAll(x => x.User.Id == user.Id && (x.ResultPoints != null && x.ResultTest != null)).ToList();
                        allTestUser.AddRange(testUser);
                        break;
                    }       
                }
            }

            testsUserResultTest = new BindingList<DAL.TestUser>(allTestUser);
            dataGridViewResultTest.DataSource = testsUserResultTest;
            dataGridViewResultTest.RowHeadersVisible = false;
            dataGridViewResultTest.Columns["UserAnswers"].Visible = false;
            dataGridViewResultTest.Columns["Id"].Width = 20;
        }

        private void InitDataGridViewResultTest(DAL.User user)
        {
            dataGridViewResultTest.DataSource = null;
            List<DAL.TestUser> testUser;

            if (user == null)
                testUser = repoTestUsers.FindAll(x => (x.ResultPoints != null && x.ResultTest != null)).ToList();
            else
                testUser = repoTestUsers.FindAll(x => x.User.Id == user.Id && (x.ResultPoints != null && x.ResultTest != null)).ToList();
            
            testsUserResultTest = new BindingList<DAL.TestUser>(testUser);
            dataGridViewResultTest.DataSource = testsUserResultTest;
            dataGridViewResultTest.RowHeadersVisible = false;
            dataGridViewResultTest.Columns["UserAnswers"].Visible = false;
            dataGridViewResultTest.Columns["Id"].Width = 20;
        }

        private void dataGridViewResultTest_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewResultTest.SelectedRows.Count > 0)
                buttonShowReport.Enabled = true;
            else
                buttonShowReport.Enabled = false;
        }

        private void buttonShowReport_Click(object sender, EventArgs e)
        {
            int index = dataGridViewResultTest.SelectedRows[0].Index;            
            var currentTestUser = repoTestUsers.FindById(testsUserResultTest[index].Id);
            var currentTestDAL = repoTests.FindById(currentTestUser.Test.Id);

            TestLibrary.Test currentTestTL = new TestLibrary.Test()
            {
                TestUser_Id = currentTestUser.Id,
                Test_Id = currentTestDAL.Id,
                Title = currentTestDAL.Title,
                Author = currentTestDAL.Author,
                Description = currentTestDAL.Description,
                InfoForTestTaker = currentTestDAL.Info,
                MinimumPassingPercent = (float)currentTestDAL.Percent / 100
            };

            var currentQuestions = repoQuestions.FindAll(x => x.Test.Id == currentTestTL.Test_Id).ToList();
            foreach (var question in currentQuestions)
            {
                TestLibrary.Question questionTL = new TestLibrary.Question() 
                {
                    Text = question.Text,
                    Image = question.Image,
                    Points = question.Points
                };

                var currentAnswers = repoAnswers.FindAll(x => x.Question.Id == question.Id).ToList();
                foreach (var answer in currentAnswers)
                {
                    TestLibrary.Answer answerTL = new TestLibrary.Answer() 
                    {
                        Text = answer.Text,
                        IsTrue = answer.IsTrue                        
                    };
                    var userAnswer = repoUserAnswers.FirstOrDefault(x => x.TestUser.Id == currentTestTL.TestUser_Id && x.Answer.Id == answer.Id);
                    if (userAnswer != null) answerTL.IsCheckUser = true;
                    questionTL.answers.Add(answerTL);
                }
                currentTestTL.questions.Add(questionTL);
            }

            FormShowReportTest formReport = new FormShowReportTest(currentTestTL.GetReportTest(), currentTestUser.User);
            formReport.Show();

        }
    }
}
