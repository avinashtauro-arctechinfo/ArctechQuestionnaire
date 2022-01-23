using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
                var examText = _examService.GetExamTextById(RequestQueryStringExamId);
                LabelExam.Text = examText.Replace("\n", "<br />");

                ShowQuestionAnswer();
                PanelStudentName.Visible = true;
            }
            catch (Exception)
            {
                LabelExam.Text = "Specify the exam which you want to attend. Contact your trainer for the exam url!";
            }
        }

        private void ShowQuestionAnswer()
        {
            var questionAnswer = _questionAnswerService.GetNextQuestionAnswer();

            LabelQuestionNumber.Text = questionAnswer.QuestionNumber.ToString();
            LabelTotalQuestions.Text = questionAnswer.TotalQuestions.ToString();
            LabelQuestion.Text = questionAnswer.QuestionText;

            RadioButtonListAnswers.DataSource = questionAnswer.AnswerOptions;
            RadioButtonListAnswers.DataBind();
        }

        private int RequestQueryStringExamId => int.Parse(Request.QueryString["exam"]);

        protected void ButtonNext_OnClick(object sender, EventArgs e)
        {
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
    }
}