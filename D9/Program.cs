namespace D9;

class Program
{ 
    public static void Main()
    {
        string input = File.ReadAllText("../../../data/input.txt");
        Rope rope = new Rope(9, input);
       Console.WriteLine(rope.PositionsVisitedByTheLastNode.Count);
    }    
}
