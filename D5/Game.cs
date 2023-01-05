namespace D5;

class Game
{
    public Game(string input)
    {
        Main(input);
    }

    public string Menssager = "";
    private readonly List<List<char>> _table = new List<List<char>>();
    private readonly List<int[]> _moves = new List<int[]>();

    void Main(string input)
    {
        string[] inputArray = ReadInput(input);

        string[] table = inputArray[0].Split("\r\n");
        FillTable(table);

        string[] moves = inputArray[1].Split("\r\n");
        FillMoves(moves);


        string decision = Console.ReadLine();

        if (decision == "1")
        {
            foreach (int[] var in _moves)
            {
                Move(var[0], var[1], var[2]);
            }

            FillMenssager(_table);
        }
        else if (decision == "2")
        {
            foreach (int[] var in _moves)
            {
                UltimateMove(var[0], var[1], var[2]);
            }

            FillMenssager(_table);
        }
    }

    string[] ReadInput(string input)
    {
        return input.Split("\r\n\r\n");
    }

    void FillTable(string[] table)
    {
        int totalColumn = table[^1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;

        for (int i = 0; i < totalColumn; i++)
        {
            _table.Add(new List<char>());
        }

        for (int k = table.Length - 2; 0 <= k; k--)
        {
            for (int i = 1; i < table[k].Length; i += 4)
            {
                if (table[k][i] == ' ')
                    continue;
                _table.ElementAt((i - 1) / 4).Add(table[k][i]);
            }
        }
    }

    void FillMoves(string[] moves)
    {
        foreach (var mov in moves)
        {
            string[] move = mov.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            _moves.Add(new[]
            {
                Int32.Parse(move[1]),
                Int32.Parse(move[3]),
                Int32.Parse(move[5]),
            });
        }
    }

    void Move(int count, int from, int to)
    {
        for (int i = 0; i < count; i++)
        {
            _table.ElementAt(to - 1).Add(_table.ElementAt(from - 1).ElementAt(_table.ElementAt(from - 1).Count - 1));
            _table.ElementAt(from - 1).RemoveAt(_table.ElementAt(from - 1).Count - 1);
        }
    }

    void FillMenssager(List<List<char>> table)
    {
        foreach (List<char> var in table)
        {
            Menssager += (var.ElementAt(var.Count - 1));
        }
    }

    void UltimateMove(int count, int from, int to)
    {
        char[] characters = new char[count];
        for (int i = 0; i < count; i++)
        {
            characters[i] = _table.ElementAt(from - 1).ElementAt(_table.ElementAt(from - 1).Count - 1);
            _table.ElementAt(from - 1).RemoveAt(_table.ElementAt(from - 1).Count - 1);
        }

        for (int i = count - 1; 0 <= i; i--)
        {
            _table.ElementAt(to - 1).Add(characters[i]);
        }
    }
}