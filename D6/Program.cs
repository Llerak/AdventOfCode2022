namespace D6;

class Program
{
    public static void Main()
    {
        int Maker(int charactersNumber, string input)
        {
            int total = input.Length;
            input = StringCorrect(charactersNumber, input);
            return total - input.Length + charactersNumber;
        }
        
        string StringCorrect(int charactersNumber, string input)
        {
            char[] characters = new char[charactersNumber];
            for (int i = 0; i < charactersNumber; i++)
            {
                if (!characters.Contains(input[i]))
                {
                    characters[i] = input[i];
                }
                else
                {
                    int count = 0;
                    foreach (char var in characters)
                    {
                        if (var != input[i])
                        {
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    return StringCorrect(charactersNumber, input.Substring(count + 1));
                }
            }

            return input;
        }

        string input = File.ReadAllText("../../../data/input.txt");

        Console.WriteLine(Maker(14, input));
        
    }
}