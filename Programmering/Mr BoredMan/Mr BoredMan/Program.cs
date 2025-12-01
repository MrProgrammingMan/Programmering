namespace Mr_BoredMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] frames = { "(O_O)", "(o_o)", "(-_-)", "(o_o)", "(O_O)", "(^_^)", "(o_o)" };

            while (true)
            {
                foreach (string i in frames)
                {
                    Console.Clear();
                    Console.WriteLine(i);
                    Thread.Sleep(500);
                }
            }
        }
    }
}
