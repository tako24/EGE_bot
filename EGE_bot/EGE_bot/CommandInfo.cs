using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot;

namespace EGE_bot
{
    public class CommandInfo // хранит информацию о команде 
    {
        public string name { get; set; }
        public string text { get; set; }
        public string taskNumber { get; set; }
        public InlineKeyboardMarkup inlineKeyboard { get; set; }

        public CommandInfo(string name, string text, string taskNumber, List<string> buttonsTexts) {
            this.name = name;
            this.text = text;
            this.taskNumber = taskNumber;
            this.inlineKeyboard = CreateReplyMarkup(buttonsTexts);
        }

        private static InlineKeyboardMarkup CreateReplyMarkup(List<string> buttons)
        {
            List<InlineKeyboardButton[]> list = new List<InlineKeyboardButton[]>(); // Создаём массив колонок
            for (int i = 0; i < buttons.Count; ++i)
            {
                if (buttons[i] != "")
                {
                    InlineKeyboardButton button = new InlineKeyboardButton() { CallbackData = $"{buttons[i]}", Text = buttons[i].ToString() };//Создаём кнопку
                    InlineKeyboardButton[] row = new InlineKeyboardButton[1] { button }; // Создаём массив кнопок,в нашем случае он будет из одного элемента
                    list.Add(row);//И добавляем его
                }
            }
            return new InlineKeyboardMarkup(list);//создаём клавиатуру
        }
    }


}
