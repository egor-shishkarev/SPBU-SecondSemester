using MapFilterFold;

var listOfElements = new List<int>() { 1, 2, 3 };
int? accumulator = null;
var function = (int acc, int x) => acc + x;

CustomMethods.Fold(listOfElements, (int)accumulator!, function);
