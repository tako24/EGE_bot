using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGE_bot
{
    class CompoundVariant : Variant
    {
        public CompoundVariant(params string[] themes)
        {
            Tasks = AllTasks.Tasks.Where(theme => themes.Contains(theme.Theme)).Select(theme =>theme).OrderBy(a => Guid.NewGuid()).ToList();
        }
    }
}
