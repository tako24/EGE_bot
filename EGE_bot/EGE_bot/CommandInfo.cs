using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace EGE_bot
{

    public class CommandInfo // нужен только для десериализации
    {
        public string name { get; set; }
        public string text { get; set; }
        public string taskNumber { get; set; }
        public List<string> buttonsTexts { get; set; }
    }
    public class CommandInfoWithInlineKeyboard // хранит информацию о команде 
    {
        public string name { get; set; }
        public string text { get; set; }
        public string taskNumber { get; set; }
        public InlineKeyboardMarkup inlineKeyboard { get; set; }

        public CommandInfoWithInlineKeyboard(string name, string text, string taskNumber, InlineKeyboardMarkup inlineKeyboard) {
            this.name = name;
            this.text = text;
            this.taskNumber = taskNumber;
            this.inlineKeyboard = inlineKeyboard;
        }
    }
}
