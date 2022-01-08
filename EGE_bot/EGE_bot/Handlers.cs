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
            //switch (update.Type) { }
            SystemTasks.Task handler = null;
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
            if (AllTasks.Numbers.Contains(callbackQuery.Data))
            {
                var temp = Keyboard.GetInline(AllTasks.Tasks.Where(th => th.Number == callbackQuery.Data).Select(th => th.Theme).Distinct().ToArray());
                await bot.EditMessageReplyMarkupAsync(callbackQuery.Message.Chat.Id, callbackQuery.Message.MessageId);
                await bot.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "Выбери тему!", replyMarkup: temp);
            }

            foreach (var theme in AllTasks.Themes)
            {
                var temp = theme;
                if (theme.Length > 29)
                {
                    temp = theme.Substring(0, 29);
                }

                if (temp.Contains(callbackQuery.Data))
                {
                    var user = new User(callbackQuery.Message.Chat.Id, theme);
                    Program.users.Add(user);

                    await SendTask(bot, user);
                    return;
                }
            }
        }

        private static SystemTasks.Task UnknownUpdateHandlerAsync(ITelegramBotClient botClient, Update update)
        {
            Console.WriteLine($"Unknown update type: {update.Type}");
            return SystemTasks.Task.CompletedTask;
        }

        private static async SystemTasks.Task BotOnMessageReceived(ITelegramBotClient bot, Message message)
        {
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

                    if (user.CurrentVariant.currentIndex >= user.CurrentVariant.Tasks.Count)
                    {
                        await bot.SendTextMessageAsync(chatId: user.ChatId,
                        text: "Тест окончен");
                        Console.WriteLine("{0} удален", message.Chat.Username);
                        Program.users.Remove(user);
                        return;
                    }
                    await SendTask(bot, user);
                    return;
                }
            }

            switch (message.Text)
            {
                case @"/start":
                    await bot.SendTextMessageAsync(chatId: message.Chat.Id,
                    text: "Выбирите", replyMarkup: Keyboard.GetStartReplyKeyboard());
                    return;
                case @"/users":
                    await bot.SendTextMessageAsync(chatId: message.Chat.Id,
                    text: "Выбирите", replyMarkup: Keyboard.GetStartReplyKeyboard());
                    return;
                case @"Выбор задания":
                    await bot.SendTextMessageAsync(message.Chat.Id, "Жамкни!", replyMarkup: Keyboard.GetTasksKeyboard(20, 5));
                    return;
                case @"Полный вариант":
                    var user = new User(message.Chat.Id);
                    Program.users.Add(user);
                    await SendTask(bot, user);
                    return;
                default:
                    break;
            }
        }


        private static async SystemTasks.Task SendTask(ITelegramBotClient bot, User user)
        {
            if (!string.IsNullOrEmpty(user.CurrentVariant.GetCurrentPicturepath()))
                await bot.SendPhotoAsync(user.ChatId, user.CurrentVariant.GetCurrentPicturepath());

            await bot.SendTextMessageAsync(chatId: user.ChatId,
            text: user.CurrentVariant.GetCurrentQuestion());
        }

    }
}