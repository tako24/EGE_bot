using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EGE_bot
{
    [TestFixture]
    class TaskTests
    {
        [Test]
        public void TaskConstruct()
        {
            var task0 = Data.AllQuestions;
            //Assert.AreEqual("По каналу связи передаются сообщения, содержащие только семь букв: А, Б, Г, И, М, Р, Я. Для передачи используется двоичный код, удовлетворяющий условию Фано. Кодовые слова для некоторых букв известны: А — 010, Б — 00, Г — 101. Какое наименьшее количество двоичных знаков потребуется для кодирования слова МАГИЯ? Примечание.Условие Фано означает, что ни одно кодовое слово не является началом другого кодового слова.", task0.Question);
            Assert.AreEqual("14", task0[0].Answer); ;
        }

        [Test]
        public void TaskChekAnswer0()
        {
            var task0 = new Task();
            task0.Answer = "15";
            Assert.AreEqual(true, task0.Check("15"));
        }
    }

    //[TestFixture]
    //class QuestionsTests
    //{
    //    static string[] str0 = "question0|answer0|theme0|picturePath0".Split('|');
    //    Task task0 = new Task("question0", "answer0", "theme0", "picturePath0");
    //    Task task1 = new Task("question1", "answer1", "theme1", "picturePath1");
    //    Task task2 = new Task(str0);
    //    Data questions = new Data(File.ReadAllText(@"D:\C# tests\EGE_bot\EGE_bot\EGE_bot\bin\Debug\Questions\CorrectJsonFormat.json"));
    //    [Test]
    //    public void IndexerGetter_Fails_WhenIndexIsWrong()
    //    {
    //        Assert.Catch<ArgumentException>(() => { var a = questions[15]; });
    //    }
    //}
}
