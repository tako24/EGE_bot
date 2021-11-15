using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot;


namespace EGE_bot
{
    class ReplyKeyboardMarkups
    {
        public static IReplyMarkup GetButtons()
        {
            return StartKeyboard;
        }

        public static ReplyKeyboardMarkup StartKeyboard = new ReplyKeyboardMarkup
        {
            Keyboard = new[] {
                new[] // row 1
                               {
                    new KeyboardButton("Выдать вариант"),
                    new KeyboardButton("Выбрать номер задания")
                },
            },
            ResizeKeyboard = true,
            OneTimeKeyboard = true

        };

        public ReplyKeyboardMarkup SecondKeyboard = new ReplyKeyboardMarkup
        {
            Keyboard = new[] {
                new[] // row 1
                               {
                    new KeyboardButton("Назад к выбору формата"),
                },
            },
            ResizeKeyboard = true,
            OneTimeKeyboard = true

        };

        public ReplyKeyboardMarkup ThirdKeyboard = new ReplyKeyboardMarkup
        {
            Keyboard = new[] {
                new[] // row 1
                               {
                    new KeyboardButton("Назад к выбору номера задания"),
                },
            },
            ResizeKeyboard = true,
            OneTimeKeyboard = true

        };

        public ReplyKeyboardMarkup FourthKeyboard = new ReplyKeyboardMarkup
        {
             Keyboard = new[] {
                new[] // row 1
                               {
                    new KeyboardButton("Назад к выбору темы"),
                    new KeyboardButton("Выдать вариант"),
                    new KeyboardButton("Выбрать номер задания"),
                },
            },
            ResizeKeyboard = true,
            OneTimeKeyboard = true

        };

    }
}
