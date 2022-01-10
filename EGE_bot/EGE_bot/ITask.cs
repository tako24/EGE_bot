using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGE_bot
{
    interface ITask
    {
        string Question { set; get; }
        string Answer { set; get; }
        string Theme { set; get; }
        string Solution { set; get; }
        string PicturePath { set; get; }
        string Number { set; get; }
        bool Check(string result);
    }
}
