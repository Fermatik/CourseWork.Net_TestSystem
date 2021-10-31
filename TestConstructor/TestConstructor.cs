using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLibrary;

namespace TestConstructor
{
    public partial class TestConstructor : Form
    {
        private Test currentTest;
        private BindingList<Question> bindingListQuestions;
        private BindingList<Answer> bindingListAnswers;

        public TestConstructor()
        {
            InitializeComponent();
            DirectoryAndFileTests.InitDirectory(DirectoryAndFileTests.NameDirectoryForTests);
            DirectoryAndFileTests.InitDirectory(DirectoryAndFileTests.nameDirectoryForImage);
            ClearForm();
        }

        private void InitDataGridViewQuestion(List<Question> questions)
        {
            bindingListQuestions = new BindingList<Question>(questions);
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

        private void InitDataGridViewAnswers(List<Answer> answers)
        {
            bindingListAnswers = new BindingList<Answer>(answers);
            dataGridViewAnswers.DataSource = bindingListAnswers;
            dataGridViewAnswers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridViewAnswers.RowHeadersVisible = false;

            dataGridViewAnswers.Columns["Text"].HeaderText = "Text of answer";
            dataGridViewAnswers.Columns["Text"].Width = 375;

            dataGridViewAnswers.Columns["IsTrue"].HeaderText = "Is true answer";
            dataGridViewAnswers.Columns["IsTrue"].Width = 160;
            dataGridViewAnswers.Columns["IsCorrectAnswer"].Visible = false;
            dataGridViewAnswers.Columns["IsCheckUser"].Visible = false;
            dataGridViewAnswers.Columns["Id"].Visible = false;
            
        }


        private void dataGridViewQuestions_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewQuestions.SelectedRows.Count == 0) 
            {
                dataGridViewAnswers.DataSource = null;
                pictureBoxImage.Image = null;                
                buttonEdit.Enabled = false;
                buttonDelete.Enabled = false;
            }
            else
            {   
                buttonEdit.Enabled = true;
                buttonDelete.Enabled = true;

                int selectedRow = dataGridViewQuestions.SelectedRows[0].Index;            
                InitDataGridViewAnswers(currentTest.questions[selectedRow].answers);
                
                if (currentTest.questions[selectedRow].GetImage(out Bitmap bitmap))
                    pictureBoxImage.Image = bitmap;
                else
                    pictureBoxImage.Image = null;
            }
        }

        private void toolStripMenuItemCreateNew_Click(object sender, EventArgs e)
        {
            SaveTestFromFormToFile(currentTest);
            ClearForm();

            string name = DirectoryAndFileTests.GetNewNameForTest();
            
            currentTest = new Test();    
            
            string path = Path.Combine(DirectoryAndFileTests.NameDirectoryForTests, name + DirectoryAndFileTests.ExtentionFileForTest);
            
            if (!ObjectAndBinary<TestLibrary.Test>.SaveToFile (path, currentTest))
            {
                currentTest = null;
                MessageBox.Show("Error save file");
                return;
            }

            currentTest.FullPathFile = Path.GetFullPath( path);

            InitDataGridViewQuestion(currentTest.questions);

            buttonAdd.Enabled = true;

            panelTestInfo.Enabled = true;
            panelQuestion.Enabled = true;
            dataGridViewAnswers.Enabled = true;
            dataGridViewQuestions.Enabled = true;
            pictureBoxImage.Enabled = true;

            toolStripMenuItemSave.Enabled = true;
            toolStripMenuItemClose.Enabled = true;

            this.toolStripStatusLabel1.Text = currentTest.FullPathFile;

            textBoxAuthor.Focus();
        }

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Test files(*.test)|*.test|All files(*.*)|*.*";            
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Open test file:";
            openFileDialog1.InitialDirectory = Path.GetFullPath(DirectoryAndFileTests.NameDirectoryForTests);
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            if (!TestLibrary.ObjectAndBinary<TestLibrary.Test>.LoadFromFile(openFileDialog1.FileName, out currentTest))
            {
                MessageBox.Show($"Invalid test file format!\nFile: {openFileDialog1.FileName}\nPlease choose another file whith extensions  .test ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            currentTest.FullPathFile = openFileDialog1.FileName;

            buttonAdd.Enabled = true;

            panelTestInfo.Enabled = true;
            panelQuestion.Enabled = true;
            dataGridViewAnswers.Enabled = true;
            dataGridViewQuestions.Enabled = true;
            pictureBoxImage.Enabled = true;

            toolStripMenuItemSave.Enabled = true;
            toolStripMenuItemClose.Enabled = true;

            LoadToForm(currentTest);
        }

        private void LoadToForm(Test test)
        {
            if (test != null)
            {
                textBoxAuthor.Text = test.Author;
                textBoxTitle.Text = test.Title;
                textBoxDescription.Text = test.Description;
                textBoxInfoForTestTaker.Text = test.InfoForTestTaker;
                textBoxMaximumPoints.Text = test.MaximumPoints.ToString();
                numericUpDownMinimumPassingPercent.Value = (decimal)test.MinimumPassingPercent * 100;
                textBoxCountQuestion.Text = test.CountQuestion.ToString();
                toolStripStatusLabel1.Text = test.FullPathFile;
                
                InitDataGridViewQuestion(test.questions);

                if (test.questions.Count > 0)
                    dataGridViewQuestions.Rows[0].Selected = true;

            }


        }

        private void SaveFormToTest(Test test)
        {   
            test.Author = textBoxAuthor.Text;
            test.Title = textBoxTitle.Text;
            test.Description = textBoxDescription.Text;
            test.InfoForTestTaker = textBoxInfoForTestTaker.Text;
            test.MinimumPassingPercent = (float)numericUpDownMinimumPassingPercent.Value / 100;            
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {   
            this.Close();
        }

        private void toolStripMenuItemSave_Click(object sender, EventArgs e)
        {
            if (currentTest == null) return;

            SaveFormToTest(currentTest);

            if (!ObjectAndBinary<Test>.SaveToFile(currentTest.FullPathFile, currentTest))
            {
                MessageBox.Show($"Error save test file [{currentTest.FullPathFile}]");
                return;
            }

        }

        private void SaveTestFromFormToFile(Test test)
        {
            if (test == null) return;

            if (ObjectAndBinary<Test>.LoadFromFile(test.FullPathFile, out Test testOnDisc))
            {
                SaveFormToTest(test);

                if (!test.Equals(testOnDisc))
                {
                    if (MessageBox.Show("Save current test?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ObjectAndBinary<Test>.SaveToFile(test.FullPathFile, test);
                    }
                }
            }
        }

        private void toolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            panelTestInfo.Enabled = false;
            dataGridViewAnswers.Enabled = false;
            dataGridViewQuestions.Enabled = false;
            pictureBoxImage.Enabled = false;

            SaveTestFromFormToFile(currentTest);

            ClearForm();
        }

        private void ClearForm()
        {
            currentTest = null;

            panelTestInfo.Enabled = false;
            panelQuestion.Enabled = false;
            dataGridViewAnswers.Enabled = false;
            dataGridViewQuestions.Enabled = false;
            pictureBoxImage.Enabled = false;

            textBoxAuthor.Text = String.Empty;
            textBoxDescription.Text = String.Empty;
            textBoxInfoForTestTaker.Text = String.Empty;
            textBoxMaximumPoints.Text = String.Empty;
            textBoxTitle.Text = String.Empty;
            numericUpDownMinimumPassingPercent.Value = 0;
            textBoxCountQuestion.Text = String.Empty;

            dataGridViewQuestions.DataSource = null;
            dataGridViewAnswers.DataSource = null;
            pictureBoxImage.Image = null;

            toolStripMenuItemSave.Enabled = false;
            toolStripMenuItemClose.Enabled = false;

            buttonAdd.Enabled = false;
            buttonEdit.Enabled = false;
            buttonDelete.Enabled = false;
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddEditQuestion formAddQuestion = new AddEditQuestion(null);
            formAddQuestion.Text = "Add new question";
            
            if (formAddQuestion.ShowDialog() == DialogResult.OK)
            {   
                bindingListQuestions.Add(formAddQuestion.currentQuestion);
                currentTest.questions = bindingListQuestions.ToList();

                if (dataGridViewQuestions.Rows.Count > 0)
                {
                        int index = dataGridViewQuestions.Rows.Count - 1;
                        dataGridViewQuestions.Rows[index].Selected = true;
                }

                this.textBoxCountQuestion.Text = currentTest.CountQuestion.ToString();
                this.textBoxMaximumPoints.Text = currentTest.MaximumPoints.ToString();
            }           
            
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewQuestions.SelectedRows.Count > 0)
            {
                int index = dataGridViewQuestions.SelectedRows[0].Index;

                AddEditQuestion formEditQuestion = new AddEditQuestion(currentTest.questions[index]);
                formEditQuestion.Text = "Edit question";
                if (formEditQuestion.ShowDialog() == DialogResult.OK)
                {
                    bindingListQuestions[index] = formEditQuestion.currentQuestion;
                    currentTest.questions = bindingListQuestions.ToList();                    
                    dataGridViewQuestions.Rows[index].Selected = true;

                    this.textBoxCountQuestion.Text = currentTest.CountQuestion.ToString();
                    this.textBoxMaximumPoints.Text = currentTest.MaximumPoints.ToString();

                    InitDataGridViewAnswers(currentTest.questions[index].answers);

                    if (currentTest.questions[index].GetImage(out Bitmap bitmap))
                        pictureBoxImage.Image = bitmap;
                    else
                        pictureBoxImage.Image = null;
                }
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewQuestions.SelectedRows.Count > 0)
            {
                int index = dataGridViewQuestions.SelectedRows[0].Index;
                bindingListQuestions.RemoveAt(index);
                currentTest.questions = bindingListQuestions.ToList();

                this.textBoxCountQuestion.Text = currentTest.CountQuestion.ToString();
                this.textBoxMaximumPoints.Text = currentTest.MaximumPoints.ToString();
            }
        }

        private void TestConstructor_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveTestFromFormToFile(currentTest);            
        }
    }
}
