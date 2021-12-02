using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGE_bot
{
    class User
    {
        public Questions CurrentQuestions { get; set; }
        public int CurrentIndex { get; set; }
        public long ChatId { get;  }
        public User(long chatId)
        {
            ChatId = chatId;
            CurrentQuestions = new Questions();
            CurrentIndex = 0;
        }
        public string OnMessageSend(string text)
        {
            CurrentQuestions[CurrentIndex].Check(text);
            string temp = "Верно";
            if (!CurrentQuestions[CurrentIndex].isCorrectAnswer)
            {
                temp =  CurrentQuestions[CurrentIndex].Solution;
            }
            CurrentIndex++;
            return temp;
        }
    }
}
