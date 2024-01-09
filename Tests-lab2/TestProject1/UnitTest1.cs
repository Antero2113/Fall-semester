using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Lab2
{
    [TestClass]
    public class WordsDictionaryTests
    {
        [TestMethod]
        public void Check_ѕустое—лово_¬ыбрасывает»сключение()
        {
            var session = new WordsDictionary();

            Assert.ThrowsException<ArgumentNullException>(() => session.Check(""));
        }

        [TestMethod]
        public void Check_—уществующее—лово_»звестное—лово¬ыводитс€()
        {
            var session = new WordsDictionary();
            string word = "существующее";
            session.AddToDictionary(word, "существующее-слово", "сущ");

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                session.Check(word);

                string ожидаемый = "»звестные однокоренные слова:";
                Assert.IsTrue(sw.ToString().Contains(ожидаемый));
            }
        }

        [TestMethod]
        public void AddToDictionary_ƒобавл€ет¬—ловарь()
        {
            var session = new WordsDictionary();
            string ключ = "ключ";
            string слово = "слово";
            string корень = "корень";

            session.AddToDictionary(ключ, слово, корень);

            Assert.IsTrue(session.dictionary.ContainsKey(ключ));
            Assert.AreEqual(session.dictionary[ключ][0], слово);
            Assert.AreEqual(session.dictionary[ключ][1], корень);
        }

        [TestMethod]
        public void AddToDictionary_—о—ловомѕриставкой»—уффиксом_ƒобавл€ет¬—ловарь()
        {
            var session = new WordsDictionary();
            string ключ = "ключ";
            string слово = "пример";
            string корень = "пр";
            string слово—ѕриставкой = "до-" + слово + "-суффикс";

            session.AddToDictionary(ключ, слово—ѕриставкой, корень);

            Assert.IsTrue(session.dictionary.ContainsKey(ключ));
            Assert.AreEqual(session.dictionary[ключ][0], слово—ѕриставкой);
            Assert.AreEqual(session.dictionary[ключ][1], корень);
        }

        [TestMethod]
        public void RemoveFromDictionary_”дал€ет—лово»з—ловар€()
        {
            var session = new WordsDictionary();
            string ключ = "ключ";
            string слово = "удал€емое";

            session.AddToDictionary(ключ, слово, "удал");

            session.dictionary.Remove(ключ);

            Assert.IsFalse(session.dictionary.ContainsKey(ключ));
        }
    }
}
