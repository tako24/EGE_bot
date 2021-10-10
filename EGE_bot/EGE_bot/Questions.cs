using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGE_bot
{
    class Questions
    {
        public List<Task> AllQuestions { get; }
        public Questions()
        {
            AllQuestions = new List<Task>();
            var tasks = File.ReadAllLines("Questions/Test.txt");
            foreach (var task in tasks)
            {
                var temp = task.Split('|');
                AllQuestions.Add(new Task(temp));
            }
        }
        public Task GetQuastion()
        {
            throw new ArgumentException();
        }
    }
}
