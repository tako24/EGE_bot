using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGE_bot
{
    class Task : ITask
    {
        public string Question { set; get; }
        public string Answer { set; get; }
        public string Theme { set; get; }
        public string Solution { set; get; }
        public string PicturePath { set; get; }
        public string Number { set; get; }

        public bool Check(string result)
        {
            Console.WriteLine("Answer is " + (Answer.Trim() == result.Trim()).ToString());
            return Answer.Trim() == result.Trim();
        }
        public override string ToString() => string.Format("{0}\n{1}\n{2}\n{3}", Question, Answer, Theme, PicturePath);
    }
}
