using System;
using System.Collections.Generic;
using System.Text;

namespace C48_G03_EXAM01
{
    public class TfQuestion : Question
    {
        public TfQuestion(string header, string body, int mark, int rightAnswerId)
            : base(header, body, mark)
        {
            Answers = new Answer[]
            {
                new Answer(1, "True"),
                new Answer(2, "False")
            };
            RightAnswer = rightAnswerId == 1 ? Answers[0] : Answers[1];
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header} (Marks: {Mark})");
            Console.WriteLine(Body);
            Console.WriteLine("1. True\n2. False");
        }
    }

 }
