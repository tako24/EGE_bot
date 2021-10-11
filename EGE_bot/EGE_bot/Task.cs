using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGE_bot
{
    class Task
    {
        public string Question { get; }
        public string Answer { get; }
        public string PicturePath { get; }
        public string Theme { get; }
        public Task(string[] task)
        {
            Question = task[0];
            Answer = task[1];
            Theme = task[2];
            PicturePath = task[3];

        }
        public Task(string question, string answer, string theme, string picturePath = "")
        {
            Question = question;
            Answer = answer;
            PicturePath = picturePath;
            Theme = theme;
        }
        public bool Check(string result)
        {
            return Answer == result;
        }
    }
}
