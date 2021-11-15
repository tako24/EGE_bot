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
    class MarkupStorage<T>  
    {
        public  Dictionary<string, T> RepliesDict { get; }


         public MarkupStorage(string jsonPath)
         {
            RepliesDict = new Dictionary<string, T>();
            var jsonText = File.ReadAllText(jsonPath);
            RepliesDict = JsonConvert.DeserializeObject<Dictionary<string, T>>(jsonText);
         }

    }
}
