namespace Queue;

/// <summary>
/// Class of priority queue based on List.
/// </summary>
public class PriorityQueue
{
    /// <summary>
    /// Main element of the List - head.
    /// </summary>
    private readonly List<(int priority, int value)> head;

    /// <summary>
    /// Constructor for priority queue.
    /// </summary>
    public PriorityQueue()
    {
        head = new List<(int, int)>();
    }

    /// <summary>
    /// Add element to queue.
    /// </summary>
    /// <param name="value">Value, that we want to add in queue</param>
    /// <param name="priority">Priority of current element</param>
    /// <exception cref="ArgumentOutOfRangeException">Priority was less than zero.</exception>
    public void Enqueue(int value, int priority)
    {
        if (priority < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(priority), "Priority should be positive");
        }
        head.Add((priority, value));
    }

    /// <summary>
    /// Returns an element with max priority.
    /// </summary>
    /// <returns>Value of max priority./returns>
    /// <exception cref="ArgumentException">Queue has no elements.</exception>
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

    /// <summary>
    /// Check if queue has no elements.
    /// </summary>
    public bool Empty => head.Count == 0;
}
