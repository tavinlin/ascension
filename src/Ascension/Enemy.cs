using System;

namespace Ascension
{
    class Enemy : Entity
    {
        public static int InstanceCounter {get; set;}
        private int AtkPatternSize { get; set; }
        public Enemy(string name, int maxHealth, int atk, int amr, int patternSize)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
            AtkPoint = atk;
            AmrPoint = amr;
            InstanceCounter += 1;
            AtkPatternSize = patternSize;
        }

        public string[] GenerateAtkPattern()
        {
            string[] atkPattern = new string[AtkPatternSize];
            string[] options = new string[] { "vertical", "horizontal", "thrust" };
            Random rnd = new Random();

            for(int i = 0; i < atkPattern.Length; i++)
            {
                atkPattern[i] = options[rnd.Next(1, 4) - 1];
            }

            return atkPattern;
        }
    }
}