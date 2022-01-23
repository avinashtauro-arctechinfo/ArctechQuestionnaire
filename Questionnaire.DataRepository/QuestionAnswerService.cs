using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Questionnaire.DataAccess;

namespace Questionnaire.DataRepository
{
    public class QuestionAnswerService
    {
        private readonly SessionService _sessionService = new SessionService();
        public QuestionAnswer GetNextQuestionAnswer()
        {
            var lastQuestionNumber = _sessionService.LastQuestionId;
            var questionAnswer = new QuestionAnswer();

            using (var db = new QuestionnaireEntities())
            {
                var question = db.Questions.Where(q => q.Id == lastQuestionNumber + 1)
                    .Select(q => new {q.Id, q.Text})
                    .FirstOrDefault();

                if (question == null)
                {
                    HttpContext.Current.Response.Redirect("/ExamEnd");
                    return null;
                }


                questionAnswer.QuestionNumber = question.Id;
                questionAnswer.QuestionText = question.Text;
                questionAnswer.TotalQuestions = db.Questions.Count();

                var answerOptions = db.AnswerOptions.Where(ao => ao.QuestionRefId == question.Id)
                    .Select(ao => ao.Text)
                    .ToList();

                questionAnswer.AnswerOptions = answerOptions;

                _sessionService.LastQuestionId = question.Id;
            }

            return questionAnswer;
        }
    }
}
