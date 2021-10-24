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
        public void SnatchOutOfJson()
        {
            var task0 = Data.AllQuestions[0];
            Assert.AreEqual("14", task0.Answer); ;
        }

        [Test]
        public void TaskChekAnswer0()
        {
            var task0 = new Task();
            task0.Answer = "15";
            Assert.AreEqual(true, task0.Check("15"));
        }

        [Test]
        public void TaskChekAnswer1()
        {
            var task0 = Data.AllQuestions[0];
            Assert.AreEqual(false, task0.Check("15"));
        }
    }

    [TestFixture]
    class QuestionsTests
    {
        List<Task> task1 = Data.AllQuestions;
        static string[] str0 = "question0|answer0|theme0|picturePath0".Split('|');
        [Test]
        public void IndexerGetter_Fails_WhenIndexIsWrong0()
        {
            task1[4].Question = str0[0];
            task1[4].Answer = str0[1];
            task1[4].Theme = str0[2];
            task1[4].PicturePath = str0[3];
            Assert.AreEqual("theme0", task1[4].Theme);
        }

        [Test]
        public void IndexerGetter_Fails_WhenIndexIsWrong1()
        {
            task1[4].Question = "question0";
            task1[4].Answer = "answer0";
            task1[4].Theme = "theme0";
            task1[4].PicturePath = "picturePath0";
            Assert.AreEqual("theme0", task1[4].Theme);
        }
    }
}
