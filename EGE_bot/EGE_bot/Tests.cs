using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EGE_bot
{
    [TestFixture]
    class TaskTest
    {
        [Test]
        public void SnatchOutOfJson()
        {
            var task0 = Data.AllQuestions[0];
            Assert.AreEqual("46", task0.Answer); ;
        }

        [Test]
        public void TaskChekAnswerOne()
        {
            var task0 = Data.AllQuestions[0];
            Assert.AreEqual(true, task0.Check("46"));
        }

        [Test]
        public void TaskChekAnswerTwo()
        {
            var task0 = Data.AllQuestions[0];
            Assert.AreEqual(false, task0.Check("15"));
        }

        [Test]
        public void IndexerGetter_Fails_WhenIndexIsWrongOne()
        {
            List<Task> task1 = Data.AllQuestions;
            string[] str0 = "question0|answer0|theme0|picturePath0".Split('|');
            task1[4].Question = str0[0];
            task1[4].Answer = str0[1];
            task1[4].Theme = str0[2];
            task1[4].PicturePath = str0[3];
            Assert.AreEqual("theme0", task1[4].Theme);
        }

        [Test]
        public void IndexerGetter_Fails_WhenIndexIsWrongTwo()
        {
            List<Task> task1 = Data.AllQuestions;
            task1[4].Question = "question0";
            task1[4].Answer = "answer0";
            task1[4].Theme = "theme0";
            task1[4].PicturePath = "picturePath0";
            Assert.AreEqual("theme0", task1[4].Theme);
        }
    }

    [TestFixture]
    class VariantTest
    {
        //[Test]
        //public void VariantTestOne()
        //{
        //    Questions variant = new Questions("Сравнение двух способов передачи данных");
        //    Assert.AreEqual("Верно", variant.OnMessageSend("A216"));
        //}

        //[Test]
        //public void VariantTestTwo()
        //{
        //    Questions variant = new Questions("Слова по порядку");
        //    Assert.AreEqual("Заменим буквы А, О, У на 0, 1, 2(для них порядок очевиден – по возрастанию) Выпишем начало списка, " +
        //        "заменив буквы на цифры: 1. 00000 2. 00001 3. 00002 4. 00010 ... Полученная запись есть числа, " +
        //        "записанные в троичной системе счисления в порядке возрастания. Тогда на 210 месте будет стоять число 209 " +
        //        "(т. к. первое число 0). Переведём число 209 в троичную систему (деля и снося остаток справа налево): " +
        //        "209 / 3 = 69 (2) 69 / 3 = 23 (0) 23 / 3 = 7 (2) 7 / 3 = 2 (1) 2 / 3 = 0(2) В троичной системе 209 запишется как 21202. " +
        //        "Произведём обратную замену и получим УОУАУ.", variant.OnMessageSend("A216"));
        //}

        //[Test]
        //public void VariantTestTree()
        //{
        //    Questions variant = new Questions("лова по порядку");
        //    Assert.AreEqual("Все 5-буквенные слова, составленные из букв А, О, У, записаны в алфавитном порядке. " +
        //        "Вот начало списка: 1. ААААА 2. ААААО 3. ААААУ 4. АААОА …… Запишите слово, которое стоит на 210-м месте от начала списка.",
        //        variant.GetCurrentQuestion());
        //}

        //[Test]
        //public void VariantTestFour()
        //{
        //    Questions variant = new Questions("Подсчёт путей с обязательной вершиной");
        //    Assert.AreEqual("https://inf-ege.sdamgia.ru/get_file?id=25035", variant.GetCurrentPicturepath());
        //}
    }

    [TestFixture]
    class HandlersTest
    {
        [Test]
        public void HandlersTestOne()
        {
            //To be continued
        }
    }

    [TestFixture]
    class UserTest
    {
        [Test]
        public void UserTestOne()
        {
            User user = new User(0, "");
            var userVar = user.ChatId == 2;
            Assert.AreEqual(false, userVar);
        }

        [Test]
        public void UserTestTwo()
        {
            User user = new User(0, "");
            var userVar = user.ChatId == 0;
            Assert.AreEqual(true, userVar);
        }
    }
}