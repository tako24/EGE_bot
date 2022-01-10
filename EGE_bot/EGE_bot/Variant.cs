using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGE_bot
{
    abstract class Variant 
    {
        protected virtual List<Task> Tasks { get; set; }
        public int Count { get { return Tasks.Count; } }
        public int CurrentIndex { get; set; }
        public int CorrectAnswersCount { get; set; }
        virtual public string GetSolution(string text) 
        {
            if (this[CurrentIndex].Check(text))
            {
                CorrectAnswersCount++;
                CurrentIndex++;
                return "Верно";
            }
            string sulution = "Неверно!\nСмотри правильое решение:\n" + this[CurrentIndex].Solution;
            CurrentIndex++;
            return sulution;
        }
        virtual public string GetCurrentPicturepath()
        {
            return this[CurrentIndex].PicturePath;
        }

        virtual public string GetCurrentQuestion()
        {
            return this[CurrentIndex].Question;
        }
        public ITask this[int index]
        {
            get
            {
                return Tasks[index];
            }
        }
    }
}
