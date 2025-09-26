namespace Euler;
using static System.Console;
using System.Diagnostics;
internal class Program
{
    static void Main(string[] args)
    {
        Stopwatch clock = Stopwatch.StartNew();

        int sum = 0;
        int a = 1;
        for (int i = 1; i < 10; i++)
        {
            if (a / a - i != 1)
            {
                sum += a;
                WriteLine(sum);
            }
            a++;
        }


        clock.Stop();
        WriteLine("Tid (ms): " + clock.Elapsed.TotalMilliseconds);
    }
}
