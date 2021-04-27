using System;
using System.Collections.Generic;

namespace Ascension.Utility
{
    class User
    {
        public static string Input(string prompt, string invalidMsg)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            while (String.IsNullOrEmpty(input))
            {
                Console.Write(invalidMsg);
                input = Console.ReadLine();
            }
            return input;
        }
        public static int Int16Input(string prompt, string invalidMsg)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            int number;
            while(!int.TryParse(input, out number))
            {
                Console.Write(invalidMsg);
                input = Console.ReadLine();
            }
            return number;
        }

        public static string DictInput(Dictionary<int,string> options, string prompt, string invalidMsg)
        {
            string value;
            int input = Int16Input(prompt, "Not a number: ");
            while (!options.TryGetValue(input, out value))
            {
                Console.WriteLine(invalidMsg);
                input = Int16Input(prompt, "Not a number: ");
            }
            return value;
        }

        public static void PressKey(string prompt)
        {
            Console.WriteLine(prompt);
            Console.ReadKey();
        }
    }
}