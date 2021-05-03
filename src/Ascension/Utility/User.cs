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
                Console.WriteLine(invalidMsg);
                Console.Write(prompt);
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
                Console.WriteLine(invalidMsg);
                Console.Write(prompt);
                input = Console.ReadLine();
            }
            return number;
        }

        public static string DictInput(Dictionary<int,string> options, string prompt, string inputMsg, string invalidMsg)
        {
            string value;
            int input = Int16Input(prompt, inputMsg);
            while (!options.TryGetValue(input, out value))
            {
                Console.WriteLine(invalidMsg);
                input = Int16Input(prompt, inputMsg);
            }
            return value;
        }

        public static void PressKey(string prompt)
        {
            Console.WriteLine(prompt);
            Console.ReadKey();
        }

        public static int ArrayInput(int arraySize, string prompt, string inputMsg, string invalidMsg)
        {
            int intInput = User.Int16Input(prompt, inputMsg) - 1;
            while (intInput < 0 || intInput > arraySize - 1)
            {
                Console.WriteLine(invalidMsg);
                intInput = User.Int16Input(prompt, inputMsg) - 1;
            }
            return intInput;
        }
    }
}