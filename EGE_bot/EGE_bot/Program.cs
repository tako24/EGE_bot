using System;
using System.Linq;
using Newtonsoft.Json;
using System.Threading;
using sysTask = System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Extensions.Polling;

namespace EGE_bot
{

    class Program
    {
        private static TelegramBotClient client;
        private static string Token { get; } = "2061132160:AAHRnhICjh2hP3RlwXUopKKDZ1aBx3ZRfMg";
        public static async sysTask.Task Main()
        {
            client = new TelegramBotClient(Token);
            CancellationTokenSource cts = new CancellationTokenSource();
            client.StartReceiving(new DefaultUpdateHandler(Handlers.HandleUpdateAsync, Handlers.HandleErrorAsync),
                               cts.Token);
            Console.ReadLine();
            cts.Cancel();
        }

    }
}
