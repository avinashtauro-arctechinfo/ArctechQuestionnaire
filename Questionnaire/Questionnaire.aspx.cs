using System;
using Questionnaire.DataRepository;

namespace Questionnaire
{
    public partial class Questionnaire : System.Web.UI.Page
    {
        private readonly ExamService _examService = new();
        private readonly QuestionAnswerService _questionAnswerService = new();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            try
            {
                var examText = _examService.GetExamTextById(ExamId);
                LabelExam.Text = examText.Replace("\n", "<br />");

                PanelStudentName.Visible = true;
            }
            catch (Exception)
            {
                LabelExam.Text = "Specify the exam which you want to attend. Contact your trainer for the exam url!";
            }
        }

        private void ShowQuestionAnswer()
        {
            var questionAnswer = _questionAnswerService.GetNextQuestionAnswer(ExamId);

            if (questionAnswer == null)
            {
                RedirectToExamEnd();
                return;
            }

            LabelQuestionNumber.Text = questionAnswer.QuestionInfo.Id.ToString();
            LabelTotalQuestions.Text = questionAnswer.TotalQuestions.ToString();
            LabelQuestion.Text = questionAnswer.QuestionInfo.Text;

            RadioButtonListAnswers.DataSource = questionAnswer.AnswerOptions;
            RadioButtonListAnswers.DataBind();
        }

        private int ExamId => int.Parse(Request.QueryString["exam"]);

        protected void ButtonNext_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(RadioButtonListAnswers.SelectedValue))
                _questionAnswerService.Save(LabelQuestionNumber.Text, RadioButtonListAnswers.SelectedValue);

            ShowQuestionAnswer();
        }

        protected void ButtonStartExam_OnClick(object sender, EventArgs e)
        {
            _examService.SaveStudentName(TextBoxStudentName.Text);

            PanelStudentName.Visible = false;
            PanelQuestionAnswer.Visible = true;
            LabelCandidateName.Text = TextBoxStudentName.Text;

            ShowQuestionAnswer();
        }

        protected void ButtonExitTest_Click(object sender, EventArgs e)
        {
            RedirectToExamEnd();
        }

        private void RedirectToExamEnd()
        {
            Response.Redirect($"/ExamEnd?candidate={LabelCandidateName.Text}&candidateId={_examService.CandidateId}&examId={ExamId}");
        }
    }
}