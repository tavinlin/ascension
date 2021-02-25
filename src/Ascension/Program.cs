using System;

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

            string[] occupants = {"enemy", "friend", "unoccupied"};

            Console.WriteLine(dottedLine);
            Console.WriteLine(spacedTitle);
            Console.WriteLine(dottedLine);
            Console.WriteLine("Find a safe spot to hide from the monster");
            Console.WriteLine();
            while(keepPlaying == "y"){
                Console.Write("Choose a spot from 1 - 5: ");
                var input = Console.ReadLine();

                string[] spots = new string[5];
                for(int i = 0; i < 5; i++){
                    spots[i] = occupants[rand.Next(3)];
                }

                Console.WriteLine("Revealing spots...");
                Console.WriteLine($"1. {spots[0]} 2. {spots[1]} 3. {spots[2]} 4. {spots[3]} 5. {spots[4]}");

                if(spots[Int32.Parse(input) - 1] == "enemy"){
                    Console.WriteLine("You been caught by the enemy!");
                }else{
                    Console.WriteLine("You successfully hid from the enemy!");
                }
                Console.Write("Keep playing? Yes(y) or No(n): ");
                keepPlaying = Console.ReadLine();
            }
        }
    }
}
