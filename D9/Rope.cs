namespace D9;

public class Rope
{
    // ATTRIBUTES
    private readonly Head _head = new Head();
    public readonly List<Knot> PositionsVisitedByTheLastNode = new List<Knot>();
    private readonly Knot[] _knots;

    public Rope(int size, string instructions)
    {
        _knots = new Knot[size];
        Main(instructions);
    }

    private void Main(string instructions)
    {
        string[] instructionsOneForOne = instructions.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        FillKnot();
        foreach (string var in instructionsOneForOne)
        {
            char direction = var[0];
            int amount = int.Parse(var.Split(" ")[1]);

            for (int i = 0; i < amount; i++)
            {
                _head.Move(direction);
                var a = new Knot(_head.HeadPositionX, _head.HeadPositionY);
                if (!_knots[0].Pass(a))
                {
                    _knots[0].Move(_head.HeadPositionX, _head.HeadPositionY);
                }

                for (int j = 1; j < _knots.Length; j++)
                {
                    if (!_knots[j].Pass(_knots[j - 1]))
                    {
                        _knots[j].Move(_knots[j - 1].KnotPositionX, _knots[j - 1].KnotPositionY);
                    }
                }
                
                if (!PositionsVisitedByTheLastNode.Contains(_knots[^1])) 
                    PositionsVisitedByTheLastNode.Add(_knots[^1]);
            }
        }
    }

    void FillKnot()
    {
        for (int i = 0; i < _knots.Length; i++)
        {
            _knots[i] = new Knot();
        }
    }
    
}