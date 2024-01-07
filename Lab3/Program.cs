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
        Console.WriteLine("Äîáðî ïîæàëîâàòü â ïðîãðàììó ñëîâàðÿ îäíîêîðåííûõ ñëîâ");
        var session = new WordsDictionary();
        while (true)
        {
            Console.WriteLine("Âûáåðèòå äåéñòâèå:");
            Console.WriteLine("1. Ââîä ñëîâà");
            Console.WriteLine("2. Ñîõðàíåíèå â JSON");
            Console.WriteLine("3. Çàãðóçêà èç JSON");
            Console.WriteLine("4. Ñîõðàíåíèå â XML");
            Console.WriteLine("5. Çàãðóçêà èç XML");
            Console.WriteLine("6. Ñîõðàíåíèå â SQLite");
            Console.WriteLine("7. Çàãðóçêà èç SQLite");
            Console.WriteLine("q. Âûõîä");
            Console.WriteLine("v. Âîçâðàò ê ìåíþ");
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
                Console.WriteLine("Íåêîððåêòíûé âûáîð.");
                break;
            }
        }
    }
}
}

