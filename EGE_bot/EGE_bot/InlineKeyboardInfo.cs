﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot;


namespace EGE_bot
{
    public class InlineKeyboardInfo // хранит информацию о команде 
    {
        public string Text { get; set; }
        public InlineKeyboardMarkup Keyboard { get; set; }

        public InlineKeyboardInfo( string text, List<string> buttonsTexts) {
            this.Text = text;
            this.Keyboard = CreateMarkup(buttonsTexts);
        }

        private static InlineKeyboardMarkup CreateMarkup(List<string> buttons)
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
