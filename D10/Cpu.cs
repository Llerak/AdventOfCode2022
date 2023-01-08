namespace D10;

public class Cpu
{
    //ATTRIBUTES
    private int _register = 1;
    private int _cycle = 1;
    public readonly int Frequency;

    //BUILDER
    public Cpu(string input, int stop)
    {
        string[] instructions = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < instructions.Length; i++)
        {
            if (stop == _cycle)
            {
                break;
            }

            if (stop == _cycle - 1)
            {
                _cycle--;
                _register -= int.Parse(instructions[i - 1].Split(" ")[1]);
                break;
            }

            Instruction(instructions[i]);
        }

        Frequency = _register * _cycle;
    }

    //METHODS
    private void Instruction(string instruction)
    {
        if (instruction == "noop")
        {
            CycleNoop();
        }

        if (instruction.Split(" ")[0] == "addx")
        {
            CycleAddx(int.Parse(instruction.Split(" ")[1]));
        }
    }

    private void CycleAddx(int amount)
    {
        _cycle += 2;
        _register += amount;
    }

    private void CycleNoop()
    {
        _cycle++;
    }
}