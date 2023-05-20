namespace FindPair;

public class Logic
{
    int[] tableOfNumbers;

    private List<Button> listOfCards = new List<Button>();

    public int GetCount => listOfCards.Count;

    private int countOfOpenCards = 0;

    public Logic(int number)
    {
        int numberOfPairs = (int)Math.Pow(number, 2) / 2 - 1;
        var tableOfNumbers = new int[number * number];
        var listOfNumbers = new List<int>();
        for (int i = 0; i <= numberOfPairs; ++i)
        {
            listOfNumbers.Add(i);
            listOfNumbers.Add(i);
        }
        for (int i = 0; i < number; ++i)
        {
            for (int j = 0; j < number; ++j)
            {
                var currentElement = listOfNumbers[new Random().Next(0, listOfNumbers.Count)];
                listOfNumbers.Remove(currentElement);
                tableOfNumbers[j * number + i] = currentElement;
            }
        }
        this.tableOfNumbers = tableOfNumbers;
    }

    public async void OpenCard(object sender)
    {
        if (listOfCards.Count == 2)
        {
            return;
        }
        var _sender = sender as Button;
        _sender.Text = tableOfNumbers[_sender.TabIndex].ToString();
        listOfCards.Add(_sender);
        if (listOfCards.Count == 2)
        {
            await Task.Delay(500);
            if (listOfCards[0].Text == listOfCards[1].Text)
            {
                foreach (var card in listOfCards)
                {
                    card.Enabled = false;
                }
                listOfCards.Clear();
                ++countOfOpenCards;
                if (countOfOpenCards == tableOfNumbers.Count())
                {
                    Application.Exit();
                }
            }
            CloseCards();
        }
    }

    public void CloseCards()
    {
        foreach (var button in listOfCards)
        {
            button.Text = "";
        }
        listOfCards.Clear();
    }
}
