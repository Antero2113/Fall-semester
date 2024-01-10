using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WordsDictionary1;
namespace TestLab5

{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void SearchWordsByRoot_WithValidSearchRoot_ShouldReturnMatchingWords()
        {
            // Arrange
            var dictionary = new WordsDictionary();
            dictionary.AddToDictionary("новое_слово", "слово", "корень");
            dictionary.AddToDictionary("еще_слово", "слово", "другой_корень");
            dictionary.AddToDictionary("старое_слово", "старое", "корень");

            // Act
            var matchingWords = dictionary.SearchWordsByRoot("корень");

            // Assert
            CollectionAssert.AreEqual(new List<string> { "новое_слово", "старое_слово" }, matchingWords);
        }


        [TestMethod]
        public void SearchWordsByRoot_WithInvalidSearchRoot_ShouldReturnEmptyList()
        {
            // Arrange
            var dictionary = new WordsDictionary();
            dictionary.AddToDictionary("новое_слово", "слово", "корень");
            dictionary.AddToDictionary("еще_слово", "слово", "другой_корень");
            dictionary.AddToDictionary("старое_слово", "старое", "корень");

            // Act
            var matchingWords = dictionary.SearchWordsByRoot("не_существующий_корень");

            // Assert
            Assert.AreEqual(0, matchingWords.Count);
        }
        
            [TestMethod]
        public void AddToDictionary_ƒобавл€етЌовое—лово¬—ловарь()
        {
            // Arrange
            var dictionary = new WordsDictionary();
            string key = "новое_слово";
            string word = "слово";
            string root = "корень";

            // Act
            dictionary.AddToDictionary(key, word, root);

            // Assert
            Assert.IsTrue(dictionary.GetDictionary().ContainsKey(key));
            Assert.AreEqual(dictionary.GetDictionary()[key].Word, word);
            Assert.AreEqual(dictionary.GetDictionary()[key].Root, root);
        }

        [TestMethod]
        public void SaveAndLoadToJson_—охран€ет»«агружает»зJson()
        {
            // Arrange
            var dictionary = new WordsDictionary();
            string key = "новое_слово";
            string word = "слово";
            string root = "корень";
            dictionary.AddToDictionary(key, word, root);

            // Act
            dictionary.SaveToJson();
            dictionary.GetDictionary().Clear(); // ќчищаем словарь
            dictionary.LoadFromJson();

            // Assert
            Assert.IsTrue(dictionary.GetDictionary().ContainsKey(key));
            Assert.AreEqual(dictionary.GetDictionary()[key].Word, word);
            Assert.AreEqual(dictionary.GetDictionary()[key].Root, root);
        }

        [TestMethod]
        public void SaveAndLoadToXml_—охран€ет»«агружает»зXml()
        {
            // Arrange
            var dictionary = new WordsDictionary();
            string key = "новое_слово";
            string word = "слово";
            string root = "корень";
            dictionary.AddToDictionary(key, word, root);

            // Act
            dictionary.SaveToXml();
            dictionary.GetDictionary().Clear(); // ќчищаем словарь
            dictionary.LoadFromXml();

            // Assert
            Assert.IsTrue(dictionary.GetDictionary().ContainsKey(key));
            Assert.AreEqual(dictionary.GetDictionary()[key].Word, word);
            Assert.AreEqual(dictionary.GetDictionary()[key].Root, root);
        }
        [TestMethod]
        public void SaveToSQLite_—охран€ет¬SQLite()
        {
            // Arrange
            var dictionary = new WordsDictionary();
            string key = "новое_слово";
            string word = "слово";
            string root = "корень";
            dictionary.AddToDictionary(key, word, root);

            // Act
            dictionary.SaveToSQLite();

            // Assert
            dictionary.GetDictionary().Clear(); // ќчищаем словарь
            dictionary.LoadFromSQLite();
            Assert.IsTrue(dictionary.GetDictionary().ContainsKey(key));
            Assert.AreEqual(dictionary.GetDictionary()[key].Word, key);
            Assert.AreEqual(dictionary.GetDictionary()[key].Root, root);
        }

        [TestMethod]
        public void LoadFromSQLite_«агружает»зSQLite()
        {
            // Arrange
            var dictionary = new WordsDictionary();
            string key = "новое_слово";
            string word = "слово";
            string root = "корень";
            dictionary.AddToDictionary(key, word, root);
            dictionary.SaveToSQLite();

            // Act
            dictionary.GetDictionary().Clear(); // ќчищаем словарь перед загрузкой
            dictionary.LoadFromSQLite();

            // Assert
            Assert.IsTrue(dictionary.GetDictionary().ContainsKey(key));
            Assert.AreEqual(dictionary.GetDictionary()[key].Word, key);
            Assert.AreEqual(dictionary.GetDictionary()[key].Root, root);
        }


    }
}
