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
                Write("Skriv in ett tal (skriv 0 för att avsluta): ");
                Exit(ref a);
                Write("Vilket räknesätt vill du använda? (* / + eller -): ");

                Calculate(ref a);
                WriteLine("");
            }
        }

        static void Exit(ref float a)
        {
            string input = ReadLine();
            if (input == "0")
            {
                Environment.Exit(0);
            }
            else
            {
                a = float.Parse(input);
            }
        }
        static void Calculate(ref float a)
        {
            float sum = 0;
            string räknesätt = ReadLine();
            for (int i = 1; i <= 10; i++)
            {
                if (räknesätt == "*")
                {
                    sum = a * i;
                }
                else if (räknesätt == "/")
                {
                    sum = a / i;
                }
                else if (räknesätt == "+")
                {
                    sum = a + i;
                }
                else if (räknesätt == "-")
                {
                    sum = a - i;
                }
                WriteLine($"{a}{räknesätt}{i} = {sum}");
            }
        }
    }
}