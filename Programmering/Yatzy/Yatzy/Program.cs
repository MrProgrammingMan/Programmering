using static System.Console;
using System.Linq;
namespace Yatzy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            List<int> tärningar = new();
            for(int i = 0; i < 5; i++)
            {
                tärningar.Add(rng.Next(0, 10));
            }
            for (int i = tärningar.Count - 1; i >= 0; i--)
            {
                if (tärningar.Contains(1))
                {
                    tärningar.Remove(i);
                }
                WriteLine(tärningar[i]);
            }
        }
    }
}