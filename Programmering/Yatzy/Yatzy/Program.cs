using System;
using System.Collections;
using System.Linq;
using static System.Console;
namespace Yatzy
{
    internal class Program
    {
        const int NUM_DICE = 6;
        const int MAX_ROLLS = 3;
        const int ROW_INPUT = 6;
        const int ROW_DICE = 2;
        const int ROW_SCORE = 4;
        static void Main(string[] args)
        {
            bool play = true;
            Random rng = new();
            while (play)
            {
                int currentRoll = 0;
                List<int> dice = new();

                RollDice(ref dice, rng);

                int[] upperSection = new int[6];
                List<int> ones = new();
                List<int> twos = new();
                List<int> threes = new();
                List<int> fours = new();
                List<int> fives = new();
                List<int> sixes = new();

                DrawScoreTable();

                bool rolling = true;
                while (rolling)
                {
                    ones.Clear();
                    twos.Clear();
                    threes.Clear();
                    fours.Clear();
                    fives.Clear();
                    sixes.Clear();

                    for (int i = 0; i < NUM_DICE; i++)
                    {
                        switch (dice[i])
                        {
                            case 1:
                                ones.Add(dice[i]);
                                break;
                            case 2:
                                twos.Add(dice[i]);
                                break;
                            case 3:
                                threes.Add(dice[i]);
                                break;
                            case 4:
                                fours.Add(dice[i]);
                                break;
                            case 5:
                                fives.Add(dice[i]);
                                break;
                            case 6:
                                sixes.Add(dice[i]);
                                break;
                        }
                    }

                    string display = String.Format("|{0,-6}|{1,-6}|{2,-6}|{3,-6}|{4,-6}|{5,-6}",
                    string.Join(",", ones),
                    string.Join(",", twos),
                    string.Join(",", threes),
                    string.Join(",", fours),
                    string.Join(",", fives),
                    string.Join(",", sixes));

                    string score = String.Format("|{0,-6}|{1,-6}|{2,-6}|{3,-6}|{4,-6}|{5,-6}|", 1 * ones.Count + "p", 2 * twos.Count + "p", 3 * threes.Count + "p", 4 * fours.Count + "p", 5 * fives.Count + "p", 6 * sixes.Count + "p");

                    SetCursorPosition(0, ROW_DICE);
                    Write(display);
                    SetCursorPosition(0, ROW_SCORE);
                    WriteLine(score);

                    rolling = Reroll(ref dice, ref currentRoll, rng);
                }
            }
        }

        public static void WriteColour(string text, ConsoleColor colour = ConsoleColor.White, int breaks = 0)
        {
            ForegroundColor = colour;
            Write(text);
            ResetColor();

            for (int i = 0; i < breaks; i++)
            {
                WriteLine();
            }
        }

        static void DrawScoreTable()
        {
            WriteLine("|Ones  |Twos  |Threes|Fours |Fives |Sixes |");
            WriteLine("------------------------------------------");
            WriteLine("|      |      |      |      |      |      |");
            WriteLine("------------------------------------------");
        }

        static void RollDice(ref List<int> dice, Random rng)
        {
            dice.Clear();
            for (int i = 0; i < NUM_DICE; i++)
            {
                dice.Add(rng.Next(1, 7));
            }
        }

        static bool Reroll(ref List<int> dice, ref int currentRoll, Random rng)
        {

            while (true)
            {
                if (currentRoll >= MAX_ROLLS)
                {
                    WriteColour("You have already rolled 2 times, now choose which numbers you want to use: 1, 2, 3, 4, 5, 6", ConsoleColor.Red, 2);
                    WriteColour("WORK IN PROGRESS, NOT FINISHED YET", ConsoleColor.Red);
                    currentRoll = 0;
                    return false;
                }

                SetCursorPosition(0, ROW_INPUT);
                WriteColour("Do you want to reroll your dice? You can reroll max 3 times. [Y/N]", ConsoleColor.Yellow, 1);
                char input = char.ToLower(ReadKey(true).KeyChar);
                WriteLine();

                if (input == 'y')
                {
                    currentRoll++;
                    ChooseDiceToReroll(ref dice, rng);
                    return true;
                }
                else if (input == 'n')
                {
                    WriteColour("You chose not to reroll, select which numbers you want to keep: 1, 2, 3, 4, 5, 6", ConsoleColor.Blue, 2);
                    WriteColour("WORK IN PROGRESS, NOT FINISHED YET", ConsoleColor.Red);
                    currentRoll = 0;
                    return false;
                }
                else
                {
                    WriteColour("Press [Y/N]", ConsoleColor.Red, 1);
                }
            }
        }

        static void ChooseDiceToReroll(ref List<int> dice, Random rng)
        {

            WriteColour("Type the numbers 1-5 depending on which dice you want to reroll (separated by commas e.g. 1,3,6)", ConsoleColor.Yellow, 2);
            WriteColour($"Current dice: ", ConsoleColor.Yellow);
            WriteColour($"{string.Join(", ", dice)}", ConsoleColor.Cyan, 1);


            while (true)
            {
                string input = ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    WriteColour("You did not reroll any dice, remember it is e.g. 1,3,4", ConsoleColor.Red, 1);
                }

                string[] reroll = input.Split(',');
                List<string> invalidChoices = new List<string>();
                bool allValid = true;

                foreach (var die in reroll)
                {
                    if (int.TryParse(die, out int index) && index >= 1 && index <= NUM_DICE)
                    {
                        dice[index - 1] = rng.Next(1, 7);
                    }
                    else
                    {
                        invalidChoices.Add(die);
                        allValid = false;
                    }
                }
                if (invalidChoices.Count > 0)
                {
                    WriteColour($"Invalid choices: {string.Join(", ", invalidChoices)}", ConsoleColor.Red, 2);
                }

                if (allValid)
                {
                    break;
                }
                else
                {
                    WriteColour("You must enter numbers between 1-6.", ConsoleColor.Red, 1);
                }
            }

            WriteColour("New dice: ", ConsoleColor.Yellow);
            WriteColour(string.Join(", ", dice), ConsoleColor.Cyan, 2);
            WriteColour("Updating table...", ConsoleColor.Red);
            Thread.Sleep(3000);
            ShowNewDice();

        }
        static void ShowNewDice()
        {
            Clear();
            DrawScoreTable();
        }
    }
}
