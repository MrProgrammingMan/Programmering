using System.Security.Cryptography;
using static System.Console;
namespace Bet_on_black
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            int money = 1000;

            while (true)
            {
                WriteLine("Do you wish to go gambling? [Y/N]");

                char key = ReadKey(true).KeyChar;

                if (key == 'y')
                {
                    WriteLine($"Very excellent. What do you want to bet on and how much? Example: red 100 or black 543. You currently own {money} bucks");

                    string? input = ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        WriteLine("Invalid input.");
                        return;
                    }

                    string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string color = parts[0].ToLower();

                    if (parts.Length != 2)
                    {
                        WriteLine("Use format such as: red 100");
                        continue;
                    }

                    if (color != "red" && color != "black")
                    {
                        WriteLine("You can only bet on 'red' or 'black'.");
                        continue;
                    }

                    if (!int.TryParse(parts[1], out int betAmount))
                    {
                        WriteLine("Bet amount must be a valid number.");
                        continue;
                    }

                    if (betAmount <= 0)
                    {
                        WriteLine("You must bet more than 0.");
                        continue;
                    }

                    if (betAmount > money)
                    {
                        WriteLine($"You can't bet more than your current balance ({money}).");
                        continue;
                    }

                    money -= betAmount;

                    WriteLine();

                    string[] colors = { "black", "red" };
                    string winningColor = colors[rng.Next(0, 2)];

                    WriteLine("Spinning the wheel...");
                    Thread.Sleep(500);
                    WriteLine($"The winning color is {winningColor}");

                    if (color == winningColor)
                    {
                        money += betAmount * 2;
                        WriteLine($"Congrats! You won and you now own {money}!");
                    }
                    else
                    {
                        WriteLine($"You lost and your new balance is {money}.");
                    }
                    WriteLine();
                }
                else if (key == 'n')
                {
                    WriteLine("Disappointing. Be gone from my sight. Filth");
                    break;
                }
            }
        }
    }
}