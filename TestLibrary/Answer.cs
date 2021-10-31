using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    /// <summary>
    /// Answer class for TestSystem
    /// </summary>
    [Serializable]
    public class Answer
    {
        /// <summary>
        /// answer text
        /// </summary>
        public string Text { set; get; }

        /// <summary>
        /// true if the answer is true, otherwise false, default false
        /// </summary>
        public bool IsTrue { set; get; }

        public bool IsCheckUser { set; get; }

        public int Id { set; get; }

        /// <summary>
        /// true if there is a answer text, false otherwise
        /// </summary>
        public bool IsCorrectAnswer
        {
            get { return String.IsNullOrWhiteSpace(this.Text) ? false : true; }
        }

        /// <summary>
        /// default costructor 
        /// </summary>
        public Answer()
        {
            this.Text = String.Empty;
            this.IsTrue = false;
        }

        /// <summary>
        /// constructor with parameters
        /// </summary>
        /// <param name="text"></param>
        /// <param name="isTrue"></param>
        public Answer(string text, bool isTrue)
        {
            this.Text = text;
            this.IsTrue = isTrue;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            Answer answer = (Answer)obj;
            return (answer.Text != this.Text || answer.IsTrue != this.IsTrue) ? false : true ;
        }
    }
}
