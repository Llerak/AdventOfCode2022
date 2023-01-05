using System.Diagnostics;

namespace D8;

class Program
{
    public static void Main()
    {
        Stopwatch time = new Stopwatch();
        time.Start();
        string[] input = File.ReadAllText("../../../data/input.txt").Split("\r\n");

        int[,] map = new int[input.Length, input[0].Length];


        int up = 0;
        int right = 0;
        int down = 0;
        int left = 0;

        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < input[0].Length; j++)
            {
                map[i, j] = input[i][j] - 48;
            }
        }

        int count = (map.GetLength(0) + map.GetLength(1) - 2) * 2;
        int partiture = 0;

        for (int i = 1; i < map.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < map.GetLength(1) - 1; j++)
            {
                if (Up(map, j, i) || Right(map, j, i) || Down(map, j, i) || Left(map, j, i))
                    count++;

                up = 0;
                right = 0;
                down = 0;
                left = 0;

                Up(map, j, i);
                Right(map, j, i);
                Down(map, j, i);
                Left(map, j, i);

                if (partiture < (up * right * down * left))
                    partiture = up * right * down * left;
            }
        }

        Console.WriteLine(count);
        Console.WriteLine(partiture);
        Console.WriteLine(time.Elapsed.Nanoseconds);

        bool Up(int[,] forest, int x, int y)
        {
            for (int i = y - 1; 0 <= i; i--)
            {
                up++;
                if (forest[y, x] <= forest[i, x])
                    return false;
            }

            return true;
        }

        bool Down(int[,] forest, int x, int y)
        {
            for (int i = y + 1; i < forest.GetLength(0); i++)
            {
                down++;
                if (forest[y, x] <= forest[i, x])
                    return false;
            }

            return true;
        }

        bool Right(int[,] forest, int x, int y)
        {
            for (int i = x + 1; i < forest.GetLength(1); i++)
            {
                right++;
                if (forest[y, x] <= forest[y, i])
                    return false;
            }

            return true;
        }

        bool Left(int[,] forest, int x, int y)
        {
            for (int i = x - 1; 0 <= i; i--)
            {
                left++;
                if (forest[y, x] <= forest[y, i])
                    return false;
            }

            return true;
        }
    }
}