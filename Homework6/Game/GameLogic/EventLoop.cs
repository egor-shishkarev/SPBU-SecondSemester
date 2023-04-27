namespace GameLogic;

public class EventLoop
{
    /// <summary>
    /// Action on right arrow press.
    /// </summary>
    public event EventHandler<EventArgs> RightHandler = (sender, args) => { };

    /// <summary>
    /// Action on left arrow press.
    /// </summary>
    public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };

    /// <summary>
    /// Action on up arrow press.
    /// </summary>
    public event EventHandler<EventArgs> UpHandler = (sender, args) => { };

    /// <summary>
    /// Action on down arrow press.
    /// </summary>
    public event EventHandler<EventArgs> DownHandler = (sender, args) => { };

    /// <summary>
    /// Action on R key press.
    /// </summary>
    public event EventHandler<EventArgs> RestartHandler = (sender, args) => { };

    /// <summary>
    /// Method, that run game actions.
    /// </summary>
    public void Run()
    {
        while (true)
        {
            var key = Console.ReadKey(true);
            switch (key.Key) 
            { 
                case ConsoleKey.Escape:
                    {
                        return;
                    }
                case ConsoleKey.RightArrow:
                    {
                        RightHandler(this, EventArgs.Empty);
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        LeftHandler(this, EventArgs.Empty);
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        UpHandler(this, EventArgs.Empty);
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        DownHandler(this, EventArgs.Empty);
                        break;
                    }
                case ConsoleKey.R:
                    {
                        RestartHandler(this, EventArgs.Empty);
                        return;
                    }
            }
        }
    }
}
