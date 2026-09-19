using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace C48_G03_EXAM01
{
    public class FinalExam : Exam
    {
        public FinalExam(int timeInMinutes, int numberOfQuestions) : base(timeInMinutes, numberOfQuestions)
        {
        }

        public double Grade { get; set; }
        public override void ShowExam()
        {
            Console.WriteLine("Final Exam");

            foreach (Question question in Questions)
            {
                Console.WriteLine(question.Header);
                Console.WriteLine(question.Body);
                Console.WriteLine("Mark: " + question.Mark);

                foreach (Answer answer in question.Answers)
                {
                    Console.WriteLine(answer.AnswerId + "- " + answer.AnswerText);
                }

                Console.WriteLine("Right Answer: " + question.RightAnswer.AnswerText);
                Console.WriteLine();
            }
            Console.WriteLine("Grade: " + Grade);
        }
    }
 }
