using System.Linq;
using static System.Console;
namespace Yatzy
{
    internal class Program
    {
        const int ANTAL_TÄRNINGAR = 6;
        const int MAX_KAST = 3;
        const int RAD_INPUT = 6;
        const int RAD_TÄRNINGAR = 2;
        const int ANTAL_RUNDOR = 6;
        const int RAD_POÄNG = 4;
        static void Main(string[] args)
        {
            bool spela = true;
            Random rng = new();
            int nuvarandeKast = 0;
            int nuvarandeRunda = 0;
            int antalLåsta = 0;
            List<int> tärningar = new();
            List<bool> låsta = new();

            for (int i = 0; i < ANTAL_TÄRNINGAR; i++)
            {
                låsta.Add(false);
            }

            while (spela)
            {
                if (tärningar.Count == 0)
                {
                    SlåTärningar(ref tärningar, ref låsta, rng);
                }

                int[] övreDelen = new int[6];
                List<int> ettor = new();
                List<int> tvår = new();
                List<int> treor = new();
                List<int> fyror = new();
                List<int> femmor = new();
                List<int> sexor = new();

                RitaPoängTabell();

                bool rolling = true;
                while (rolling)
                {

                    for (int i = 0; i < ANTAL_TÄRNINGAR; i++)
                    {
                        if (låsta[i])
                        {
                            continue;
                        }

                        switch (tärningar[i])
                        {
                            case 1:
                                ettor.Add(tärningar[i]);
                                break;
                            case 2:
                                tvår.Add(tärningar[i]);
                                break;
                            case 3:
                                treor.Add(tärningar[i]);
                                break;
                            case 4:
                                fyror.Add(tärningar[i]);
                                break;
                            case 5:
                                femmor.Add(tärningar[i]);
                                break;
                            case 6:
                                sexor.Add(tärningar[i]);
                                break;
                        }
                    }


                    string utskrift = String.Format("|{0,-6}|{1,-6}|{2,-6}|{3,-6}|{4,-6}|{5,-6}",
                    string.Join(",", ettor),
                    string.Join(",", tvår),
                    string.Join(",", treor),
                    string.Join(",", fyror),
                    string.Join(",", femmor),
                    string.Join(",", sexor));

                    string poäng = String.Format("|{0,-6}|{1,-6}|{2,-6}|{3,-6}|{4,-6}|{5,-6}|", 1 * ettor.Count + "p", 2 * tvår.Count + "p", 3 * treor.Count + "p", 4 * fyror.Count + "p", 5 * femmor.Count + "p", 6 * sexor.Count + "p");

                    SetCursorPosition(0, RAD_TÄRNINGAR);
                    Write(utskrift);
                    SetCursorPosition(0, RAD_POÄNG);
                    WriteLine(poäng);

                    rolling = RollaOm(ref tärningar, ref nuvarandeKast, rng, ref antalLåsta, ref nuvarandeRunda, ref låsta);
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

        static void RitaPoängTabell()
        {
            WriteLine("|Ettor |Tvåor |Treor |Fyror |Femmor|Sexor |");
            WriteLine("------------------------------------------");
            WriteLine("|      |      |      |      |      |      |");
            WriteLine("------------------------------------------");
        }

        static void SlåTärningar(ref List<int> tärningar, ref List<bool> låsta, Random rng)
        {
            for (int i = 0; i < ANTAL_TÄRNINGAR; i++)
            {
                if (tärningar.Count <= i)
                {
                    tärningar.Add(rng.Next(1, 7));
                }
                else if (!låsta[i])
                {
                    tärningar[i] = rng.Next(1, 7);
                }
            }
        }


        static void LåsaNummer(ref int nuvarandeRunda, ref List<int> tärningar, ref int antalLåsta, ref List<bool> låsta, Random rng, int nuvarandeKast)
        {
            if (nuvarandeRunda <= ANTAL_RUNDOR)
            {
                WriteColour("Välj ett nummer mellan 1-6 för att låsa (t.ex 1 låser alla ettor)", ConsoleColor.Blue, 1);
                string val = ReadLine();

                if (int.TryParse(val, out int nummer) && nummer >= 1 && nummer <= 6)
                {

                    for (int i = 0; i < ANTAL_TÄRNINGAR; i++)
                    {
                        if (tärningar[i] == nummer && !låsta[i])
                        {
                            låsta[i] = true;
                            antalLåsta++;
                        }
                    }

                    if (antalLåsta > 0)
                    {
                        WriteColour($"Låser {antalLåsta} stycken tärningar med nummer {nummer}...", ConsoleColor.Red, 2);
                        nuvarandeRunda++;
                        Thread.Sleep(3000);
                    }
                    else
                    {
                        WriteColour($"Inga tärningar med nummer {nummer} att låsa, eller så är de redan låsta.", ConsoleColor.Yellow, 2);
                    }
                }
                else
                {
                    WriteColour("Du måste skriva in ett nummer mellan 1-6 för att låsa dem", ConsoleColor.Red, 1);
                }
            }
            SlåTärningar(ref tärningar, ref låsta, rng);
            VisaNyaTärningar();
            nuvarandeKast = 0;
            antalLåsta = 0;

        }


        static bool RollaOm(ref List<int> tärningar, ref int nuvarandeKast, Random rng, ref int antalLåsta, ref int nuvarandeRunda, ref List<bool> låsta)
        {
            while (true)
            {
                if (nuvarandeKast >= MAX_KAST)
                {
                    nuvarandeKast = 0;
                    LåsaNummer(ref nuvarandeRunda, ref tärningar, ref antalLåsta, ref låsta, rng, nuvarandeKast);
                    return false;
                }

                SetCursorPosition(0, RAD_INPUT);
                WriteColour($"Runda {nuvarandeRunda}", ConsoleColor.Green, 1);
                WriteColour($"Vill du kasta om dina tärningar? Du får kasta om {MAX_KAST - nuvarandeKast} gånger till. [Y/N]", ConsoleColor.Yellow, 1);
                char input = char.ToLower(ReadKey(true).KeyChar);
                WriteLine();

                if (input == 'y')
                {
                    nuvarandeKast++;
                    VäljTärningarAttRolla(ref tärningar, ref låsta, rng);
                    return true;
                }
                else if (input == 'n')
                {
                    nuvarandeKast = 0;
                    LåsaNummer(ref nuvarandeRunda, ref tärningar, ref antalLåsta, ref låsta, rng, nuvarandeKast);
                    return false;
                }
                else
                {
                    WriteColour("Tryck på [Y/N]", ConsoleColor.Red, 1);
                }
            }
        }

        static void VäljTärningarAttRolla(ref List<int> tärningar, ref List<bool> låsta, Random rng)
        {
            WriteColour("Skriv siffrorna 1-6 beroende på vilken av tärningarna du vill rolla om? (separerade med kommatecken t.ex 1,3,6)", ConsoleColor.Yellow, 2);
            WriteColour($"Nuvarande tärningar: ", ConsoleColor.Yellow);
            WriteColour($"{string.Join(", ", tärningar)}", ConsoleColor.Cyan, 1);

            while (true)
            {
                string input = ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    WriteColour("Du slog inte om några tärningar, kom ihåg det är t.ex 1,3,4", ConsoleColor.Red, 1);
                    continue; 
                }

                string[] reroll = input.Split(',');
                List<string> ogiltigaVal = new List<string>();
                bool allaGiltiga = true;

                foreach (var die in reroll)
                {
                    if (int.TryParse(die.Trim(), out int index) && index >= 1 && index <= ANTAL_TÄRNINGAR)
                    {
                        if (!låsta[index - 1])
                        {
                            tärningar[index - 1] = rng.Next(1, 7);
                        }
                        else
                        {
                            WriteColour($"Tärning {index} är låst och kan inte kastas om.", ConsoleColor.Red, 1);
                        }
                    }
                    else
                    {
                        ogiltigaVal.Add(die);
                        allaGiltiga = false;
                    }
                }

                if (ogiltigaVal.Count > 0)
                {
                    WriteColour($"Ogiltiga val: {string.Join(", ", ogiltigaVal)}", ConsoleColor.Red, 2);
                }

                if (allaGiltiga)
                {
                    break;
                }
                else
                {
                    WriteColour("Du måste skriva nummer mellan 1-6.", ConsoleColor.Red, 1);
                }
            }

            WriteColour("Nya tärningar: ", ConsoleColor.Yellow);
            Thread.Sleep(500);
            WriteColour(string.Join(", ", tärningar), ConsoleColor.Cyan, 2);
            WriteColour("Uppdaterar tabell...", ConsoleColor.Red);
            Thread.Sleep(3000);
            VisaNyaTärningar();
        }

        static void VisaNyaTärningar()
        {
            Clear();
            RitaPoängTabell();
        }
    }
}