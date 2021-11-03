using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace EGE_bot
{
    class CommandsData
    {
        public static Dictionary<string, CommandInfo> CommandsDict { get; }

        static CommandsData()
        {
            CommandsDict = new Dictionary<string, CommandInfo>();
            var jsonText = File.ReadAllText("Replies/CommandsInfo.json");
            CommandsDict = JsonConvert.DeserializeObject<Dictionary<string, CommandInfo>>(jsonText);
        }
    }
}
