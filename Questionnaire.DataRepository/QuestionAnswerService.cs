using System.Data.Entity.Core.Objects;
using System.Linq;
using Questionnaire.DataAccess;

namespace Questionnaire.DataRepository
{
    public class QuestionAnswerService
    {
        private readonly SessionService _sessionService = new SessionService();
        public QuestionAnswer GetNextQuestionAnswer(int examId)
        {
            var lastQuestionNumber = _sessionService.LastQuestionId;
            var questionAnswer = new QuestionAnswer();

            using (var db = new QuestionnaireEntities())
            {
                //var question1 = db.Questions.Where(q => q.Id == lastQuestionNumber + 1)
                //    .Select(q => new {q.Id, q.Text})
                //    .FirstOrDefault();

                var questionInfo = (from question in db.Questions
                                    join examQuestion in db.ExamQuestions on question.Id equals examQuestion.QuestionRefId
                                    where examQuestion.ExamRefId == examId && question.Id == lastQuestionNumber + 1
                                    select new { ExamQuestionId = examQuestion.Id, QuestionId = question.Id, question.Text }).FirstOrDefault();

                if (questionInfo == null)
                {
                    return null;
                }

                questionAnswer.QuestionInfo = new DataItem { Id = questionInfo.ExamQuestionId, Text = questionInfo.Text };
                questionAnswer.TotalQuestions = db.Questions.Count();

                var answerOptions = db.AnswerOptions.Where(ao => ao.QuestionRefId == questionInfo.QuestionId)
                    .Select(ao => new DataItem { Id = ao.Id, Text = ao.Text })
                    .ToList();

                questionAnswer.AnswerOptions = answerOptions;

                _sessionService.LastQuestionId = questionInfo.ExamQuestionId;
            }

            return questionAnswer;
        }

        public void Save(string examQuestionId, string selectedAnswerId)
        {
            using (var db = new QuestionnaireEntities())
            {
                var examAnswer = new ExamAnswer
                {
                    ExamQuestionRefId = int.Parse(examQuestionId),
                    AnswerOptionRefId = int.Parse(selectedAnswerId),
                    CandidateRefId = _sessionService.CandidateId
                };

                db.ExamAnswers.Add(examAnswer);
                db.SaveChanges();
            }
        }

        public int GetScore(int candidateId)
        {
            using (var db = new QuestionnaireEntities())
            {
                var paramScore = new ObjectParameter("score", typeof(int));
                db.GetScoreForCandidate(candidateId, paramScore);

                return (int)paramScore.Value;
            }
        }
    }
}
