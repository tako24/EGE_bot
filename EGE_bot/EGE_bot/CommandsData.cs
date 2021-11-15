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
        //public static Dictionary<string, ReplyKeyboardInfo> CommandsDict { get; }
        public  static MarkupStorage<ReplyKeyboardInfo> ReplyKeyboardMarkups { get; }
        public  static MarkupStorage<InlineKeyboardInfo> InlineKeyboardMarkups { get; }
        static CommandsData()
        {
            //CommandsDict = new Dictionary<string, ReplyKeyboardInfo>();
            //ReplyKeyboardMarkups = new MarkupStorage<ReplyKeyboardInfo>();
            InlineKeyboardMarkups = new MarkupStorage<InlineKeyboardInfo>("Replies/InlineKeyboardInfo.json");
            ReplyKeyboardMarkups = new MarkupStorage<ReplyKeyboardInfo>("Replies/ReplyKeyboardInfo.json");
            // var jsonText = File.ReadAllText("Replies/CommandsInfo.json");
            //CommandsDict = JsonConvert.DeserializeObject<Dictionary<string, ReplyKeyboardInfo>>(jsonText);
        }
    }
}
