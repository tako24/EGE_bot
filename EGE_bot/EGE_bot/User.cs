using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGE_bot
{
    class User
    {
        public Variant CurrentVariant { get; set; }
       // public int CurrentIndex { get; set; }
        public long ChatId { get;  }
        public User(long chatId)
        {
            ChatId = chatId;
            CurrentVariant = new Variant();
            //CurrentIndex = 0;
        }

        public User(long chatId, string str = "")
        {
            ChatId = chatId;
            CurrentVariant = new Variant(str);
            //CurrentIndex = 0;
        }

    }
}
