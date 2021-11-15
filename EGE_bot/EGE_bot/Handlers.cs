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
            var flag = true;
            if (CommandsData.InlineKeyboardMarkups.RepliesDict.ContainsKey(message.Text))
            {
                await SendInlineKeyboard(botClient, message, CommandsData.InlineKeyboardMarkups.RepliesDict[message.Text]);
                flag = false;
            }

            if (CommandsData.ReplyKeyboardMarkups.RepliesDict.ContainsKey(message.Text))
            {
                await SendReplyKeyboard(botClient, message, CommandsData.ReplyKeyboardMarkups.RepliesDict[message.Text]);
                flag = false;
            }
         
            if (flag == true) await UnknownMessage(botClient, message);

            static async sysTask.Task<Message> SendReplyKeyboard(ITelegramBotClient botClient, Message message, ReplyKeyboardInfo repliesDict)
            {
                return await botClient.SendTextMessageAsync(message.Chat.Id, repliesDict.Text, replyMarkup: repliesDict.Keyboard);
            }

            static async sysTask.Task<Message> SendInlineKeyboard(ITelegramBotClient botClient, Message message, InlineKeyboardInfo commandInfo)
            {
                return await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                            text: String.Format("{0}", commandInfo.Text),
                                                          replyMarkup: commandInfo.Keyboard);
            }

            static async sysTask.Task<Message> UnknownMessage(ITelegramBotClient botClient, Message message)
            {
                const string usage = "отправьте /start , чтобы начать работу\n";

                return await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                            text: usage,
                                                            replyMarkup: new ReplyKeyboardRemove());
            }
        }

        private static async sysTask.Task BotOnCallbackQueryReceived(ITelegramBotClient botClient, CallbackQuery callbackQuery)
        {
            var flag = true;
            if (CommandsData.InlineKeyboardMarkups.RepliesDict.ContainsKey(callbackQuery.Data))
            {
                await SendInlineKeyboard(botClient, callbackQuery , CommandsData.InlineKeyboardMarkups.RepliesDict[callbackQuery.Data]);
                flag = false;
            }

            static async sysTask.Task<Message> SendInlineKeyboard(ITelegramBotClient botClient, CallbackQuery callbackQuery, InlineKeyboardInfo inlineKeyboardInfo)
            {
                return await botClient.SendTextMessageAsync(
                chatId: callbackQuery.Message.Chat.Id,
                text: inlineKeyboardInfo.Text,
                replyMarkup: inlineKeyboardInfo.Keyboard);
            }
            if (flag == true)
            { 
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