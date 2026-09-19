using System;
using System.Collections.Generic;
using System.Text;

namespace C48_G03_EXAM01
{

    public abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] Answers { get; set; }
        public Answer RightAnswer { get; set; }
        public Answer UserAnswer { get; set; }

        protected Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }

        public abstract void DisplayQuestion();

        public object Clone() => MemberwiseClone();

        public int CompareTo(Question other)
        {
            if (other is null) return 1;
            return Mark.CompareTo(other.Mark);
        }

        public override string ToString() => $"{Header}\n{Body} (Mark: {Mark})";
    }
}
