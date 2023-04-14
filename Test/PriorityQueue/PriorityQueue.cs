/*Copyright 2023 Egor Shishkarev
*
*Licensed under the Apache License, Version 2.0 (the "License");
*you may not use this file except in compliance with the License.
*You may obtain a copy of the License at
*
*http://www.apache.org/licenses/LICENSE-2.0
*
*Unless required by applicable law or agreed to in writing, software
*distributed under the License is distributed on an "AS IS" BASIS,
*WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
*See the License for the specific language governing permissions and
*limitations under the License.
*/

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
        if (Empty)
        {
            head.Add((priority, value));
        } 
        else
        {
            var curretnIndex = 0;
            while (curretnIndex < head.Count - 1)
            {
                if (priority <= head[curretnIndex].priority && priority > head[curretnIndex + 1].priority)
                {
                    head.Insert(curretnIndex + 1, (priority, value));
                    return;
                }
                ++curretnIndex;
            }
            head.Add((priority, value));
        }
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
        var result = head[0].value;
        head.RemoveAt(0);
        return result;
    }

    /// <summary>
    /// Check if queue has no elements.
    /// </summary>
    public bool Empty => head.Count == 0;
}
