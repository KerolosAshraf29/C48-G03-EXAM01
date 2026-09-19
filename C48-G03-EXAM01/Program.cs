using System;
using System.Diagnostics;

namespace C48_G03_EXAM01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(10, "C# and OOP Examination");
            Console.WriteLine($"Configuring exam for: {subject.SubjectName}\n");
            NewMethod(subject);

            Console.Clear();
            Console.Write("Do you want to start the exam now? (Y/N): ");
            char choice = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (choice == 'Y')
            {
                Console.Clear();

                Stopwatch sw = Stopwatch.StartNew();

                double score = subject.SubjectExam.TakeExam();

                sw.Stop();

                if (subject.SubjectExam is FinalExam finalExam)
                {
                    finalExam.Grade = score;
                }
                else if (subject.SubjectExam is PracticalExam practicalExam)
                {
                    practicalExam.Grade = score;
                }

                Console.Clear();
                Console.WriteLine("======= Exam Results =======n");
                subject.SubjectExam.ShowExam();
                Console.WriteLine($"Time Taken: {sw.Elapsed.Minutes:00}:{sw.Elapsed.Seconds:00}");
            }
            else
            {
                Console.WriteLine("Exam cancelled.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        private static void NewMethod(Subject subject) =>
            subject.CreateExam();
    }
}