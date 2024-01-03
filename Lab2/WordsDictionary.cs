using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab2
{
    public class WordsDictionary
    {
        Dictionary<string, List<string>> dictionary;

        public WordsDictionary()
        {
            dictionary = new Dictionary<string, List<string>>();
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
                if(text!="")
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
            foreach(var d in dictionary)
            {
                if (d.Value[1] == root)
                {
                    Console.WriteLine(d.Value[0]);
                }
            }
        }
    }
}
