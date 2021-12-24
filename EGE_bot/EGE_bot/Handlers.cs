using System;
using System.IO;
using System.Linq;
using System.Threading;
using SystemTasks = System.Threading.Tasks;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot;
using System.Collections.Generic;
namespace EGE_bot
{
    class Handlers
    {
        public static SystemTasks.Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception.ToString();

            Console.WriteLine(ErrorMessage);
            return SystemTasks.Task.CompletedTask;
        }
        public static async SystemTasks.Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            SystemTasks.Task handler= null;
            switch (update.Type)
            {
                case UpdateType.Unknown:
                    break;
                case UpdateType.Message:
                    Console.WriteLine("Клиент {0} с типом {1}", update.Message.Chat.Username, update.Type.ToString());
                    handler = BotOnMessageReceived(botClient, update.Message);
                    break;
                case UpdateType.InlineQuery:
                    break;
                case UpdateType.ChosenInlineResult:
                    break;
                case UpdateType.CallbackQuery:
                    handler = BotOnCallbackQueryReceived(botClient, update.CallbackQuery);
                    break;
                //case UpdateType.EditedMessage:
                //    handler = BotOnMessageReceived(botClient, update.EditedMessage);
                //    break;
                default:
                    handler = UnknownUpdateHandlerAsync(botClient, update);
                    break;
            }

            try
            {
                await handler;
            }
            catch (Exception exception)
            {
                //await HandleErrorAsync(botClient, exception, cancellationToken);
            }
        }



        private static async SystemTasks.Task BotOnCallbackQueryReceived(ITelegramBotClient bot, CallbackQuery callbackQuery)
        {
            foreach (var item in Program.themes.Values)
            {
                if (item.Contains(callbackQuery.Data))
                {
                    var user = new User(callbackQuery.Message.Chat.Id, callbackQuery.Data);
                    Console.WriteLine("Добавлен новый юзер - {0}", callbackQuery.Message.Chat.Username);
                    Program.users.Add(user);


                    await bot.SendTextMessageAsync(chatId: user.ChatId,
                        text: user.CurrentQuestions[user.CurrentIndex].Question);

                    if (!string.IsNullOrEmpty(user.CurrentQuestions[user.CurrentIndex].PicturePath))
                        await bot.SendPhotoAsync(callbackQuery.Message.Chat.Id, user.CurrentQuestions[user.CurrentIndex].PicturePath);

                    Console.WriteLine(callbackQuery.Message.Text + " " + callbackQuery.Message.Chat.Username + " " + callbackQuery.Message.Chat.Id);
                    return;
                }
            }
            await bot.EditMessageReplyMarkupAsync(callbackQuery.Message.Chat.Id, callbackQuery.Message.MessageId);
            Console.WriteLine("Клиент {0} вызвал колбек {1}", callbackQuery.Message.Chat.Username, callbackQuery.Data.ToString());
            if (Program.themes.ContainsKey(callbackQuery.Data))
            {
                var temp = Keyboard.GetInline(Program.themes[callbackQuery.Data]);
                Console.WriteLine(Program.themes[callbackQuery.Data][0]);
                await bot.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "Выбери тему!", replyMarkup: temp);
            }
        }
        private static SystemTasks.Task UnknownUpdateHandlerAsync(ITelegramBotClient botClient, Update update)
        {
            Console.WriteLine($"Unknown update type: {update.Type}");
            return SystemTasks.Task.CompletedTask;
        }

        private static async SystemTasks.Task BotOnMessageReceived(ITelegramBotClient bot, Message message)
        {
            if (message.Text == @"/start")
            {
                await bot.SendTextMessageAsync(chatId: message.Chat.Id,
                    text: "Выбирите", replyMarkup: Keyboard.GetStartReplyKeyboard());
                return;
            }

            if (message.Text == @"Выбор задания")
            {
                await bot.SendTextMessageAsync(message.Chat.Id, "Жамкни!", replyMarkup: Keyboard.GetTasksKeyboard(20,5));
                return;
            }

            foreach (var user in Program.users)
            {
                if (user.ChatId == message.Chat.Id)
                {
                    if (message.Text == @"Полный вариант" || message.Text == @"Выбор задания") 
                    {
                        Program.users.Remove(user);
                        break;
                    }
                    await bot.SendTextMessageAsync(chatId: user.ChatId,
                        text: user.OnMessageSend(message.Text));
                    if (user.CurrentIndex >= user.CurrentQuestions.Variant.Count)
                    {
                        await bot.SendTextMessageAsync(chatId: user.ChatId,
                            text: "Тест окончен");
                        Console.WriteLine("{0} удален", message.Chat.Username);
                        Program.users.Remove(user);
                        return;
                    }

                    await bot.SendTextMessageAsync(chatId: user.ChatId,
                    text: user.CurrentQuestions[user.CurrentIndex].Question);
                    return;
                }
            }

            if (message.Text == @"Полный вариант")
            {
                var user = new User(message.Chat.Id);
                Console.WriteLine("Добавлен новый юзер - {0}", message.Chat.Username);
                Program.users.Add(user);


                await bot.SendTextMessageAsync(chatId: user.ChatId,
                    text: user.CurrentQuestions[user.CurrentIndex].Question);

                if (!string.IsNullOrEmpty(user.CurrentQuestions[user.CurrentIndex].PicturePath))
                    await bot.SendPhotoAsync(message.Chat.Id, user.CurrentQuestions[user.CurrentIndex].PicturePath);

                Console.WriteLine(message.Text + " " + message.Chat.Username + " " + message.Chat.Id);
            }
        }
    }
}
