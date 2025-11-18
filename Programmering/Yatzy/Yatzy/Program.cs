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
            int[] poängTabell = new int[6];


            while (spela)
            {
                låsta = Enumerable.Repeat(false, ANTAL_TÄRNINGAR).ToList();

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

                RitaPoängTabell(ref poängTabell);

                bool rolling = true;
                while (rolling)
                {
                    ettor.Clear();
                    tvår.Clear();
                    treor.Clear();
                    fyror.Clear();
                    femmor.Clear();
                    sexor.Clear();

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


                    string utskrift = String.Format("|{0,-6}|{1,-6}|{2,-6}|{3,-6}|{4,-6}|{5,-6}|",
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

                    rolling = RollaOm(ref tärningar, ref nuvarandeKast, rng, ref antalLåsta, ref nuvarandeRunda, ref låsta, ref poängTabell);
                    VisaNyaTärningar(ref poängTabell);
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

        static void RitaPoängTabell(ref int[] poängTabell)
        {
            WriteLine($"|Ettor |Tvåor |Treor |Fyror |Femmor|Sexor |");
            WriteLine("------------------------------------------");
            WriteLine();
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


        static void LåsaNummer(ref int nuvarandeRunda, ref List<int> tärningar, ref int antalLåsta, ref List<bool> låsta, Random rng, int nuvarandeKast, ref int[] poängTabell)
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
                        int poängFörDennaKategori = nummer * antalLåsta;
                        poängTabell[nummer - 1] = poängFörDennaKategori;

                        WriteColour($"Du fick {poängFörDennaKategori} poäng på {nummer}:or", ConsoleColor.Green, 2);

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
            VisaNyaTärningar(ref poängTabell);
        }


        static bool RollaOm(ref List<int> tärningar, ref int nuvarandeKast, Random rng, ref int antalLåsta, ref int nuvarandeRunda, ref List<bool> låsta, ref int[] poängTabell)
        {
            while (true)
            {
                if (nuvarandeKast >= MAX_KAST)
                {
                    nuvarandeKast = 0;
                    LåsaNummer(ref nuvarandeRunda, ref tärningar, ref antalLåsta, ref låsta, rng, nuvarandeKast, ref poängTabell);
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
                    VäljTärningarAttRolla(ref tärningar, ref låsta, rng, ref poängTabell);
                    return true;
                }
                else if (input == 'n')
                {
                    nuvarandeKast = 0;
                    LåsaNummer(ref nuvarandeRunda, ref tärningar, ref antalLåsta, ref låsta, rng, nuvarandeKast, ref poängTabell);
                    return false;
                }
                else
                {
                    WriteColour("Tryck på [Y/N]", ConsoleColor.Red, 1);
                }
            }
        }

        static void VäljTärningarAttRolla(ref List<int> tärningar, ref List<bool> låsta, Random rng, ref int[] poängTabell)
        {
            WriteColour("Skriv siffrorna 1-6 beroende på vilken av tärningarna du vill kasta om? (separerade med kommatecken t.ex 1,3,6)", ConsoleColor.Yellow, 2);
            WriteColour($"Nuvarande tärningar: ", ConsoleColor.Yellow);
            WriteColour($"{string.Join(", ", tärningar)}", ConsoleColor.Cyan, 1);

            while (true)
            {
                string input = ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    WriteColour("Du kastade inte om några tärningar, kom ihåg att skriva t.ex 1,3,4", ConsoleColor.Red, 1);
                    continue;
                }

                var giltigaTärningar = new List<int>();
                var ogiltigaVal = new List<string>();

                foreach (var die in input.Split(','))
                {
                    if (int.TryParse(die.Trim(), out int index) && index >= 1 && index <= ANTAL_TÄRNINGAR)
                    {
                        if (låsta[index - 1])
                        {
                            WriteColour($"Tärning {index} är låst och kan inte kastas om.", ConsoleColor.Red, 1);
                        }
                        else
                        {
                            giltigaTärningar.Add(index - 1);
                        }
                    }
                    else
                    {
                        ogiltigaVal.Add(die);
                    }
                }

                if (ogiltigaVal.Count > 0)
                {
                    WriteColour($"Ogiltiga val: {string.Join(", ", ogiltigaVal)}", ConsoleColor.Red, 2);
                    continue;
                }

                if (giltigaTärningar.Count == 0)
                {
                    WriteColour("Inga giltiga tärningar att kasta om.", ConsoleColor.Red, 1);
                    continue;
                }

                foreach (var die in giltigaTärningar)
                {
                    tärningar[die] = rng.Next(1, 7);
                }

                break;
            }

            WriteColour("Nya tärningar: ", ConsoleColor.Yellow);
            Thread.Sleep(500);
            WriteColour(string.Join(", ", tärningar), ConsoleColor.Cyan, 2);
            WriteColour("Uppdaterar tabell...", ConsoleColor.Red);
            Thread.Sleep(3000);
        }


        static void VisaNyaTärningar(ref int[] poängTabell)
        {
            Clear();
            RitaPoängTabell(ref poängTabell);
        }
    }
}