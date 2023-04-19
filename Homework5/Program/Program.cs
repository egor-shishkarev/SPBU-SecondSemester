using Routers;
using static Routers.RoutersTopology;

var listOfRouters = new List<Router>();
var allLines = File.ReadAllLines("../../../NetworkTopology.txt");
CreateOptimalConfiguration(allLines);

//1: 2(2), 6(5)
//2: 5(10), 6(7), 3(4)
//3: 6(8), 4(9)
//4: 6(8), 5(6)