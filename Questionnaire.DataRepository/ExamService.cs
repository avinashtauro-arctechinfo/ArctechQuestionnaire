using System.Linq;
using Questionnaire.DataAccess;

namespace Questionnaire.DataRepository
{
    public class ExamService
    {
        private readonly SessionService _sessionService = new SessionService();
        public int CandidateId => _sessionService.CandidateId;

        public string GetExamTextById(int id)
        {
            using (var db = new QuestionnaireEntities())
            {
                return db.Exams.Where(e => e.Id == id).Select(e => e.Title).FirstOrDefault();
            }
        }

        public void SaveStudentName(string studentName)
        {
            using (var db = new QuestionnaireEntities())
            {
                var candidate = new Candidate {Name = studentName};
                db.Candidates.Add(candidate);
                db.SaveChanges();

                _sessionService.CandidateId = candidate.Id;
            }
        }
    }
}
