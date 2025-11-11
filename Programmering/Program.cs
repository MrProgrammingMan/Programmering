using System.Threading;
using System.Diagnostics;
using static System.Console;
using System.Globalization;
namespace Besöksdagen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;

            // skapar filen för poängen om den inte redan existerar
            string filePath = "scores.txt";

            // kollar om filen redan existerar, om den gör det så läser den vad som står i filen
            List<string> namnLista = new List<string>();
            List<float> poäng = new List<float>();

            if (File.Exists(filePath))
            {
                string[] linjer = File.ReadAllLines(filePath);

                // delar upp så vi bara får nummerna och inte namnet också, då kan vi använda nummerna för att byta , till .
                foreach (string linje in linjer)
                {
                    string[] delar = linje.Split(':');
                    if (delar.Length == 2)
                    {
                        namnLista.Add(delar[0]);
                        if (float.TryParse(delar[1].Trim(), NumberStyles.Float, nfi, out float score))
                        {
                            poäng.Add(score);
                        }
                        else
                        {
                            WriteLine("Hittade inte poäng");
                            poäng.Add(0f);
                        }
                    }
                }
            }


            // Används för att rensa leaderboarden om det skulle behövas (RÖR INTE OM DU INTE ÄR SANDER)
            /*
            bool devMode = true;

            if (devMode)
            {
                File.WriteAllText("scores.txt", "");
                WriteColour("scores.txt rensad (devMode aktiv)", ConsoleColor.DarkRed, 2);
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
                VisaLeaderboard(namnLista, poäng, nfi);

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
                        WriteColour("För tidigt! Du får inte trycka ENTER innan NU!", ConsoleColor.DarkRed, 1);
                        Thread.Sleep(1000);
                        Clear();
                        goto Restart;
                    }

                    Thread.Sleep(10);
                    waited += 10;
                }

                WriteColour("NU", ConsoleColor.Red, 1);

                // Startar klockan för att mäta hur många millisekunder det tar tills användaren trycker på ENTER
                Stopwatch clock = Stopwatch.StartNew();

                ReadLine();

                // Stoppar klockan efter ENTER har tryckits på
                clock.Stop();


                // Kollar hur mycket tid du har i sekunder och avrundar det till 2 decimaler
                WriteLine("Bra jobbat! Din tid blev:");
                WriteColour("Tid (s): " + Math.Round(clock.Elapsed.TotalSeconds, 2), ConsoleColor.Green, 2);

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
                WriteColour("Vill du lägga in ditt resultat på leaderboarden? [Y/N]", ConsoleColor.Yellow, 2);

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

                            // sparar både namn och nummret i "resultat"
                            string resultat = $"{namn}:{nuvarandeFörsök}";

                            // delar upp resultat i två delar: där split[0] = namnn och split[1] = tid
                            string[] split = resultat.Split(':');

                            // gör om split[1] till en float som då håller ett nummer (i detta fall tiden)
                            float num = float.Parse(split[1]);

                            // lägger till namn i listan "namnLista" och tiden i listan "poäng"
                            namnLista.Add(namn);
                            poäng.Add(num);


                            List<string> combined = new();
                            for (int i = 0; i < namnLista.Count; i++)
                            {
                                combined.Add($"{namnLista[i]}:{poäng[i].ToString(nfi)}");
                            }

                            File.WriteAllLines("scores.txt", combined);

                            WriteColour("Ditt resultat har sparats!", ConsoleColor.Green, 2);
                            break;
                        }
                        break;
                    }
                    else if (input == 'N')
                    {
                        WriteColour("Hoppar över resultat!", ConsoleColor.DarkRed, 2);
                        break;
                    }
                    else
                    {
                        WriteColour("Tryck på Y eller N", ConsoleColor.DarkRed, 2);
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
                        WriteColour("Startar om...", ConsoleColor.DarkRed, 2);
                        Thread.Sleep(200);
                        break;
                    }
                    else if (key == 'N')
                    {
                        Clear();
                        WriteColour("Nollställer poäng...", ConsoleColor.DarkRed, 2);
                        rekord = 0;
                        nuvarandeFörsök = 0;
                        Thread.Sleep(200);
                        break;
                    }
                    else
                    {
                        WriteColour("Tryck på Y eller N", ConsoleColor.DarkRed, 2);
                        continue;
                    }
                }
                continue;
            }
        }

        // static void som gör det möjligt att använda WriteColour denna hämtar string som då är det man skrev in sen hämtar den färgen och till slut radbrott
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

        // static void för att visa leaderboarden, den hämtar listan "namnLista", listtan "poäng" och till slut "nfi" som gör så att decimaler blir punkter
        static void VisaLeaderboard(List<string> namnLista, List<float> poäng, NumberFormatInfo nfi)
        {
            if (namnLista.Count == 0)
            {
                WriteLine("Ingen poänglista hittades ännu, testa att köra en runda först.");
                return;
            }

            // skapar en lista som tempoärt sätter ihop namnLista och poäng för att kunna lägga in det i listan "leaderboard" som sen skriver ut de snabbaste människorna
            List<(string namn, float tid)> leaderboard = new List<(string, float)>();
            for (int i = 0; i < namnLista.Count; i++)
            {
                leaderboard.Add((namnLista[i], poäng[i]));
            }

            // sorterar listan så att de snabbaste är längst up och resten är under (simpelt)
            leaderboard.Sort((a, b) => a.tid.CompareTo(b.tid));

            // skriver ut den vackra leaderboarden :)
            WriteLine("Leaderboard:");
            foreach (var entry in leaderboard)
            {
                WriteLine($"{entry.namn}: {entry.tid.ToString(nfi)} sekunder");
            }
        }
    }
}
