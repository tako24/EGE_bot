using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGE_bot
{
    static class AllTasks
    {

        public static List<Task> Tasks { get; }
        public static List<string> Themes { get; }
        public static List<string> Numbers { get; }
        static AllTasks()
        {
            Console.WriteLine("all tasks");
            Tasks = new List<Task>();
            var jsonText = File.ReadAllText("Questions/CorrectJsonFormat.json");
            var parsed = JsonConvert.DeserializeObject<Dictionary<string, Task>>(jsonText);
            foreach (var task in parsed.Values)
            {
                Tasks.Add(task);
            }
            Themes = AllTasks.Tasks.Select(t => t.Theme).Distinct().ToList();
            Numbers = AllTasks.Tasks.Select(t => t.Number).Distinct().ToList();
           // Tasks = Tasks.OrderBy(x => Int32.Parse(x.Number.Split('_')[2])).ToList();
        }
        //public static void Add(Task task)
        //{
        //    AllTasks.Add(task);
        //}
    }
}