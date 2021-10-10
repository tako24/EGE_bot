﻿using System;
using System.Collections.Generic;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace inf_sdamgia_bot
{

    class Program
    {
        private static string Token { get; } = "2061132160:AAHRnhICjh2hP3RlwXUopKKDZ1aBx3ZRfMg";
        private static TelegramBotClient client;
        static void Main(string[] args)
        {
            client = new TelegramBotClient(Token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            client.StopReceiving();
            var x = File.ReadAllLines("Questions/Test.txt");
            Console.WriteLine(x[0]);
            Console.ReadLine();
        }

        private async static void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if (message != null)
                Console.WriteLine("Check");
            await client.SendTextMessageAsync(message.Chat.Id, message.Text, replyMarkup: GetButtons());

        }
        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "fsdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdf"} },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "342"} },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "fdfsafasd"} },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "fsdfasdfasdffasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdf"} },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "234123423541235134523451254523452345134"} }
                }
            };
        }
    }
}
