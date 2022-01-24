using System;
using Questionnaire.DataRepository;

namespace Questionnaire
{
    public partial class ExamEnd : System.Web.UI.Page
    {
        private readonly ExamService _examService = new();
        private readonly QuestionAnswerService _questionAnswerService = new(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            InitializeScore();
        }

        private void InitializeScore()
        {
            var examIdText = Request.QueryString["examId"];
            var examId = int.Parse(examIdText);
            var examText = _examService.GetExamTextById(examId);
            LabelExam.Text = examText.Replace("\n", "<br />");

            LabelCandidateName.Text = Request.QueryString["candidate"];
            var candidateIdText = Request.QueryString["candidateId"];
            var candidateId = int.Parse(candidateIdText);

            LabelScore.Text = _questionAnswerService.GetScore(candidateId).ToString();
        }
    }
}