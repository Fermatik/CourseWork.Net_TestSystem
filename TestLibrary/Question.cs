using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    /// <summary>
    /// Question class for TestSystem
    /// </summary>
    [Serializable]
    public class Question
    {
        /// <summary>
        /// question text 
        /// </summary>
        public string Text { set; get; }

        /// <summary>
        /// points per question, default 1
        /// </summary>
        public int Points { set; get; }

        public byte[] Image;

        public bool SetImage(string path)
        {
            bool result = true;
            try
            {
                Bitmap bitmap = new Bitmap(path);
                Image = File.ReadAllBytes(path);
            }
            catch
            {
                Image = null;
                result = false;
            }
            return result;
        }


        public bool GetImage(out Bitmap bitmap)
        {
            bitmap = null;            
            bool result = true;
            try
            {
                MemoryStream stream = new MemoryStream(Image);
                bitmap = new Bitmap(stream);
            }
            catch
            {
                bitmap = null;
                result = false;
            }
            return result;
        }

        /// <summary>
        /// list answers of question
        /// </summary>
        public List<Answer> answers;

        /// <summary>
        /// counter of answers for question 
        /// </summary>
        public int CountAnswers
        {
            get { return answers.Count; }
        }

        /// <summary>
        /// true if there is at least one correct answer to the question, false otherwise
        /// </summary>
        public bool IsCorrect
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.Text))
                    return false;

                foreach (Answer answer in answers)
                    if (answer.IsTrue) return true;

                return false;
            }
        }
        

        /// <summary>
        /// Default costructor
        /// </summary>
        public Question()
        {
            this.Text = String.Empty;
            this.Points = 1;                        
            this.answers = new List<Answer>();
            this.Image = null;

        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            Question question = (Question)obj;

            if (question.Text != this.Text ||
                question.Points != this.Points ||                                
                question.CountAnswers != this.CountAnswers) return false;

            if (question.Image==null)
            {
                if (this.Image != null) return false;
            }
            else
            {
                if (this.Image == null) return false;
                else
                {
                    for (int i = 0; i < this.Image.Length; i++)
                        if (question.Image[i] != this.Image[i]) return false;                    
                }
            }
            
            for (int i = 0; i < question.CountAnswers; i++)
                if (!question.answers[i].Equals(this.answers[i])) return false;
            
            return true;
        }

        public Question Clone()
        {
            if (this == null) return null;
            Question result = new Question();
            result.Text = this.Text;
            result.Points = this.Points;
            if (this.Image == null)
            {
                result.Image = null;
            }
            else
            {
                result.Image = new byte[this.Image.Length];
                for (int i = 0; i < this.Image.Length; i++)
                    result.Image[i] = this.Image[i];
            }
            foreach (var answer in this.answers)
                result.answers.Add(new Answer(answer.Text, answer.IsTrue));
            return result;
        }

        public override string ToString()
        {
            string result = $"Text [{this.Text}]\n" +
                            $"Points [{this.Points}]\n" +
                            $"IsCorrect [{this.IsCorrect}]\n";
            
            result += (Image == null) ? "Image [null]\n" : $"Image.Lenght [{Image.Length}]\n";
            result += $"CountAnswers [{CountAnswers}]\n";
            int i = 0;
            foreach (var answer in this.answers)
                result += $"{++i} [{answer.Text}] [{answer.IsTrue}] [{answer.IsCorrectAnswer}]\n";
            
            return result;
        }

        public bool IsNotCheckUser
        {
            get 
            { 
                foreach (var answer in answers)
                    if (answer.IsCheckUser) return false;

                return true;
            }
        }

        public bool IsQuestionIncorrectAnswerUser()
        {
            foreach (var answer in answers)
            {
                if (answer.IsTrue != answer.IsCheckUser)
                    return true;                
            }
            return false;
        }

        public List<Answer> GetIsTrueAnswers()
        {
            List<Answer> list = new List<Answer>();
            foreach (var answer in answers)
            {
                if (answer.IsTrue)
                    list.Add(answer);
            }
            return list;
        }

        public List<Answer> GetAnswerUser()
        {
            List<Answer> list = new List<Answer>();
            foreach (var answer in answers)
            {
                if (answer.IsCheckUser)
                    list.Add(answer);
            }
            return list;
        }
    }
}
