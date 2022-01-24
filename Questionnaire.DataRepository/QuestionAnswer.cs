using System.Collections.Generic;

namespace Questionnaire.DataRepository
{
    public class DataItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

    public class QuestionAnswer
    {
        public DataItem QuestionInfo { get; set; }
        //public int QuestionNumber { get; set; }
        //public string QuestionText { get; set; }

        public List<DataItem> AnswerOptions { get; set; }
        public int TotalQuestions { get; set; }
    }
}