using System;
using System.Collections.Generic;
using Ascension.Utility;

namespace Ascension
{
    class Program
    {
        static void Main(string[] args)
        {
            Text.IntroBanner();
            User.PressKey("Press any key to continue...");
            var nameInput = User.Input("Enter your name: ", "Name cannot be blank.");
            var game = new Ascension(nameInput);
            game.start();
        }
    }
}
