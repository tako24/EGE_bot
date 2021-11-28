using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGE_bot
{
    class Task
    {
        public string Question { set; get; }
        public string Answer { set; get; }
        public string Theme { set; get; }
        public string Solution { set; get; }
        public string PicturePath { set; get; }
        public string Number { set; get; }

        //public Task(string[] task)
        //{
        //    Question = task[0];
        //    Answer = task[1];
        //    Theme = task[2];
        //    PicturePath = task[3];
        //}

        //public Task(string question, string answer, string theme, string picturePath = "")
        //{
        //    Question = question;
        //    Answer = answer;
        //    PicturePath = picturePath;
        //    Theme = theme;
        //}
        public bool Check(string result)
        {
            return Answer.Trim() == result.Trim();
        }
        public override string ToString() => string.Format("{0}\n{1}\n{2}\n{3}", Question, Answer, Theme, PicturePath);
    }
}
