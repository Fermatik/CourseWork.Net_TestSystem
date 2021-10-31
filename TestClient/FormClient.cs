using ClientServer;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLibrary;

namespace TestClient
{
    public partial class FormClient : Form
    {
        private DAL.User currentUser;        
        private const int BUFFER_SIZE = 4096;
        private TcpClient tcpClient;
        private NetworkStream networkStream;

        BindingList<TestLibrary.TestUser> listTestUsers;
        BindingList<TestLibrary.TestUser> listResultTest;
        public FormClient(User currentUser, TcpClient tcpClient, NetworkStream networkStream)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            this.tcpClient = tcpClient;
            this.networkStream = networkStream;
            toolStripStatusLabel1.Text = $"Current user: {currentUser.ToString()}";
            
            InitDataGridViewTestUsers();
            InitDataGridViewResultTest();
        }


        private void InitDataGridViewTestUsers()
        {
            listTestUsers = new BindingList<TestLibrary.TestUser>(GetTestUser(currentUser));
            dataGridViewResultTest.DataSource = listTestUsers;
            dataGridViewResultTest.Columns["User_Id"].Visible = false;
            dataGridViewResultTest.Columns["User_FullName"].Visible = false;
            dataGridViewResultTest.Columns["ResultPoints"].Visible = false;
            dataGridViewResultTest.Columns["ResultTest"].Visible = false;
        }
        

        private List<TestLibrary.TestUser> GetTestUser(DAL.User currentUser)
        {

            MessageClientServer mcs = new MessageClientServer(TypeMessage.ListTestRequest, String.Empty, String.Empty, currentUser);
            
            mcs.GetBytes(out byte[] sendByte);
            networkStream.Write(sendByte, 0, sendByte.Length);

            byte[] data = new byte[BUFFER_SIZE];            
            List<byte> fullData = new List<byte>();
            do
            {
                int countBytes = networkStream.Read(data, 0, data.Length);
                for (int i = 0; i < countBytes; i++)
                    fullData.Add(data[i]);
            } while (networkStream.DataAvailable);

            mcs = MessageClientServer.GetObject(fullData.ToArray());
            fullData.Clear();

            return (mcs.TypeMessage == TypeMessage.ListTestResponse) ? (List<TestLibrary.TestUser>)mcs.ObjectMessage  : new List<TestLibrary.TestUser>();

        }

        private void InitDataGridViewResultTest()
        {
            MessageClientServer mcs = new MessageClientServer(TypeMessage.ResultTestRequest, String.Empty, String.Empty, currentUser);

            mcs.GetBytes(out byte[] sendBytes);
            networkStream.Write(sendBytes, 0, sendBytes.Length);

            byte[] data = new byte[BUFFER_SIZE];
            List<byte> fullData = new List<byte>();
            do
            {
                int countBytes = networkStream.Read(data, 0, data.Length);
                for (int i = 0; i < countBytes; i++)
                    fullData.Add(data[i]);
            } while (networkStream.DataAvailable);

            mcs = MessageClientServer.GetObject(fullData.ToArray());
            fullData.Clear();

            List<TestLibrary.TestUser> result = (mcs.TypeMessage == TypeMessage.ResultTestResponse) ? (List<TestLibrary.TestUser>)mcs.ObjectMessage : new List<TestLibrary.TestUser>();

            listResultTest = new BindingList<TestLibrary.TestUser>(result);
            dataGridViewResultTestUser.DataSource = listResultTest;
            dataGridViewResultTestUser.Columns["User_Id"].Visible = false;
            dataGridViewResultTestUser.Columns["User_FullName"].Visible = false;
            
        }

        private void FormClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageClientServer mcs = new MessageClientServer(TypeMessage.ClientClose, String.Empty, String.Empty, currentUser);
            mcs.GetBytes(out byte[] sendBytes);
            networkStream.Write(sendBytes, 0, sendBytes.Length);
        }

        private void dataGridViewTestUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewResultTest.SelectedRows.Count > 0)            
                buttonGetTested.Enabled = true;            
            else            
                buttonGetTested.Enabled = false;
            
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            InitDataGridViewTestUsers();
            InitDataGridViewResultTest();

        }

        private void buttonGetTested_Click(object sender, EventArgs e)
        {
            int index = dataGridViewResultTest.SelectedRows[0].Index;
            TestLibrary.TestUser currentTest = listTestUsers[index];
            MessageClientServer mcs = new MessageClientServer(TypeMessage.TestRequest, String.Empty, String.Empty, currentTest);
            mcs.GetBytes(out byte[] sendBytes);
            networkStream.Write(sendBytes, 0, sendBytes.Length);

            byte[] data = new byte[BUFFER_SIZE];
            List<byte> fullData = new List<byte>();
            do
            {
                int countBytes = networkStream.Read(data, 0, data.Length);
                for (int i = 0; i < countBytes; i++)
                    fullData.Add(data[i]);
            } while (networkStream.DataAvailable);

            mcs = MessageClientServer.GetObject(fullData.ToArray());
            fullData.Clear();

            TestLibrary.Test test = (TestLibrary.Test)mcs.ObjectMessage;
            this.Visible = false;
            FormGetTested formGetTested = new FormGetTested(test, networkStream);
            formGetTested.ShowDialog();            
            this.Visible = true;
            toolStripProgressBar.Visible = true;
            for (int i = 0; i < 100; i++)
            {
                toolStripProgressBar.Value = i;
                Thread.Sleep(10);
            }
            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Visible = false;
            buttonRefresh_Click(null, null);
        }
    }
}
