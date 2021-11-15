using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot;


namespace EGE_bot
{
    public class ReplyKeyboardInfo : IReplyInfo<ReplyKeyboardMarkup>  // хранит информацию о команде 
    { 
        public string Text { get; set; }
        public ReplyKeyboardMarkup Keyboard { get; set; }

 

        public ReplyKeyboardInfo( string text, List<string> buttonsTexts, bool ResizeKeyboard, bool OneTimeKeyboard) {
            this.Text = text;
            this.Keyboard = CreateMarkup(buttonsTexts, ResizeKeyboard, OneTimeKeyboard);
        }

        private static ReplyKeyboardMarkup CreateMarkup(List<string> buttons, bool resizeKeyboard, bool oneTimeKeyboard)
        {
            var keyboardList = new List<KeyboardButton[]>(); // Создаём массив колонок
            for (int i = 0; i < buttons.Count; ++i)
            {
                if (buttons[i] != "")
                {
                    KeyboardButton button = new KeyboardButton() {Text = buttons[i].ToString()};//Создаём кнопку
                    KeyboardButton[] row = new KeyboardButton[1] {button}; // Создаём массив кнопок,в нашем случае он будет из одного элемента
                    keyboardList.Add(row);//И добавляем его
                }
            }
            return new ReplyKeyboardMarkup
            {
                Keyboard = keyboardList,
                ResizeKeyboard = resizeKeyboard,
                OneTimeKeyboard = oneTimeKeyboard
            };
           
        }
    }


}
