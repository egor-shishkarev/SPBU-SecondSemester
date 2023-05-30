namespace SkipList.Tests;

public class SkipListTests
{
    private readonly SkipList<int> list = new();

    private bool IsEqual(int[] arrayOfElements, SkipList<int> list)
    {
        int currentIndex = 0;
        foreach (var element in arrayOfElements)
        {
            if (element != arrayOfElements[currentIndex])
            {
                return false;
            }
            ++currentIndex;
        }
        return true;
    }

    [TearDown]
    public void TearDown()
    {
        list.Clear();
    }

    [Test]
    public void AddElementsToSkipListShouldWorkTest()
    {
        list.Add(1);
        list.Add(-1);

        Assert.Multiple(() =>
        {
            Assert.That(list.Contains(1), Is.True);
            Assert.That(list.Contains(-1), Is.True);
            Assert.That(list.Count, Is.EqualTo(2));
        });
    }

    [Test]
    public void ClearShouldWorkTest()
    {
        list.Add(1);
        list.Add(2);

        list.Clear();

        Assert.Multiple(() =>
        {
            Assert.That(list.Count, Is.EqualTo(0));
            Assert.That(list.Contains(1), Is.False);
            Assert.That(list.Contains(2), Is.False);
        });
    }

    [Test]
    public void RemoveElementsFromSkipListShouldWorkTest()
    {
        list.Add(1);
        list.Add(-1);

        list.Remove(1);

        Assert.Multiple(() =>
        {
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list.Contains(-1), Is.True);
            Assert.That(list.Contains(1), Is.False);
        });
    }

    [Test]
    public void ForeachMethodShouldWorkForSkipListTest()
    {
        list.Add(1);
        list.Add(5);
        list.Add(4);
        list.Add(2);
        list.Add(3);

        Assert.That(IsEqual(new int[] { 1, 2, 3, 4, 5 }, list), Is.True);
    }

    [Test]
    public void IndexOfShouldWorkTest()
    {
        list.Add(1);
        list.Add(5);
        list.Add(4);

        Assert.That(list.IndexOf(4), Is.EqualTo(1));
    }

    [Test]
    public void RemoveAtShouldWorkTest()
    {
        list.Add(1);
        list.Add(5);
        list.Add(4);

        list.RemoveAt(0);

        Assert.Multiple(() =>
        {
            Assert.That(list.Count, Is.EqualTo(2));
            Assert.That(IsEqual(new int[] { 4, 5 }, list));
        });
    }

    [Test]
    public void CopyToShouldWorkTest()
    {
        list.Add(1);
        list.Add(0);
        list.Add(-1);

        var arrayToPaste = new int[] { -3, -2, 0, 0, 0 };
        var expectedResult = new int[] { -3, -2, -1, 0, 1 };
        list.CopyTo(arrayToPaste, 2);

        Assert.That(arrayToPaste, Is.EqualTo(expectedResult));
    }

    [Test]
    public void TryingToChangeValueShouldThrowExceptionTest()
    {
        list.Add(1);
        list.Add(2);

        Assert.Throws<NotSupportedException>(() => list[0] = 0);
    }

    [Test]
    public void TryingToInsertValueShouldThrowExceptionTest()
    {
        list.Add(1);

        Assert.Throws<NotSupportedException>(() => list.Insert(0, 2));
    }
}