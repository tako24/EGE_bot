//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;

//namespace EGE_bot
//{
//    [TestFixture]
//    class TaskTests
//    {
//        [Test]
//        public void TaskConstruct()
//        {
//            var str0 = "q|a|t|pp".Split('|');
//            var task0 = new Task(str0);
//            Assert.AreEqual("q", task0.Question);
//            Assert.AreEqual("a", task0.Answer);
//            Assert.AreEqual("pp", task0.PicturePath);
//            Assert.AreEqual("t", task0.Theme);
//            var str1 = "q|a|pp|t".Split('|');
//            var task1 = new Task("q","a","t","pp");
//            Assert.AreEqual("q", task1.Question);
//            Assert.AreEqual("a", task1.Answer);
//            Assert.AreEqual("pp", task1.PicturePath);
//            Assert.AreEqual("t", task1.Theme);
//        }
//        [Test]
//        public void TaskConstructWithEmptyPP()
//        {
//            var str0 = "q|a|t|".Split('|');
//            var task0 = new Task(str0);
//            Assert.AreEqual("q", task0.Question);
//            Assert.AreEqual("a", task0.Answer);
//            Assert.AreEqual("", task0.PicturePath);
//            Assert.AreEqual("t", task0.Theme);
//            var str1 = "q|a|t".Split('|');
//            var task1 = new Task(str0);
//            Assert.AreEqual("q", task1.Question);
//            Assert.AreEqual("a", task1.Answer);
//            Assert.AreEqual("", task1.PicturePath);
//            Assert.AreEqual("t", task1.Theme);
//        }
//    }
//    [TestFixture]
//    class QuestionsTests
//    {
//        static string[] str0 = "question0|answer0|theme0|picturePath0".Split('|');
//        Task task0 = new Task("question0", "answer0", "theme0", "picturePath0");
//        Task task1 = new Task("question1", "answer1", "theme1", "picturePath1");
//        Task task2 = new Task(str0);
//        Data questions = new Data(File.ReadAllText(@"D:\C# tests\EGE_bot\EGE_bot\EGE_bot\bin\Debug\Questions\CorrectJsonFormat.json"));
//        [Test]
//        public void IndexerGetter_Fails_WhenIndexIsWrong()
//        {
//            Assert.Catch<ArgumentException>(() => { var a = questions[15]; });
//        }
//    }

//}
