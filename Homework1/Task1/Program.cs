using BubbleSort;

if (!SortingTest.Test())
{
    Console.WriteLine("Тесты не пройдены!");
    return;
}
Console.WriteLine("Тесты успешно пройдены!");
Console.WriteLine("Введите число элементов массива => ");
int numberOfElements;
while (!int.TryParse(Console.ReadLine(), out numberOfElements) || numberOfElements <= 0 || numberOfElements > 50000000)
{
    Console.WriteLine("Было введено не число или слишком большое/маленькое число, повторите ввод => ");
}
var array = new int[numberOfElements];
Console.WriteLine("Вводите числа через Enter: ");
for (int i = 0; i < numberOfElements; ++i)
{
    while (!int.TryParse(Console.ReadLine(), out array[i]))
    {
        Console.WriteLine("Было введено не число, повторите ввод => ");
    }
}
if (!Sorting.BubbleSort(array))
{
    Console.WriteLine("Произошла ошибка при сортировке массива!");
    return;
}
Console.WriteLine("Отсортированный массив: ");
for (int i = 0; i < array.Length; ++i)
{
    Console.Write(array[i].ToString() + " ");
}
