using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;
using System.Data.SQLite;

namespace WebApplication1
{
    public class WordsDictionary
    {
        Dictionary<string, List<string>> dictionary;

        public WordsDictionary()
        {
            dictionary = new Dictionary<string, List<string>>();
        }

        public Dictionary<string, List<string>> GetDictionary()
        {
            return dictionary;
        }

        public void Check(string currentWord)
        {
            if (currentWord == "")
            {
                throw new ArgumentNullException(paramName: nameof(currentWord), message: "Слово не может быть пустым. Введите символы.");
            }
            if (dictionary.ContainsKey(currentWord))
            {
                KnownWord(currentWord);
            }
            else
            {
                Console.WriteLine("Неизвестное слово. Хотите его добавить в словарь?");
                Console.WriteLine("Если да, введите корень слова: ");
                string root = Console.ReadLine();
                if (root == "")
                {
                    throw new ArgumentNullException(paramName: nameof(root), message: "Корень не может быть пустым. Введите символы.");
                }
                string newWord = "";
                newWord += root;
                Console.WriteLine("Теперь приставку: ");
                string text = Console.ReadLine();
                if (text != "")
                {
                    newWord = "-" + newWord;
                    newWord = text + newWord;
                }
                Console.WriteLine("Суффикс: ");
                text = Console.ReadLine();
                if (text != "")
                {
                    newWord += "-";
                    newWord += text;
                }
                Console.WriteLine("Второй суффикс или окончание: ");
                text = Console.ReadLine();
                if (text != "")
                {
                    newWord += "-";
                    newWord += text;
                }
                AddToDictionary(currentWord, newWord, root);
            }
        }
        public void AddToDictionary(string k, string word, string root)
        {
            List<string> l = new List<string>();
            l.Add(word);
            l.Add(root);
            dictionary.Add(k, l);

        }

        public void KnownWord(string key)
        {
            Console.WriteLine("Известные однокоренные слова:");
            List<string> value;
            string root = "";
            foreach (var d in dictionary)
            {
                if (dictionary.TryGetValue(key, out value))
                {
                    root = value[1];
                }
            }
            foreach (var d in dictionary)
            {
                if (d.Value[1] == root)
                {
                    Console.WriteLine(d.Value[0]);
                }
            }
        }

        public void ProcessInput()
        {
            while (true)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Чтобы начать, введите слово на кириллице:");
                string message = Console.ReadLine();
                if (message == "v")
                {
                    break;
                }
                Check(message);
            }
        }

        public void SaveToJson()
        {
            string json = JsonSerializer.Serialize(dictionary);
            File.WriteAllText("dictionary.json", json);
            Console.WriteLine("Словарь сохранен в формате JSON.");
        }

        public void LoadFromJson()
        {
            if (File.Exists("dictionary.json"))
            {
                string json = File.ReadAllText("dictionary.json");
                dictionary = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);
                Console.WriteLine("Словарь загружен из формата JSON.");
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }
        }

        public void SaveToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Dictionary<string, List<string>>));
            using (TextWriter writer = new StreamWriter("dictionary.xml"))
            {
                serializer.Serialize(writer, dictionary);
            }
            Console.WriteLine("Словарь сохранен в формате XML.");
        }

        public void LoadFromXml()
        {
            if (File.Exists("dictionary.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Dictionary<string, List<string>>));
                using (TextReader reader = new StreamReader("dictionary.xml"))
                {
                    dictionary = (Dictionary<string, List<string>>)serializer.Deserialize(reader);
                }
                Console.WriteLine("Словарь загружен из формата XML.");
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }
        }

        public void SaveToSQLite()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=dictionary.db;Version=3;"))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Dictionary (Word TEXT, WordsList TEXT)", connection))
                {
                    command.ExecuteNonQuery();
                }

                foreach (var entry in dictionary)
                {
                    using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Dictionary (Word, WordsList) VALUES (@word, @wordsList)", connection))
                    {
                        command.Parameters.AddWithValue("@word", entry.Key);
                        command.Parameters.AddWithValue("@wordsList", string.Join(",", entry.Value));
                        command.ExecuteNonQuery();
                    }
                }
            }

            Console.WriteLine("Словарь сохранен в базе данных SQLite.");
        }

        public void LoadFromSQLite()
        {
            dictionary.Clear();
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=dictionary.db;Version=3;"))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Dictionary", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string word = reader["Word"].ToString();
                            string wordsList = reader["WordsList"].ToString();
                            List<string> words = new List<string>(wordsList.Split(','));
                            dictionary[word] = words;
                        }
                    }
                }
            }

            Console.WriteLine("Словарь загружен из базы данных SQLite.");
        }

    }
}
