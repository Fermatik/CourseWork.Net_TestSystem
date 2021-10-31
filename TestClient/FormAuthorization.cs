using ClientServer;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLibrary;

namespace TestClient
{
    public partial class FormAuthorization : Form
    {
        private const string SERVER = "127.0.0.1";
        private const int PORT = 8080;
        private const int BUFFER_SIZE = 4096;
        private TcpClient tcpClient;
        NetworkStream networkStream;
        public FormAuthorization()
        {
            InitializeComponent();            
        }

        private void CheckDataForm()
        {
            if (this.textBoxPassword.Text == String.Empty || this.textBoxLogin.Text == String.Empty)
                this.buttonLogIn.Enabled = false;
            else
                this.buttonLogIn.Enabled = true;
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {   
            try
            {
                tcpClient = new TcpClient(SERVER, PORT);
                networkStream = tcpClient.GetStream();

                MessageClientServer request = new MessageClientServer();
                request.TypeMessage = TypeMessage.AutorizationRequest;                
                request.ObjectMessage = new User() { Login = textBoxLogin.Text, Password = textBoxPassword.Text };
                request.GetBytes(out byte[] requestBytes);                
                networkStream.Write(requestBytes, 0, requestBytes.Length);

                byte[] data = new byte[BUFFER_SIZE];
                int countBytes = 0;
                List<byte> fullData = new List<byte>();
                
                do
                {
                    countBytes = networkStream.Read(data, 0, data.Length);
                    for (int i = 0; i < countBytes; i++)
                        fullData.Add(data[i]);                    
                }
                while (networkStream.DataAvailable);

                MessageClientServer mcs_response = MessageClientServer.GetObject(fullData.ToArray());                
                
                fullData.Clear();

                if (mcs_response.TypeMessage == TypeMessage.AutorizationResponse &&
                    mcs_response.TextMessage == TextMessageClientServer.AUTHORIZATION_SUCCESSFUL)
                {
                    this.Visible = false;
                    FormClient formClient = new FormClient((DAL.User)mcs_response.ObjectMessage, tcpClient, networkStream);                    
                    formClient.ShowDialog();

                    this.Close();
                }
                else
                {
                    MessageBox.Show(mcs_response.TextMessage + "\n\n" + mcs_response.SubTextMessage, "Authorization", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SocketException ex)
            {   
                MessageBox.Show(ex.Message, "Connect server", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
            finally
            {
                networkStream?.Close();
                tcpClient?.Close();
            }
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            CheckDataForm();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            CheckDataForm();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {   
            this.Close();
        }

        private void FormAuthorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            networkStream?.Close();
            tcpClient?.Close();
        }
    }
}
