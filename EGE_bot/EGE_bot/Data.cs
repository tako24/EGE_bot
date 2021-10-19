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
    static class Data
    {
        public static List<Task> AllQuestions { get; }
        //public static List<CommandInfo> AllKeyboards { get; }
        public static Dictionary<string, CommandInfoWithInlineKeyBoard> CommandsDict { get; }
        static Data()
        {
            AllQuestions = new List<Task>();
            //AllKeyboards = new List<CommandInfo>();
            CommandsDict = new Dictionary<string, CommandInfoWithInlineKeyBoard>();
            var jsonTextQ = File.ReadAllText("C:/Users/Настя/EGE_bot/EGE_bot/EGE_bot/numberFor.json");
            var jsonTextK = File.ReadAllText("C:/Users/Настя/EGE_bot/EGE_bot/EGE_bot/CommandsInfo.json");
            var parsedQ = JsonConvert.DeserializeObject<Dictionary<string, Task>>(jsonTextQ);
            foreach (var task in parsedQ.Values)
            {
                AllQuestions.Add(task);
            }
            var parsedK = JsonConvert.DeserializeObject<Dictionary<string, CommandInfo>>(jsonTextK);
            foreach (var keyboard in parsedK.Values)
            {
                var keyb = CreateReplyMarkup(keyboard.buttonsTexts);
                var commandInfoWithInlineKeyBoard = new CommandInfoWithInlineKeyBoard(keyboard.name, keyboard.text, keyb);
                CommandsDict[keyboard.name] = commandInfoWithInlineKeyBoard;
                //AllKeyboards.Add(keyboard);
            }
           
        }
        
        private static InlineKeyboardMarkup CreateReplyMarkup(List<string> buttons)
        {
            List<InlineKeyboardButton[]> list = new List<InlineKeyboardButton[]>(); // Создаём массив колонок
            for (int i = 0; i < buttons.Count; ++i)
            {
                InlineKeyboardButton button = new InlineKeyboardButton() { CallbackData = "Data", Text = buttons[i].ToString() };//Создаём кнопку
                InlineKeyboardButton[] row = new InlineKeyboardButton[1] { button }; // Создаём массив кнопок,в нашем случае он будет из одного элемента
                list.Add(row);//И добавляем его
            }
            return new InlineKeyboardMarkup(list);//создаём клавиатуру
        }
    }
}
