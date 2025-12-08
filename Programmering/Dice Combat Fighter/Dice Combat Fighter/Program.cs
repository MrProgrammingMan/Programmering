using static System.Console;
namespace Dice_Combat_Fighter
{
    public class Monster
    {
        public int HP { get; set; }
        public int Attack { get; set; }
    }

    public class Player
    {
        public int HP { get; set; }
        public int Attack { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Write("hur många kast och sidor vill du? (t.ex 3T6 eller 5T20): ");
                string tärningOchKast = ReadLine().ToLower();
                string[] split = tärningOchKast.Split('t');
                int antalSidor = int.Parse(split[1]);
                int antalkast = int.Parse(split[0]);
                int resultat = 0;
                int poäng = KastaTärning(antalkast, resultat, antalSidor);
                Console.WriteLine(poäng + "p");
            }
        }
        static int KastaTärning(int antalkast, int resultat, int tärningsSida)
        {
            Random rng = new Random();
            for (int i = 0; i < antalkast; i++)
            {
                int slumpkast = rng.Next(1, tärningsSida + 1);
                resultat = resultat + slumpkast;
                Console.WriteLine($"{i}) totalt fick du: {resultat} poäng");
                Thread.Sleep(120);

            }
            return resultat;

        }
    }
}