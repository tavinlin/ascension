using System;

namespace Ascension{
    class Player : Entity{
        public bool isDead{ get; set; }
        public Player(string name)
        {
            Name = name;
            MaxHealth = 50;
            CurrentHealth = MaxHealth;
            AtkPoint = 10;
            AmrPoint = 30;
            isDead = false;
        }
    }
}