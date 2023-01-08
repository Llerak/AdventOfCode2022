namespace D10;

class Program
{
    public static void Main()
    {
        string input = File.ReadAllText("../../../data/input.txt");
        int[] breakpoints = { 20, 60, 100, 140, 180, 220 };

        int frequency = new Solution(breakpoints, input).Amount;

        Console.WriteLine(frequency);
    }
}