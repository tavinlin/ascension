using System;
using System.Collections.Generic;
using Ascension.Utility;

namespace Ascension
{
    class Ascension
    {
        private bool isPlaying;
        private Player player;
        public void start()
        {
            isPlaying = true;
            string name = User.Input("What's your name? ");
            player = new Player(name);
            Console.Clear();
            // Show intro banner of the game
            Text.IntroBanner();

            while(isPlaying)
            {
                // Setting up the game
                Enemy[] enemies = LoadEnemies();
                var area = Area.Setup(10, enemies);

                while(Enemy.InstanceCounter > 0 && player.isDead == false)
                {
                    Console.WriteLine($"There are {Enemy.InstanceCounter} enemies in the area.");
                    Console.WriteLine($"1. {area[0].ExploreStr()} 2. {area[1].ExploreStr()} 3. {area[2].ExploreStr()} 4. {area[3].ExploreStr()} 5. {area[4].ExploreStr()}\n" + 
                    $"6. {area[5].ExploreStr()} 7. {area[6].ExploreStr()} 8. {area[7].ExploreStr()} 9. {area[8].ExploreStr()} 10. {area[9].ExploreStr()}");
                    // Number prompt
                    int intInput = User.Int16Input("Choose a spot from 1 - 10: ") - 1;
                    var spot = area[intInput];
                    if(spot.isOccupied)
                    {
                        Console.Clear();
                        Console.WriteLine($"You encounter {spot.Enemy.Name}");
                        spot.isExplored = true;
                        bool isBattle = true;
                        int damageDealt = 0;
                        Random rnd = new Random();
                        // start battle
                        while(isBattle)
                        {
                            Console.WriteLine($"{player.Name}: {player.CurrentHealth} - {spot.Enemy.Name}: {spot.Enemy.CurrentHealth}");
                            var atkInput = User.Int16Input("Choose an attack: 1. vertical, 2. horizontal, 3. thrust: ");
                            var playerOptions = new Dictionary<int, string>(){
                                {1, "vertical"},
                                {2, "horizontal"},
                                {3, "thrust"}
                            };
                            // TODO: Enemy will loop through an array and start over the iteration in order simulate attack pattern
                            string[] monsterOptions = new string[] {"vertical", "horizontal", "thrust"};
                            switch(monsterOptions[rnd.Next(1,4) - 1])
                            {
                                case "vertical":
                                    Console.WriteLine("Enemy chose vertical attack!");
                                    if(playerOptions[atkInput] == "vertical")
                                    {
                                        Console.WriteLine($"{player.Name} and {spot.Enemy.Name} cancel each other attack.");
                                    }
                                    else if(playerOptions[atkInput] == "horizontal")
                                    {
                                        damageDealt = spot.Enemy.AtkPoint;
                                        Console.WriteLine($"{player.Name} took {damageDealt} damage!");
                                        player.CurrentHealth -= damageDealt;
                                    }
                                    else
                                    {
                                        damageDealt = player.AtkPoint;
                                        Console.WriteLine($"{spot.Enemy.Name} took {damageDealt} damage!");
                                        spot.Enemy.CurrentHealth -= damageDealt;
                                    }
                                    break;
                                case "horizontal":
                                    Console.WriteLine("Enemy chose horizontal attack!");
                                    if(playerOptions[atkInput] == "horizontal")
                                    {
                                        Console.WriteLine($"{player.Name} and {spot.Enemy.Name} cancel each other attack.");
                                    }
                                    else if(playerOptions[atkInput] == "thrust")
                                    {
                                        damageDealt = spot.Enemy.AtkPoint;
                                        Console.WriteLine($"{player.Name} took {damageDealt} damage!");
                                        player.CurrentHealth -= damageDealt;
                                    }
                                    else
                                    {
                                        damageDealt = player.AtkPoint;
                                        Console.WriteLine($"{spot.Enemy.Name} took {damageDealt} damage!");
                                        spot.Enemy.CurrentHealth -= damageDealt;
                                    }
                                    break;
                                case "thrust":
                                    Console.WriteLine("Enemy chose thrust attack");
                                    if(playerOptions[atkInput] == "thrust")
                                    {
                                        Console.WriteLine($"{player.Name} and {spot.Enemy.Name} cancel each other attack.");
                                    }
                                    else if(playerOptions[atkInput] == "vertical")
                                    {
                                        damageDealt = spot.Enemy.AtkPoint;
                                        Console.WriteLine($"{player.Name} took {damageDealt} damage!");
                                        player.CurrentHealth -= damageDealt;
                                    }
                                    else
                                    {
                                        damageDealt = player.AtkPoint;
                                        Console.WriteLine($"{spot.Enemy.Name} took {damageDealt} damage!");
                                        spot.Enemy.CurrentHealth -= damageDealt;
                                    }
                                    break;
                            }
                            if(spot.Enemy.CurrentHealth <= 0)
                            {
                                Console.WriteLine($"{spot.Enemy.Name} Died!");
                                Enemy.InstanceCounter -= 1;
                                isBattle = false;
                                spot.isOccupied = false;
                            }
                            else if(player.CurrentHealth <= 0)
                            {
                                Console.WriteLine($"{player.Name} Died!");
                                isBattle = false;
                                player.isDead = true;
                                isPlaying = false;
                            }
                        }
                    }
                    else
                    {
                        spot.isExplored = true;
                        Console.WriteLine("There is nothing in this spot...");
                    }
                }
            }
            Console.WriteLine("Game Over!");
        }

        private Enemy[] LoadEnemies()
        {
            Enemy[] enemies = new Enemy[]
            {
                new Enemy("Satan", 14, 3, 0),
                new Enemy("Kappa", 12, 1, 0),
                new Enemy("Zombie", 4, 1, 0),
                new Enemy("Banshee", 6, 2, 0),
                new Enemy("Anima", 20, 4, 0),
                new Enemy("Demon", 4, 2, 0)
            };
            return enemies;
        }

        private void Battle(Player player, Space spot)
        {

        }
    }
}