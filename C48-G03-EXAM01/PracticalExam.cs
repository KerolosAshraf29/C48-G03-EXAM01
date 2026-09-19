using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace C48_G03_EXAM01
{
    public class PracticalExam : Exam
    {
        public PracticalExam(int timeInMinutes, int numberOfQuestions)
            : base(timeInMinutes, numberOfQuestions)
        {
        }

        public double Grade { get; set; }

        public override void ShowExam()
        {
            Console.WriteLine("=== Practical Exam Results ===\n");

            if (Questions != null)
            {
                for (int i = 0; i < Questions.Length; i++)
                {
                    var question = Questions[i];
                    Console.WriteLine($"Question {i + 1}: {question.Header}");
                    Console.WriteLine(question.Body);

                    if (question.UserAnswer != null)
                    {
                        Console.WriteLine("Your Answer: " + question.UserAnswer.AnswerText);
                    }

                    if (question.RightAnswer != null)
                    {
                        Console.WriteLine("Right Answer: " + question.RightAnswer.AnswerText);
                    }

                    Console.WriteLine();
                }
            }

            Console.WriteLine("Grade: " + Grade);
        }
    }
 }
