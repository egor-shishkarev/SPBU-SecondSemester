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

namespace Queue.Tests;

public class QueueTests
{
    [Test]
    public void DequeueWithEmptyQueueShouldThrowException()
    {
        var priorityQueue = new PriorityQueue();

        Assert.Throws<ArgumentException>(() => priorityQueue.Dequeue());
    }

    [Test]
    public void EnqueueWithNegativePrioritiesShouldThrowException()
    {
        var priorityQueue = new PriorityQueue();

        Assert.Throws<ArgumentOutOfRangeException>(() => priorityQueue.Enqueue(1, -10));
    }

    [Test]
    public void DequeueShouldReturnExpectedResul()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(1, 5);
        priorityQueue.Enqueue(2, 1);
        priorityQueue.Enqueue(0, 2);

        Assert.Multiple(() =>
        {
            Assert.That(priorityQueue.Dequeue(), Is.EqualTo(1));
            Assert.That(priorityQueue.Dequeue(), Is.EqualTo(0));
            Assert.That(priorityQueue.Dequeue(), Is.EqualTo(2));
            Assert.That(priorityQueue.Empty, Is.True);
        });
    }

    [Test]
    public void DequeueWithSamePriorititesShouldReturnExprectedResult()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(1, 1);
        priorityQueue.Enqueue(2, 1);
        priorityQueue.Enqueue(3, 1);

        Assert.Multiple(() =>
        {
            Assert.That(priorityQueue.Dequeue(), Is.EqualTo(1));
            Assert.That(priorityQueue.Dequeue(), Is.EqualTo(2));
            Assert.That(priorityQueue.Dequeue(), Is.EqualTo(3));
            Assert.That(priorityQueue.Empty, Is.True);
        });
    }
}