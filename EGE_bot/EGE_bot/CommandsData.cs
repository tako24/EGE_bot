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
        public static Dictionary<string, CommandInfoWithInlineKeyboard> CommandsDict { get; }

        static CommandsData() 
        {
            CommandsDict = new Dictionary<string, CommandInfoWithInlineKeyboard>();
            var jsonText = File.ReadAllText("C:/Users/Настя/EGE_bot/EGE_bot/EGE_bot/CommandsInfo.json");
            var parsed = JsonConvert.DeserializeObject<Dictionary<string, CommandInfo>>(jsonText);
            foreach (var keyboard in parsed.Values)
            {
                var keyb = CreateReplyMarkup(keyboard.buttonsTexts);
                var commandInfoWithInlineKeyboard = new CommandInfoWithInlineKeyboard(keyboard.name, keyboard.text, keyboard.taskNumber, keyb);
                CommandsDict[keyboard.name] = commandInfoWithInlineKeyboard;
            }
        }

        private static InlineKeyboardMarkup CreateReplyMarkup(List<string> buttons)
        {
            List<InlineKeyboardButton[]> list = new List<InlineKeyboardButton[]>(); // Создаём массив колонок
            for (int i = 0; i < buttons.Count; ++i)
            {
                if (buttons[i] != "")
                {
                    InlineKeyboardButton button = new InlineKeyboardButton() { CallbackData = $"{buttons[i]}", Text = buttons[i].ToString() };//Создаём кнопку
                    InlineKeyboardButton[] row = new InlineKeyboardButton[1] { button }; // Создаём массив кнопок,в нашем случае он будет из одного элемента
                    list.Add(row);//И добавляем его
                }
            }
            return new InlineKeyboardMarkup(list);//создаём клавиатуру
        }
    }
}
