using static System.Console;
using System.Linq;
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

            /*
            WriteLine("Hur många celsius är det ute?");

            double celsius = double.Parse(ReadLine());
            double fahrenheit = CelsiusTillFahrenheit(celsius);

            WriteLine($"Celsius: {celsius} -> Fahrenheit: {fahrenheit}");
            */

            /*
            int myNum1 = Add(3, 5);
            double myNum2 = Add(6.7, 4.2);
            float myNum3 = Add(8.214321f, 7.32319804f);
            WriteLine($"Sum of two ints: {myNum1}");
            WriteLine($"Sum of two doubles: {myNum2}");
            WriteLine($"Sum of two floats: {myNum3}");
            */

            Write("Skriv in antalet element du vill ha i din array: ");
            int arrayLängd = int.Parse(ReadLine());
            int[] element = new int[arrayLängd];
            WriteLine($"Skriv in {arrayLängd} nummer:");

            for (int i = 0; i < arrayLängd; i++)
            {
                Write($"Element {i + 1}: ");
                element[i] = int.Parse(ReadLine());
            }

            int minsta = element.Min();
            int största = element.Max();


            WriteLine();
            WriteLine($"Det största värdet är: {största}");
            WriteLine($"Det minsta värdet är: {minsta}");
        }
        /// <summary>
        ///  :3 adderar :3
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int Add(int a, int b)
        {
            return a + b;
        }
        /// <summary>
        /// Float med mer decimaler
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static double Add (double a, double b)
        {
            return a + b;
        }
        /// <summary>
        /// double med mindre decimaler
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static float Add(float a, float b)
        {
            return a + b;
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
        
        static double CelsiusTillFahrenheit(double celsius)
        {
            double fahrenheit = celsius / 5.0f * 9 + 32;

            return fahrenheit;
        }
    }
}