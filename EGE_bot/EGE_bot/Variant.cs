using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGE_bot
{
    class Variant
    {
        public int CurrentIndex;
        public  List<Task> Tasks { get; }

        public Variant()
        {
            Tasks = new List<Task>();
            for (var i = 1; i <= 3; i++)
            {
                Tasks.Add(AllTasks.Tasks.Where(number => number.Number == ("инф" + i.ToString())).Select(x => x).OrderBy(a => Guid.NewGuid()).ToList()[0]);
            }
            Tasks.OrderBy(a => Guid.NewGuid()).ToList();
        }

        public Variant(string theme)
        {
            CurrentIndex = 0;
           // Tasks = new List<Task>();
            Tasks = AllTasks.Tasks.Where(task => task.Theme == theme).Select(task => task).OrderBy(a => Guid.NewGuid()).ToList();
            //Console.WriteLine("{0}", Tasks);
            //foreach (var question in Data.AllQuestions)
            //{`
            //    if (themes.Contains(question.Theme))
            //    {
            //        AllQuestions.Add(question);
            //    }
            //}
        }

        public string GetCurrentPicturepath()
        {
            return this[CurrentIndex].PicturePath;
        }

        public string GetCurrentQuestion()
        {
            return this[CurrentIndex].Question;
        }

        //public Task GetTask()
        //{
        //    CurrentIndex++;
        //    if (CurrentIndex == Tasks.Count())
        //        CurrentIndex = 0;
        //    return Tasks[CurrentIndex];
        //}

        public string OnMessageSend(string text)
        {
            this[CurrentIndex].Check(text);
            string temp = "Верно";
            if (!this[CurrentIndex].Check(text))
            {
                temp = this[CurrentIndex].Solution;
            }
            CurrentIndex++;
            return temp;
        }

        public Task this[int index]
        {
            get
            {
                return Tasks[index];
            }
        }
    }
}
