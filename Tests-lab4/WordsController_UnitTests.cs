using NUnit.Framework;
using WebApplication1.Controllers;

namespace WordsController_UnitTests
{
    [TestFixture]
    public class WordsController_UnitTests
    {
        private WordsController _wordsController;

        [SetUp]
        public void Setup()
        {
            _wordsController = new WordsController();
        }

        [Test]
        public void AddWord_ReturnsOkResult()
        {
            var result = _wordsController.AddWord("test");
            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public void GetWordsJson_ReturnsString()
        {
            var result = _wordsController.GetWordsJson();
            Assert.IsInstanceOf<string>(result.Value);
        }

        [Test]
        public void SaveWordsJson_ReturnsOkResult()
        {
            var result = _wordsController.SaveWordsJson("test");
            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public void GetWordsXml_ReturnsString()
        {
            var result = _wordsController.GetWordsXml();
            Assert.IsInstanceOf<string>(result.Value);
        }

        [Test]
        public void SaveWordsXml_ReturnsOkResult()
        {
            var result = _wordsController.SaveWordsXml("test");
            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public void GetWordsFromSQLite_ReturnsList()
        {
            var result = _wordsController.GetWordsFromSQLite();
            Assert.IsInstanceOf<List<string>>(result.Value);
        }

        [Test]
        public void SaveWordsToSQLite_ReturnsOkResult()
        {
            var result = _wordsController.SaveWordsToSQLite();
            Assert.IsInstanceOf<OkResult>(result);
        }
    }
}
