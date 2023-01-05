namespace D5;

class Program
{
    public static void Main()
    {
        string input = File.ReadAllText("../../../data/input.txt");

        Game game = new Game(input);
        Console.WriteLine(game.Menssager);
    }
}