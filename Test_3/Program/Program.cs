using MTF;

var newString = "Ababa";
var MTFSequence = MTFEncoding.Encode(newString);
Console.Write("[");
foreach (var item in MTFSequence)
{
    Console.Write($"{item}, ");
}
Console.WriteLine("]");

Console.WriteLine((int)'Т');