using System;

namespace Ascension.Utility
{
    class User
    {
        public static string Input(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return input;
        }
        public static int Int16Input(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return Int16.Parse(input);
        }
    }
}