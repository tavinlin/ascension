using System;

namespace Ascension
{
    class Player : Entity
    {
        public bool isDead{ get; set; }
        public Player(string name)
        {
            Name = name;
            MaxHealth = 10;
            CurrentHealth = MaxHealth;
            AtkPoint = 1;
            AmrPoint = 0;
            isDead = false;
        }
    }
}