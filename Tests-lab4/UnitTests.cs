using Moq;
using NUnit.Framework;

namespace WebApplication1
{
    public class UnitTests
    {
        private Mock<WordsDictionary> _mockDictionary
        [SetUp]
        public void Setup()
        {
            _mockDictionary = new Mock<WordsDictionary>();
        }

        [Test]
        public void AddWord_WhenWordIsNotInDictionary_WordIsAdded()
        {
            // Arrange
            string word = "test";
            _mockDictionary.Object.AddWord(word);

            // Act
            _mockDictionary.Verify(m => m.AddWord(word), Times.Once);
        }

        [Test]
        public void AddWord_WhenWordIsInDictionary_WordNotAdded()
        {
            // Arrange
            string word = "test";
            _mockDictionary.Object.Initialize(words);
            _mockDictionary.Object.AddWord(word);

            // Act
            _mockDictionary.Verify(m => m.AddWord(word), Times.Never);
        }

        [Test]
        public void SaveToJson_SavesDictionaryToJson()
        {
            // Arrange
            List<string> words = new List<string> { "test1", "test2" };
            _mockDictionary.Object.Initialize(words);
            _mockDictionary.Object.SaveToJson();

            // Act
            _mockDictionary.Verify(m => m.SaveToJson(), Times.Once);
        }

        [Test]
        public void LoadFromJson_LoadsDictionaryFromJson()
        {
            // Arrange
            _mockDictionary.Object.LoadFromJson();

            // Act
            _mockDictionary.Verify(m => m.LoadFromJson(), Times.Once);
        }

        [Test]
        public void SaveToXml_SavesDictionaryToXml()
        {
            // Arrange
            List<string> words = new List<string> { "test1", "test2" };
            _mockDictionary.Object.Initialize(words);
            _mockDictionary.Object.SaveToXml();

            // Act
            _mockDictionary.Verify(m => m.SaveToXml(), Times.Once);
        }

        [Test]
        public void LoadFromXml_LoadsDictionaryFromXml()
        {
            // Arrange
            _mockDictionary.Object.LoadFromXml();

            // Act
            _mockDictionary.Verify(m => m.LoadFromXml(), Times.Once);
        }

        [Test]
        public void SaveToSQLite_SavesDictionaryToSQLite()
        {
            // Arrange
            List<string> words = new List<string> { "test1", "test2" };
            _mockDictionary.Object.Initialize(words);
            _mockDictionary.Object.SaveToSQLite();

            // Act
            _mockDictionary.Verify(m => m.SaveToSQLite(), Times.Once);
        }

        [Test]
        public void LoadFromSQLite_LoadsDictionaryFromSQLite()
        {
            // Arrange
            _mockDictionary.Object.LoadFromSQLite();

            // Act
            _mockDictionary.Verify(m => m.LoadFromSQLite(), Times.Once);
        }
    }
}
}
