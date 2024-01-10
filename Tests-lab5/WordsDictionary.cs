using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Data.SQLite;
using Newtonsoft.Json;

namespace WordsDictionary1
{
    public class WordsDictionary
    {
        public Dictionary<string, WordInfo> dictionary;

        public WordsDictionary()
        {
            dictionary = new Dictionary<string, WordInfo>();
        }

        public Dictionary<string, WordInfo> GetDictionary()
        {
            return dictionary;
        }
        public List<string> SearchWordsByRoot(string searchRoot)
        {
            var matchingWords = new List<string>();

            foreach (var entry in dictionary)
            {
                string root = entry.Value.Root;

                if (root.StartsWith(searchRoot))
                {
                    matchingWords.Add(entry.Key);
                }
            }

            return matchingWords;
        }


        public void AddToDictionary(string k, string word, string root)
        {
            if (!dictionary.ContainsKey(k))
            {
                WordInfo wordInfo = new WordInfo { Word = word, Root = root };
                dictionary.Add(k, wordInfo);
            }
            else
            {
                //MessageBox.Show("Слово уже существует в словаре.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SaveToJson()
        {
            string json = JsonConvert.SerializeObject(dictionary);
            File.WriteAllText("dictionary.json", json);
            //MessageBox.Show("Данные сохранены в JSON файл.");
        }

        public void LoadFromJson()
        {
            if (File.Exists("dictionary.json"))
            {
                string json = File.ReadAllText("dictionary.json");
                dictionary = JsonConvert.DeserializeObject<Dictionary<string, WordInfo>>(json);
                //MessageBox.Show("Данные загружены из JSON файла.");
            }
            else
            {
                //MessageBox.Show("Файл не найден.");
            }
        }
        [Serializable]
        public class DictionaryContainer
        {
            [XmlArray("Items")]
            [XmlArrayItem("WordInfo")]
            public List<WordDictionaryItem> Items { get; set; }
        }

        [Serializable]
        public class WordDictionaryItem
        {
            [XmlElement("Key")]
            public string Key { get; set; }

            [XmlElement("Value")]
            public WordInfo Value { get; set; }
        }


        public void SaveToXml()
        {
            DictionaryContainer container = new DictionaryContainer();
            container.Items = dictionary.Select(kv => new WordDictionaryItem { Key = kv.Key, Value = kv.Value }).ToList();

            XmlSerializer serializer = new XmlSerializer(typeof(DictionaryContainer));
            using (TextWriter writer = new StreamWriter("dictionary.xml"))
            {
                serializer.Serialize(writer, container);
            }
            //MessageBox.Show("Словарь сохранен в формате XML.");
        }



        public void LoadFromXml()
        {
            if (File.Exists("dictionary.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DictionaryContainer));
                using (TextReader reader = new StreamReader("dictionary.xml"))
                {
                    DictionaryContainer container = (DictionaryContainer)serializer.Deserialize(reader);
                    dictionary.Clear();
                    foreach (var item in container.Items)
                    {
                        dictionary.Add(item.Key, item.Value);
                    }
                }
                //MessageBox.Show("Словарь загружен из формата XML.");
            }
            else
            {
                //MessageBox.Show("Файл не найден.");
            }
        }

        public void SaveToSQLite()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=dictionary.db;Version=3;"))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Dictionary (Word TEXT, Root TEXT)", connection))
                {
                    command.ExecuteNonQuery();
                }

                foreach (var entry in dictionary)
                {
                    using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Dictionary (Word, Root) VALUES (@word, @root)", connection))
                    {
                        command.Parameters.AddWithValue("@word", entry.Key);
                        command.Parameters.AddWithValue("@root", entry.Value.Root);
                        command.ExecuteNonQuery();
                    }
                }
            }

           // MessageBox.Show("Словарь сохранен в базе данных SQLite.");
        }

        public void LoadFromSQLite()
        {
            dictionary.Clear();

            if (!File.Exists("dictionary.db"))
            {
                //MessageBox.Show("Файл базы данных не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=dictionary.db;Version=3;"))
            {
                connection.Open();

                // Проверка наличия таблицы Dictionary в базе данных
                using (SQLiteCommand checkTableCommand = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' AND name='Dictionary'", connection))
                {
                    object result = checkTableCommand.ExecuteScalar();
                    if (result == null)
                    {
                        //MessageBox.Show("Таблица 'Dictionary' не найдена в базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Dictionary", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string word = reader["Word"].ToString();
                            string root = reader["Root"].ToString();
                            if (!dictionary.ContainsKey(word)) // Проверяем, что ключа нет в словаре
                            {
                                WordInfo wordInfo = new WordInfo();
                                wordInfo.Word = word;
                                wordInfo.Root = root;

                                dictionary.Add(word, wordInfo);
                            }
                            else
                            {
                                return;
                                throw new InvalidOperationException($"Слово '{word}' уже существует в словаре.");
                            }
                        }
                    }
                }
            }

            //MessageBox.Show("Словарь загружен из базы данных SQLite.");
        }
    }
}
