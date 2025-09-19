using static System.Console;
namespace KortLek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string showName = "";
            int[] Hearts = new int[13];
            int[] Diamonds = new int[13];
            int[] Spades = new int[13];
            int[] Clover = new int[13];

            WriteLine("====== Creating Cards ======");
            DrawCards(ref Hearts, ref Diamonds, ref Spades, ref Clover);
        }
        static void DrawCards(ref int[] Hearts, ref int[] Diamonds, ref int[] Spades, ref int[] Clover)
        {
            for (int i = 0; i < 13; i++)
            {
                Hearts[i] += i + 1;
                Diamonds[i] += i + 1;
                Spades[i] += i + 1;
                Clover[i] += i + 1;
            }
        }
    }
}
