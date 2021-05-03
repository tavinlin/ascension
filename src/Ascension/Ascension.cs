using System;
using System.Collections.Generic;
using Ascension.Utility;

namespace Ascension
{
    class Ascension
    {
        private bool isPlaying;
        private Player player;

        public Ascension(string name)
        {
            player = new Player(name);
        }
        public void start()
        {
            isPlaying = true;

            Console.Clear();
            Console.WriteLine("Objective: Defeat all enemies in the area:");

            while(isPlaying)
            {
                // Setting up the game
                Enemy[] enemies = LoadEnemies();
                Space spot;
                var area = Area.Setup(10, enemies);

                while(Enemy.InstanceCounter > 0 && player.isDead == false)
                {
                    Console.WriteLine($"There are {Enemy.InstanceCounter} enemies in the area.");
                    Console.WriteLine($"1. {area[0].ExploreStr()} 2. {area[1].ExploreStr()} 3. {area[2].ExploreStr()} 4. {area[3].ExploreStr()} 5. {area[4].ExploreStr()}\n" + 
                    $"6. {area[5].ExploreStr()} 7. {area[6].ExploreStr()} 8. {area[7].ExploreStr()} 9. {area[8].ExploreStr()} 10. {area[9].ExploreStr()}");
                    int intInput = User.ArrayInput(area.Length, "Choose a spot from 1 - 10: ", "Not a number.", "Enter a number between 1 and 10.");
                    spot = area[intInput];
                    if (spot.isOccupied == true && spot.isExplored == false)
                    {
                        Console.Clear();
                        Console.WriteLine($"You encounter {spot.Enemy.Name}");
                        spot.isExplored = true;
                        // start battle
                        this.Battle(spot);
                    }
                    else if (spot.isExplored)
                    {
                        Console.WriteLine("You already explored this spot...");
                        User.PressKey("Press any key to continue...");
                        Console.Clear();
                    }
                    else
                    {
                        spot.isExplored = true;
                        Console.WriteLine("There is nothing in this spot...");
                        User.PressKey("Press any key to continue...");
                        Console.Clear();
                    }
                }
            }
            Console.WriteLine("Game Over!");
        }

        private Enemy[] LoadEnemies()
        {
            Enemy[] enemies = new Enemy[]
            {
                new Enemy("Satan", 14, 3, 0, 5),
                new Enemy("Kappa", 12, 1, 0, 5),
                new Enemy("Zombie", 4, 1, 0, 5),
                new Enemy("Banshee", 6, 2, 0, 5),
                new Enemy("Anima", 18, 4, 0, 5),
                new Enemy("Demon", 7, 2, 0, 5)
            };
            return enemies;
        }

        private void Battle(Space spot)
        {
            bool isBattle = true;
            int damageDealt = 0;
            int atkCount = 0;
            var playerOptions = new Dictionary<int, string>() { { 1, "vertical" }, { 2, "horizontal" }, { 3, "thrust" } };
            string[] generatedPattern = spot.Enemy.GenerateAtkPattern();

            while (isBattle)
            {
                Console.WriteLine($"{player.Name}: {player.CurrentHealth} - {spot.Enemy.Name}: {spot.Enemy.CurrentHealth}");
                var playerInput = User.DictInput(playerOptions, "Choose an attack: 1. vertical, 2. horizontal, 3. thrust: ", "Not a number.", "Invalid input.");
                // Enemy will loop through a string array of options and start over the iteration in order simulate attack pattern

                switch (generatedPattern[atkCount])
                {
                    case "vertical":
                        Console.WriteLine("Enemy chose vertical attack!");
                        if (playerInput == "vertical")
                        {
                            Console.WriteLine($"{player.Name} and {spot.Enemy.Name} cancel each other attack.");
                        }
                        else if (playerInput == "horizontal")
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
                        if (playerInput == "horizontal")
                        {
                            Console.WriteLine($"{player.Name} and {spot.Enemy.Name} cancel each other attack.");
                        }
                        else if (playerInput == "thrust")
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
                        if (playerInput == "thrust")
                        {
                            Console.WriteLine($"{player.Name} and {spot.Enemy.Name} cancel each other attack.");
                        }
                        else if (playerInput == "vertical")
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
                if (spot.Enemy.CurrentHealth <= 0)
                {
                    Enemy.InstanceCounter -= 1;
                    isBattle = false;
                    spot.isOccupied = false;
                    Console.WriteLine($"{spot.Enemy.Name} Died!");
                    User.PressKey("Press any key to continue...");
                    Console.Clear();
                }
                else if (player.CurrentHealth <= 0)
                {
                    isBattle = false;
                    player.isDead = true;
                    isPlaying = false;
                    Console.WriteLine($"{player.Name} Died!");
                }

                atkCount += 1;
                if (atkCount == generatedPattern.Length)
                    atkCount = 0;
            }
        }


    }
}