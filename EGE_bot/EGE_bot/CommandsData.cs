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
        public  static Dictionary<string, InlineKeyboardInfo> InlineKeyboardMarkups { get; }
        static CommandsData()
        {
            var jsonText = File.ReadAllText("Replies/InlineKeyboardInfo.json");
            InlineKeyboardMarkups = JsonConvert.DeserializeObject<Dictionary<string, InlineKeyboardInfo>>(jsonText);
        }
    }
}
