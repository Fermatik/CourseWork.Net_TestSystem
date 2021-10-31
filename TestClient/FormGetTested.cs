using DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestClient
{
    public partial class FormGetTested : Form
    {
        const int MAX_COUNT_QUESTION_VISIBLE_INDICATORS = 40;
        private TestLibrary.Test currentTest;
        private BindingList<TestLibrary.Question> bindingListQuestions;
        private BindingList<TestLibrary.Answer> bindingListAnswers;

        PanelIndicateQuestions piq = null;

        private NetworkStream networkStream;
        public FormGetTested(TestLibrary.Test currentTest, NetworkStream networkStream)
        {
            InitializeComponent();
            this.currentTest = currentTest;
            this.Text += $" [Id test: {currentTest.Test_Id}]";
            this.networkStream = networkStream;

            textBoxTitle.Text = currentTest.Title;
            textBoxAuthor.Text = currentTest.Author;
            textBoxDescription.Text = currentTest.Description;
            textBoxInfoForTestTaker.Text = currentTest.InfoForTestTaker;
            textBoxMaximumPoints.Text = currentTest.MaximumPoints.ToString();
            textBoxCountQuestion.Text = currentTest.CountQuestion.ToString();
            textBoxPercent.Text = (currentTest.MinimumPassingPercent * 100).ToString();

            InitDataGridViewQuestion(currentTest.questions);

           
            if (currentTest.CountQuestion <= MAX_COUNT_QUESTION_VISIBLE_INDICATORS)
            {
                piq = new PanelIndicateQuestions(panelIndicatorQuestion, currentTest.CountQuestion, MAX_COUNT_QUESTION_VISIBLE_INDICATORS);
                foreach (var button in piq.Buttons)
                {
                    button.Click += Button_Click;
                }
            }
            
            
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = (int)btn.Tag;            
            dataGridViewQuestions.Focus();
            dataGridViewQuestions.ClearSelection();
            dataGridViewQuestions.Rows[index].Selected = true;
            dataGridViewQuestions.FirstDisplayedScrollingRowIndex = index;
        }

        private void InitDataGridViewQuestion(List<TestLibrary.Question> questions)
        {
            bindingListQuestions = new BindingList<TestLibrary.Question>(questions);
           
            dataGridViewQuestions.DataSource = bindingListQuestions;

            dataGridViewQuestions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewQuestions.MultiSelect = false;
            dataGridViewQuestions.RowHeadersVisible = false;

            dataGridViewQuestions.Columns["IsCorrect"].Visible = false;
            dataGridViewQuestions.Columns["IsNotCheckUser"].Visible = false;

            dataGridViewQuestions.Columns["Text"].HeaderText = "Text of question";
            dataGridViewQuestions.Columns["Text"].Width = 600;

            dataGridViewQuestions.Columns["Points"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewQuestions.Columns["Points"].Width = 80;

            dataGridViewQuestions.Columns["CountAnswers"].HeaderText = "Count of answers";
            dataGridViewQuestions.Columns["CountAnswers"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewQuestions.Columns["CountAnswers"].Width = 80;

        }

        private void InitDataGridViewAnswers(List<TestLibrary.Answer> answers)
        {
            bindingListAnswers = new BindingList<TestLibrary.Answer>(answers);
            
            dataGridViewAnswers.DataSource = bindingListAnswers;
            
            dataGridViewAnswers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridViewAnswers.RowHeadersVisible = false;
            dataGridViewAnswers.Columns["Text"].HeaderText = "Text of answer";
            dataGridViewAnswers.Columns["Text"].Width = 375;
            dataGridViewAnswers.Columns["Text"].ReadOnly = true;
            dataGridViewAnswers.Columns["IsCheckUser"].HeaderText = "Select true answers";
            dataGridViewAnswers.Columns["IsCheckUser"].Width = 160;
            dataGridViewAnswers.Columns["IsCorrectAnswer"].Visible = false;
            dataGridViewAnswers.Columns["IsTrue"].Visible = false;
            dataGridViewAnswers.Columns["Id"].Visible = false;

            if (piq != null)
            {
                for (int i = 0; i < bindingListQuestions.Count; i++)
                {
                    if (bindingListQuestions[i].IsNotCheckUser)
                        piq.Buttons[i].BackColor = Color.Red;
                    else
                        piq.Buttons[i].BackColor = Color.Green;
                }

            }

        }

        private void OcListAnswers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void dataGridViewQuestions_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewQuestions.SelectedRows.Count == 0)
            {
                dataGridViewAnswers.DataSource = null;
                pictureBoxImage.Image = null;
                
                buttonClearSelectTrueAnswer.Enabled = false;
            }
            else
            {                
                buttonClearSelectTrueAnswer.Enabled = true;

                int selectedRow = dataGridViewQuestions.SelectedRows[0].Index;
                InitDataGridViewAnswers(currentTest.questions[selectedRow].answers);

                if (currentTest.questions[selectedRow].GetImage(out Bitmap bitmap))
                    pictureBoxImage.Image = bitmap;
                else
                    pictureBoxImage.Image = null;
            }
        }

        private void buttonClearSelectTrueAnswer_Click(object sender, EventArgs e)
        {   
            int index = dataGridViewQuestions.SelectedRows[0].Index;
            for (int i = 0; i < currentTest.questions[index].answers.Count; i++)
            {
                currentTest.questions[index].answers[i].IsCheckUser = false;
            }

            InitDataGridViewAnswers(currentTest.questions[index].answers);

        }

        private void buttonFinishTested_Click(object sender, EventArgs e)
        {
            if (!IsAllAnswerUser())
            {
                if (MessageBox.Show("Not all questions have been answered.\n\nDo you want to finish testing anyway?", "Question to user", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
            }

            int resultPoints = currentTest.GetResultPoints();
            float resultPercent = (float)resultPoints / currentTest.MaximumPoints;

            string str =    $"Maximum points: {currentTest.MaximumPoints.ToString()}\n" +
                            $"Result points: {resultPoints.ToString()}\n\n" +
                            $"Minimum percent: {(currentTest.MinimumPassingPercent * 100).ToString("F2")} %\n" +
                            $"You percent: { (resultPercent * 100).ToString("F2")} %\n\n";

            if (currentTest.GetResultTest())
                str += "Congratulations, you passed the test successfully!";
            else
                str += "Sorry, you didn't pass the test!";

            MessageClientServer mcs = new MessageClientServer(TypeMessage.ResultTest, String.Empty, String.Empty, currentTest);
            mcs.GetBytes(out byte[] sendByte);
            networkStream.Write(sendByte, 0, sendByte.Length);

            MessageBox.Show(str, "Result test", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private bool IsAllAnswerUser()
        {
            foreach (var question in currentTest.questions)
            {
                bool result = false;
                foreach (var answer in question.answers)
                {
                    if (answer.IsCheckUser)
                    {
                        result = true;
                        break;
                    }
                }
                if (result == false) return false;
            }

            return true;
        }


        private void dataGridViewAnswers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewAnswers.Columns[e.ColumnIndex].Name == "IsCheckUser")
            {                
                dataGridViewAnswers.Invalidate();

                if (piq != null)
                {
                    int i = dataGridViewQuestions.SelectedRows[0].Index;
                    if (bindingListQuestions[i].IsNotCheckUser)                        
                        piq.Buttons[i].BackColor = Color.Red;
                    else
                        piq.Buttons[i].BackColor = Color.Green;
                    

                }
            }
        }

        private void dataGridViewAnswers_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewAnswers.IsCurrentCellDirty)
            {
                dataGridViewAnswers.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
