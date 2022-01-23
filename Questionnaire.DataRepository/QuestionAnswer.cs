using System.Collections.Generic;

namespace Questionnaire.DataRepository
{
    public class QuestionAnswer
    {
        public string QuestionText { get; set; }
        public List<string> AnswerOptions { get; set; }
        public int QuestionNumber { get; set; }
        public int TotalQuestions { get; set; }
    }
}