using static System.Console;
using System.Linq;
namespace Yatzy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool spela = true;
            while (spela)
            {
                int nuvarandeKast = 0;
                Random rng = new Random();
                List<int> tärningar = new();

                slåTärningar(ref tärningar, rng);

                int[] övreDelen = new int[6];
                List<int> ettor = new();
                List<int> tvår = new();
                List<int> treor = new();
                List<int> fyror = new();
                List<int> femmor = new();
                List<int> sexor = new();

                int tärningRadY = 2;
                int poängRadY = 4;
                string utskriftTop = String.Format("|{0,-6}|{1,-6}|{2,-6}|{3,-6}|{4,-6}|{5,-6}", "Ettor", "Tvår", "Treor", "Fyror", "Femmor", "Sexor");
                WriteLine(utskriftTop);
                WriteLine("-----------------------------------------");
                WriteLine("      |      |      |      |      |      ");
                WriteLine("-----------------------------------------");

                bool rulla = true;
                while (rulla)
                {
                    ettor.Clear();
                    tvår.Clear();
                    treor.Clear();
                    fyror.Clear();
                    femmor.Clear();
                    sexor.Clear();

                    for (int i = 0; i < tärningar.Count; i++)
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

                    string poäng = String.Format("|{0,-6}|{1,-6}|{2,-6}|{3,-6}|{4,-6}|{5,-6}", 1 * ettor.Count + "p", 2 * tvår.Count + "p", 3 * treor.Count + "p", 4 * fyror.Count + "p", 5 * femmor.Count + "p", 6 * sexor.Count + "p");

                    SetCursorPosition(0, tärningRadY);
                    Write(utskrift);
                    SetCursorPosition(0, poängRadY);
                    WriteLine(poäng);

                    rollaOm(ref tärningar, ref spela, rng, ref nuvarandeKast);
                }
            }
        }
        static void slåTärningar(ref List<int> tärningar, Random rng)
        {
            tärningar.Clear();
            for (int i = 0; i <= 5; i++)
            {
                tärningar.Add(rng.Next(1, 7));
            }
        }
        static void rollaOm(ref List<int> tärningar, ref bool spela, Random rng, ref int nuvarandeKast)
        {
            int maxKast = 2;

            while (true)
            {
                tärningar.Clear();
                WriteLine();
                WriteLine("Vill du kasta om dina tärningar? Du får kasta om max 2 gånger. [Y/N]");
                char input = char.ToLower(ReadKey().KeyChar);
                WriteLine("");

                if (input == 'y')
                {
                    if (nuvarandeKast < maxKast)
                    {
                        nuvarandeKast++;
                        WriteLine($"Kastar om...");
                        slåTärningar(ref tärningar, rng);
                        break;
                    }
                    else
                    {
                        WriteLine();
                        WriteLine("Du har redan rollat 2 gånger, du behöver nu välja de nummerna du vill använda: 1, 2, 3, 4, 5, 6");
                        nuvarandeKast = 0;
                        spela = false;
                        break;
                    }
                }

                else if (input == 'n')
                {
                    WriteLine("Du valde att inte kasta om, välj vilka nummer du villa ha.");
                    nuvarandeKast = 0;
                    break;
                }
                else
                {
                    WriteLine("Tryck på [Y/N]");
                }
            }
        }
    }
}
