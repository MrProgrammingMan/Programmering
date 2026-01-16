using System.Diagnostics;
using System.Globalization;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Threading;
using static System.Console;
namespace Besöksdagen
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // C# använder systemets språk (svenska) som normalt har kommatecken för decimaler
            // Vi sätter därför engelsk ("en-US") formatering så att decimaler skrivs med punkt när "nfi" används
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;

            // skapar en variabel som sparar namnet på filen där poängen ska sparas
            string filePath = "scores.txt";

            // skapar två listor, en som är en string (text) och en som är en float (nummer som kan innehålla decimaler)
            List<string> namnLista = new List<string>();
            List<float> poäng = new List<float>();

            // kollar om filen redan existerar, om den gör det så läser den vad som står i filen
            if (File.Exists(filePath))
            {
                string[] linjer = File.ReadAllLines(filePath); // alla rader i filen sparas i en array, så vi kan komma åt varje rad med ett nummer

                // delar upp så vi bara får nummerna och inte namnen, då kan vi byta nummerna från ',' till '.' med "nfi"
                foreach (string linje in linjer)
                {
                    string[] delar = linje.Split(':');
                    if (delar.Length == 2)
                    {
                        namnLista.Add(delar[0]);

                        // försöker göra poängen till ett nummer, t.ex. "2.54" (string) -> 2.54 (float)
                        if (float.TryParse(delar[1].Trim(), NumberStyles.Float, nfi, out float score))
                        {
                            poäng.Add(score);
                        }
                        else
                        {
                            WriteLine("Hittade inte poäng"); // om något gick fel
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
                Thread.Sleep(3000);
            }
            */



            // skapar alla variablerna som borde vara UTANFÖR själva loopen
            Random rng = new Random();
            double nuvarandeFörsök = 0;
            double rekord = 0;


            // skapar loopen och kör detta tills while är 'false'
            while (true)
            {
            // Här börjar "Restart" används sedan för att kunna återvända här om man skriver in för tidigt
            Restart:

                // Clear rensar bara det som syns på skärmen, men "\x1b[3J" tar även bort det som ligger ovanför (scroll-historiken)
                Clear();
                Console.Write("\x1b[3J");

                // Denna 'metoden' som det kallas kör koden som är inuti den (finns om du skrollar längst ner)
                // då slipper man kopiera och klistra in kod på flera olika ställen och kan istället bara använda metoden
                VisaLeaderboard(namnLista, poäng, nfi);

                WriteLine();

                // WriteColour 'metoden' som gör det möjligt att lägga till färg OCH antalet radbrott man vill ha mellan texterna på en rad
                // färgen och antal radbrott ser man längst åt höger i koden på varje rad
                WriteColour("Välkommen till Reaktionspelet!", ConsoleColor.Yellow, 2);

                WriteColour("Instruktioner: Tryck på ENTER när du ser ordet 'NU'. Din tid kommer vara räknad i SEKUNDER.", ConsoleColor.Cyan, 2);

                WriteLine("För att starta tryck på ENTER knappen!");

                ReadLine();

                WriteColour("Vänta...", ConsoleColor.Blue, 2);

                while (KeyAvailable)
                {
                    ReadKey(true);
                }

                // Startar klockan och väntar en slumpmässig tid (1–5 sekunder som är då i millisekunder) innan "NU" visas
                Stopwatch väntaKlocka = Stopwatch.StartNew();
                int timer = rng.Next(1000, 5000);

                while (väntaKlocka.ElapsedMilliseconds < timer)
                {
                    if (KeyAvailable)
                    {
                        ReadKey(true);
                        WriteColour("För tidigt! Du får inte trycka ENTER innan NU!", ConsoleColor.DarkRed, 1);
                        Thread.Sleep(1000);
                        goto Restart;
                    }
                    Thread.Sleep(10);
                }

                WriteColour("NU", ConsoleColor.Red, 1);

                Stopwatch clock = Stopwatch.StartNew();

                while (true)
                {
                    SetCursorPosition(0, CursorTop);
                    Write($"Tid: {clock.ElapsedMilliseconds} ms");

                    if (KeyAvailable)
                    {
                        var key = ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                            break;
                    }

                    Thread.Sleep(10);
                }

                clock.Stop();
                WriteLine();

                WriteLine("Bra jobbat! Din tid blev:");
                WriteColour("Tid (s): " + Math.Round(clock.Elapsed.TotalSeconds, 3), ConsoleColor.Green, 2);

                nuvarandeFörsök = Math.Round(clock.Elapsed.TotalSeconds, 3);

                if (rekord == 0)
                {
                    rekord = Math.Round(clock.Elapsed.TotalSeconds, 3);
                }
                else if (nuvarandeFörsök < rekord)
                {
                    rekord = nuvarandeFörsök;
                    WriteLine("Nytt rekord!");
                }
                else if (nuvarandeFörsök == rekord)
                {
                    WriteLine("Wow du fick samma nummer som ditt rekord! Det är inte alltid det händer ;)");
                }

                // Låter användaren lägga in sitt resultat på leaderboarden om de vill
                WriteColour("Vill du lägga in ditt resultat på leaderboarden? tryck på [Y/N]", ConsoleColor.Yellow, 2);

                while (true)
                {
                    // Läser vilken tangent användaren trycker på och tar bara tecknet (KeyChar)
                    // Char.ToUpper gör bokstaven stor (t.ex. 'y' → 'Y') så vi slipper skilja på stora/små bokstäver för lättare programmering ;)
                    // (true) döljer tangenttrycket i konsolen
                    char input = Char.ToUpper(ReadKey(true).KeyChar);
                    if (input == 'Y')
                    {
                        while (true)
                        {
                            WriteColour("Skriv in ditt namn:", ConsoleColor.Cyan, 1);
                            string? namn = ReadLine();

                            // Kontrollerar om stringen "namn" inte innehåller något riktigt värde, alltså om det är 'null', tomt ("") eller bara mellanslag/tabbar
                            if (string.IsNullOrWhiteSpace(namn))
                            {
                                WriteColour("Du skrev inte in något namn! Försök igen.", ConsoleColor.DarkRed);
                                continue;
                            }

                            // Gör så att variabelen "namn" alltid börjar med stor bokstav
                            namn = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(namn.Trim().ToLower());

                            // sparar både namn och nummret i "resultat" genom att lägga de i en string
                            // exempel på hur stringen kan se ut: "Timmy:0.36"
                            string resultat = $"{namn}:{nuvarandeFörsök}";

                            // delar upp resultat i två delar: där split[0] = namn och split[1] = nuvarandeFörsök
                            // split[] betyder att vi har flera ord sparade i en lista (en array av strängar)
                            // varje ord har ett nummer, så man kan hämta dem genom t.ex split[0], split[1] osv
                            string[] split = resultat.Split(':');

                            // gör om split[1] = nuvarandeFörsök till en float som heter "num" som då håller ett nummer med decimaler (i detta fall är det tiden man fick)
                            float num = float.Parse(split[1]);

                            // Letar efter indexet för det namn som användaren skrev in i namnLista
                            // StringComparison.OrdinalIgnoreCase gör att jämförelsen inte bryr sig om stora eller små bokstäver
                            // Om namnet finns returneras dess index (0, 1, 2 osv.), annars returneras -1
                            int befintligtNamnIndex = namnLista.FindIndex(n => n.Equals(namn, StringComparison.OrdinalIgnoreCase));

                            bool listanÄndrad = false;

                            if (befintligtNamnIndex >= 0)
                            {
                                // personen finns redan — jämför mot gammalt värde utan att skriva över direkt
                                float oldScore = poäng[befintligtNamnIndex];
                                if (num < oldScore)
                                {
                                    poäng[befintligtNamnIndex] = num;
                                    listanÄndrad = true;
                                    WriteColour($"Namnet {namn} fanns redan i leaderboarden! Ditt gammla resultat har uppdateras: {oldScore.ToString(nfi)} -> {num.ToString(nfi)} sekunder", ConsoleColor.Green, 2);
                                }
                                else
                                {
                                    WriteColour("Du har redan ett bättre resultat!", ConsoleColor.DarkRed, 2);
                                }
                            }
                            else
                            {
                                namnLista.Add(namn);
                                poäng.Add(num);
                                listanÄndrad = true;
                                WriteColour("Ditt resultat har sparats!", ConsoleColor.Green, 2);
                            }

                            // skriv till filen EN gång, bara om listan har ändrats
                            if (listanÄndrad)
                            {
                                List<string> combined = new();
                                for (int i = 0; i < namnLista.Count; i++)
                                {
                                    combined.Add($"{namnLista[i]}:{poäng[i].ToString(nfi)}");
                                }
                                File.WriteAllLines("scores.txt", combined);
                            }
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
                WriteColour($"Vill du köra igen? Ditt rekord är just nu: {rekord} sekunder! [Y/N]", ConsoleColor.Yellow, 2);

                while (true)
                {
                    char key = Char.ToUpper(ReadKey(true).KeyChar);
                    if (key == 'Y')
                    {
                        WriteColour("Startar om...", ConsoleColor.DarkRed, 2);
                        Thread.Sleep(500);
                        break;
                    }
                    else if (key == 'N')
                    {
                        WriteColour("Nollställer poäng...", ConsoleColor.DarkRed, 2);
                        rekord = 0;
                        nuvarandeFörsök = 0;
                        Thread.Sleep(500);
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

        /// <summary>
        /// Skriver text med färg och radbrott
        /// </summary>
        /// <param name="text"></param>
        /// <param name="colour"></param>
        /// <param name="breaks"></param>
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

        /// <summary>
        /// Visar leaderboarden genom att kolla igenom filen där namnen är och sorterar dem
        /// </summary>
        /// <param name="namnLista"></param>
        /// <param name="poäng"></param>
        /// <param name="nfi"></param>
        static void VisaLeaderboard(List<string> namnLista, List<float> poäng, NumberFormatInfo nfi)
        {
            if (namnLista.Count == 0) // kolla om listan är tom 
            {
                WriteLine("Ingen poänglista hittades ännu, testa att köra en runda först.");
                return;
            }

            // Här sparar vi både namn och tid tillsammans i en lista
            List<(string namn, float tid)> leaderboard = new List<(string, float)>();
            for (int i = 0; i < namnLista.Count; i++)
            {
                leaderboard.Add((namnLista[i], poäng[i]));
            }

            // Sortera från snabbast till långsamast
            leaderboard.Sort((a, b) => a.tid.CompareTo(b.tid));

            // skriver ut den vackra leaderboarden :)
            WriteLine("Leaderboard:");
            for (int i = 0; i < leaderboard.Count; i++)
            {
                var entry = leaderboard[i];
                WriteLine($"{i + 1}. {entry.namn}: {entry.tid.ToString(nfi)} sekunder");
            }
        }
    }
}
