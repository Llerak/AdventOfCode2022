namespace D9;

class Program
{
    public static void Main()
    {
        //tablero
        int[,] table = new int[10, 10];

        int hx = table.GetLength(1) / 2;
        int hy = table.GetLength(0) / 2;
        int tx = hx;
        int ty = hy;

/*
        int[,] nude =
        {
            { tx, ty, 0, 0 }
        };
         for (int i = 0; i < nude.GetLength(0); i++)
         {
             nude[i, 0] = hx;
             nude[i, 1] = tx;
         }*/


        string[] input = File.ReadAllText("../../../data/input.txt").Split("\r\n");

        foreach (string var in input)
        {
            string[] inputArray = var.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Move(inputArray[0], int.Parse(inputArray[1]));
        }

        int count = 0;
        for (int i = 0; i < table.GetLength(0); i++)
        {
            for (int j = 0; j < table.GetLength(1); j++)
            {
                if (table[i, j] == 1)
                    count++;
            }
        }

        Console.WriteLine(count);


        //metodo que tomo una letra y el numero de movimientos
        void Move(string d, int amount)
        {
            if (d == "U")
            {
                for (int i = 0; i < amount; i++)
                {
                    table[ty, tx] = 1;
                    int temporalhx = hx;
                    int temporalhy = hy;
                    hy--;
                    if (!Distance(hx, hy, tx, ty))
                    {
                        tx = temporalhx;
                        ty = temporalhy;
                    }
                }
               /* for (int i = 0; i < amount; i++)
                {
                    //problema aqui
                    table[nude[nude.GetLength(0) - 1, 1],nude[nude.GetLength(0) - 1, 0]] = 1;

                    for (int j = 0; j < nude.GetLength(0); j++)
                    {
                        if (j == 0)
                        {
                            nude[j, 2] = hx;
                            nude[j, 3] = hy;
                        }
                        else
                        {
                            nude[j - 1, 2] = hx;
                            nude[j - 1, 3] = hy;
                        }
                    }

                    hy--;

                    for (int j = 0; j < nude.GetLength(0); j++)
                    {
                        if (j == 0)
                        {
                            if (!Distance(hx, hy, nude[j, 0], nude[j, 1]))
                            {
                                nude[j, 0] = nude[j, 2];
                                nude[j, 1] = nude[j, 3];
                            }
                        }
                        else
                        {
                            if (!Distance(nude[j - 1, 0], nude[j - 1, 1], nude[j, 0], nude[j, 1]))
                            {
                                nude[j, 0] = nude[j, 2];
                                nude[j, 1] = nude[j, 3];
                            }
                        }
                    }
                }*/
            }

            if (d == "R")
            {
                for (int i = 0; i < amount; i++)
                {
                    table[ty, tx] = 1;
                    int temporalhx = hx;
                    int temporalhy = hy;
                    hx++;
                    if (!Distance(hx, hy, tx, ty))
                    {
                        tx = temporalhx;
                        ty = temporalhy;
                    }
                }
            }

            if (d == "D")
            {
                for (int i = 0; i < amount; i++)
                {
                    table[ty, tx] = 1;
                    int temporalhx = hx;
                    int temporalhy = hy;
                    hy++;
                    if (!Distance(hx, hy, tx, ty))
                    {
                        tx = temporalhx;
                        ty = temporalhy;
                    }
                }
            }

            if (d == "L")
            {
                for (int i = 0; i < amount; i++)
                {
                    table[ty, tx] = 1;
                    int temporalhx = hx;
                    int temporalhy = hy;
                    hx--;
                    if (!Distance(hx, hy, tx, ty))
                    {
                        tx = temporalhx;
                        ty = temporalhy;
                    }
                }
            }
        }

        bool Distance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)) <= Math.Sqrt(2);
        }
    }
}