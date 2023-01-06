namespace D9;

class Program
{
    public static void Main()
    {
        //tablero
        int[,] table = FillMatrixWithZero(15, 15);

        string[] input = File.ReadAllText("../../../data/input.txt").Split("\r\n");

        int[,] snake = {{5,5 },{5,5}};

        foreach (string var in input)
        {
            string[] parameters = var.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Move(parameters[0], Int32.Parse(parameters[1]));
        }
        Console.WriteLine(Count(table));
        
        void Move(string direction, int amount)
        {
            if (direction == "U")
            {
                for (int i = 0; i < amount; i++)
                {
                    Up();
                }
            }
            else if (direction == "R")
            {
                for (int i = 0; i < amount; i++)
                {
                    Right();
                }
            }
            else if (direction == "D")
            {
                for (int i = 0; i < amount; i++)
                {
                    Down();
                }
            }
            else if (direction == "L")
            {
                for (int i = 0; i < amount; i++)
                {
                    Left();
                }
            }
        }

        void Up()
        {
            snake[0, 1]--;
            table[snake[snake.GetLength(0) - 1, 1], snake[snake.GetLength(0) - 1, 0]] = 1;
            for (int i = 1; i < snake.GetLength(0); i++)
            {
                if (DistanceInLine(snake[i - 1, 0], snake[i - 1, 1], snake[i, 0], snake[i, 1]))
                {
                    snake[i, 1]--;
                }
                else if (DistanceInDiagonal(snake[i - 1, 0], snake[i - 1, 1], snake[i, 0], snake[i, 1]))
                {
                    //case1
                    if (DistanceInOne(snake[i - 1, 0], snake[i - 1, 1], snake[i, 0] + 1, snake[i, 1] - 1))
                    {
                        snake[i, 0]++;
                        snake[i, 1]--;
                    }
                    //case2
                    else
                    {
                        snake[i, 0]--;
                        snake[i, 1]--;
                    }
                }

                table[snake[snake.GetLength(0) - 1, 1], snake[snake.GetLength(0) - 1, 0]] = 1;
            }
        }

        void Right()
        {
            snake[0, 0]++;
            table[snake[snake.GetLength(0) - 1, 1], snake[snake.GetLength(0) - 1, 0]] = 1;
            for (int i = 1; i < snake.GetLength(0); i++)
            {
                if (DistanceInLine(snake[i - 1, 0], snake[i - 1, 1], snake[i, 0], snake[i, 1]))
                {
                    snake[i, 0]++;
                }
                else if (DistanceInDiagonal(snake[i - 1, 0], snake[i - 1, 1], snake[i, 0], snake[i, 1]))
                {
                    //case1
                    if (DistanceInOne(snake[i - 1, 0], snake[i - 1, 1], snake[i, 0] + 1, snake[i, 1] - 1))
                    {
                        snake[i, 0]++;
                        snake[i, 1]--;
                    }
                    //case2
                    else
                    {
                        snake[i, 0]++;
                        snake[i, 1]++;
                    }
                }

                table[snake[snake.GetLength(0) - 1, 1], snake[snake.GetLength(0) - 1, 0]] = 1;
            }
        }

        void Down()
        {
            snake[0, 1]++;
            table[snake[snake.GetLength(0) - 1, 1], snake[snake.GetLength(0) - 1, 0]] = 1;
            for (int i = 1; i < snake.GetLength(0); i++)
            {
                if (DistanceInLine(snake[i - 1, 0], snake[i - 1, 1], snake[i, 0], snake[i, 1]))
                {
                    snake[i, 1]++;
                }
                else if (DistanceInDiagonal(snake[i - 1, 0], snake[i - 1, 1], snake[i, 0], snake[i, 1]))
                {
                    //case1
                    if (DistanceInOne(snake[i - 1, 0], snake[i - 1, 1], snake[i, 0] + 1, snake[i, 1] + 1))
                    {
                        snake[i, 0]++;
                        snake[i, 1]++;
                    }
                    //case2
                    else
                    {
                        snake[i, 0]--;
                        snake[i, 1]++;
                    }
                }

                table[snake[snake.GetLength(0) - 1, 1], snake[snake.GetLength(0) - 1, 0]] = 1;
            }
        }

        void Left()
        {
            snake[0, 0]--;
            table[snake[snake.GetLength(0) - 1, 1], snake[snake.GetLength(0) - 1, 0]] = 1;
            for (int i = 1; i < snake.GetLength(0); i++)
            {
                if (DistanceInLine(snake[i - 1, 0], snake[i - 1, 1], snake[i, 0], snake[i, 1]))
                {
                    snake[i, 0]--;
                }
                else if (DistanceInDiagonal(snake[i - 1, 0], snake[i - 1, 1], snake[i, 0], snake[i, 1]))
                {
                    //case1
                    if (DistanceInOne(snake[i - 1, 0], snake[i - 1, 1], snake[i, 0] - 1, snake[i, 1] - 1))
                    {
                        snake[i, 0]--;
                        snake[i, 1]--;
                    }
                    //case2
                    else
                    {
                        snake[i, 0]--;
                        snake[i, 1]++;
                    }
                }

                table[snake[snake.GetLength(0) - 1, 1], snake[snake.GetLength(0) - 1, 0]] = 1;
            }
        }

        bool DistanceInLine(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)) == 2;
        }

        bool DistanceInDiagonal(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)) >= 1.43;
        }

        bool DistanceInOne(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)) == 1;
        }

        int[,] FillMatrixWithZero(int y, int x)
        {
            int[,] matrix = new int[y, x];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 0;
                }
            }

            return matrix;
        }

        int Count(int[,] map)
        {
            int count = 0;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 1)
                        count++;
                }
            }

            return count;
        }
    }
}