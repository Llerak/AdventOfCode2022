using static System.Char;

namespace D7;

abstract class Program
{
    public static void Main()
    {
        Dictionary<string, int> directories = new();

        string[] lines = File.ReadAllText("../../../data/input.txt").Split("\r\n");

        void Fill(string[] line, string route = "")
        {
            ProcessDirectoriesAndFiles(line, route);
            SubDirectories();
            Result();
        }

        Fill(lines);
        

        bool IsDigit(string number)
        {
            foreach (char var in number)
            {
                if (!IsNumber(var))
                {
                    return false;
                }
            }

            return true;
        }

        void ProcessDirectoriesAndFiles(string[] line, string route)
        {
            foreach (string var in line)
            {
                string[] varArray = var.Split();

                //Directories
                if (varArray[0] == "$" && varArray[1] == "cd")
                {
                    if (varArray[2] != "..")
                    {
                        route = $@"{route}{varArray[2]}/";
                        directories.Add(route, 0);
                    }
                    else
                    {
                        for (int i = route.Length - 2; 0 <= i; i--)
                        {
                            if (route[i] == '/')
                            {
                                route = route.Substring(0, i + 1);
                                break;
                            }
                        }
                    }
                }

                //Files
                if (IsDigit(varArray[0]))
                {
                    directories[route] += int.Parse(varArray[0]);
                }
            }
        }

        void SubDirectories()
        {
            for (int i = 0; i < directories.Count; i++)
            {
                for (int j = i + 1; j < directories.Count; j++)
                {
                    if (directories.Keys.ElementAt(j).Contains(directories.Keys.ElementAt(i)))
                    {
                        directories[directories.Keys.ElementAt(i)] += directories[directories.Keys.ElementAt(j)];
                    }
                }
            }
        }

        void Result()
        {
            int total = 0;
            int totalSize = 70000000 - directories.Values.ElementAt(0);
            int temporary = int.MaxValue;
            foreach (int var in directories.Values)
            {
                if (var <= 100000)
                    total += var;
                if (var >= 30000000 - totalSize && var < temporary)
                    temporary = var;
            }

            Console.WriteLine($"{total}\n{temporary}");
        }
    }
}