using static System.Console;
namespace Arrays_and_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            string[] dagar = new string[7];
            dagar = ["Måndag", "Tisdag", "Onsdag", "Torsdag", "Fredag", "Lördag", "Söndag"];

            for (int i = 0; i < dagar.Length; i++)
            {
                WriteLine(dagar[i]);
            }
            */

            string[] namn = new string[5];
            int[] ålder = new int[5];

            WriteLine("Insruktion: Skriv in 5 namn och en ålder till varje person.");
            WriteLine();

            for (int i = 0; i < namn.Length; i++)
            {
                WriteLine($"Du kan skriva in personer {10 - namn.Length - i} gånger till.");

                WriteLine($"Skriv in namnet till person {i + 1}");
                string? input = ReadLine();

                namn[i] = input;

                WriteLine("Hur gammal är hen?");

                int nummerInput = int.Parse(ReadLine());

                ålder[i] = nummerInput;
                WriteLine();
            }

            WriteLine();

            for (int i = 0; i < namn.Length; i++)
            {
                Write($"Kundnummer {i + 1}:");
                Write($" {namn[i]},");
                WriteLine($" {ålder[i]} år");
            }
        }
    }
}
