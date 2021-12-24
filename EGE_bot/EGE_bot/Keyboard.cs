using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace EGE_bot
{
    static class Keyboard
    {
        public static IReplyMarkup GetInlineKeyboard(int taskNumber)
        {
            switch (taskNumber)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                default:
                    break;
            }
        }
        public static IReplyMarkup GetStartReplyKeyboard()
        {
            var Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton("Выбор задания") },
                    new List<KeyboardButton>{ new KeyboardButton("Полный вариант") }
                };
            return new ReplyKeyboardMarkup(Keyboard);
        }

        public static IReplyMarkup GetInline(params string[] tasksName)
        {

            var Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton("Выбор задания") },
                    new List<KeyboardButton>{ new KeyboardButton("Полный вариант") }
                };
            return new ReplyKeyboardMarkup(Keyboard);
        }

        public static IReplyMarkup GetBackKeyboard()
        {
            var Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton("Назад") }
                };
            return new ReplyKeyboardMarkup(Keyboard);
        }

        public static IReplyMarkup GetTasksKeyboard(int count, int length = 8)
        {
            if (length>8)
            {
                length = 8;
            }
            var keyboard = new List<List<InlineKeyboardButton>>();
            keyboard.Add(new List<InlineKeyboardButton>());
            for (int i = 0; i < count; i++) 
            {
                if (i % length == 0)
                {
                    keyboard.Add(new List<InlineKeyboardButton>());
                }
                keyboard[keyboard.Count - 1].Add(InlineKeyboardButton.WithCallbackData((i + 1).ToString(),  (i + 1).ToString()));
            }
            return new InlineKeyboardMarkup(keyboard);
        }
    }
}
