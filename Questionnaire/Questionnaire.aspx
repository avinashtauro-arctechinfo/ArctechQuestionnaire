<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Questionnaire.aspx.cs" Inherits="Questionnaire.Questionnaire" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Exam Questions</title>
    <link href="Content/questionnaire.css" rel="stylesheet" />
</head>
<body onload="window.history.forward();">
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <asp:ScriptReference Name="bootstrap" />
            </Scripts>
        </asp:ScriptManager>

        <div>
            <h3>
                <asp:Label runat="server" ID="LabelExam" />
            </h3>
            <asp:Panel runat="server" ID="PanelStudentName" Visible="false">
                <div>
                    Enter your name:
                    <br />
                    <asp:TextBox runat="server" ID="TextBoxStudentName" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server"
                        Display="Dynamic"
                        ControlToValidate="TextBoxStudentName"
                        ErrorMessage="Name is required" />
                    <asp:RegularExpressionValidator runat="server"
                        Display="Dynamic"
                        ControlToValidate="TextBoxStudentName"
                        ValidationExpression="^[\s\S]{5,50}$"
                        ErrorMessage="Minimum 5 and Maximum 50 characters required." />
                </div>
                <div>
                    <br />
                    <asp:Button runat="server" ID="ButtonStartExam" Text="Start Exam" OnClick="ButtonStartExam_OnClick" />
                </div>
            </asp:Panel>

            <asp:Panel runat="server" ID="PanelQuestionAnswer" Visible="false">
                <div class="candidate">
                    Candidate:
                    <asp:Label runat="server" ID="LabelCandidateName"></asp:Label>
                </div>
                <div class="question">
                    Question
                    <asp:Label runat="server" ID="LabelQuestionNumber" />
                    out of
                    <asp:Label runat="server" ID="LabelTotalQuestions" />
                </div>
                <div class="question">
                    <asp:Label runat="server" ID="LabelQuestion"></asp:Label>
                </div>
                <div class="answers">
                    <asp:RadioButtonList class="radio-list" runat="server" ID="RadioButtonListAnswers" DataTextField="Text" DataValueField="Id" />
                </div>
                <div class="next-button">
                    <asp:Button class="next-button" runat="server" ID="ButtonNext" Text="Next Question"
                        OnClick="ButtonNext_OnClick"
                        OnClientClick="return validateMoveNext();" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button class="next-button" runat="server" ID="ButtonExitTest" Text="Next Question"
                                OnClick="ButtonExitTest_Click" />
                </div>
                <div class="note-messages">
                    *Note: You cannot go back to the previous question!<br />
                    **Note: Do not refresh the page, else current question will be marked zero and move to next question!
                </div>
            </asp:Panel>
        </div>
    </form>
    <script type="text/javascript">
        var alreadyClicked = false;
        function validateMoveNext() {
            const radio = document.getElementsByName("<%= RadioButtonListAnswers.ClientID %>");

            for (let i = 0; i < radio.length; i++) {
                if (radio[i].checked) {
                    return true;
                }
            }

            const response = confirm("You have not answered this question. \nIf you continue, you will be marked 0 for this question.\n\nDo you wish to continue to the next question?");

            return (response === true);
        }
    </script>
</body>
</html>
