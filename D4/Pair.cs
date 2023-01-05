namespace D4;

public class Pair
{
    public Pair(string input)
    {
        PairInPair = 0;
        Overlap = 0;
        this.GetPair(input);
    }

    public int PairInPair { get; private set; }
    public int Overlap { get; private set; }
    void GetPair(string input)
    {
        string[] pair = input.Split("\r\n");

        foreach (string var in pair)
        {
            string[] arrayPair = var.Split(',');
            int[] pair1 = ConvertArrayToInt(arrayPair[0].Split('-'));
            int[] pair2 = ConvertArrayToInt(arrayPair[1].Split('-'));

            if (FitInside(pair1, pair2))
                PairInPair++;
            if (OverlaP(pair1, pair2))
                Overlap++;
        }
    }

    private static int[] ConvertArrayToInt(string[] pairArray)
    {
        int[] pairInt = new int[2];
        for (int i = 0; i < pairArray.Length; i++)
        {
            pairInt[i] = int.Parse(pairArray[i]);
        }

        return pairInt;
    }

    private static bool FitInside(int[] pair1, int[] pair2)
    {
        return ((pair1[0] >= pair2[0]) && (pair1[1] <= pair2[1])) || ((pair2[0] >= pair1[0]) && (pair2[1] <= pair1[1]));
    }

    private static bool OverlaP(int[] pair1, int[] pair2)
    {
        return ((pair1[0] <= pair2[1]) && (pair1[1] >= pair2[0])) || ((pair2[0] <= pair1[0]) && (pair2[1] >= pair1[1]));
    }
}