using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using Newtonsoft.Json;
using System.Threading;

namespace EGE_bot
{

    class Program
    {
        private static string Token { get; } = "2061132160:AAHRnhICjh2hP3RlwXUopKKDZ1aBx3ZRfMg";
        private static TelegramBotClient bot;
        private static List<User> users;
        static void Main(string[] args)
        {
            bot = new TelegramBotClient(Token);
            bot.StartReceiving();
            users = new List<User>();
            bot.OnMessage += OnMessageHandler;
            Console.ReadLine();
            bot.StopReceiving();
        }

        private async static void OnMessageHandler(object sender, MessageEventArgs e)
        {
            
            var message = e.Message;
            if (message.Text == @"/start")
            {
                await bot.SendTextMessageAsync(chatId: message.Chat.Id
                    , text: "выберите", replyMarkup: GetButtons());
            }
            foreach (var user in users)
            {
                if (user.ChatId == message.Chat.Id)
                    await bot.SendTextMessageAsync(chatId: user.ChatId
                    , text: user.OnMessageSend(message.Text));
                if (user.CurrentIndex>= user.CurrentQuestions.Variant.Count)
                {
                    await bot.SendTextMessageAsync(chatId: user.ChatId
                    , text: "Тест окончен");
                    users.Remove(user);
                    return;
                }
                await bot.SendTextMessageAsync(chatId: user.ChatId
                    , text: user.CurrentQuestions[user.CurrentIndex].Question);
                return;
            }
            if (message.Text == @"Полный варинт")
            {
                var user = new User(message.Chat.Id);
                users.Add(user);
                await bot.SendTextMessageAsync(chatId: user.ChatId
                    , text: user.CurrentQuestions[user.CurrentIndex].Question,replyMarkup: GetButtons());

                Console.WriteLine(e.Message.Text + " " + message.Chat.Username + " " + message.Chat.Id);
            }

        }
        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Полный варинт"} },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Выбор задания"} },
                }
            };
        }
    }
}
