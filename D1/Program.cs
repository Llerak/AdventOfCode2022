using static System.Int32;

string input = File.ReadAllText("../../../data/input.txt");

string[] listElf = input.Split("\r\n\r\n");

List<int> elfList = new List<int>();

foreach (string var in listElf)
{
    if (var.Contains("\r\n"))
    {
        string[] comidas = var.Split("\r\n");
        int total = 0;
        foreach (string comida in comidas)
        {
            total += Parse(comida);
        }
        elfList.Add(total);
    }
    else
    {
        elfList.Add(Parse(var));
    }
    
}

int totalsuma = 0;

for (int i = 0; i < 3; i++)
{
    totalsuma += elfList.Max();
    elfList.Remove(elfList.Max());
    
}

Console.WriteLine(totalsuma);
