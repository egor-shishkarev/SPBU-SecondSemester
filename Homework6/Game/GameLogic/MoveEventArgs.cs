namespace GameLogic;

public class MoveEventArgs : EventArgs
{
    public MoveEventArgs(string filePath)
    {
        map = new Map(filePath);
        character = new Character((1, 1));
        currentCoin = new Coin(File.ReadAllLines(filePath), (1, 1));
    }

    public Map map { get; }

    public Character character { get; }

    public Coin currentCoin { get; }
    
}
