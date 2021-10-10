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
            PicturePath = task[2];
            Theme = task[3];
        }
        public bool Check(string result)
        {
            return Answer == result;
        }
    }
}
