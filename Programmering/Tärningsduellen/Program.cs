using static System.Console;
namespace Tärningsduellen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tärning


            int Money = 500;
            int PlayerScore = 0;
            int ComputerScore = 0;
            int PlayerMatchesWon = 0;
            int ComputerMatchesWon = 0;
            int FinalComputerNumber = 0;
            int FinalPlayerNumber = 0;
            int betAmount = 0;
            int loanAmount = 0;
            int[] playerDice = new int[2];
            int[] computerDice = new int[2];
            bool chosen = false;
            bool isD6Chosen = false;
            bool isD20Chosen = false;
            bool Play = true;


            WriteLine("Hello Welcome to Dice Throw! You will be throwing 2 dices every round, the person with the highest dice value wins, best of 3 wins. You may quit by typing 'Exit'.");
            WriteLine("");

            WriteLine("Do you wish to use a 'd6' dice or 'd20' dice?");
            diceChoice(ref isD6Chosen, ref isD20Chosen, ref chosen);
            WriteLine("");
            while (Play)
            {
                checkBet(ref Money, ref loanAmount, ref betAmount);
                while (PlayerScore != 3 && ComputerScore != 3)
                {
                    WriteLine("Player score - " + PlayerScore + ". Computer Score - " + ComputerScore);
                    WriteLine("Press enter to roll your dices.");
                    if (Exit()) return;

                    if (isD6Chosen)
                        RollDice(playerDice, computerDice, 6);
                    else
                        RollDice(playerDice, computerDice, 20);

                    FinalPlayerNumber = Math.Max(playerDice[0], playerDice[1]);
                    FinalComputerNumber = Math.Max(computerDice[0], computerDice[1]);

                    WriteLine("Your dices:");
                    Dice(playerDice[0], playerDice[1]);
                    WriteLine($"Your final number is {FinalPlayerNumber}");

                    WriteLine();
                    WriteLine("Press enter to roll the Computer's dices.");
                    if (Exit()) return;

                    WriteLine("Computer's Dices:");
                    Dice(computerDice[0], computerDice[1]);
                    WriteLine($"The Computer's final number is {FinalComputerNumber}");

                    WriteLine();
                    if (FinalPlayerNumber > FinalComputerNumber)
                    {
                        WriteLine($"You win! because {FinalPlayerNumber} > {FinalComputerNumber}");
                        PlayerScore++;
                    }
                    else if (FinalPlayerNumber < FinalComputerNumber)
                    {
                        WriteLine($"You lost! because {FinalComputerNumber} > {FinalPlayerNumber}");
                        ComputerScore++;
                    }
                    else
                    {
                        WriteLine($"It's a tie!");
                    }

                    if (PlayerScore == 2)
                    {
                        Play = false;
                        WriteLine("You won the match!");
                        if (betAmount >= 0)
                        {
                            WriteLine($"Your bet of {betAmount} has been doubled!");
                            Money += betAmount * 2;
                        }
                        if (loanAmount > 0)
                        {
                            Payback(ref loanAmount, ref Money);
                        }
                        PlayerMatchesWon++;
                        Winner(PlayerMatchesWon, ComputerMatchesWon);
                        Play = true;
                        PlayerScore = 0;
                        ComputerScore = 0;
                        checkBet(ref Money, ref loanAmount, ref betAmount);
                        WriteLine("");
                    }
                    else if (ComputerScore == 2)
                    {
                        Play = false;
                        WriteLine("You lost the match!");
                        if (loanAmount > 0)
                        {
                            Payback(ref loanAmount, ref Money);
                        }

                        ComputerMatchesWon++;
                        Winner(PlayerMatchesWon, ComputerMatchesWon);
                        Play = true;
                        PlayerScore = 0;
                        ComputerScore = 0;
                        checkBet(ref Money, ref loanAmount, ref betAmount);
                        WriteLine("");
                    }
                }
            }


















        }

        static bool Exit()
        {
            if (ReadLine().ToLower() == "exit")
            {
                return true;
            }

            return false;
        }

        static void Loan(ref int Money, ref int loanAmount, ref int betAmount)
        {
            WriteLine("");
            WriteLine("You can have a maximum loan of 1500 kr, if you reach higher than that you will go bankrupt and the program will close.");
            WriteLine("");
            WriteLine("How much money do you want to loan? It can only be between 100 - 1000 and it must be an even hundred number such as 200, 300, 400 etc.");
            while (true)
            {
                int newLoanAmount;
                if (!int.TryParse(ReadLine(), out newLoanAmount))
                {
                    WriteLine($"You did not input a valid number, try again and remember it must be an even hundredth number such as 100, 200 etc.");
                    continue;
                }

                if (newLoanAmount >= 100 && newLoanAmount <= 1000 && newLoanAmount % 100 == 0)
                {
                    loanAmount += newLoanAmount;
                    Money += newLoanAmount;

                    WriteLine($"Congrats! You now have a total loan of {loanAmount} kr and your money is {Money} kr!");
                    break;
                }
                else
                {
                    WriteLine("This is not an even hundredth number such as 100 or 200, try again.");
                }
            }
        }

        static void payLoan(ref int loanAmount, ref int Money)
        {
            int payBack = 0;
            WriteLine($"Please pay back your loan of {loanAmount} by typing '{loanAmount}'");
            while (!int.TryParse(ReadLine(), out payBack))
            {
                WriteLine($"You did not input a valid number, please input {loanAmount}");
            }
            if (payBack == loanAmount)
            {
                WriteLine("Congrats, you've paid back your loan!");
                loanAmount = 0;
                Money = Money - payBack;
            }
        }

        static void checkBet(ref int Money, ref int loanAmount, ref int betAmount)
        {
            if (Money > 3000)
            {
                WriteLine("You've reached above 3000 and have gone over the maximum amount of money on your account allowed, you will be reset back to 3000 kr");
                Money = 3000;
            }
            else if (Money >= 100)
            {
                betMoney(ref Money, ref betAmount);
                WriteLine("");
            }
            else
            {
                WriteLine("You do not have enough money to bet, do you wish to take out a loan? You may end up in debt if you cannot pay it back.  Otherwise, you will be unable to play");
                WriteLine("");
                WriteLine("Click Y/N");
                while (true)
                {
                    char input = ReadKey().KeyChar;

                    if (input == 'y')
                    {
                        Loan(ref Money, ref loanAmount, ref betAmount);
                        betMoney(ref Money, ref betAmount);
                        break;
                    }
                    else if (input == 'n')
                    {
                        WriteLine("Since you won't bet, you will be forced to quit.");
                        Environment.Exit(0);
                    }
                    else
                    {
                        WriteLine("Please click Y/N.");
                    }
                }
            }
        }

        static void betMoney(ref int Money, ref int betAmount)
        {
            WriteLine($"How much do you want to bet? 100, 300 or 500 kr? You currently own {Money} kr. Maximum amount you can have is 3000 kr");
            while (!int.TryParse(ReadLine(), out betAmount))
            {
                WriteLine("You did not input a valid number, please input either 100, 300 or 500 kr");
            }
            if (betAmount == 100)
            {
                WriteLine("Your bet of '100 kr' is successful");
                Money -= 100;
                WriteLine($"You now have {Money} kr left");
            }
            else if (betAmount == 300)
            {
                WriteLine("Your bet of '300 kr' is successful");
                Money -= 300;
                WriteLine($"You now have {Money} kr left");
            }
            else if (betAmount == 500)
            {
                WriteLine("Your bet of '500 kr' is successful");
                Money -= 500;
                WriteLine($"You now have {Money} kr left");
            }
            else
            {
                WriteLine("That's an invalid bet amount, please choose either 100, 300 or 500");
            }
        }

        static void diceChoice(ref bool d6, ref bool d20, ref bool chosen)
        {
            while (chosen == false)
            {
                string Choice = ReadLine().ToLower();
                if (Choice == "d6")
                {
                    WriteLine("You have chosen a d6 dice.");
                    d6 = true;
                    chosen = true;
                }
                else if (Choice == "d20")
                {
                    WriteLine("You have chosen a d20 dice.");
                    d20 = true;
                    chosen = true;
                }
                else
                {
                    WriteLine("That's not a valid answer, please type 'd6' or 'd20'");
                }
            }
        }

        static void Dice(int Dice1, int Dice2)
        {
            WriteLine($"Dice 1: {Dice1}");
            WriteLine($"Dice 2: {Dice2}");
        }

        static void Payback(ref int loanAmount, ref int Money)
        {
            while (true)
            {
                if (loanAmount >= 1500)
                {
                    WriteLine("");
                    WriteLine("You have however, gone over your loan amount, you have to pay it back now otherwise you will be forced to quit");
                    WriteLine("");
                    WriteLine($"You are {loanAmount} kr in debt. Do you wish to pay it back now? You currently have {Money} kr. (yes or no)");
                    string input = ReadLine().ToLower();
                    if (input == "yes")
                    {
                        payLoan(ref loanAmount, ref Money);
                        if (loanAmount == 0)
                        {
                            break;
                        }
                    }
                    else if (input == "no")
                    {
                        WriteLine("");
                        WriteLine("Since you did not pay your loan in time, you have gone bankrupt, Goodbye.");
                        Environment.Exit(0);
                    }
                    else
                    {
                        WriteLine("Please type Yes or No.");
                    }
                }
                else if (loanAmount < 1500)
                {
                    WriteLine("");
                    WriteLine($"You are still {loanAmount} kr in debt. Do you wish to pay it back now, you currently have {Money} kr? (yes or no)");
                    string input = ReadLine().ToLower();
                    if (input == "yes")
                    {
                        payLoan(ref loanAmount, ref Money);
                        break;
                    }
                    else if (input == "no")
                    {
                        WriteLine($"If you won't pay back your loan now, make sure you do it later, since you still owe {loanAmount} kr.");
                        break;
                    }
                    else
                    {
                        WriteLine("Please type Yes or No.");
                    }
                }
                else
                {
                    break;
                }
            }
        }

        static void Winner(int playerWin, int computerWin)
        {
            WriteLine();
            WriteLine("Press enter to play again or type 'exit' to quit!");
            if (Exit()) Environment.Exit(0);

            Clear();
            WriteLine("Reminder: you can type 'exit' to quit at any time!");
            WriteLine("Player Matches won - " + playerWin + ". Computer Matches won - " + computerWin);
            WriteLine();
        }

        static Random rng = new Random();
        static void RollDice(int[] playDice, int[] comDice, int max)
        {
            playDice[0] = rng.Next(1, max + 1);
            playDice[1] = rng.Next(1, max + 1);
            comDice[0] = rng.Next(1, max + 1);
            comDice[1] = rng.Next(1, max + 1);
        }
    }
}