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
        public long ChatId { get;  }
        public User(long chatId)
        {
            ChatId = chatId;
            CurrentVariant = new FullVariant();
        }

        public User(long chatId, string str = "")
        {
            ChatId = chatId;
            CurrentVariant = new CompoundVariant(str);
        }

    }
}
