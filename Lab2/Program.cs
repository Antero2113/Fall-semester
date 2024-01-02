using System.Collections.Generic;
using System;

namespace Lab2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var session = new WordsDictionary();
            Console.WriteLine("Добро пожаловать в программу словаря однокоренных слов");
            Console.WriteLine("Для завершения введите 'end'.");
            while (true)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Чтобы начать, введите слово на кириллице:");
                string message = Console.ReadLine();
                if (message == "end")
                {
                    break;
                }
                session.Check(message);
            }
        }
    }
}
