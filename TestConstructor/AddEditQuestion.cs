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
    public partial class AddEditQuestion : Form
    {
        public Question currentQuestion;
        private Question startQuestion;
        BindingList<Answer> bindingListAnswers;

        public AddEditQuestion(Question currentQuestion)
        {
            InitializeComponent();

            buttonSave.Enabled = false;

            if (currentQuestion == null)
                this.currentQuestion = new Question();                
            else
                this.currentQuestion = currentQuestion.Clone();
            
            this.startQuestion = this.currentQuestion.Clone();

            textBoxText.Text = this.currentQuestion.Text;
            numericUpDownPoints.Value = (decimal)this.currentQuestion.Points;

            if (this.currentQuestion.GetImage(out Bitmap bitmap))
            { 
                pictureBoxImage.Image = bitmap;
                buttonClearImage.Enabled = true;
            }
            else
            {
                pictureBoxImage.Image = null;
                buttonClearImage.Enabled = false;
            }

            InitDataGridViewAnswers(this.currentQuestion.answers);
        }

        private void InitDataGridViewAnswers(List<Answer> answers)
        {
            bindingListAnswers = new BindingList<Answer>(answers);

            dataGridViewAnswers.ReadOnly = true;            

            dataGridViewAnswers.DataSource = bindingListAnswers;

            dataGridViewAnswers.RowHeadersVisible = false;
            dataGridViewAnswers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAnswers.MultiSelect = false;
            dataGridViewAnswers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            
            
            dataGridViewAnswers.Columns["Text"].HeaderText = "Text of answer";
            dataGridViewAnswers.Columns["Text"].Width = 280;
            
            dataGridViewAnswers.Columns["IsTrue"].HeaderText = "Is true answer";
            dataGridViewAnswers.Columns["IsTrue"].Width = 50;
            
            dataGridViewAnswers.Columns["IsCorrectAnswer"].Visible = false;
        }



        private void dataGridViewAnswers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewAnswers.SelectedRows.Count > 0)
            {
                buttonEditAnswer.Enabled = true;
                buttonDeleteAnswer.Enabled = true;                
            }
            else
            {
                buttonEditAnswer.Enabled = false;
                buttonDeleteAnswer.Enabled = false;
            }
        }

        private void buttonAddAnswer_Click(object sender, EventArgs e)
        {
            AddEditAnswer formAddAnswer = new AddEditAnswer(new Answer());
            formAddAnswer.Text = "Add new answer";
            if (formAddAnswer.ShowDialog() == DialogResult.OK)
            {
                bindingListAnswers.Add(formAddAnswer.currentAnswer);
                currentQuestion.answers = bindingListAnswers.ToList();
                if (dataGridViewAnswers.Rows.Count > 0)
                    dataGridViewAnswers.Rows[dataGridViewAnswers.Rows.Count-1].Selected = true;                
                
                DataChecking();
            }
        }

        private void buttonDeleteAnswer_Click(object sender, EventArgs e)
        {
            if (dataGridViewAnswers.SelectedRows.Count > 0) 
            { 
                int index = dataGridViewAnswers.SelectedRows[0].Index;
                bindingListAnswers.RemoveAt(index);
                currentQuestion.answers = bindingListAnswers.ToList();
                
                DataChecking();
            }
        }

        private void buttonEditAnswer_Click(object sender, EventArgs e)
        {
            if (dataGridViewAnswers.SelectedRows.Count > 0)
            {
                int index = dataGridViewAnswers.SelectedRows[0].Index;
                Answer selectedAnswer = currentQuestion.answers[index];
                AddEditAnswer formEditAnswer = new AddEditAnswer(selectedAnswer);
                formEditAnswer.Text = "Edit answer";
                if (formEditAnswer.ShowDialog() == DialogResult.OK)
                {
                    bindingListAnswers[index] = formEditAnswer.currentAnswer;
                    currentQuestion.answers = bindingListAnswers.ToList();
                    dataGridViewAnswers.Rows[index].Selected = true;

                    DataChecking();
                }

            }
        }

        private void textBoxText_TextChanged(object sender, EventArgs e)
        {
            currentQuestion.Text = textBoxText.Text.Trim();
            DataChecking();            
        }

        private void DataChecking()
        {
            bool flagText = true;

            if (textBoxText.Text.Trim() == String.Empty)
            {   
                labelErrorText.Visible = true;
                flagText = false;
            }
            else
                labelErrorText.Visible = false;
            
            
            bool flagAnswer = false;

            foreach (var answer in currentQuestion.answers)
            {
                if (answer.IsTrue)
                {
                    flagAnswer = true;
                    break;
                }
            }

            labelErrorAnswers.Visible = !flagAnswer;

            if (flagText && flagAnswer && !this.currentQuestion.Equals(this.startQuestion))
                buttonSave.Enabled = true;
            else
                buttonSave.Enabled = false;
            
        }



        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files(*.*)|*.*|JPG files(*.jpg)|*.jpg|BMP files(*.bmp)|*.bmp|JPEG files(*.jpeg)|*.jpeg|GIF files(*.gif)|*.gif|PNG files(*.png)|*.png";
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Open image file for question:";
            openFileDialog1.InitialDirectory = Path.GetFullPath(DirectoryAndFileTests.nameDirectoryForImage);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            { 
                if (currentQuestion.SetImage(openFileDialog1.FileName))
                {
                    currentQuestion.GetImage(out Bitmap bitmap);
                    pictureBoxImage.Image = bitmap;
                    buttonClearImage.Enabled = true;
                    
                    DataChecking();
                }
            }
        }

        private void numericUpDownPoints_ValueChanged(object sender, EventArgs e)
        {
            currentQuestion.Points = (int)numericUpDownPoints.Value;
            DataChecking();
        }

        private void buttonClearImage_Click(object sender, EventArgs e)
        {
            currentQuestion.Image = null;
            pictureBoxImage.Image = null;
            buttonClearImage.Enabled = false;

            DataChecking();
        }

    }
}
