using System;
using System.Collections.Generic;

namespace Ascension
{
    class Ascension
    {
        public void start()
        {
            bool isPlaying = true;
            // Show intro of the game
            this.IntroMessage();

            while(isPlaying)
            {
                // Setting up the game
                string[] monName = new string[] {"Satan", "Kappa", "Zombie", "Banshee", "Anima", "Demon"};
                var area = AreaSetup(10, monName);
                Player player = new Player("Iorek");

                while(Monster.InstanceCounter > 0 && player.isDead == false)
                {
                    Console.WriteLine($"There are {Monster.InstanceCounter} monsters in the area.");
                    Console.WriteLine($"1. {area[0].ExploreStr()} 2. {area[1].ExploreStr()} 3. {area[2].ExploreStr()} 4. {area[3].ExploreStr()} 5. {area[4].ExploreStr()}\n" + 
                    $"6. {area[5].ExploreStr()} 7. {area[6].ExploreStr()} 8. {area[7].ExploreStr()} 9. {area[8].ExploreStr()} 10. {area[9].ExploreStr()}");
                    // Number prompt
                    int intInput = IntInput("Choose a spot from 1 - 10: ") - 1;
                    var spot = area[intInput];
                    if(spot.isOccupied)
                    {
                        Console.WriteLine($"You encounter {spot.Monster.Name}");
                        spot.isExplored = true;
                        bool isBattle = true;
                        Random rnd = new Random();
                        // start battle
                        while(isBattle)
                        {
                            Console.WriteLine($"{player.Name}: {player.CurrentHealth} - {spot.Monster.Name}: {spot.Monster.CurrentHealth}");
                            var atkInput = IntInput("Choose an attack: 1. vertical, 2. horizontal, 3. thrust: ");
                            var playerOptions = new Dictionary<int, string>(){
                                {1, "vertical"},
                                {2, "horizontal"},
                                {3, "thrust"}
                            };
                            // TODO: Monster will loop through an array and start over the iteration in order simulate attack pattern
                            string[] monsterOptions = new string[] {"vertical", "horizontal", "thrust"};
                            switch(monsterOptions[rnd.Next(1,4) - 1])
                            {
                                case "vertical":
                                    Console.WriteLine("Monster chose vertical attack!");
                                    if(playerOptions[atkInput] == "vertical")
                                    {
                                        Console.WriteLine($"{player.Name} and {spot.Monster.Name} cancel each other attack.");
                                    }
                                    else if(playerOptions[atkInput] == "horizontal")
                                    {
                                        Console.WriteLine($"{player.Name} took damage!");
                                        player.CurrentHealth -= spot.Monster.AtkPoint;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{spot.Monster.Name} took damage!");
                                        spot.Monster.CurrentHealth -= player.AtkPoint;
                                    }
                                    break;
                                case "horizontal":
                                    Console.WriteLine("Monster chose horizontal attack!");
                                    if(playerOptions[atkInput] == "horizontal")
                                    {
                                        Console.WriteLine($"{player.Name} and {spot.Monster.Name} cancel each other attack.");
                                    }
                                    else if(playerOptions[atkInput] == "thrust")
                                    {
                                        Console.WriteLine($"{player.Name} took damage!");
                                        player.CurrentHealth -= spot.Monster.AtkPoint;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{spot.Monster.Name} took damage!");
                                        spot.Monster.CurrentHealth -= player.AtkPoint;
                                    }
                                    break;
                                case "thrust":
                                    Console.WriteLine("Monster chose thrust attack");
                                    if(playerOptions[atkInput] == "thrust")
                                    {
                                        Console.WriteLine($"{player.Name} and {spot.Monster.Name} cancel each other attack.");
                                    }
                                    else if(playerOptions[atkInput] == "vertical")
                                    {
                                        Console.WriteLine($"{player.Name} took damage!");
                                        player.CurrentHealth -= spot.Monster.AtkPoint;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{spot.Monster.Name} took damage!");
                                        spot.Monster.CurrentHealth -= player.AtkPoint;
                                    }
                                    break;
                            }
                            if(spot.Monster.CurrentHealth == 0)
                            {
                                Console.WriteLine($"{spot.Monster.Name} Died!");
                                Monster.InstanceCounter -= 1;
                                isBattle = false;
                                spot.isOccupied = false;
                            }
                            else if(player.CurrentHealth == 0)
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

        private Space[] AreaSetup(int size, string[] monsters)
        {
            var spaces = new Space[size];
            int count = 0;
            for(int i = 0; i < spaces.Length; i++)
            {
                if(count < monsters.Length)
                {
                    // Add the monsters first
                    spaces[i] = new Space(new Monster(monsters[count]));
                    count += 1;
                }
                else
                {
                    // After adding all the monster. Instantiate all other spaces
                    spaces[i] = new Space();
                }
            }
            return this.Shuffle(spaces);
        }

        private void IntroMessage()
        {
            var dottedLine = new String('-', 72);
            string title = "Ascension v0.0.1";
            int width = 72;

            string msg = $"{dottedLine}\n"+
                        $"{this.CenterTitle(width, title)}\n"+
                        $"{dottedLine}\n"+
                        $"Defeat all monsters in the area.\n";

            Console.WriteLine(msg);
        }

        private string CenterTitle(int width, string title)
        {
            int space = width - title.Length;
            int padLeft = space / 2 + title.Length;
            return title.PadLeft(padLeft, ' ').PadRight(width, ' ');
        }

        private Space[] Shuffle(Space[] spaces)
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

        private string Input(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return input;
        }

        private int IntInput(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return Int16.Parse(input);
        }
    }
}