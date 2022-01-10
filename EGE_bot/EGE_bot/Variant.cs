using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGE_bot
{
    class Variant
    {
        public int currentIndex;
        public  List<Task> Tasks { get; }
        private int fullVariantTasksCount = 21;
        public int correctAnswers;
        public Variant()
        {
            Tasks = new List<Task>();
            for (var i = 1; i <= fullVariantTasksCount; i++)
            {
                Tasks.Add(AllTasks.Tasks.Where(number => number.Number == (i.ToString())).Select(x => x).OrderBy(a => Guid.NewGuid()).ToList()[0]);
            }
            Tasks.OrderBy(a => Guid.NewGuid()).ToList();
        }

        public Variant(string theme)
        {
            currentIndex = 0;
            Tasks = AllTasks.Tasks.Where(task => task.Theme == theme).Select(task => task).OrderBy(a => Guid.NewGuid()).ToList();
        }

        public string GetCurrentPicturepath()
        {
            return this[currentIndex].PicturePath;
        }

        public string GetCurrentQuestion()
        {
            return this[currentIndex].Question;
        }

        public string GetSolution(string text)
        {
            var temp = this[currentIndex].Check(text);
            string sulution = "Неверно!\nСмотри правильое решение:\n" + this[currentIndex].Solution;
            if (temp)
            {
                correctAnswers++;
                sulution = "Верно";
            }
            currentIndex++;
            return sulution;
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
