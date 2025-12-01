using System.Data.Common;
using static System.Console;
namespace Battleship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] player1Grid = new char[5, 5];
            char[,] player2Grid = new char[5, 5];
            char[,] p1Tracking = new char[5, 5];
            char[,] p2Tracking = new char[5, 5];

            InitiateGrids(player1Grid);
            InitiateGrids(player2Grid);
            InitiateGrids(p1Tracking);
            InitiateGrids(p2Tracking);

            WriteLine("Player 1 places their ships first, Player 2 has to look away");
            PlaceShips(player1Grid, "Player 1");
            WriteLine("Player 2 now places their ships and Player 1 looks away");
            PlaceShips(player2Grid, "Player 2");

            ShowGrid(player1Grid);
        }


        static void InitiateGrids(char[,] grid)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    grid[i, j] = '.';
                }
            }

        }
        static void PlaceShips(char[,] grid, string playerName)
        {
            for (int i = 0; i < 3; i++)
            {
                WriteLine($"Place ship number {i + 1}");

                int row, column;

                while (true)
                {
                    Write("Enter row (0-4): ");
                    row = int.Parse(ReadLine());

                    Write("Enter column (0-4): ");
                    column = int.Parse(ReadLine());

                    if (column >= 5 || column < 0 || row >= 5 || row < 0)
                    {
                        WriteLine("Invalid placement.");
                        continue;
                    }
                    break;
                }
                WriteLine();

                if (grid[row, column] == 'S')
                {
                    WriteLine("There's already a ship there! Try again.");
                    i--;
                    continue;
                }

                grid[row, column] = 'S';
            }
        }
        static void ShowGrid(char[,] grid)
        {
            Write("  ");
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                Write(col + " ");
            }
            WriteLine();

            for (int row = 0; row < grid.GetLength(0); row++)
            {
                Write(row + " ");
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    Write(grid[row, col] + " ");
                }
                WriteLine();
            }
        }
    }
}
