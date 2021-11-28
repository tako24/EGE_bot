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
        private static TelegramBotClient client;
        static void Main(string[] args)
        {
            var client = new TelegramBotClient(Token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            //var a = new Questions("Шифрование по известному коду и перевод в различные СС", "Передача информации. Выбор кода");
            //foreach (var item in a.AllQuestions)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //Console.WriteLine(a.AllQuestions.Count());

            Console.ReadLine();
            //client.StopReceiving();
        }

        private async static void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if (message != null)
            {
                Console.WriteLine(e.Message.Text + " " + message.Chat.Username + " " + message.Chat.Id);
            }
            if (message.Text == @"/fulltask")
            {
                var questions = new Questions();
                foreach (var question in questions.AllQuestions)
                {
                    //Console.WriteLine(question.Question + " " + question.Number + "\n");
                    await client.SendTextMessageAsync(message.Chat.Id, "123");
                }
            }
            //await client.SendTextMessageAsync(message.Chat.Id, message.Text, replyMarkup: GetButtons());

        }
        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = ""} },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "342"} },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "fdfsafasd"} },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "fsdfasdfasdffasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdf"} },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "234123423541235134523451254523452345134"} }
                }
            };
        }
    }
}
