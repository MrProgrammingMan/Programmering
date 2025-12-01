using System.Text;
using static System.Console;
namespace Password_Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Hello and welcome to the password generator!");
            WriteLine();

            WriteLine("How many characters do you want to use?");
            int length = int.Parse(ReadLine());

            string password = GeneratePassword(length);
            WriteLine($"Generated password: {password}");
        }

        /// <summary>
        /// Generates a string with random characters with the length of what the number is that the user input.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        static string GeneratePassword(int length)
        {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=<>?";
            StringBuilder result = new StringBuilder();
            Random rand = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rand.Next(chars.Length);
                result.Append(chars[index]);
            }

            return result.ToString();
        }
    }
}
