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
            //bot.OnCallbackQuery += async (object sc, Telegram.Bot.Args.CallbackQueryEventArgs ev) =>
            //{
            //    var message = ev.CallbackQuery.Message;
            //    if (ev.CallbackQuery.Data == "вопрос номер 1")
            //    {
            //        var keyboard = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(new[]
            //        {
            //            new []
            //            {
            //                InlineKeyboardButton.WithCallbackData("тема 1 для задания 1", "тема 1 для задания 1"),
            //                InlineKeyboardButton.WithCallbackData("тема 2 для задания 1", "тема 2 для задания 1")
            //            }
            //        });
            //        await bot.SendTextMessageAsync(message.Chat.Id, "Жамкни!", replyMarkup: keyboard);
            //        Console.WriteLine("1");
            //    }
            //    else
            //    if (ev.CallbackQuery.Data == "вопрос номер 2")
            //    {
            //        var keyboard = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(new[]
            //        {
            //            new []
            //            {
            //                InlineKeyboardButton.WithCallbackData("тема 1 для задания 2", "тема 1 для задания 2")
            //            },
            //            new []
            //            {
            //                InlineKeyboardButton.WithCallbackData("Выбор кода при неиспользуемых сигналах", "тема 1 для задания 2"),
            //            }
            //        });
            //        await bot.SendTextMessageAsync(message.Chat.Id, "Жамкни!", replyMarkup: keyboard);
            //        Console.WriteLine("2");
            //    }
            //};
            Console.ReadLine();
            bot.StopReceiving();
        }

        private async static void OnMessageHandler(object sender, MessageEventArgs e)
        {

            var message = e.Message;

            //var keyboard = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(new[]
            //{
            //    new []
            //    {
            //        InlineKeyboardButton.WithCallbackData("1", "вопрос номер 1"),
            //        InlineKeyboardButton.WithCallbackData("2", "вопрос номер 2"),
            //    }
            //});
            //await bot.SendTextMessageAsync(message.Chat.Id, "Жамкни!", replyMarkup: keyboard);

            if (message.Text == @"/start")
            {
                await bot.SendTextMessageAsync(chatId: message.Chat.Id,
                    text: "выберите", replyMarkup: GetButtons());
                return;
            }

            if (message.Text == @"Выбор задания")
            {
                return;
            }

            foreach (var user in users)
            {
                if (user.ChatId == message.Chat.Id)
                {
                    await bot.SendTextMessageAsync(chatId: user.ChatId,
                        text: user.OnMessageSend(message.Text));

                    if (user.CurrentIndex >= user.CurrentQuestions.Variant.Count)
                    {
                        await bot.SendTextMessageAsync(chatId: user.ChatId,
                            text: "Тест окончен");
                        users.Remove(user);
                        return;
                    }

                    await bot.SendTextMessageAsync(chatId: user.ChatId,
                    text: user.CurrentQuestions[user.CurrentIndex].Question);
                    return;
                }
            }

            if (message.Text == @"Полный варинт")
            {
                var user = new User(message.Chat.Id);
                users.Add(user);


                await bot.SendTextMessageAsync(chatId: user.ChatId,
                    text: user.CurrentQuestions[user.CurrentIndex].Question, replyMarkup: GetButtons());

                if (!string.IsNullOrEmpty(user.CurrentQuestions[user.CurrentIndex].PicturePath))
                    await bot.SendPhotoAsync(message.Chat.Id, user.CurrentQuestions[user.CurrentIndex].PicturePath);

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
