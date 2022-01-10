using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGE_bot
{
    class FullVariant : Variant
    {
        private int fullVariantTasksCount = 20;
        public FullVariant()
        {
            Tasks = new List<Task>();
            for (var i = 1; i <= fullVariantTasksCount; i++)
            {
                Tasks.Add(AllTasks.Tasks.Where(number => number.Number == (i.ToString())).Select(x => x).OrderBy(a => Guid.NewGuid()).ToList()[0]);
            }
            Tasks.OrderBy(a => Guid.NewGuid()).ToList();
        }

    }
}
