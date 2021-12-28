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
        public static IReplyMarkup GetStartReplyKeyboard()
        {
            var list = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton("Выбор задания") },
                    new List<KeyboardButton>{ new KeyboardButton("Полный вариант") }
                };
            var keyboard = new ReplyKeyboardMarkup(list);
            keyboard.ResizeKeyboard = true;
            return keyboard;
        }

        public static IReplyMarkup GetInline(params string[] tasksNames)
        {
            var keyboard = new List<List<InlineKeyboardButton>>();
            foreach (var tasksName in tasksNames)
            {
                keyboard.Add(new List<InlineKeyboardButton> { InlineKeyboardButton.WithCallbackData(tasksName, tasksName) });
            }
            return new InlineKeyboardMarkup(keyboard);
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
                keyboard[keyboard.Count - 1].Add(InlineKeyboardButton.WithCallbackData((i + 1).ToString(), "инф"+(i + 1).ToString()));
            }
            return new InlineKeyboardMarkup(keyboard);
        }
    }
}
