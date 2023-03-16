using TrieClass;

Console.WriteLine("Данная программа позволяет продемонстрировать работу со структурой данных - Бор");
Console.WriteLine("Выберите одно из действий для продолжения:\n");
Console.WriteLine("""
    0 - Закончить выполнение программы,
    1 - Добавить строку в дерево,
    2 - Проверить, что строка содержится в дереве,
    3 - Удалить строку из дерева,
    4 - Проверить сколько строк начинаются с префикса,
    5 - Узнать количество слов в дереве.
    """);
var trie = new Trie();
int currentState;
bool inWork = true;
while (inWork)
{
    Console.WriteLine("Выберите следующее действие => ");
    if (!int.TryParse(Console.ReadLine(), out currentState))
    {
        Console.WriteLine("Вводите числа из списка выше!");
        continue;
    }
    switch (currentState)
    {
        case 0:
            {
                Console.WriteLine("Работа закончена.");
                inWork = false;
                break;
            }
        case 1:
            {
                Console.WriteLine("Введите строку, которую хотите добавить => ");
                var newElement = Console.ReadLine();
                while (newElement == null)
                {
                    Console.WriteLine("Строка не была введена, повторите ввод => ");
                    newElement = Console.ReadLine();
                }
                if (!trie.Add(newElement))
                {
                    Console.WriteLine("Эта строка уже есть в дереве!");
                }
                Console.WriteLine("Строка успешно добавлена.");
                break;
            }
        case 2:
            {
                Console.WriteLine("Введите строку, которую хотите проверить на принадлежность к дереву => ");
                var newElement = Console.ReadLine();
                while (newElement == null)
                {
                    Console.WriteLine("Строка не была введена, повторите ввод => ");
                    newElement = Console.ReadLine();
                }
                if (trie.Contains(newElement))
                {
                    Console.WriteLine("Данная строка есть в дереве.");
                }
                else
                {
                    Console.WriteLine("Данной строки нет в дереве.");
                }
                break;
            }
        case 3:
            {
                Console.WriteLine("Введите строку, которую хотите удалить => ");
                var newElement = Console.ReadLine();
                while (newElement == null)
                {
                    Console.WriteLine("Строка не была введена, повторите ввод => ");
                    newElement = Console.ReadLine();
                }
                if (trie.Remove(newElement))
                {
                    Console.WriteLine("Элемент был успешно удален!");
                }
                else
                {
                    Console.WriteLine("Данной строки нет в дереве.");
                }
                break;
            }
        case 4:
            {
                Console.WriteLine("Введите префикс, который хотите проверить => ");
                var newElement = Console.ReadLine();
                while (newElement == null)
                {
                    Console.WriteLine("Строка не была введена, повторите ввод => ");
                    newElement = Console.ReadLine();
                }
                Console.WriteLine($"С префикса {newElement} начинаются {trie.HowManyStartsWithPrefix(newElement)} строк");
                break;
            }
        case 5:
            {
                Console.WriteLine($"В дереве - {trie.Size} строк");
                break;
            }
        default:
            {
                Console.WriteLine("Введите значение из предложенного выше!");
                break;
            }
    }
}
