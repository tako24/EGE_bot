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
            Assert.AreEqual("46", AllTasks.Tasks[0].Answer);
        }

        [Test]
        public void TaskChekAnswerOne()
        {
            var task0 = AllTasks.Tasks[0];
            Assert.AreEqual(true, task0.Check("46"));
        }

        [Test]
        public void TaskChekAnswerTwo()
        {
            var task0 = AllTasks.Tasks[0];
            Assert.AreEqual(false, task0.Check("15"));
        }

        [Test]
        public void IndexerGetter_Fails_WhenIndexIsWrongOne()
        {
            List<Task> task1 = AllTasks.Tasks;
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
            List<Task> task1 = AllTasks.Tasks;
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
        [Test]
        public void VariantTestOne()
        {
            CompoundVariant variant = new CompoundVariant("Сравнение двух способов передачи данных");
            Assert.AreEqual("Верно", variant.GetSolution("A216"));
        }



        [Test]
        public void VariantTestFour()
        {
            CompoundVariant variant = new CompoundVariant("Подсчёт путей с обязательной вершиной");
            Assert.AreEqual("https://inf-ege.sdamgia.ru/get_file?id=25035", variant.GetCurrentPicturepath());
        }
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