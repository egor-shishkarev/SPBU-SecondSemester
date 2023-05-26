using System.Drawing;

namespace ButtonLogic;

public class ButtonLogic
{
    public Point MoveButton(Point location)
    {
        var random = new Random();
        var (x, y) = (location.X, location.Y);
        var partOfXCoordinate = random.Next(0, 2);
        int newXCoordinate;
        int newYCoordinate;
        if ((partOfXCoordinate == 0 && x > 75) || x > 650)
        {
            newXCoordinate = random.Next(0, x - 75);
        }
        else
        {
            newXCoordinate = random.Next(x + 75, 725);
        }

        var partOfYCoordinate = random.Next(0, 2);
        if ((partOfYCoordinate == 0 && y > 75)|| y > 300)
        {
            newYCoordinate = random.Next(0, y - 75);
        }
        else
        {
            newYCoordinate = random.Next(y + 75, 375);
        }
        var newPosition = new Point(newXCoordinate, newYCoordinate);
        return newPosition;
    }
}