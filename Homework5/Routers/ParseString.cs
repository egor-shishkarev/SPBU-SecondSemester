namespace Routers;

using System.Text;
using static Routers.RoutersTopology;

public class ParseString
{
    public enum State
    {
        Number,
        Colon,
        SpaceAfterColonOrComma,
        RouterNumber,
        SpaceAfterRouterNumber,
        OpenBracket,
        Bandwidth,
        ClosedBracket,
        Comma,
        Wrong
    }

    public static Router Parse(string configuration)
    {
        (var router, int[] relatedRouters, int[] bandwidth) = ParseConfiguration(configuration);
        if (relatedRouters == Array.Empty<int>())
        {
            throw new ArgumentException(nameof(configuration));
        }
        Console.WriteLine($"{router.Name} = ");
        for (int i = 0; i < relatedRouters.Length; ++i)
        {
            Console.WriteLine($"{relatedRouters[i]} - {bandwidth[i]}");
        }
        return router;
    }

    private static (Router router, int[] relatedRouters, int[] bandwidth) ParseConfiguration(string configuration)
    {
        List<int> numberOfRelatedRouters = new List<int>();
        List<int> bandwidth = new List<int>();
        var currentState = State.Number;
        int currentIndex = 0;
        StringBuilder currentSubstring = new StringBuilder();
        int numberOfRouter = -1;
        while (currentIndex < configuration.Length)
        {
            if (Char.IsDigit(configuration[currentIndex]) && currentState == State.Number)
            {
                currentSubstring.Append(configuration[currentIndex]);
                currentState = State.Number;
                currentIndex++;
                continue;
            }
            if (configuration[currentIndex] == ':' && currentState == State.Number)
            {
                numberOfRouter = Convert.ToInt16(currentSubstring.ToString());
                currentState = State.Colon;
                currentIndex++;
                currentSubstring.Clear();
                continue;
            }
            if (configuration[currentIndex] == ' ' && (currentState == State.Colon || currentState == State.Comma))
            {
                currentState = State.SpaceAfterColonOrComma;
                currentIndex++;
                continue;
            }
            if (Char.IsDigit(configuration[currentIndex]) && (currentState == State.SpaceAfterColonOrComma || currentState == State.RouterNumber)) {
                currentSubstring.Append(configuration[currentIndex]);
                currentState = State.RouterNumber;
                currentIndex++;
                continue;
            }
            if (configuration[currentIndex] == ' ' && currentState == State.RouterNumber)
            {
                numberOfRelatedRouters.Add(Convert.ToInt16(currentSubstring.ToString()));
                currentSubstring.Clear();
                currentState = State.SpaceAfterRouterNumber;
                currentIndex++;
                continue;
            } 
            if (configuration[currentIndex] == '(' && currentState == State.SpaceAfterRouterNumber)
            {
                currentState = State.OpenBracket;
                currentIndex++;
                continue;
            }
            if (Char.IsDigit(configuration[currentIndex]) && (currentState == State.OpenBracket || currentState == State.Bandwidth))
            {
                currentSubstring.Append(configuration[currentIndex]);
                currentState = State.Bandwidth;
                currentIndex++;
                continue;
            }
            if (configuration[currentIndex] == ')' && currentState == State.Bandwidth)
            {
                bandwidth.Add(Convert.ToInt16(currentSubstring.ToString()));
                currentSubstring.Clear();
                currentState = State.ClosedBracket;
                currentIndex++;
                continue;
            }
            if (configuration[currentIndex] == ',' && currentState == State.ClosedBracket)
            {
                currentState = State.Comma;
                currentIndex++;
                continue;
            }
            currentState = State.Wrong;
            break;
        }
        if (currentState != State.ClosedBracket)
        {
            return (new Router(0), Array.Empty<int>(), Array.Empty<int>());
        }
        var router = new Router(numberOfRouter);
        return (router, numberOfRelatedRouters.ToArray(), bandwidth.ToArray());
    }
}
