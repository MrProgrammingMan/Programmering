﻿using static System.Console;
namespace Number_guessing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int currentNumber = 0;
            int min = 1;
            int max = 101;
            int currentGuesses = 0;
            Random rng = new Random();

            currentNumber = rng.Next(min, max);

            while (true)
            {
                WriteLine("Enter a number between 1-100.");

                string? input = ReadLine();

                if (int.TryParse(input, out int result)) 
                {
                    if (result < currentNumber)
                    {
                        WriteLine("Bigger");
                        currentGuesses++;
                    }
                    else if (result > currentNumber)
                    {
                        WriteLine("Smaller");
                        currentGuesses++;
                    }
                }

                if (result == currentNumber)
                {
                    WriteLine($"You got it! the number was {currentNumber}!");
                    WriteLine();
                    WriteLine($"It took you {currentGuesses} guesses!");

                    currentGuesses = 0;

                    while (true)
                    {
                        WriteLine("Do you wish to play again? [Y/N]");
                        char key = char.ToLower(ReadKey(true).KeyChar);

                        if (key == 'y')
                        {
                            Clear();
                            currentNumber = rng.Next(min, max);
                            break;
                        }
                        else if (key == 'n')
                        {
                            return;
                        }
                        else
                        {
                            WriteLine("Type [Y/N]");
                        }
                    }
                }
            }
        }
    }
}
