using static System.Console;
using System.Linq;
using System.Xml.Linq;
namespace Övningsprov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Namn;
            bool frånvarande;
            List<string> elevNamn = new List<string>();
            List<bool> närvaroLista = new List<bool>();

            WriteLine("Skriv in dena elevnamn! Om du vill skriva ut listan skriv 'avsluta'");

            while (true)
            {
                Namn = LäggTillElever();
                if (Namn == "avsluta")
                {
                    break;
                }
                else
                {
                    elevNamn.Add(Namn);
                }
                frånvarande = RegistreraNärvaro(närvaroLista, elevNamn);
                närvaroLista.Add(frånvarande);
            }
            SkrivUtEleverOchNärvaro(elevNamn, närvaroLista);
            WriteLine();
            SkrivUtFrånvarnande(närvaroLista);
            SkrivUtNärvarande(närvaroLista);

            SökElev(elevNamn, närvaroLista);
        }

        static string LäggTillElever()
        {
            while (true)
            {
                WriteLine();
                Write("Skriv in ett elevnamn: ");
                string input = ReadLine();
                if (input == "")
                {
                    WriteLine("Du skriv inte in något namn!");
                    continue;
                }
                return input;
            }
        }
        static void SkrivUtEleverOchNärvaro(List<string> elevNamn, List<bool> närvaroLista)
        {
            WriteLine("Elevlista:");
            for (int i = 0; i < elevNamn.Count; i++)
            {
                WriteLine($"Elev {i + 1}: {elevNamn[i]}. Frånvarande?: {närvaroLista[i]}");
            }
        }
        static bool RegistreraNärvaro(List<bool> närvaroLista, List<string> elevNamn)
        {
            bool frånvarande;
            WriteLine("Är eleven frånvarande? [j/n]");
            while (true)
            {
                char key = ReadKey(true).KeyChar;
                if (key == 'j')
                {
                    frånvarande = true;
                    return frånvarande;
                }
                else if (key == 'n')
                {
                    frånvarande = false;
                    return frånvarande;
                }
                else
                {
                    WriteLine("Tryck på J eller N");
                    continue;
                }
            }
        }
        static void SkrivUtNärvarande(List <bool> närvaroLista)
        {
            WriteLine("Närvaro lista:");
            int närvarande = 0;

            for (int i = 0; i < närvaroLista.Count; i++)
            {
                if (närvaroLista[i] == false)
                {
                    närvarande++;
                }
            }
            WriteLine($"Antal närvarande elever: {närvarande}");
        }
        static void SkrivUtFrånvarnande(List<bool> närvaroLista)
        {
            WriteLine("Frånvaro lista:");
            int frånvarande = 0;

            for (int i = 0; i < närvaroLista.Count; i++)
            {
                if (närvaroLista[i] == true)
                {
                    frånvarande++;
                }
            }
            WriteLine($"Antal frånvarande elever: {frånvarande}");
        }

        static void SökElev(List<string> elevNamn, List<bool> närvaroLista)
        {
            WriteLine();
            WriteLine("Vill du söka efter en elev? [j/n]");
            while (true)
            {
                char key = ReadKey(true).KeyChar;
                if (key == 'j')
                {
                    Write("Skriv in ett namn: ");
                    string sök = ReadLine();
                    string resultat = "";
                    for (int i = 0; i < elevNamn.Count; i++)
                    {
                        if (elevNamn[i].Contains(sök))
                        {
                            resultat = elevNamn[i];
                            Write($"Hittade namnet: {resultat}. Hen är: ");

                            if (närvaroLista[i] == true)
                            {
                                Write("frånvarande.");
                            }
                            else
                            {
                                Write("här.");
                            }

                        }
                    }
                }
                else if (key == 'n')
                {
                    return;
                }
                else
                {
                    WriteLine("Ogiltig tangentknapp, tryck på J eller N");
                }
            }
        }
    }
}
