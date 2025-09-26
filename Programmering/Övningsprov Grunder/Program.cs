using static System.Console;
namespace Övningsprov_Grunder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float a = 0;
            while (true)
            {
                Write("Skriv in ett heltal (skriv 0 för att avsluta): ");
                Exit(ref a);
                Write("Vilket räknesätt vill du använda? (* / + eller -): ");

                string räknesätt = ReadLine();
                if (räknesätt == "*")
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        WriteLine($"{a}x{i} = {a * i}");
                    }
                }
                else if (räknesätt == "/")
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        WriteLine($"{a}/{i} = {MathF.Round(a / i, 2)}");
                    }
                }
                else if (räknesätt == "+")
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        WriteLine($"{a}+{i} = {a + i}");
                    }
                }
                else if (räknesätt == "-")
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        WriteLine($"{a}-{i} = {a - i}");
                    }
                }
                WriteLine("");
            }
        }
        static void Exit(ref float a)
        {
            string Input = ReadLine();
            if (Input == "0")
            {
                Environment.Exit(0);
            }
            else
            {
                a = int.Parse(Input);
            }
        }
    }
}
