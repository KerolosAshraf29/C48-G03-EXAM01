using System;
using System.Collections.Generic;
using System.Text;

namespace C48_G03_EXAM01
{
    public class McqQuestion : Question
    {
        public McqQuestion(string header, string body, int mark, Answer[] answers, Answer rightAnswer)
            : base(header, body, mark)
        {
            Answers = answers;
            RightAnswer = rightAnswer;
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header} (Marks: {Mark})");
            Console.WriteLine(Body);
            if (Answers != null)
            {
                foreach (var answer in Answers)
                {
                    Console.WriteLine(answer);
                }
            }
        }
    }
}
