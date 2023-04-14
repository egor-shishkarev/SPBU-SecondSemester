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