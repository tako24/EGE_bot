using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace EGE_bot
{

    public class CommandInfo 
    {
        public string name { get; set; }
        public string text { get; set; }
        public List<string> buttonsTexts { get; set; }
        //public CommandInfo(string name, string text, List<string> buttons)
        //{
        //    this.name = name;
        //    this.text = text;
        //    List<InlineKeyboardButton[]> list = new List<InlineKeyboardButton[]>(); // Создаём массив колонок
        //    for (int i = 0; i < buttons.Count; ++i)
        //    {
        //        InlineKeyboardButton button = new InlineKeyboardButton() { CallbackData = "Data", Text = buttons[i].ToString() };//Создаём кнопку
        //        InlineKeyboardButton[] row = new InlineKeyboardButton[1] { button }; // Создаём массив кнопок,в нашем случае он будет из одного элемента
        //        list.Add(row);//И добавляем его
        //    }
        //    this.keyboard = new InlineKeyboardMarkup(list);//создаём клавиатуру
        //}
    }
    public class CommandInfoWithInlineKeyBoard
    {
        public string name { get; set; }
        public string text { get; set; }
        public InlineKeyboardMarkup inlineKeyboard { get; set; }

        public CommandInfoWithInlineKeyBoard(string name, string text, InlineKeyboardMarkup inlineKeyboard) {
            this.name = name;
            this.text = text;
            this.inlineKeyboard = inlineKeyboard;
        }
    }
}
