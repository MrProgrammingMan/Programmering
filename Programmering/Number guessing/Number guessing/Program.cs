using static System.Console;
namespace Number_guessing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int currentNumber = 0;
            int min = 1;
            int max = 101;
            Random rng = new Random();


            currentNumber = rng.Next(min, max);

            while(true)
            {
                WriteLine("Enter a number between 1-100.");

                int input = int.Parse(ReadLine());

                    if (input < currentNumber)
                    {
                        WriteLine("Bigger");
                    }
                    else if (input > currentNumber)
                    {
                        WriteLine("Smaller");
                    }

                if (input == currentNumber)
                {
                    WriteLine("You got it!");
                }
            }
        }
    }
}
