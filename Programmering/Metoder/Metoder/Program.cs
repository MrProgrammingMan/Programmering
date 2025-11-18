using static System.Console;
namespace Metoder
{
    internal class Program
    {
        const float PI = 3.14159f;

        static void Main(string[] args)
        {
            // Uppgift 1

            /*
             ÖkaMotivation();
            */

            // Uppgift 2

            /*
            int tal = int.Parse(ReadLine());
            InfoOmTal(tal);
            */

            // Uppgift 3

            /*
            string rättLösenord = "HejPåDig123";
            string rättNamn = "SandMan";

            WriteLine("Skriv in ditt användarnamn:");
            string? namn = ReadLine();

            WriteLine("Skriv in ditt lösenord:");
            string? lösenord = ReadLine();

            WriteLine();
            LoggaIn(namn, lösenord, rättLösenord, rättNamn);
            */

            // Uppgift 4


            
            WriteLine("Hur många celsius är det ute?");

            float celsius = int.Parse(ReadLine());
            float fahrenheit = CelsiusTillFahrenheit(celsius);

            WriteLine($"Celsius: {celsius} -> Fahrenheit: {fahrenheit}");
            
        }

        static void ÖkaMotivation()
        {
            WriteLine("Bra jobbat!");
        }

        static void InfoOmTal(int tal)
        {
            if (tal > 0 )
            {
                WriteLine("Talet är positivt!");
            }
            else if (tal < 0)
            {
                WriteLine("Talet är negativt!");
            }
            else
            {
                WriteLine("Talet är noll.");
            }
        }

        static void LoggaIn(string namn, string lösenord, string rättLösenord, string rättNamn)
        {
            if (namn == rättNamn && lösenord == rättLösenord)
            {
                WriteLine($"Välkommen {namn}!");
            }
            else
            {
                WriteLine("Fel kontouppgifter!");
            }
        }
        
        static float CelsiusTillFahrenheit(float celsius)
        {
            float fahrenheit = celsius / 5.0f * 9 + 32;

            return fahrenheit;
        }
    }
}