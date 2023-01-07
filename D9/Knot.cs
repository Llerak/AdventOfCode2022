namespace D9;

public struct Knot
{
    //ATTRIBUTES
    public int KnotPositionX;
    public int KnotPositionY;

    // CONSTRUCTOR
    public Knot(int x = 0, int y = 0)
    {
        KnotPositionY = y;
        KnotPositionX = x;
    }

    //METHODS
    public void Move(int positionX, int positionY)
    {
        if (KnotPositionX == positionX)
        {
            KnotPositionY += (positionY - KnotPositionY > 0) ? 1 : -1;
        }
        else if (KnotPositionY == positionY)
        {
            KnotPositionX += (positionX - KnotPositionX > 0) ? 1 : -1;
        }
        else
        {
            KnotPositionY += positionY - KnotPositionY > 0 ? 1 : -1;
            KnotPositionX += positionX - KnotPositionX > 0 ? 1 : -1;
        }
    }

    public bool Pass(Knot other)
    {
        return Math.Sqrt(Math.Pow(KnotPositionX - other.KnotPositionX, 2) +
                         Math.Pow(KnotPositionY - other.KnotPositionY, 2)) < 1.45;
    }

    public override bool Equals(object? obj)
    {
        return obj is Knot other && KnotPositionX == other.KnotPositionX && KnotPositionY == other.KnotPositionY;
    }
}