using System;
using System.Collections.Generic;

namespace Ascension
{
    class Program
    {
        static void Main(string[] args)
        {
            string keepPlaying = "y";
            var rand = new Random();
            var dottedLine = new String('-', 72);
            string title = "Ascension v0.0.1";
            int width = 72;
            int space = width - title.Length;
            int padLeft = space / 2 + title.Length;
            string spacedTitle = title.PadLeft(padLeft, ' ').PadRight(width, ' ');
            var healthMeter = new Dictionary<string, int>();

            string[] occupants = {"monster", "friend", "unoccupied"};
            healthMeter.Add("player", 40);
            healthMeter.Add("monster", 30);

            Console.WriteLine(dottedLine);
            Console.WriteLine(spacedTitle);
            Console.WriteLine(dottedLine);
            Console.WriteLine("Find a safe spot to hide from the monster");
            Console.WriteLine();

            while(keepPlaying == "y"){
                Console.Write("Choose a spot from 1 - 5: ");
                var choiceInput = Console.ReadLine();

                string[] spots = new string[5];
                for(int i = 0; i < 5; i++){
                    spots[i] = occupants[rand.Next(3)];
                }

                Console.WriteLine("Revealing spots...");
                Console.WriteLine($"1. {spots[0]} 2. {spots[1]} 3. {spots[2]} 4. {spots[3]} 5. {spots[4]}");

                if(spots[Int32.Parse(choiceInput) - 1] == "monster"){
                    Console.WriteLine("You been spotted by the monster!");
                    bool continueAtk = true;
                    healthMeter["player"] = 40;
                    healthMeter["monster"] = 30;
                    while(continueAtk){
                        Console.WriteLine($"Player: {healthMeter["player"]} - Monster: {healthMeter["monster"]}");
                        Console.Write("Attack the monster? Yes(y) or No(n): ");
                        var attackInput = Console.ReadLine();
                        if(attackInput == "n"){
                            Console.WriteLine("The monster ate you...");
                            break;
                        }

                        string[] hitList = {"player", "monster", "monster", "player", "monster"};
                        int randHit = rand.Next(5);
                        string hitChosen = hitList[randHit];
                        Console.WriteLine($"{hitChosen} got hit!");
                        healthMeter[hitChosen] -= 10;
                        
                        if(healthMeter["player"] <= 0){
                            Console.WriteLine("The monster ate you...");
                            break;
                        }

                        if(healthMeter["monster"] <= 0){
                            Console.WriteLine("You killed the monster");
                            break;
                        }
                    }

                }else{
                    Console.WriteLine("You successfully hid from the monster!");
                }
                Console.Write("Keep playing? Yes(y) or No(n): ");
                keepPlaying = Console.ReadLine();
            }
        }
    }
}
