namespace D10;

public class Solution
{
    //ATTRIBUTES
    public readonly int Amount;

    //BUILDER
    public Solution(int[] breakpoints, string input)
    {
        foreach (int var in breakpoints)
        {
            Amount += new Cpu(input, var).Frequency;
        }
    }
}