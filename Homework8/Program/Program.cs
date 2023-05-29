using SkipList;

var list = new SkipList<int>();
list.Add(30);
list.Add(40);
list.Add(50);
list.Add(60);
list.Add(70);
list.Add(90);
foreach (var item in list)
{
    Console.Write($"{item} ");
}