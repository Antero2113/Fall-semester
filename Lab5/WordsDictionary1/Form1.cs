using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Data.SQLite;
using Newtonsoft.Json;

namespace WordsDictionary1
{
    public partial class Form1 : Form
    {
        WordsDictionary dictionary = new WordsDictionary();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            // Показать форму как диалоговое окно
            if (form2.ShowDialog() == DialogResult.OK)
            {
                // Если результат диалога ОК, получить введенные значения
                string pre1 = form2.Pre1Part;
                string pre2 = form2.Pre2Part;
                string koren = form2.KorenPart;
                string suf1 = form2.Suf1Part;
                string suf2 = form2.Suf2Part;
                string kon = form2.KonPart;

                // Создать переменную для слова
                string word = "";

                // Добавить части слова с учётом их наличия
                if (!string.IsNullOrWhiteSpace(pre1))
                {
                    word += $"{pre1}-";
                }
                if (!string.IsNullOrWhiteSpace(pre2))
                {
                    word += $"{pre2}-";
                }
                if (!string.IsNullOrWhiteSpace(koren))
                {
                    word += $"{koren}-";
                }
                if (!string.IsNullOrWhiteSpace(suf1))
                {
                    word += $"{suf1}-";
                }
                if (!string.IsNullOrWhiteSpace(suf2))
                {
                    word += $"{suf2}-";
                }
                if (!string.IsNullOrWhiteSpace(kon))
                {
                    word += $"{kon}";
                }

                string newKey = $"{pre1 + pre2 + koren + suf1 + suf2 + kon}";

                // Проверка наличия ключа в словаре
                if (!dictionary.GetDictionary().ContainsKey(newKey))
                {
                    dictionary.AddToDictionary(newKey,word, koren);
                    UpdateWordCountLabel();
                }
                else
                {
                    MessageBox.Show("Слово уже существует в словаре.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveJSONButton_Click(object sender, EventArgs e)
        {
            dictionary.SaveToJson();
        }

        private void loadJSONButton_Click(object sender, EventArgs e)
        {
            dictionary.LoadFromJson();
            UpdateWordCountLabel();
        }

        private void saveXMLButton_Click(object sender, EventArgs e)
        {
            dictionary.SaveToXml();
        }

        private void loadXMLButton_Click(object sender, EventArgs e)
        {
            dictionary.LoadFromXml();
            UpdateWordCountLabel();
        }

        private void saveSQLiteButton_Click(object sender, EventArgs e)
        {
            dictionary.SaveToSQLite();
        }

        private void loadSQLiteButton_Click(object sender, EventArgs e)
        {
            dictionary.LoadFromSQLite();
            UpdateWordCountLabel();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void findButton_Click(object sender, EventArgs e)
        {
            string searchWord = searchTextBox.Text.Trim(); // Получаем слово для поиска

            if (!string.IsNullOrWhiteSpace(searchWord))
            {
                treeView1.Nodes.Clear();
                TreeNode rootNode = treeView1.Nodes.Add(searchWord); // Создание нового узла с искомым словом

                // Поиск слов с заданным корнем
                foreach (var entry in dictionary.dictionary)
                {
                    string word = entry.Value.Word; // Получаем слово
                    string root = entry.Value.Root; // Получаем корень

                    if (searchWord.Contains(root))
                    {
                        TreeNode childNode = rootNode.Nodes.Add(word); // Добавление слов с корнем как дочерних узлов
                    }
                }

                rootNode.Expand(); // Раскрыть новый узел с результатами поиска
            }
            else
            {
                MessageBox.Show("Введите слово для поиска.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Метод для обновления Label1 с количеством слов в словаре
        private void UpdateWordCountLabel()
        {
            int wordCount = dictionary.GetDictionary().Count;
            label1.Text = $"Кол-во слов в словаре: {wordCount}";
        }

        private void openDictionaryButton_Click(object sender, EventArgs e)
        {
            Dictionary dictionaryForm = new Dictionary(dictionary.GetDictionary());
            dictionaryForm.Show();
        }
    }
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

        public void AddToDictionary(string k, string word, string root)
        {
            if (!dictionary.ContainsKey(k))
            {
                WordInfo wordInfo = new WordInfo { Word = word, Root = root };
                dictionary.Add(k, wordInfo);
            }
            else
            {
                MessageBox.Show("Слово уже существует в словаре.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SaveToJson()
        {
            string json = JsonConvert.SerializeObject(dictionary);
            File.WriteAllText("dictionary.json", json);
            MessageBox.Show("Данные сохранены в JSON файл.");
        }

        public void LoadFromJson()
        {
            if (File.Exists("dictionary.json"))
            {
                string json = File.ReadAllText("dictionary.json");
                dictionary = JsonConvert.DeserializeObject<Dictionary<string, WordInfo>>(json);
                MessageBox.Show("Данные загружены из JSON файла.");
            }
            else
            {
                MessageBox.Show("Файл не найден.");
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
            MessageBox.Show("Словарь сохранен в формате XML.");
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
                MessageBox.Show("Словарь загружен из формата XML.");
            }
            else
            {
                MessageBox.Show("Файл не найден.");
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

            MessageBox.Show("Словарь сохранен в базе данных SQLite.");
        }

        public void LoadFromSQLite()
        {
            dictionary.Clear();

            if (!File.Exists("dictionary.db"))
            {
                MessageBox.Show("Файл базы данных не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Таблица 'Dictionary' не найдена в базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                            WordInfo wordInfo = new WordInfo();
                            wordInfo.Word = word;
                            wordInfo.Root = root;

                            dictionary.Add(word, wordInfo);
                        }
                    }
                }
            }

            MessageBox.Show("Словарь загружен из базы данных SQLite.");
        }
    }
}
