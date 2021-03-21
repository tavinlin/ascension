using System;

namespace Ascension{
    class Monster : Entity{
        public static int InstanceCounter {get; set;}
        public Monster(string name)
        {
            Name = name;
            MaxHealth = 30;
            CurrentHealth = MaxHealth;
            AtkPoint = 10;
            AmrPoint = 20;
            InstanceCounter += 1;
        }
    }
}