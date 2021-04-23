using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascension
{
    class Area
    {
        public static Space[] Setup(int size, Enemy[] enemies)
        {
            var spaces = new Space[size];
            int count = 0;
            for (int i = 0; i < spaces.Length; i++)
            {
                if (count < enemies.Length)
                {
                    // Add the enemies first
                    spaces[i] = new Space(enemies[count]);
                    count += 1;
                }
                else
                {
                    // After adding all the monster. Instantiate all other spaces
                    spaces[i] = new Space();
                }
            }
            return Shuffle(spaces);
        }
        private static Space[] Shuffle(Space[] spaces)
        {
            Random rand = new Random();
            for (int i = spaces.Length - 1; i > 0; i--)
            {
                int randIndex = rand.Next(0, i + 1);
                Space temp = spaces[i];
                spaces[i] = spaces[randIndex];
                spaces[randIndex] = temp;
            }
            return spaces;
        }
    }
}
