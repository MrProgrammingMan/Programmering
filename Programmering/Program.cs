using System.Threading;
using System.Diagnostics;
using static System.Console;
using System.Xml.Schema;
using System.ComponentModel.Design;
using System.Buffers;
using System.Globalization;
namespace Besöksdagen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;

            // skapar filen för poängen
            string filePath = "scores.txt";

            // kollar om filen redan existerar, om den gör det så läser den vad som står i filen
            List<string> poäng = new List<string>();
            if (File.Exists(filePath))
            {
                poäng = File.ReadAllLines(filePath).ToList();
            }


            // Används för att rensa leaderboarden om det skulle behövas (RÖR INTE OM DU INTE ÄR SANDER)
            /*
            bool devMode = true;

            if (devMode)
            {
                File.WriteAllText("scores.txt", "");
                WriteColour("scores.txt rensad (devMode aktivt)", ConsoleColor.DarkRed, 2);
            }
            */

            // skapar alla variablerna som borde vara UTANFÖR själva loopen
            Random rng = new Random();
            double nuvarandeFörsök = 0;
            double rekord = 0;


            // skapar loopen och kör detta tills while är 'false'
            while (true)
            {
            // Här börjar "Restart" används sedan för att kunna återvända här om man skriver in för tidigt.
            Restart:

                // Visar leaderboarden om den hittar filen scores.txt
                if (File.Exists("scores.txt"))
                {
                    string[] scores = File.ReadAllLines("scores.txt");

                    WriteLine("Leaderboard:");
                    foreach (string line in scores)
                    {
                        WriteLine(line + " sekunder", nfi);
                    }
                }
                else
                {
                    WriteLine("Ingen poänglista hittades.");
                }

                WriteLine();

                // Text med WriteColour vilket gör det möjligt att lägga till färg OCH antalet radbrott man vill ha mellan texterna.
                WriteColour("Välkommen till Reaktionspelet!", ConsoleColor.Yellow, 2);

                WriteColour("Instruktioner: Tryck på ENTER när du ser ordet NU. Du kommer få en tid på hur snabb du var på att trycka den i SEKUNDER.", ConsoleColor.Cyan, 2);

                WriteLine("För att starta tryck på ENTER");

                // Läser konsolens input (då man trycker på ENTER)
                ReadLine();

                // Skapar en int som är en variabel med ett nummer i. I detta fallet så är nummret mellan 1000 och 5000 (som används som millisekunder, så då blir det mellan 1 och 5 sekunder) Vilket betyder att den högsta möjliga tiden att vänta är 5 sekunder
                WriteColour("Vänta...", ConsoleColor.Blue, 2);
                int timer = rng.Next(1000, 5000);
                int waited = 0;

                // Fortsätter lägga till 10 millisekunder hela tiden på variabelen waited tills waited = timer
                while (waited < timer)
                {
                    if (Console.KeyAvailable)
                    {
                        ReadKey(true);
                        WriteColour("För tidigt! Du får inte trycka ENTER innan NU!", ConsoleColor.Red, 1);
                        Thread.Sleep(1000);
                        Clear();
                        goto Restart;
                    }

                    Thread.Sleep(10);
                    waited += 10;
                }

                WriteColour("NU", ConsoleColor.Red, 2);

                // Startar klockan för att mäta hur många millisekunder det tar tills användaren trycker på ENTER
                Stopwatch clock = Stopwatch.StartNew();

                ReadLine();

                // Stoppar klockan efter ENTER har tryckits på
                clock.Stop();


                // Kollar hur mycket tid du har i sekunder och avrundar det till 2 decimaler
                WriteLine("Bra jobbat! Din tid blev:");
                WriteColour("Tid (s): " + Math.Round(clock.Elapsed.TotalSeconds, 2), ConsoleColor.Green, 1);

                // Sätter in tiden du fick i variabelen nuvarandeFörsök som då skapades utanför hela while loopen
                nuvarandeFörsök = Math.Round(clock.Elapsed.TotalSeconds, 2);

                // kollar om det är ett nytt rekord eller inte
                if (rekord == 0)
                {
                    rekord = Math.Round(clock.Elapsed.TotalSeconds, 2);
                }
                else if (nuvarandeFörsök < rekord)
                {
                    rekord = nuvarandeFörsök;
                    WriteLine("Nytt rekord!");
                }
                else if (nuvarandeFörsök == rekord)
                {
                    WriteLine("Wow du fick samma nummer igen! Det är inte alltid det händer ;)");
                }

                // Låter användaren lägga in sitt resultat på leaderboarden om den vill
                WriteColour("Vill du lägga in ditt resultat på leaderboarden? [Y/N]", ConsoleColor.Yellow, 1);

                while (true)
                {

                    char input = Char.ToUpper(ReadKey(true).KeyChar);
                    if (input == 'Y')
                    {
                        while (true)
                        {
                            WriteColour("Skriv in ditt namn:", ConsoleColor.Cyan, 1);
                            string? namn = ReadLine();

                            if (string.IsNullOrWhiteSpace(namn))
                            {
                                WriteLine("Du skrev inte in något namn! Försök igen.");
                                continue;
                            }

                            string resultat = $"{namn}:{nuvarandeFörsök}";

                            string[] split = resultat.Split(':');

                            float num = float.Parse(split[1]);

                            poäng.Add(split[1]);

                            File.WriteAllLines(filePath, poäng);

                            WriteColour("Ditt resultat har sparats!", ConsoleColor.Yellow, 2);
                            break;
                        }
                        break;
                    }
                    else if (input == 'N')
                    {
                        WriteColour("Okej då gör vi inte det!", ConsoleColor.Red, 2);
                        break;
                    }
                    else
                    {
                        WriteColour("Tryck på Y eller N", ConsoleColor.Red, 2);
                        continue;
                    }
                }


                // Frågar om användaren vill köra igen
                WriteColour($"Vill du köra igen? Ditt rekord är: {rekord} sekunder! [Y/N]", ConsoleColor.Yellow, 2);

                while (true)
                {
                    char key = Char.ToUpper(ReadKey(true).KeyChar);
                    if (key == 'Y')
                    {
                        Clear();
                        WriteColour("Startar om...", ConsoleColor.Red, 2);
                        Thread.Sleep(200);
                        break;
                    }
                    else if (key == 'N')
                    {
                        Clear();
                        WriteColour("Resettar poäng...", ConsoleColor.Red, 2);
                        rekord = 0;
                        nuvarandeFörsök = 0;
                        Thread.Sleep(200);
                        break;
                    }
                    else
                    {
                        WriteColour("Tryck på Y eller N", ConsoleColor.Red, 2);
                        continue;
                    }
                }
                continue;
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

        static void VisaLeaderboard()
        {

        }
    }
}