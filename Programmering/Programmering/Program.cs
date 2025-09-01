using System;
using static System.Console;
namespace Programmering
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //////////////////////////////////////////////////////////
            /// Skriv aldrig något ovanför denna rad!!!!!!!!
            /*

            /// Övning 1
            ForegroundColor = ConsoleColor.Red;
            BackgroundColor = ConsoleColor.White;
            WriteLine("Hello, World!");
            ResetColor();
            
            /// Övning 2
            string minText = "Hej på dig!"; // Skapar en variabel för text
            int mittTal = 21;               // Skapar en variabel för heltal

            Console.WriteLine(minText);
            minText = "Hej igen!";
            Console.WriteLine($"minText: {minText}"); // $ och { } används för att
                                                      // kunna skriva text och 
            Console.WriteLine(mittTal);               // variabler på samma rad.
            mittTal = mittTal + 1;
            Console.WriteLine($"mittTal: {mittTal}");

            //////////////////////////////////////////////////////////
            /// Övning 3
            var Math1 = 10 * 10;
            var Math2 = 10 + 5;
            Random rng = new Random();
            int chans1 = rng.Next(1, 10);
            WriteLine($"{Math1} - {Math2} * {chans1} = {Math1 - Math2 * chans1}");
            */

            /////////////////////////////////////////////////////////////
            /// Övning 4
            /*
            Write("Vad heter du? ");
            string namn = Console.ReadLine();
            WriteLine($"Hej {namn}!");

            // För att pausa programmet efter utskriften är klar
            ReadLine();
            */

            /////////////////////////////////////////////////////////////
            /// Övning 5
            /*
            WriteLine("Skriv ett nummer: ");
            int m = Int32.Parse(ReadLine());
            WriteLine("Skriv ett till nummer: ");
            int n = Int32.Parse(ReadLine());
            WriteLine("Skriv det sista nummret: ");
            int b = Int32.Parse(ReadLine());
            int summa = m + n + b;
            int medelvärde = (m + n + b) / 3;
            WriteLine($"Totalt blir din summa {summa}");
            Write($"Ditt medelvärde blir {medelvärde}");
            */




            /////////////////////////////////////////////////////////////
            /// Extra ig
            /*
            int AntalElever = 200;
            Random elev = new Random();
            int hoppsan = elev.Next(1, 201);
            int AntalSkyldiga = hoppsan;
            int AntalOskyldiga = AntalElever - AntalSkyldiga;
            WriteLine($"För att reda ut Oskyliga elever använder vi ekvationen: {AntalElever} - {AntalSkyldiga} = {AntalElever - AntalSkyldiga}");
            WriteLine($"Då vet vi att antalet oskyldiga är {AntalOskyldiga}");
            */

            ////////////////////////////////////////////////
            /// jag hitta det här
            /*
            WriteLine("Enter first number: ");
            int m = Int32.Parse(ReadLine());
            WriteLine("Enter second number: ");
            int n = Int32.Parse(ReadLine());
            Write("The multiplication of numbers entered = " + m * n);
            ReadLine();
            */

            /*
                WriteLine("Du ska skriva in betygen du tror du kommer få i följande ämnen mellan F-A");
                WriteLine("Engelska: ");
                string Eng = ReadLine();
                WriteLine("Svenska: ");
                string Sve = ReadLine();
                WriteLine("Matte 1: ");
                string Matteett = ReadLine();
                WriteLine("Matte 2: ");
                string Mattetvå = ReadLine();
                WriteLine("Historia: ");
                string His = ReadLine();
                WriteLine("Samhäll: ");
                string Sam = ReadLine();
                WriteLine("Teknik 1: ");
                string Tek = ReadLine();
            */

            /*
            WriteLine("Skriv in kursens namn");
            string kurs = ReadLine();
            WriteLine("Vilket värde kommer du få, baserat på ditt betyg?");
            WriteLine("F = 0, E = 10, D = 12,5 C = 15, B = 17,5 A = 20");

            float poäng = float.Parse(ReadLine());

            WriteLine($"Total poäng för kursen: {kurs}: {poäng + 150}");
            */
            /////////////////////////////////////////////////////////////////////////
            ///gameshow
            /*
            Random choice = new Random();
            bool tryAgain = true;
            string response = "";
            string input1;
            string input2;
            string input3;

            while(tryAgain)
            {
            int rng = choice.Next(1, 5);
            if (rng == 1)
            {
                WriteLine("Womp womp no gameshow for you");
                    WriteLine("Would you like to try again? (Y/N)");
                    response = ReadLine();
                    response = response.ToUpper();

                if (response == "Y")
                    {
                        tryAgain = true;
                    }
                else
                    {
                        tryAgain = false;
                    }

                }
            else if (rng == 2)
            {
                WriteLine("gitgud");
                    WriteLine("Would you like to try again? (Y/N)");
                    response = ReadLine();
                    response = response.ToUpper();

                    if (response == "Y")
                    {
                        tryAgain = true;
                    }
                    else
                    {
                        tryAgain = false;
                    }
                }
            else if (rng == 3)
            {
                WriteLine("You lost better luck next time");
                    WriteLine("Would you like to try again? (Y/N)");
                    response = ReadLine();
                    response = response.ToUpper();

                    if (response == "Y")
                    {
                        tryAgain = true;
                    }
                    else
                    {
                        tryAgain = false;
                    }
                }
            if (rng == 4)
            {
                    int retries = 0;
                    bool usedalready1 = false;
                    bool usedalready2 = false;
                    bool usedalready3 = false;
                    for (int i = 100; i <= 100; i--)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Write(i + " ");
                        Thread.Sleep(1000);
                        ResetColor();
                    }
                    WriteLine("CONGRATULATIONS YOU'VE BEEN SELECTED AS A LUCKY CONTESTANT IN OUR GAMESHOW");
                WriteLine("YOU WILL BE GIVEN 5 QUESTIONS TO ANSWER WITHIN A TIME LIMIT, IF YOU DO NOT COMPLETE, YOUR CERTAIN DEMISE IS INEVITABLE.");
                Write("Your first question is: ");

                Random gameshow = new Random();
                while (retries != 5)
                {
                    int fr = gameshow.Next(1, 6);
                    if (fr == 1)
                    {
                        if (usedalready1 == false)
                        {
                            WriteLine("What is the capital of Thailand?");
                            input1 = ReadLine().ToLower();
                            if (input1 == "bangkok")
                            {
                                WriteLine("That's correct! The answer is Bangkok, you're so smart aren't you, you damn geography nerd. Woops sorry got out of hand, let's continue.");
                            }
                            else
                            {
                                WriteLine("You got it wrong, have you never payed attention in class or do you think the gameshow is a joke? I can assure you. It's not.");
                            }
                            usedalready1 = true;
                            retries++;
                                WriteLine ("Your next question is:");
                        }
                        else if (fr == 2)
                        {
                            if (usedalready2 == false)
                            {
                                Write("How many days are in a year?");
                            input2 = ReadLine();
                            
                            if (input2 == "365")
                            {
                                WriteLine("Wow, you're so educated, good job, i mean if you include every 4 years it's 366, bet ya didn't take that into account.");
                            }
                            else if (input2 == "366")
                            {
                                WriteLine("Your answer is only valid every 4 years, and the year right now is 2025. So SMARTASS, you got it wrong, but i'll give you half a point");
                            }
                            else
                            {
                                WriteLine("Let me ask you, are you human? Have you perchance been living under a rock? Or can you only count to 5? Whatever you choose, you got it wrong so too late for taksies backsies.");
                            }
                            usedalready2 = true;
                            retries++;
                                }
                            }
                        else if (fr == 3)
                        {
                            if (usedalready3 == false)
                            {
                                    WriteLine("What is the square root of 81?");
                                    input3 = ReadLine();

                                    if (input3 == "9")
                                    {
                                        WriteLine("WOWWWW you got it, are you a math nerd or was this just too easy for you");
                                    }
                                    else if (input3 == "-9")
                                    {
                                        WriteLine("OHHH YEP YOU'RE DEFINETELY A MATH NERD, CONGRATS YOU DID IT THO");
                                    }
                                    else
                                    {
                                        WriteLine("It's okay to fail math, not your fault buddy :)");
                                    }
                                    usedalready3 = true;
                                    retries++;
                                    
                            }
                        }
                    }
                }
            }
            */

            ///////////////////////////////////////////////////////////////////////////////////////
            ///uhm number guessing game
            /*
             Random random = new Random();
             bool playAgain = true;
             int min = 1;
             int max = 100;
             int guess;
             int number;
             int guesses;
             int highScore = int.MaxValue;
             String response;

             while (playAgain)
             {
                 WriteLine("Guess a number between " + min + " - " + max + ": ");
                 guess = 0;
                 guesses = 0;
                 response = "";
                 number = random.Next(min, max + 1);

                 while (guess != number)
                 {
                     guess = Convert.ToInt32(ReadLine());
                     WriteLine("Guess: " + guess);

                     if (guess > number)
                     {
                         WriteLine(guess + " is too high");
                     }
                     else if (guess < number)
                     {
                         WriteLine(guess + " is too low");
                     }
                     guesses++;
                 }
                 WriteLine("Number: " + number);
                 WriteLine("YOU WIN!!!!");
                 WriteLine("It took you: " + guesses + " attempts");
                 WriteLine("");
                 if (guesses < highScore)
                 {
                     highScore = guesses;
                     WriteLine("CONGRATS your new high score is " + highScore);
                 }
                 else
                 {
                     WriteLine("Sorry you didn't beat your high score of " + highScore);
                 }
                 WriteLine("Wanna try your hand at another shot? (Y/N): ");
                 response = ReadLine();
                 response = response.ToUpper();

                 if (response == "Y")
                 {
                     playAgain = true;
                 }
                 else
                 {
                     playAgain = false;
                 }

             }

             WriteLine("Thanks for playing pookie :3333333");
             */

            /////////////////////////////////////////////////////////////////////////////////////////
            ///rock paper scissors
            /*
            Random random = new Random();

            int playerScore = 0;
            int enemyScore = 0;
            bool playAgain = true;
            string response = "";
            while (playAgain)
            {
                WriteLine("Hello, you're gonna play the classic rock paper scissors game, the first to reach 3, wins.");
                while (playerScore != 3 && enemyScore != 3)
                {
                    WriteLine("Player score - " + playerScore + ". Enemy Score - " + enemyScore);
                    WriteLine("Kindly press 'r' if you want rock, 'p' for la paper or literally anything else for the cutty cut scissors");
                    string playerChoice = ReadLine();

                    int enemyChoice = random.Next(0, 3);

                    if (enemyChoice == 0)
                    {
                        WriteLine("Enemy chose the ROCK bro");

                        switch (playerChoice)
                        {
                            case "r":
                                WriteLine("Tie");
                                break;
                            case "p":
                                WriteLine("you won the round HOORAY");
                                playerScore++;
                                break;
                            default:
                                WriteLine("The computer won this round, step up your game man");
                                enemyScore++;
                                break;
                        }
                    }
                    else if (enemyChoice == 1)
                    {
                        WriteLine("Enemy chose the damn PAPER!");

                        switch (playerChoice)
                        {
                            case "r":
                                WriteLine("ENEMY WON THE ROUND");
                                enemyScore++;
                                break;
                            case "p":
                                WriteLine("IT'S A TIE");
                                break;
                            default:
                                WriteLine("YOU WON THIS ROUND YAYAYAYYA");
                                playerScore++;
                                break;
                        }
                    }
                    else
                    {
                        WriteLine("Yeah computer chose SCISSORS");

                        switch (playerChoice)
                        {
                            case "r":
                                WriteLine("You WON THE ROUND YESSSS");
                                playerScore++;
                                break;
                            case "p":
                                WriteLine("DAMN IT THAT DAMN RANDOM GENERATED NUMBER WON THIS ROUND");
                                enemyScore++;
                                break;
                            default:
                                WriteLine("WHO'S THAT POKEMON? a bowtie");
                                break;
                        }
                    }
                }



                if (playerScore == 3)
                {
                    WriteLine("Wait, you actually won? I mean- YOU WON GOOD JOB YOU BEAT THE RANDOM NUMBERS, CONGRATS!!!! HAVE THIS RANDOMLY GENERATED NUMBER FOR YOUR TROPHY");
                    Random winnernumber = new Random();
                    int YOUWON = random.Next(1, 1000);
                    WriteLine($"{YOUWON}");
                    playerScore = 0;
                    enemyScore = 0;
                }
                else if (enemyScore == 3)
                {
                    WriteLine("Yeah, you lost, not really expected, WELL if you were using the program to determine anything, HAHA TOO BAD, however it's not all bad. I wasted time coding a jumbled sentence with profanities that is randomly determined with 5 predetermined words:");
                    int wordamount = 0;
                    Random word = new Random();
                    playerScore = 0;
                    enemyScore = 0;
                    while (wordamount != 5)
                    {
                        int daword = word.Next(1, 6);

                        if (daword == 1)
                        {
                            Write("TURD ");
                            wordamount++;
                        }
                        else if (daword == 2)
                        {
                            Write("COCKADOODLE ");
                            wordamount++;
                        }
                        else if (daword == 3)
                        {
                            Write("BOLLOCKS ");
                            wordamount++;
                        }
                        else if (daword == 4)
                        {
                            Write("FIDDLESTICKS ");
                            wordamount++;
                        }
                        else if (daword == 5)
                        {
                            Write("BLIMEY ");
                            wordamount++;

                        }

                    }
                }
                WriteLine("");
                WriteLine("Wanna try your hand at another shot? (Y/N): ");
                response = ReadLine();
                response = response.ToUpper();

                if (response == "Y")
                {
                    playAgain = true;
                }
                else
                {
                    playAgain = false;
                }
            }



            WriteLine("OK BYEEEEEEEEEE");
            */

            //////////////////////////////////////////////////////////////////////////////
            ////calculator
            /*
            int totalAmount;
            int numbers;
            int retries = 0;

            WriteLine("Please type in how many numbers you want to use for this");
            totalAmount = Convert.ToInt32(ReadLine());
            WriteLine("Please type in a number");
            int number1 = Convert.ToInt32(ReadLine());

            while (retries != totalAmount - 1)
            { 
                WriteLine("What form of math would you like to use? example: addition, subtraction etc");
                string operation = ReadLine().ToLower();
                if (operation == "addition")
                {
                    WriteLine("Please enter the second number");
                    int number2 = Convert.ToInt32(ReadLine());
                    number1 = number1 + number2;
                    WriteLine("Current total: " + number1);
                }
                retries++;
            }
            */

            // Tärning

            int PlayerScore = 0;
            int ComputerScore = 0;
            int PlayerMatchesWon = 0;
            int ComputerMatchesWon = 0;
            int FinalComputerNumber = 0;
            int FinalPlayerNumber = 0;
            int [] playerDice = new int[2];
            int[] computerDice = new int[2];
            bool chosen = false;
            bool d6 = false;
            bool d20 = false;
            bool Play = true;

            WriteLine("Hello Welcome to Dice Throw! You will be throwing 2 dices every round, the person with the highest dice value wins, best of 3 wins. You may quit by typing 'Exit'.");
            WriteLine("");
            WriteLine("Do you wish to use a 'd6' dice or 'd20' dice?");
            diceChoice(ref d6, ref d20, ref chosen);
            while (Play)
            {
                while (PlayerScore != 3 && ComputerScore != 3)
                {
                    WriteLine("Player score - " + PlayerScore + ". Computer Score - " + ComputerScore);
                    WriteLine("Press enter to roll your dices.");
                    if (Exit()) return;

                    if (d6 == true)
                    {
                        Rolld6(playerDice, computerDice);
                    }
                    else if (d20 == true)
                    {
                        Rolld20(playerDice, computerDice);
                    }

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
                        PlayerMatchesWon++;
                        Winner(PlayerMatchesWon, ComputerMatchesWon);
                        Play = true;
                        PlayerScore = 0;
                        ComputerScore = 0;
                    }
                    else if (ComputerScore == 2)
                    {
                        Play = false;
                        WriteLine("You lost the match!");
                        ComputerMatchesWon++;
                        Winner(PlayerMatchesWon, ComputerMatchesWon);
                        Play = true;
                        PlayerScore = 0;
                        ComputerScore = 0;
                    }
                }
            }



























            ReadLine();
            /////////////////////////////////////////////////////////////////////
            /// Skriv aldig nÃ¥got under denna rad
        }

        static bool Exit()
        {
            if (ReadLine().ToLower() == "exit")
            {
                return true;
            }

            return false;
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
        static void Winner(int PlayerWin, int ComputerWin)
        {
            WriteLine();
            WriteLine("Press enter to play again or type 'exit' to quit!");
            if (Exit()) Environment.Exit(0);
            Clear();
            WriteLine("Reminder: you can type 'exit' to quit at any time!");
            WriteLine("Player Matches won - " + PlayerWin + ". Computer Matches won - " + ComputerWin);
            WriteLine();
        }
        static void Rolld6(int[] playDice, int[] comDice)
        {     
            Random randomd6 = new Random();
            playDice[0] = randomd6.Next(1, 7);
            playDice[1] = randomd6.Next(1, 7);
            comDice[0] = randomd6.Next(1, 7);    
            comDice[1] = randomd6.Next(1, 7);
        }
        static void Rolld20(int[] playDice, int[] comDice)
        {
            Random randomd20 = new Random();
            playDice[0] = randomd20.Next(1, 21);
            playDice[1] = randomd20.Next(1, 21);
            comDice[0] = randomd20.Next(1, 21);
            comDice[1] = randomd20.Next(1, 21);
        }
    }
}


