using Routers;
using static Routers.RoutersTopology;

var listOfRouters = new List<Router>();
using (StreamReader file = new StreamReader("../../../NetworkTopology.txt"))
{
    while (!file.EndOfStream)
    {
        var line = file.ReadLine();
        if (line == null)
        {
            break;
        }
        listOfRouters.Add(ParseString.Parse(line));
    }
}
