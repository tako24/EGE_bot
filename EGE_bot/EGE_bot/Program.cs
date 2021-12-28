using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using Newtonsoft.Json;
using System.Threading;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot.Extensions.Polling;

namespace EGE_bot
{

    class Program
    {
        private static string Token { get; } = "2061132160:AAHRnhICjh2hP3RlwXUopKKDZ1aBx3ZRfMg";
        private static TelegramBotClient bot;
        public static List<User> users;
        public static Dictionary<string, string[]> themes = new Dictionary<string, string[]> 
        {
            {"инф1", new string[]{ "Поиск оптимального маршрута", "Неоднозначное соотнесение таблицы и графа", "Однозначное соотнесение таблицы и графа"} },
            {"инф2", new string[]{ "Монотонные функции ", "Немонотонные функции ", "Строки с пропущенными значениями","Разные задачи " } },
            {"инф3", new string[]{ "Задания для подготовки" } },
            {"инф4", new string[]{ "Выбор кода при неиспользуемых сигналах", "Расшифровка сообщений " } },
            {"инф5", new string[]{ "Исполнители на плоскости", "Разные задачи" } },
            {"инф6", new string[]{ "3", "2" } }


        };
        static void Main(string[] args)
        {
            users = new List<User>();
            
            bot = new TelegramBotClient(Token);
            CancellationTokenSource cts = new CancellationTokenSource();
            bot.StartReceiving(new DefaultUpdateHandler(Handlers.HandleUpdateAsync,Handlers.HandleErrorAsync));
            Console.ReadLine();
            cts.Cancel();

        }
    }
}
