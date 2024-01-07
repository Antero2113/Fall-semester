using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;
using System.Data.SQLite;

namespace WebApplication1
{
class Program
{
    static void Main()
    {
        Console.WriteLine("Добро пожаловать в программу словаря однокоренных слов");
        var session = new WordsDictionary();
        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Ввод слова");
            Console.WriteLine("2. Сохранение в JSON");
            Console.WriteLine("3. Загрузка из JSON");
            Console.WriteLine("4. Сохранение в XML");
            Console.WriteLine("5. Загрузка из XML");
            Console.WriteLine("6. Сохранение в SQLite");
            Console.WriteLine("7. Загрузка из SQLite");
            Console.WriteLine("q. Выход");
            Console.WriteLine("v. Возврат к меню");
            Console.Write("> ");

            string choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "1":
                    session.ProcessInput();
                    break;
                case "2":
                    session.SaveToJson();
                    break;
                case "3":
                        session.LoadFromJson();
                    break;
                case "4":
                        session.SaveToXml();
                    break;
                case "5":
                        session.LoadFromXml();
                    break;
                case "6":
                        session.SaveToSQLite();
                    break;
                case "7":
                        session.LoadFromSQLite();
                    break;
                case "q":
                    return;
                default:
                Console.WriteLine("Некорректный выбор.");
                break;
            }
        }
    }
}
}

