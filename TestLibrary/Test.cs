using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestLibrary
{
    /// <summary>
    /// Test class for TestSystem
    /// </summary>
    [Serializable]
    public class Test
    {
        public int TestUser_Id { set; get; }
        public int Test_Id { set; get; }
        /// <summary>
        /// full path to xml file for test
        /// </summary>
        public string FullPathFile { get; set; }

        /// <summary>
        /// minimum percentage of points for passing the test by default
        /// </summary>
        public const float DEFAULT_MINIMUM_PASSING_PERCENT = 0.65F;

        /// <summary>
        /// title of test
        /// </summary>
        public string Title { set; get; }

        /// <summary>
        /// description of test
        /// </summary>
        public string Description { set; get; }

        /// <summary>
        /// author of test
        /// </summary>
        public string Author { set; get; }

        /// <summary>
        /// information for the test taker
        /// </summary>
        public string InfoForTestTaker { set; get; }

        /// <summary>
        /// maximum points for test
        /// </summary>
        public int MaximumPoints
        {
            get
            {
                int result = 0;
                foreach (Question question in questions)
                    result += question.Points;

                return result;
            }
        }

        private float _minimumPassingPercent;

        /// <summary>
        /// minimum passing percent for a successful test
        /// </summary>
        public float MinimumPassingPercent
        {
            set
            {
                if (value < 0)
                    _minimumPassingPercent = 0;
                else
                    if (value > 1)
                        _minimumPassingPercent = 1;
                    else
                        _minimumPassingPercent = value;

            }

            get { return _minimumPassingPercent; }
        }

        /// <summary>
        /// list questions of test
        /// </summary>
        public List<Question> questions;

        /// <summary>
        /// counter of question for test 
        /// </summary>        
        public int CountQuestion
        {
            get { return questions.Count; }
        }

        public bool IsCorrect
        {
            get
            {
                if (this.CountQuestion == 0) return false;
                foreach (var question in this.questions)
                {
                    if (!question.IsCorrect)
                        return false;
                    
                    foreach(var answer in question.answers)
                    {
                        if (!answer.IsCorrectAnswer)
                            return false;
                    }

                    foreach (var answer in question.answers)
                    {
                        if (answer.IsTrue) return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// default constructor
        /// </summary>
        public Test()
        {
            this.MinimumPassingPercent = DEFAULT_MINIMUM_PASSING_PERCENT;
            this.questions = new List<Question>();
            this.Title = String.Empty;
            this.Description = String.Empty;
            this.InfoForTestTaker = String.Empty;
            this.Author = String.Empty;
            this.FullPathFile = String.Empty;
        }

        public static bool LoadFromFileXml(string path, out Test test)
        {
            test = null;

            if (!File.Exists(path)) return false;

            XmlSerializer formatter = new XmlSerializer(typeof(Test));

            FileStream fileStream = null;

            bool result = true;

            try
            {
                fileStream = new FileStream(path, FileMode.Open);
                test = (Test)formatter.Deserialize(fileStream);                                
            }
            catch
            {
                test = null;
                result = false;
            }
            finally
            {
                if (fileStream != null) fileStream.Close();
            }

            string currentFullPathFile = Path.GetFullPath(path);
            if (result && currentFullPathFile != test.FullPathFile )
            {
                test.FullPathFile = currentFullPathFile;
                SaveToFileXml(currentFullPathFile, ref test);
            }

            return result;
        }

        public static bool SaveToFileXml(string path, ref Test test)
        {

            XmlSerializer formater = new XmlSerializer(typeof(Test));

            FileStream fileStream = null;

            bool result = true;

            try
            {
                fileStream = new FileStream(path, FileMode.OpenOrCreate);                
                test.FullPathFile = Path.GetFullPath(path);
                formater.Serialize(fileStream, test);
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (fileStream != null) fileStream.Close();
            }

            return result;

        }

        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType()) return false;
            
            Test test = (Test)obj;

            if (test.Title != this.Title ||
                test.Description != this.Description ||
                test.Author != this.Author ||
                test.FullPathFile != this.FullPathFile ||
                test.CountQuestion != this.CountQuestion ||
                test.InfoForTestTaker != this.InfoForTestTaker) return false;

            for (int i = 0; i < test.CountQuestion; i++)
                if (!test.questions[i].Equals(this.questions[i])) return false;
            
            return true;
        }

        public int GetResultPoints()
        {
            int userPoints = 0;

            foreach (var question in questions)
            {
                int point = question.Points;
                foreach (var answer in question.answers)
                {
                    if (answer.IsTrue != answer.IsCheckUser)
                    {
                        point = 0;
                        break;
                    }
                }
                userPoints += point;
            }
            return userPoints;
        }

        public bool GetResultTest()
        {
            float percent = (float)GetResultPoints() / MaximumPoints;
            if (percent >= MinimumPassingPercent) 
                return true;
            else
                return false;
        }

        public int GetCountCorrectAnswerUser()
        {
            int result = 0;
            foreach (var question in questions)
            {
                int count = 1;
                foreach (var answer in question.answers)
                {
                    if (answer.IsTrue!=answer.IsCheckUser)
                    {
                        count = 0;
                        break;
                    }
                }
                result += count;
            }
            return result;
        }

        public int GetCountIncorrectAnswerUser()
        {
            return CountQuestion - GetCountCorrectAnswerUser();
        }

        public string GetReportTest()
        {
            
            int correct = GetCountCorrectAnswerUser();
            int incorrect = CountQuestion - correct;
            int resultPoints = GetResultPoints();
            float resultPercent = (float)resultPoints / MaximumPoints * 100;
            string result = $"TestUser_Id: {TestUser_Id}" + Environment.NewLine +
                            $"Test_Id: {Test_Id}" + Environment.NewLine +
                            $"Title: {Title}" + Environment.NewLine +
                            $"Author: {Author}" + Environment.NewLine +
                            $"Description: {Description}" + Environment.NewLine +
                            $"Info for test traker: {InfoForTestTaker}" + Environment.NewLine +
                            $"Maximum points: {MaximumPoints}" + Environment.NewLine +
                            $"Minimum percent: " + (MinimumPassingPercent * 100).ToString("F2") + " % " + Environment.NewLine +
                            $"Count question: {CountQuestion}" + Environment.NewLine +
                            $"Correct question user answer: {GetCountCorrectAnswerUser()}" + Environment.NewLine +
                            $"Incorrect question user answer: {GetCountIncorrectAnswerUser()}" + Environment.NewLine +
                            $"Result points: {resultPoints}" + Environment.NewLine +
                            $"Result percent: {resultPercent.ToString("F2")} %" + Environment.NewLine + Environment.NewLine +
                            $"Result test: {GetResultTest()}"+ Environment.NewLine + Environment.NewLine + Environment.NewLine;

            if (incorrect > 0) result += "ERROR QUESTIONS:" + Environment.NewLine + Environment.NewLine;
                           

            foreach (var question in questions)
            {
                if (question.IsQuestionIncorrectAnswerUser())
                {
                    
                    result += $"Question: {question.Text}" + Environment.NewLine +
                              new string('-', 50) + Environment.NewLine +
                              $"Is true answer:" + Environment.NewLine;
                    int i = 1;
                    foreach (var trueanswer in question.GetIsTrueAnswers())
                    {
                        result += $"  {i++}. {trueanswer.Text}" + Environment.NewLine;
                    }
                    result += $"Answer user:" + Environment.NewLine;
                    i = 1;
                    foreach (var useranswer in question.GetAnswerUser())
                    {
                        result += $"  {i++}. {useranswer.Text}" + Environment.NewLine;
                    }
                    result += new string('-', 50) + Environment.NewLine;                    
                }
            }

            return result;
        }

    }
}
