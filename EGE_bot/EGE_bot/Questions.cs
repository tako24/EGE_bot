using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGE_bot
{
    class Questions
    {
        public int CurrentIndex;
        public List<Task> Variant { get; }

        public Questions()
        {
            Variant = new List<Task>();
            for (var i = 1; i <= 3; i++)
            {
                Variant.Add(Data.AllQuestions.Where(number => number.Number == i.ToString()).Select(x => x).OrderBy(a => Guid.NewGuid()).ToList()[0]); 
            }
        }

        public Questions(params string[] themes)
        {
            CurrentIndex = -1;
            Variant = new List<Task>();
            Variant = Data.AllQuestions.Where(theme => themes.Contains(theme.Theme)).Select(theme => theme).OrderBy(a => Guid.NewGuid()).ToList();
            //foreach (var question in Data.AllQuestions)
            //{
            //    if (themes.Contains(question.Theme))
            //    {
            //        AllQuestions.Add(question);
            //    }
            //}
        }

        public Task GetTask()
        {
            CurrentIndex++;
            if (CurrentIndex == Variant.Count())
                CurrentIndex = 0;
            return Variant[CurrentIndex];
        }

        public Task this[int index]
        {
            get
            {
                return Variant[index];
            }
        }
    }
}
