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
