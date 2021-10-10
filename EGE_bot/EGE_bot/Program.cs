using System;
using Telegram.Bot;
using Telegram.Bot.Args;

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
            Console.ReadLine();
            client.StopReceiving();
            Console.WriteLine("Hello World!");
        }

        private static void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if (message != null)
                Console.WriteLine("Check");

        }
    }
}
