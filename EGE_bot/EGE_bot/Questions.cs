using Newtonsoft.Json;
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
        public Questions( string jsonText)
        {
            AllQuestions = new List<Task>();
            var parsed = JsonConvert.DeserializeObject<Dictionary<string, Task>>(jsonText);
            foreach (var task in parsed.Values)
            {
                AllQuestions.Add(task);
            }
        }
        public void Add(Task task)
        {
            AllQuestions.Add(task);
        }
        public Task this[int index]
        {
            get
            {
                return AllQuestions[index];
            }
        }

        public Task GetQuastion()
        {
            throw new ArgumentException();
        }
    }
}
