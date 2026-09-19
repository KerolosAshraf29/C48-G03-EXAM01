using System;

namespace C48_G03_EXAM01
{
    public abstract class Exam
    {
        public int TimeInMinutes { get; set; }
        public int NumberOfQuestions { get; set; }
        public Question[] Questions { get; set; }
        public Subject Subject { get; set; }

        protected Exam(int timeInMinutes, int numberOfQuestions)
        {
            TimeInMinutes = timeInMinutes;
            NumberOfQuestions = numberOfQuestions;
            Questions = new Question[numberOfQuestions];
        }

        public virtual double TakeExam()
        {
            double earnedGrade = 0;

            for (int i = 0; i < Questions.Length; i++)
            {
                var q = Questions[i];
                Console.WriteLine($"\nQuestion {i + 1}: {q.Header}");
                Console.WriteLine(q.Body);

                if (q.Answers != null)
                {
                    foreach (var ans in q.Answers)
                    {
                        Console.WriteLine($"{ans.AnswerId}- {ans.AnswerText}");
                    }
                }

                int chosenId;
                do
                {
                    Console.Write("Your Answer ID: ");
                } while (!int.TryParse(Console.ReadLine(), out chosenId));

                if (q.RightAnswer != null && chosenId == q.RightAnswer.AnswerId)
                {
                    earnedGrade += q.Mark;
                }
            }

            return earnedGrade;
        }

        public abstract void ShowExam();
    }
}