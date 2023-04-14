namespace Queue;

public class PriorityQueue
{
    readonly List<(int priority, int value)> head;
    public PriorityQueue()
    {
        head = new List<(int, int)>();
    }

    public void Enqueue(int value, int priority)
    {
        if (priority < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(priority), "Priority should be positive");
        }
        head.Add((priority, value));
    }

    public int Dequeue()
    {
        if (Empty)
        {
            throw new ArgumentException("Queue has no elements");
        }
        var maxPriority = int.MinValue;
        var indexOfMaxPriority = 0;
        for (int i = 0; i < head.Count; ++i)
        {
            if (head[i].priority > maxPriority)
            {
                maxPriority = head[i].priority;
                indexOfMaxPriority = i;
            }
        }
        var result = head[indexOfMaxPriority].value;
        head.RemoveAt(indexOfMaxPriority);
        return result;
    }

    public bool Empty => head.Count == 0;
}

/*Реализовать очередь с приоритетами. Очередь должна иметь метод Enqueue(), 
 * принимающий на вход значение и численный приоритет, метод Dequeue(), 
 * возвращающий значение с наибольшим приоритетом (то есть приоритетом с 
 * наибольшим численным значением) и удаляющий его из очереди, и свойство 
 * Empty, возвращающее, пуста ли очередь. Если приоритеты элементов равны, 
 * они должны возвращаться в порядке, в котором они поступили в очередь 
 * (First In — First Out). Тип хранимых значений — любой, на ваш выбор. 
 * Если очередь пуста, Dequeue() должен бросать исключение. Комментарии, 
 * юнит-тесты и CI также ожидаются от правильного решения.*/