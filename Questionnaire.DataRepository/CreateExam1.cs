using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Questionnaire.DataAccess;

namespace Questionnaire.DataRepository
{
    public class CreateExam1
    {
        public void Test()
        {
            var topic = new Topic { Title = "C#.NET Multiple Choice Questions", Description = "WorldLine Test 1", Questions = new List<Question>() };
            const string path = @"C:\Users\avina\OneDrive - arctechinfo.com\Documents\Training\Sessions\C#\General\Questionnaire\Questionnaire\App_Data\Questions.txt";
            var questionsLines = File.ReadAllLines(path);

            var linesToSkip = 1;
            //foreach (var line in questionsLines)
            for (var index = 0; index < questionsLines.Length; index += linesToSkip)
            {
                var question = LoadQuestionAnswer(questionsLines, index, out linesToSkip);
                if (question != null)
                    topic.Questions.Add(question);
            }

            using (var db = new QuestionnaireEntities())
            {
                db.Topics.Add(topic);
                db.SaveChanges();
            }
        }

        private static Question LoadQuestionAnswer(string[] questionsLines, int startIndex, out int linesToSkip)
        {
            var index = startIndex;
            try
            {
                var question = LoadQuestion(questionsLines, ref index);
                index--;
                
                LoadAnswerOptions(questionsLines, ref index, question);
                index--;

                LoadSelectedAnswer(questionsLines[index], question);
                index++;

                linesToSkip = index - startIndex;
                return question;
            }
            catch (ArgumentOutOfRangeException)
            {
                linesToSkip = 1;
                return null;
            }
        }

        private static void LoadSelectedAnswer(string line, Question question)
        {
            var answerText = line.Substring(5);
            answerText = answerText.ToUpper();

            var answers = answerText
                .Split(',')
                .Select(a => a.Trim()[0])
                .ToList();

            var answerIndex = 'A';
            foreach (var item in question.AnswerOptions)
            {
                if (answers.Contains(answerIndex))
                {
                    item.AnswerStatus = true;
                }

                answerIndex++;
            }
        }

        private static int LoadAnswerOptions(IReadOnlyList<string> questionsLines, ref int index, Question question)
        {
            var line = questionsLines[index++];

            // Read all answer lines
            while (!line.StartsWith("Ans: "))
            {
                var answerOptionText = line.Substring(2).Trim();
                var answerOption = new AnswerOption { Text = answerOptionText };
                question.AnswerOptions.Add(answerOption);

                line = questionsLines[index++];
            }

            return index;
        }

        private static Question LoadQuestion(IReadOnlyList<string> questionsLines, ref int index)
        {
            var line = questionsLines[index++];

            // Read all question lines
            var sb = new StringBuilder();

            while (!line.StartsWith("A."))
            {
                sb.Append($"{line}\n");
                line = questionsLines[index++];
            }

            var questionText = sb.ToString();
            var dotIndex = questionText.IndexOf('.');
            var question = new Question
            {
                Text = questionText.Substring(dotIndex + 1).Trim(),
                Notes = questionText.Substring(0, dotIndex + 1),
                AnswerOptions = new List<AnswerOption>()
            };

            return question;
        }
    }
}
