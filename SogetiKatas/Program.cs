﻿using SogetiKatas.FbGame;
using System;

namespace SogetiKatas
{
    class Program
    {
        static void Main(string[] args)
        {
            bool active = true;

            WelcomeUser();

            var game = SetUpGame();

            while (active)
            {
                Console.WriteLine("Enter a number.");
                string input = Console.ReadLine();
                int number;
                if (input.Equals("Exit", StringComparison.InvariantCultureIgnoreCase))
                {
                    HandleExit(input, ref active);
                    continue;
                }

                if(!Int32.TryParse(input, out number))
                {
                    HandleInputError(input);
                    continue;
                }

                string output = game.EvaluateNumber(number);

                Console.WriteLine(output);
            }
            
        }

        private static void HandleExit(string input, ref bool active)
        {
            active = false;
            Console.WriteLine("Exiting...");
            Console.WriteLine("Thank you for playing Fizz Buzz!");
            Console.ReadLine();
        }

        private static void HandleInputError(string input)
        {
            Console.WriteLine($"Error: Unable to Convert {input} to a number.");
        }
        private static void PromptUserToAddCustomGameRules(ref FizzBuzzGame game)
        {
            bool yes = true;

            while (yes)
            {
                Console.WriteLine("Add Custom Game Rules.");
                Console.WriteLine("Enter multiple");

                int multiple = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter output when number is a multiple");

                string output = Console.ReadLine();

                game.AddCustomGameRule(multiple, output);

                Console.WriteLine("Rule Successfully Added");
                Console.WriteLine("Add More Rules? 'Y' for Yes 'N' for No");

                yes = Console.ReadLine().Equals("Y", StringComparison.InvariantCultureIgnoreCase);

            }
        }

        private static void WelcomeUser()
        {
            Console.WriteLine("Welcome to FizzBuzz!");
            Console.WriteLine("Select a Game Mode:");
            Console.WriteLine("Fizz Buzz - 1");
            Console.WriteLine("Fizz Buzz Pop - 2");
            Console.WriteLine("Custom - 3");
        }

        private static FizzBuzzGame SetUpGame()
        {
            //Assuming valid input for brevity
            GameType gameType = (GameType)int.Parse(Console.ReadLine());

            Console.WriteLine($"{Enum.GetName(typeof(GameType), gameType)} selected");

            var game = new FizzBuzzGame(gameType);

            if (gameType == GameType.Custom)
            {
                PromptUserToAddCustomGameRules(ref game);
            }

            return game;
        }
    }
}
