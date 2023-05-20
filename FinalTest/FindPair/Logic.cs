namespace FindPair;

public class Logic
{
    int[] tableOfNumbers;

    public Logic(int number)
    {
        int numberOfPairs = (int)Math.Pow(number, 2) / 2 - 1;
        var tableOfNumbers = new int[number * number];
        var listOfNumbers = new List<int>();
        for (int i = 0; i < numberOfPairs; ++i)
        {
            listOfNumbers.Add(i);
            listOfNumbers.Add(i);
        }
        for (int i = 0; i < number; ++i)
        {
            for (int j = 0; j < number; ++j)
            {
                var currentElement = listOfNumbers[new Random().Next(0, listOfNumbers.Count - 1)];
                listOfNumbers.Remove(currentElement);
                tableOfNumbers[j * number + i] = currentElement;
            }
        }
        this.tableOfNumbers = tableOfNumbers;
    }

    public void OpenCard(object sender)
    {
        var _sender = sender as Button;
        _sender.Text = tableOfNumbers[_sender.TabIndex].ToString();
    }

    public void Close()
    {

    }
}
