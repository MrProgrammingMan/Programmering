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
                    WriteLine($"Very excellent. Do you wish to bet on black or red? You currently own {money} bucks");

                    string input = ReadLine().ToLower();

                    if (input == "black")
                    {
                        Gamble(ref money, rng, input);
                    }
                    else if (input == "red")
                    {
                        Gamble(ref money, rng, input);
                    }
                    WriteLine();
                }
                else if (key == 'n')
                {
                    WriteLine("Disappointing. Be gone from my sight. Filth");
                    return;
                }
            }
        }
       

        static void Gamble(ref int money, Random rng, string input)
        {
            WriteLine();
            int betAmount = 0;

            WriteLine("How much do you wish to bet?");

            while (true)
            {
                string? text = ReadLine();

                if (int.TryParse(text, out betAmount))
                {
                    if (betAmount <= 0)
                    {
                        WriteLine("You must bet more than 0.");
                    }
                    else if (betAmount > money)
                    {
                        WriteLine($"You can't bet more than your current balance ({money}).");
                    }
                    else
                    {
                        WriteLine($"Successfully placed bet of {betAmount}.");
                        money -= betAmount;
                        break;
                    }
                }
                else
                {
                    WriteLine("Invalid input, please enter a number to bet.");
                }
            }

            string[] color = { "black", "red" };
            string winningColor = color[rng.Next(0, 2)];

            if (input == winningColor)
            {
                money += betAmount * 2;
                WriteLine($"Congrats! You won and you now own {money}!");
            }
            else
            {
                WriteLine($"You lost and your new balance is {money}.");
            }
        }
    }
}
