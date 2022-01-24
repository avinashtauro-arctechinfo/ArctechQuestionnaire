<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExamEnd.aspx.cs" Inherits="Questionnaire.ExamEnd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Exam has ended</title>
    <style type="text/css">
        .card {
            /* Add shadows to create the "card" effect */
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
            transition: 0.3s;
            text-align: center;
        }

            /* On mouse-over, add a deeper shadow */
            .card:hover {
                box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
            }

        /* Add some padding inside the card container */
        .container {
            padding: 2px 16px;
            background-color: bisque;
        }

        body {
            font-family: arial;
        }

        .score-div {
            width: 500px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="score-div">
            <div class="card">
                <h3>
                    <asp:Label runat="server" ID="LabelExam" />
                </h3>
                <h4>
                    <asp:Label runat="server" ID="LabelCandidateName" />
                </h4>
                <div class="container">
                    Your score in this test is
                <b>
                    <asp:Label runat="server" ID="LabelScore" /></b>
                    out of 100.
                </div>
            </div>
        </div>
    </form>
</body>
</html>
