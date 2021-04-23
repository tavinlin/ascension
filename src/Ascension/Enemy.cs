using System;

namespace Ascension
{
    class Enemy : Entity
    {
        public static int InstanceCounter {get; set;}
        public string[] atkPattern;
        private int AtkSize { get; set; }
        public Enemy(string name, int maxHealth, int atk, int amr)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
            AtkPoint = atk;
            AmrPoint = amr;
            InstanceCounter += 1;
        }
    }
}