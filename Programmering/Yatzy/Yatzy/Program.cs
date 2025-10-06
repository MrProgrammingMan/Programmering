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
            List<int> ettor = new();
            List<int> tvår = new();
            List<int> treor = new();
            List<int> fyror = new();
            List<int> femmor = new();
            List<int> sexor = new();
        }
    }
}