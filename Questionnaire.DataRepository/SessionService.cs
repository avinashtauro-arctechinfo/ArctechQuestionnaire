using System.Web;

namespace Questionnaire.DataRepository
{
    internal class SessionService
    {
        internal int LastQuestionId
        {
            get => int.Parse((HttpContext.Current.Session["lastQuestionId"]??"0").ToString());
            set => HttpContext.Current.Session["lastQuestionId"] = value;
        }

        public int CandidateId
        {
            get => int.Parse(HttpContext.Current.Session["candidateId"].ToString());
            set => HttpContext.Current.Session["candidateId"] = value;
        }
    }
}