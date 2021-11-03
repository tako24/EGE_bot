using System;
using System.IO;
using System.Linq;
using System.Threading;
using sysTask = System.Threading.Tasks;
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
    public class Handlers
    {
        public static sysTask.Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return sysTask.Task.CompletedTask;
        }

        public static async sysTask.Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var handler = update.Type switch
            {
                UpdateType.Message => BotOnMessageReceived(botClient, update.Message),
                UpdateType.EditedMessage => BotOnMessageReceived(botClient, update.EditedMessage),
                UpdateType.CallbackQuery => BotOnCallbackQueryReceived(botClient, update.CallbackQuery),
                _ => UnknownUpdateHandlerAsync(botClient, update)
            };

            try
            {
                await handler;
            }
            catch (Exception exception)
            {
                await HandleErrorAsync(botClient, exception, cancellationToken);
            }
        }

        private static async sysTask.Task BotOnMessageReceived(ITelegramBotClient botClient, Message message) // можно вместо команд сделать inline кнопки с командами 
        {
            Console.WriteLine($"Receive message type: {message.Type}");
            if (message.Type != MessageType.Text)
                return;
            var commandsDict = CommandsData.CommandsDict;


            var action = (message.Text.Split(' ').First()) switch
            {
                "/start" => SendInlineKeyboard(botClient, message, commandsDict["/start"]),
                "/fulltest" => SendInlineKeyboard(botClient, message, commandsDict["/fulltest"]),
                "/tasknumber" => SendInlineKeyboard(botClient, message, commandsDict["/tasknumber"]),
                "/theme" => SendInlineKeyboard(botClient, message, commandsDict["/theme"]),
                _ => Usage(botClient, message)
            };
            var sentMessage = await action;


            static async sysTask.Task<Message> SendInlineKeyboard(ITelegramBotClient botClient, Message message, CommandInfo commandInfo)
            {
                return await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                            text: String.Format("{0}", commandInfo.text),
                                                          replyMarkup: commandInfo.inlineKeyboard);
            }

            static async sysTask.Task<Message> Usage(ITelegramBotClient botClient, Message message)
            {
                const string usage = "Выбери команду:\n" +
                                     "/start   - выбор формата работы(решение полного варианта или конкретного номера)\n" +
                                     "/fulltest - выдача варианта\n" +
                                     "/tasknumber - выбор номера задания\n" +
                                     "/theme - выбор темы задания\n";

                return await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                            text: usage,
                                                            replyMarkup: new ReplyKeyboardRemove());
            }
        }

        private static async sysTask.Task BotOnCallbackQueryReceived(ITelegramBotClient botClient, CallbackQuery callbackQuery)
        {
            //await botClient.AnswerCallbackQueryAsync(
            //    callbackQueryId: callbackQuery.Id,
            //    text: $"Received {callbackQuery.Data}");

            var commandsDict = CommandsData.CommandsDict;
            var gf = commandsDict["/tasknumber"];

            if (callbackQuery.Data == "/tasknumber") // пример того, как настраивать ответ на нажатие кнопки. Нужно реализовать так, чтобы работало с большим количеством кнопок.
            {
                await botClient.SendTextMessageAsync(
                chatId: callbackQuery.Message.Chat.Id,
                text: gf.text,
                replyMarkup: gf.inlineKeyboard); //можно добавить кнопку назад
            }
            else {
                await botClient.SendTextMessageAsync(
              chatId: callbackQuery.Message.Chat.Id,
              text: $"Received {callbackQuery.Data}");
            }

           
        }


        private static sysTask.Task UnknownUpdateHandlerAsync(ITelegramBotClient botClient, Update update)
        {
            Console.WriteLine($"Unknown update type: {update.Type}");
            return sysTask.Task.CompletedTask;
        }
    }
}