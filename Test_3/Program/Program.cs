using MTF;

var newString = "Ololo123,";
var MTFSequence = MTFEncoding.Encode(newString);
Console.Write("[");
foreach (var item in MTFSequence)
{
    Console.Write($"{item} ");
}
Console.WriteLine("]");

