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
<<<<<<< HEAD
            //switch (update.Type) { }
            SystemTasks.Task handler = null;
=======
            switch (update.Type) { }   
            SystemTasks.Task handler= null;
>>>>>>> 889abdbb9cec898914a7ceff6ac83fd1ce6c1ece
            switch (update.Type)
            {
                case UpdateType.Unknown:
                    break;
                case UpdateType.Message:
                    Console.WriteLine("Клиент {0} с типом {1}", update.Message.Chat.Username, update.Type.ToString());
                    handler = BotOnMessageReceived(botClient, update.Message);
                    break;
                case UpdateType.InlineQuery:
                    Console.WriteLine("fasdfasdgasfdgasdgasdfasdfasd");
                    break;
                case UpdateType.ChosenInlineResult:
                    break;
                case UpdateType.CallbackQuery:
                    handler = BotOnCallbackQueryReceived(botClient, update.CallbackQuery);
                    break;
                //case UpdateType.EditedMessage:
                // handler = BotOnMessageReceived(botClient, update.EditedMessage);
                // break;
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
                await HandleErrorAsync(botClient, exception, cancellationToken);
            }
        }

        private static async SystemTasks.Task BotOnCallbackQueryReceived(ITelegramBotClient bot, CallbackQuery callbackQuery)
        {

            if (AllTasks.Themes.Contains(callbackQuery.Data))
            {
                var user = new User(callbackQuery.Message.Chat.Id, callbackQuery.Data);
                //Console.WriteLine("Добавлен новый юзер - {0}", callbackQuery.Message.Chat.Username);
                Program.users.Add(user);

                await SendTask(bot, user, callbackQuery.Message.Chat.Id);

                //Console.WriteLine(callbackQuery.Message.Text + " " + callbackQuery.Message.Chat.Username + " " + callbackQuery.Message.Chat.Id);
                //Console.WriteLine("{0}", AllTasks.Tasks[0]);
                return;
            }
        
            await bot.EditMessageReplyMarkupAsync(callbackQuery.Message.Chat.Id, callbackQuery.Message.MessageId);
            //Console.WriteLine("Клиент {0} вызвал колбек {1}", callbackQuery.Message.Chat.Username, callbackQuery.Data.ToString());
      
            
            if (AllTasks.Numbers.Contains(callbackQuery.Data))
            {
                var temp = Keyboard.GetInline(AllTasks.Tasks.Where(th => th.Number == callbackQuery.Data).Select(th => th.Theme).Distinct().ToArray());
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
            switch (message.Text)
            {
                case @"/start":
                    await bot.SendTextMessageAsync(chatId: message.Chat.Id,
<<<<<<< HEAD
                    text: "Выбирите", replyMarkup: Keyboard.GetStartReplyKeyboard());
                    return;
                case @"/users":
                    await bot.SendTextMessageAsync(chatId: message.Chat.Id,
                    text: "Выбирите", replyMarkup: Keyboard.GetStartReplyKeyboard());
=======
                           text: "Выбирите", replyMarkup: Keyboard.GetStartReplyKeyboard());
                    return;
                case @"/users":
                    await bot.SendTextMessageAsync(chatId: message.Chat.Id,
                           text: "Выбирите", replyMarkup: Keyboard.GetStartReplyKeyboard());
>>>>>>> 889abdbb9cec898914a7ceff6ac83fd1ce6c1ece
                    return;
                case @"Выбор задания":
                    await bot.SendTextMessageAsync(message.Chat.Id, "Жамкни!", replyMarkup: Keyboard.GetTasksKeyboard(20, 5));
                    return;
                default:
                    break;
            }
<<<<<<< HEAD
=======

>>>>>>> 889abdbb9cec898914a7ceff6ac83fd1ce6c1ece

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
                    text: user.CurrentVariant.OnMessageSend(message.Text));
                    if (user.CurrentVariant.CurrentIndex >= user.CurrentVariant.Tasks.Count)
                    {
                        await bot.SendTextMessageAsync(chatId: user.ChatId,
                        text: "Тест окончен");
                        Console.WriteLine("{0} удален", message.Chat.Username);
                        Program.users.Remove(user);
                        return;
                    }

                    await bot.SendTextMessageAsync(chatId: user.ChatId,
                    text: user.CurrentVariant.GetCurrentQuestion());
                    return;
                }
            }

            if (message.Text == @"Полный вариант")
            {
                var user = new User(message.Chat.Id);
                //Console.WriteLine("Добавлен новый юзер - {0}", message.Chat.Username);
                Program.users.Add(user);
                await SendTask(bot, user, message.Chat.Id);
                //Console.WriteLine(message.Text + " " + message.Chat.Username + " " + message.Chat.Id);
            }
        }

        private static async SystemTasks.Task SendTask(ITelegramBotClient bot, User user, long chatId)
        {
            await bot.SendTextMessageAsync(chatId: user.ChatId,
            text: user.CurrentVariant.GetCurrentQuestion());

            if (!string.IsNullOrEmpty(user.CurrentVariant.GetCurrentPicturepath()))
                await bot.SendPhotoAsync(chatId, user.CurrentVariant.GetCurrentPicturepath());
        }

    }
}