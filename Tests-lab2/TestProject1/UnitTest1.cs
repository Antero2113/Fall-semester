using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Lab2
{
    [TestClass]
    public class WordsDictionaryTests
    {
        [TestMethod]
        public void Check_ПустоеСлово_ВыбрасываетИсключение()
        {
            var session = new WordsDictionary();

            Assert.ThrowsException<ArgumentNullException>(() => session.Check(""));
        }

        [TestMethod]
        public void Check_СуществующееСлово_ИзвестноеСловоВыводится()
        {
            var session = new WordsDictionary();
            string word = "существующее";
            session.AddToDictionary(word, "существующее-слово", "сущ");

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                session.Check(word);

                string ожидаемый = "Известные однокоренные слова:";
                Assert.IsTrue(sw.ToString().Contains(ожидаемый));
            }
        }

        [TestMethod]
        public void AddToDictionary_ДобавляетВСловарь()
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
        public void AddToDictionary_СоСловомПриставкойИСуффиксом_ДобавляетВСловарь()
        {
            var session = new WordsDictionary();
            string ключ = "ключ";
            string слово = "пример";
            string корень = "пр";
            string словоСПриставкой = "до-" + слово + "-суффикс";

            session.AddToDictionary(ключ, словоСПриставкой, корень);

            Assert.IsTrue(session.dictionary.ContainsKey(ключ));
            Assert.AreEqual(session.dictionary[ключ][0], словоСПриставкой);
            Assert.AreEqual(session.dictionary[ключ][1], корень);
        }

        [TestMethod]
        public void RemoveFromDictionary_УдаляетСловоИзСловаря()
        {
            var session = new WordsDictionary();
            string ключ = "ключ";
            string слово = "удаляемое";

            session.AddToDictionary(ключ, слово, "удал");

            session.dictionary.Remove(ключ);

            Assert.IsFalse(session.dictionary.ContainsKey(ключ));
        }
    }
}
