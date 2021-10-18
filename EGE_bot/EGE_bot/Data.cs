using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGE_bot
{
    static class Data
    {
        public static List<Task> AllQuestions { get; }
        static Data()
        {
            AllQuestions = new List<Task>();
            var jsonText = File.ReadAllText("Questions/CorrectJsonFormat.json");
            var parsed = JsonConvert.DeserializeObject<Dictionary<string, Task>>(jsonText);
            foreach (var task in parsed.Values)
            {
                AllQuestions.Add(task);
            }
        }

        public static void Add(Task task)
        {
            AllQuestions.Add(task);
        }
    }
}
