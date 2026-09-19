using System;
using System.Collections.Generic;
using System.Text;

namespace C48_G03_EXAM01
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer(int id, string text)
        {
            AnswerId = id;
            AnswerText = text;
        }

        public override string ToString() => $"{AnswerId}. {AnswerText}";
    }
}
