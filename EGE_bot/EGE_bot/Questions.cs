using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGE_bot
{
    class Questions
    {
        private int currentIndex;
        public List<Task> AllQuestions { get; }


        public Questions(params string[] themes)
        {
            currentIndex = -1;
            AllQuestions = new List<Task>();
            AllQuestions = Data.AllQuestions.Where(theme => themes.Contains(theme.Theme)).Select(theme => theme).ToList();
            //foreach (var question in Data.AllQuestions)
            //{
            //    if (themes.Contains(question.Theme))
            //    {
            //        AllQuestions.Add(question);
            //    }
            //}
        }

        public Task GetQuestion()
        {
            currentIndex++;
            if (currentIndex == AllQuestions.Count())
                currentIndex = 0;
            return AllQuestions[currentIndex];
        }

        public Task this[int index]
        {
            get
            {
                return AllQuestions[index];
            }
        }
    }
}
