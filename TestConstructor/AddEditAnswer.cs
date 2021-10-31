using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLibrary;

namespace TestConstructor
{
    public partial class AddEditAnswer : Form
    {
        public Answer currentAnswer;

        public AddEditAnswer(Answer currentAnswer)
        {
            InitializeComponent();
            if (currentAnswer == null) currentAnswer = new Answer();
            this.currentAnswer = currentAnswer;

            textBoxAnswerText.Text = this.currentAnswer.Text;
            checkBoxIsTrue.Checked = this.currentAnswer.IsTrue;

        }

        private void textBoxAnswerText_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAnswerText.Text.Trim() == String.Empty)
                buttonSave.Enabled = false;
            else
            {
                Answer answer = new Answer(textBoxAnswerText.Text, checkBoxIsTrue.Checked);
                if (answer.Equals(currentAnswer))
                    buttonSave.Enabled = false;
                else
                    buttonSave.Enabled = true;
            }
            
        }

        private void checkBoxIsTrue_CheckedChanged(object sender, EventArgs e)
        {
            if (textBoxAnswerText.Text.Trim() == String.Empty)
                buttonSave.Enabled = false;
            else
            {
                Answer answer = new Answer(textBoxAnswerText.Text, checkBoxIsTrue.Checked);
                if (answer.Equals(currentAnswer))
                    buttonSave.Enabled = false;
                else
                    buttonSave.Enabled = true;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            currentAnswer.Text = this.textBoxAnswerText.Text;
            currentAnswer.IsTrue = this.checkBoxIsTrue.Checked;
        }
    }
}
