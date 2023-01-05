namespace D4;

class Programm
{
    public static void Main()
    {
        string input = File.ReadAllText("../../../data/input.txt");

        Pair pares = new Pair(input);
        
        Console.WriteLine("Total de pares que caben dentro de pares " + pares.PairInPair);
        Console.WriteLine("Total de pares que se superponen " + pares.Overlap);
    }
}