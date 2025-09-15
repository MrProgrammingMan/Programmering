namespace Euler;
using static System.Console;
using System.Diagnostics;
internal class Program
{
    static void Main(string[] args)
    {
        Stopwatch clock = Stopwatch.StartNew();

        int sum = 0;

        for (int i = 1;  i < 1000; i++)
        {
            if (i % 3 == 0 || i % 5 == 0)
            {
                sum += i;
            }
        }
        WriteLine(sum);


        clock.Stop();
        WriteLine("Tid (ms): " + clock.Elapsed.TotalMilliseconds);
    }
}
