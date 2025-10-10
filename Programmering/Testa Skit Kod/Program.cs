using static System.Console;
namespace Övningsprov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float störstaTal = float.MinValue;
            float minstaTal = float.MaxValue;
            int sum = 0;

            while (true)
            {
                Write("Skirv in ett heltal (skriv 0 for att avsluta): ");
                float heltal = float.Parse(ReadLine());

                if (heltal != 0)
                {
                    Write("Vilket räknesätt vill du använda? (* / + eller -): ");
                    string räknesätt = ReadLine();

                    for (int i = 1; i <= 10; i++)
                    {
                        if (räknesätt == "*")
                        {
                            WriteLine($"{i}x{heltal} = {heltal * i}");

                            if (heltal * i < minstaTal)
                            {
                                minstaTal = heltal * i;
                            }
                            if (heltal * i > störstaTal)
                            {
                                störstaTal = heltal * i;
                            }
                        }
                        else if (räknesätt == "/")
                        {
                            WriteLine($"{heltal}/{i} = {MathF.Round(heltal / i, 2)}");

                            if (heltal / i < minstaTal)
                            {
                                minstaTal = MathF.Round(heltal / i, 2);
                            }
                            if (heltal / i > störstaTal)
                            {
                                störstaTal = heltal / i;
                            }
                        }
                        else if (räknesätt == "+")
                        {
                            WriteLine($"{heltal} + {i} = {heltal + i}");

                            if (heltal + i < minstaTal)
                            {
                                minstaTal = heltal + i;
                            }
                            if (heltal + i > störstaTal)
                            {
                                störstaTal = heltal + i;
                            }
                        }
                        else if (räknesätt == "-")
                        {
                            WriteLine($"{heltal} - {i} = {heltal - i}");

                            if (heltal - i < minstaTal)
                            {
                                minstaTal = heltal - i;
                            }
                            if (heltal - i > störstaTal)
                            {
                                störstaTal = heltal - i;
                            }
                        }
                    }
                }
                else
                {
                    WriteLine($"Största talet du fick var:{störstaTal}");
                    WriteLine($"Minsta talet du fick var:{minstaTal}");
                    break;
                }
            }
        }
    }
}