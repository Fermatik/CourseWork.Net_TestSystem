using ClientServer;
using DAL;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using TestLibrary;

namespace TestServer
{
    public class ClientObject
    {   
        TcpClient tcpClient;
        TcpListener tcpListener;
        GenericUnitOfWork work;
        IGenericRepository<DAL.User> repoUsers;
        IGenericRepository<DAL.Group> repoGroups;
        IGenericRepository<DAL.TestUser> repoTestUsers;
        IGenericRepository<DAL.Test> repoTests;
        IGenericRepository<DAL.Question> repoQuestions;
        IGenericRepository<DAL.Answer> repoAnswers;
        IGenericRepository<DAL.UserAnswer> repoUserAnswers;
        FormMain formMain;

        private const int BUFFER_SIZE = 2048;
        
        public ClientObject
            (
                FormMain formMain,
                TcpClient tcpClient, 
                TcpListener tcpListener,                 
                IGenericRepository<DAL.User> repoUsers, 
                IGenericRepository<DAL.Group> repoGroups,
                IGenericRepository<DAL.TestUser> repoTestUsers,
                IGenericRepository<DAL.Test> repoTests,
                IGenericRepository<DAL.Question> repoQuestions,
                IGenericRepository<DAL.Answer> repoAnswers,
                IGenericRepository<DAL.UserAnswer> repoUserAnswers
            )
        {
            this.formMain = formMain;
            this.tcpClient = tcpClient;            
            this.tcpListener = tcpListener;
            this.repoUsers = repoUsers;
            this.repoGroups = repoGroups;
            this.repoTestUsers = repoTestUsers;
            this.repoTests = repoTests;
            this.repoQuestions = repoQuestions;
            this.repoAnswers = repoAnswers;
            this.repoUserAnswers = repoUserAnswers;

        }

        public void Process()
        {
            NetworkStream networkStream = null;

            try
            {
                networkStream = tcpClient.GetStream();
                MessageClientServer mcs = new MessageClientServer();
                byte[] data = new byte[BUFFER_SIZE];
                bool flagClose = false;
                
                while (true)
                {
                    List<byte> fullData = new List<byte>();                    
                    int countBytes = 0;
                    do
                    {
                        countBytes = networkStream.Read(data, 0, data.Length);
                        for (int i = 0; i < countBytes; i++)
                            fullData.Add(data[i]);
                    }
                    while (networkStream.DataAvailable);

                    mcs = MessageClientServer.GetObject(fullData.ToArray());

                    if (mcs == null) continue;


                    DAL.User user;
                    TestLibrary.TestUser testUser;
                    TestLibrary.Test testTL;
                    DAL.Test resTest;
                    DAL.TestUser testUserDAL;
                    DAL.UserAnswer userAnswer;                    
                    byte[] responseBytes;

                    switch (mcs.TypeMessage)
                    {
                        // запрос на авторизацию от клиента
                        case TypeMessage.AutorizationRequest:
                            user = (DAL.User)mcs.ObjectMessage;
                            var findUser = repoUsers.FirstOrDefault(x => x.Login == user.Login && x.Password == user.Password);
                            mcs.TypeMessage = TypeMessage.AutorizationResponse;
                            if (findUser == null)
                            {
                                mcs.TextMessage = TextMessageClientServer.AUTHORIZATION_UNSUCCESSFUL;
                                mcs.SubTextMessage = $"Incorrect login or password!";
                            }
                            else
                            {
                                user.Id = findUser.Id;
                                user.FirstName = findUser.FirstName;
                                user.LastName = findUser.LastName;
                                user.IsAdmin = findUser.IsAdmin;

                                if (formMain.serverClients.Contains(user))
                                {
                                    mcs.TextMessage = TextMessageClientServer.AUTHORIZATION_UNSUCCESSFUL;
                                    mcs.SubTextMessage = $"User with login [{findUser.Login}] has already connected to the server!";
                                }
                                else
                                {
                                    mcs.TextMessage = TextMessageClientServer.AUTHORIZATION_SUCCESSFUL;
                                    
                                    formMain.listBoxClients.Invoke(new Action(() => 
                                    {
                                        formMain.serverClients.Add(user);
                                    }));
                                }
                            }
                            
                            mcs.GetBytes(out responseBytes);
                            networkStream.Write(responseBytes, 0, responseBytes.Length);
                            break;
                        // сообщение о закрытии клиента
                        case TypeMessage.ClientClose:
                            flagClose = true;                            
                            user = (DAL.User)mcs.ObjectMessage;                            
                            formMain.listBoxClients.Invoke(new Action(() =>
                            {
                                formMain.serverClients.Remove(user);
                            }));
                            break;

                        // запрос на получение списка всех новых тестов для клиента
                        case TypeMessage.ListTestRequest:
                            user = (DAL.User)mcs.ObjectMessage;
                            var result = repoTestUsers.FindAll(x => x.User.Id == user.Id && x.ResultPoints==null && x.ResultTest==null).ToList();

                            List<TestLibrary.TestUser> testUsers = new List<TestLibrary.TestUser>();
                            foreach (var item in result)
                                testUsers.Add(TestUserClone.CloneTestUserDal(item));
                            
                            mcs.TypeMessage = TypeMessage.ListTestResponse;
                            mcs.TextMessage = String.Empty;
                            mcs.SubTextMessage = String.Empty;
                            mcs.ObjectMessage = testUsers;

                            mcs.GetBytes(out responseBytes);
                            networkStream.Write(responseBytes, 0, responseBytes.Length);                            
                            break;

                        // запрос на получения конкретного теста для клиента
                        case TypeMessage.TestRequest:
                            testUser = (TestLibrary.TestUser)mcs.ObjectMessage;
                            resTest = repoTests.FirstOrDefault(x => x.Id == testUser.Test_Id);
                            testTL = new TestLibrary.Test()
                            {
                                TestUser_Id = testUser.TestUser_Id,
                                Test_Id = resTest.Id,
                                Title = resTest.Title,
                                Author = resTest.Author,
                                Description = resTest.Description,
                                InfoForTestTaker = resTest.Info,
                                MinimumPassingPercent = (float)(resTest.Percent) / 100                            
                            };

                            foreach (var question in resTest.Questions)
                            {
                                TestLibrary.Question questionTL =  new TestLibrary.Question() 
                                { 
                                    Text = question.Text,
                                    Points = question.Points,
                                    Image = question.Image
                                };
                                foreach (var answer in question.Answers)
                                {
                                    questionTL.answers.Add(new TestLibrary.Answer()
                                    {
                                        Text = answer.Text,
                                        IsTrue = answer.IsTrue,
                                        IsCheckUser = false,
                                        Id = answer.Id
                                    });
                                }
                                testTL.questions.Add(questionTL);
                            }
                            mcs.TypeMessage = TypeMessage.TestResponse;
                            mcs.TextMessage = String.Empty;
                            mcs.SubTextMessage = String.Empty;
                            mcs.ObjectMessage = testTL;

                            mcs.GetBytes(out responseBytes);
                            networkStream.Write(responseBytes, 0, responseBytes.Length);                            

                            break;

                        // получение сервером заполненого теста, для внесению в базу данных
                        case TypeMessage.ResultTest:
                            testTL = (TestLibrary.Test)mcs.ObjectMessage;
                            testUserDAL = repoTestUsers.FirstOrDefault( x => x.Id == testTL.TestUser_Id);

                            if (testUserDAL.ResultPoints != null || testUserDAL.ResultTest != null)
                            {
                                System.Windows.Forms.MessageBox.Show($"Попытка повторного внесеня результатолв!\nId TestUser = {testUserDAL.Id}");
                                break; 
                            }

                            testUserDAL.ResultPoints = testTL.GetResultPoints();
                            testUserDAL.ResultTest = testTL.GetResultTest();
                            repoTestUsers.Update(testUserDAL);

                            foreach (var question in testTL.questions)
                            {
                                foreach (var answer in question.answers)
                                {
                                    if (answer.IsCheckUser)
                                    {
                                        userAnswer = new UserAnswer()
                                        {
                                            TestUser = testUserDAL,
                                            Answer = repoAnswers.FirstOrDefault( x => x.Id == answer.Id)
                                        };
                                        repoUserAnswers.Add(userAnswer);
                                    }
                                }
                            }

                            formMain.listBoxClients.Invoke(new Action(() =>
                            {
                                formMain.InitDataGridViewTestUser();
                                formMain.testsUserResultTest.Add(testUserDAL);
                            }));
                            break;

                        // запрос на получения результатов тестирования с сервера для клиента
                        case TypeMessage.ResultTestRequest:
                            user = (DAL.User)mcs.ObjectMessage;
                            var result1 = repoTestUsers.FindAll(x => x.User.Id == user.Id && (x.ResultPoints != null || x.ResultTest != null)).ToList();

                            List<TestLibrary.TestUser> testUsers1 = new List<TestLibrary.TestUser>();
                            foreach (var item in result1)
                                testUsers1.Add(TestUserClone.CloneTestUserDal(item));

                            mcs.TypeMessage = TypeMessage.ResultTestResponse;
                            mcs.TextMessage = String.Empty;
                            mcs.SubTextMessage = String.Empty;
                            mcs.ObjectMessage = testUsers1;

                            mcs.GetBytes(out responseBytes);
                            networkStream.Write(responseBytes, 0, responseBytes.Length);
                            break;                            
                    }

                    if (flagClose) break;
                    
                }
            }
            catch (SocketException ex)
            {
                System.Windows.Forms.MessageBox.Show("SocketException ClientObject: {0}", ex.Message);
                
            }
            finally
            {

                networkStream?.Close();
            }
        }
        
    }
}
