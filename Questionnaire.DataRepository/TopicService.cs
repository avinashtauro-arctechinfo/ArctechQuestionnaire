using System.Linq;
using Questionnaire.DataAccess;

namespace Questionnaire.DataRepository
{
    public class TopicService
    {
        public string GetTopicTextById(int id)
        {
            using (var db = new QuestionnaireEntities())
            {
                return db.Topics.Where(t => t.Id == id).Select(t => t.Title).FirstOrDefault();
            }
        }
    }
}
