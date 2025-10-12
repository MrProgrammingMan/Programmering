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
        const int RAD_POÄNG = 4;
        static void Main(string[] args)
        {
            bool spela = true;
            Random rng = new();
            while (spela)
            {
                int nuvarandeKast = 0;
                List<int> tärningar = new();

                slåTärningar(ref tärningar, rng);

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
                    ettor.Clear();
                    tvår.Clear();
                    treor.Clear();
                    fyror.Clear();
                    femmor.Clear();
                    sexor.Clear();

                    for (int i = 0; i < ANTAL_TÄRNINGAR; i++)
                    {
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

                    rolling = rollaOm(ref tärningar, ref nuvarandeKast, rng);
                    spela = false;
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

        static void slåTärningar(ref List<int> tärningar, Random rng)
        {
            tärningar.Clear();
            for (int i = 0; i < ANTAL_TÄRNINGAR; i++)
            {
                tärningar.Add(rng.Next(1, 7));
            }
        }

        static bool rollaOm(ref List<int> tärningar, ref int nuvarandeKast, Random rng)
        {
            while (true)
            {
                if (nuvarandeKast >= MAX_KAST)
                {
                    WriteColour("Du har redan rollat 3 gånger, du behöver nu välja de nummerna du vill använda: 1, 2, 3, 4, 5, 6", ConsoleColor.Blue, 2);
                    WriteColour("WORK IN PROGRESS, INTE KLAR ÄN", ConsoleColor.Red);
                    nuvarandeKast = 0;
                    return false;
                }

                SetCursorPosition(0, RAD_INPUT);
                WriteColour("Vill du kasta om dina tärningar? Du får kasta om max 3 gånger. [Y/N]", ConsoleColor.Yellow, 1);
                char input = char.ToLower(ReadKey(true).KeyChar);
                WriteLine();

                if (input == 'y')
                {
                    nuvarandeKast++;
                    VäljTärningarAttRolla(ref tärningar, rng);
                    return true;
                }
                else if (input == 'n')
                {
                    WriteColour("Du valde att inte kasta om, välj vilka nummer du villa ha: 1, 2, 3, 4, 5, 6", ConsoleColor.Blue, 2);
                    WriteColour("WORK IN PROGRESS, INTE KLAR ÄN", ConsoleColor.Red);
                    nuvarandeKast = 0;
                    return false;
                }
                else
                {
                    WriteColour("Tryck på [Y/N]", ConsoleColor.Red, 1);
                }
            }
        }

        static void VäljTärningarAttRolla(ref List<int> tärningar, Random rng)
        {
            WriteColour("Skriv siffrorna 1-5 beroende på vilken av tärningarna du vill rolla om? (seperade med kommatecken t.ex 1,3,6)", ConsoleColor.Yellow, 2);
            WriteColour($"Nuvarande tärningar: ", ConsoleColor.Yellow);
            WriteColour($"{string.Join(", ", tärningar)}", ConsoleColor.Cyan, 1);

            while (true)
            {
                string input = ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    WriteColour("Du slog inte om några tärningar, kom ihåg det är t.ex 1,3,4", ConsoleColor.Red, 1);
                }

                string[] reroll = input.Split(',');
                List<string> ogiltigaVal = new List<string>();
                bool allaGiltiga = true;

                foreach (var die in reroll)
                {
                    if (int.TryParse(die, out int index) && index >= 1 && index <= ANTAL_TÄRNINGAR)
                    {
                        tärningar[index - 1] = rng.Next(1, 7);
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
