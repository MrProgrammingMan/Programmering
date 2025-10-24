using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
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

                if (!tärningar.Any())
                    SlåTärningar(ref tärningar, ref låsta, rng);

                RitaPoängTabell(ref poängTabell);

                bool rolling = true;
                while (rolling)
                {
                    var grupper = new Dictionary<int, List<int>>()
                    {
                        { 1, new List<int>() },
                        { 2, new List<int>() },
                        { 3, new List<int>() },
                        { 4, new List<int>() },
                        { 5, new List<int>() },
                        { 6, new List<int>() }
                    };

                    for (int i = 0; i < ANTAL_TÄRNINGAR; i++)
                    {
                        if (!låsta[i])
                            grupper[tärningar[i]].Add(tärningar[i]);
                    }

                    string utskrift = $"|{string.Join(",", grupper[1]),-6}|{string.Join(",", grupper[2]),-6}|{string.Join(",", grupper[3]),-6}|{string.Join(",", grupper[4]),-6}|{string.Join(",", grupper[5]),-6}|{string.Join(",", grupper[6]),-6}|";
                    string poäng = $"|{1 * grupper[1].Count}p   |{2 * grupper[2].Count}p   |{3 * grupper[3].Count}p   |{4 * grupper[4].Count}p   |{5 * grupper[5].Count}p   |{6 * grupper[6].Count}p   |";

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
                WriteLine();
        }

        static void RitaPoängTabell(ref int[] poängTabell)
        {
            WriteLine("|Ettor |Tvåor |Treor |Fyror |Femmor|Sexor |");
            WriteLine("------------------------------------------");
            WriteLine();
            WriteLine("------------------------------------------");
        }

        static void SlåTärningar(ref List<int> tärningar, ref List<bool> låsta, Random rng)
        {
            for (int i = 0; i < ANTAL_TÄRNINGAR; i++)
            {
                if (tärningar.Count <= i)
                    tärningar.Add(rng.Next(1, 7));
                else if (!låsta[i])
                    tärningar[i] = rng.Next(1, 7);
            }
        }

        static void LåsaNummer(ref int nuvarandeRunda, ref List<int> tärningar, ref int antalLåsta, ref List<bool> låsta, Random rng, int nuvarandeKast, ref int[] poängTabell)
        {
            if (nuvarandeRunda >= ANTAL_RUNDOR)
                return;

            WriteColour("Välj ett nummer mellan 1-6 för att låsa (t.ex 1 låser alla ettor)", ConsoleColor.Blue, 1);
            string val = ReadLine();

            if (int.TryParse(val, out int nummer) && nummer >= 1 && nummer <= 6)
            {
                antalLåsta = 0;
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
            WriteColour("Vilka tärningar vill du kasta om? (1-6, kommaseparerade)", ConsoleColor.Yellow, 1);
            WriteColour($"Nuvarande tärningar: {string.Join(", ", tärningar)}\n", ConsoleColor.Cyan);

            while (true)
            {
                string input = ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    WriteColour("Inga tärningar valda, försök igen.", ConsoleColor.Red, 1);
                    continue;
                }

                var valdaIndex = new List<int>();
                var ogiltigaVal = new List<string>();

                foreach (var s in input.Split(','))
                {
                    if (int.TryParse(s.Trim(), out int idx) && idx >= 1 && idx <= tärningar.Count)
                    {
                        int listIndex = idx - 1; // korrekt 0-index
                        if (!låsta[listIndex])
                            valdaIndex.Add(listIndex);
                        else
                            WriteColour($"Tärning {idx} är låst och kan inte slås om.\n", ConsoleColor.Red);
                    }
                    else
                    {
                        ogiltigaVal.Add(s);
                    }
                }

                if (ogiltigaVal.Count > 0)
                {
                    WriteColour($"Ogiltiga val: {string.Join(", ", ogiltigaVal)}\n", ConsoleColor.Red);
                    continue;
                }

                if (valdaIndex.Count == 0)
                {
                    WriteColour("Inga giltiga tärningar att kasta om.\n", ConsoleColor.Red);
                    continue;
                }

                // Slå om endast icke-låsta tärningar
                foreach (var i in valdaIndex)
                {
                    tärningar[i] = rng.Next(1, 7);
                }

                break;
            }

            WriteColour($"Nya tärningar: {string.Join(", ", tärningar)}\n", ConsoleColor.Cyan);
            Thread.Sleep(500);
        }


        static void VisaNyaTärningar(ref int[] poängTabell)
        {
            Clear();
            RitaPoängTabell(ref poängTabell);
        }
    }
}
