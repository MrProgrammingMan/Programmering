using System.Threading;
using System.Diagnostics;
using static System.Console;
namespace Besöksdagen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            double nuvarandeFörsök = 0;
            double rekord = 0;

            while (true)
            {
            Restart:
                WriteColour("Välkommen till Reaktionspelet!", ConsoleColor.Yellow, 2);

                WriteColour("Instruktioner: Tryck på ENTER när du ser ordet NU. Du kommer få en tid på hur snabb du var på att trycka den i SEKUNDER.", ConsoleColor.Cyan, 2);

                WriteLine("För att starta tryck på ENTER");

                ReadLine();

                WriteColour("Vänta...", ConsoleColor.Blue, 2);
                int timer = rng.Next(1000, 5000); 
                int waited = 0;

                while (waited < timer)
                {
                    if (Console.KeyAvailable)
                    {
                        ReadKey(true);
                        WriteColour("För tidigt! Du får inte trycka ENTER innan NU!", ConsoleColor.Red, 1);
                        Thread.Sleep(1000);
                        Clear();
                        goto Restart;
                    }

                    Thread.Sleep(10);
                    waited += 10;
                }

                WriteColour("NU", ConsoleColor.Red, 2);

                Stopwatch clock = Stopwatch.StartNew();

                ReadLine();

                clock.Stop();

                WriteLine("Bra jobbat! Din tid blev:");
                WriteColour("Tid (s): " + Math.Round(clock.Elapsed.TotalSeconds, 2), ConsoleColor.Green, 1);

                nuvarandeFörsök = Math.Round(clock.Elapsed.TotalSeconds, 2);

                if (rekord == 0)
                {
                    rekord = Math.Round(clock.Elapsed.TotalSeconds, 2);
                }
                else if (nuvarandeFörsök < rekord)
                {
                    rekord = nuvarandeFörsök;
                    WriteLine("Nytt rekord!");
                }
                else if (nuvarandeFörsök == rekord)
                {
                    WriteLine("Wow du fick samma nummer igen! Det är inte alltid det händer ;)");
                }

                WriteColour($"Vill du köra igen? Ditt rekord är: {rekord} [Y/N]", ConsoleColor.Yellow, 2);
                
                while (true)
                {
                    char input = Char.ToUpper(ReadKey(true).KeyChar);
                    if (input == 'Y')
                    {
                        Clear();
                        WriteColour("Startar om...", ConsoleColor.Red, 2);
                        Thread.Sleep(200);
                        break;
                    }
                    else if (input == 'N')
                    {
                        WriteColour("Stänger programmet...", ConsoleColor.Red);
                        return;
                    }
                    else
                    {
                        WriteColour("Tryck på Y eller N", ConsoleColor.Red, 2);
                        continue;
                    }
                }
                continue;
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
    }
}
