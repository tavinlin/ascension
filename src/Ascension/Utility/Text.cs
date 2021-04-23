using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension.Utility
{
    class Text
    {
        public static void IntroBanner()
        {
            var dottedLine = new String('-', 72);
            string title = "Ascension v1.1.0";
            int width = 72;
            string msg = $"{dottedLine}\n" +
                        $"{CenterTitle(width, title)}\n" +
                        $"{dottedLine}\n" +
                        $"Defeat all enemies in the area.\n";
            Console.WriteLine(msg);
        }

        private static string CenterTitle(int width, string title)
        {
            int space = width - title.Length;
            int padLeft = space / 2 + title.Length;
            return title.PadLeft(padLeft, ' ').PadRight(width, ' ');
        }
    }
}
