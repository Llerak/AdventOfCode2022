namespace D9;

public class Head
{
    //ATTRIBUTES
    public int HeadPositionX;
    public int HeadPositionY;

    //METHODS
    public void Move(char direction)
    {
        switch (direction)
        {
            case 'U':
                HeadPositionY++;
                break;
            case 'R':
                HeadPositionX++;
                break;
            case 'D':
                HeadPositionY--;
                break;
            case 'L':
                HeadPositionX--;
                break;
            default:
                throw new Exception("Invalid direction");
        }
    }
}