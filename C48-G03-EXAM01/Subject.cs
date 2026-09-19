using System;
using System.Collections.Generic;

namespace C48_G03_EXAM01
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam SubjectExam { get; set; }

        public Subject(int id, string name)
        {
            SubjectId = id;
            SubjectName = name;
        }

        public void CreateExam(Exam exam)
        {
            SubjectExam = exam;
            SubjectExam.Subject = this;
        }

        public void CreateExam()
        {
            int examType;
            do
            {
                Console.Write("Please enter the type of exam (1 for Practical, 2 for Final): ");
            } while (!int.TryParse(Console.ReadLine(), out examType) || (examType != 1 && examType != 2));

            int time;
            do
            {
                Console.Write("Please enter the exam time in minutes: ");
            } while (!int.TryParse(Console.ReadLine(), out time) || time <= 0);

            int numQuestions;
            do
            {
                Console.Write("Please enter the number of questions: ");
            } while (!int.TryParse(Console.ReadLine(), out numQuestions) || numQuestions <= 0);

            // 1 = Practical, 2 = Final
            if (examType == 1)
            {
                SubjectExam = new PracticalExam(time, numQuestions);
            }
            else
            {
                SubjectExam = new FinalExam(time, numQuestions);
            }

            SubjectExam.Subject = this;

            for (int i = 0; i < numQuestions; i++)
            {
                Console.Clear();
                Console.WriteLine($"=== Question {i + 1} Configuration ===");

                int questionType = 1; // Default mcq
                if (examType == 2)
                {
                    do
                    {
                        Console.Write("Choose question type (1 for MCQ, 2 for True/False): ");
                    } while (!int.TryParse(Console.ReadLine(), out questionType) || (questionType != 1 && questionType != 2));
                }

                Console.Write("Enter Question Header: ");
                string header = Console.ReadLine() ?? $"Question {i + 1}";

                Console.Write("Enter Question Body: ");
                string body = Console.ReadLine() ?? "";

                int mark;
                do
                {
                    Console.Write("Enter Question Mark: ");
                } while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0);

                if (questionType == 1) // mcq
                {
                    int choicesCount;
                    do
                    {
                        Console.Write("Enter number of choices (minimum 2): ");
                    } while (!int.TryParse(Console.ReadLine(), out choicesCount) || choicesCount < 2);

                    Answer[] answers = new Answer[choicesCount];
                    for (int a = 0; a < choicesCount; a++)
                    {
                        Console.Write($"Enter text for choice {a + 1}: ");
                        string choiceText = Console.ReadLine() ?? "";
                        answers[a] = new Answer(a + 1, choiceText);
                    }

                    int rightAnswerId;
                    do
                    {
                        Console.Write($"Enter Right Answer ID (1 to {choicesCount}): ");
                    } while (!int.TryParse(Console.ReadLine(), out rightAnswerId) || rightAnswerId < 1 || rightAnswerId > choicesCount);

                    SubjectExam.Questions[i] = new McqQuestion(header, body, mark, answers, answers[rightAnswerId - 1]);
                }
                else 
                {
                    int rightAnswerId;
                    do
                    {
                        Console.Write("Enter Right Answer (1 for True, 2 for False): ");
                    } while (!int.TryParse(Console.ReadLine(), out rightAnswerId) || (rightAnswerId != 1 && rightAnswerId != 2));

                    SubjectExam.Questions[i] = new TfQuestion(header, body, mark, rightAnswerId);
                }
            }
        }
    }
}