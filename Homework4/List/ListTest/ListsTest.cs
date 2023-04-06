namespace Lists.Test;

public class Tests
{
    public static IEnumerable<TestCaseData> Lists 
    { 
        get
        {
            var lists = new List<int>[]
            {
                new List<int>(),
                new UniqueList<int>()
            };
            var result = new System.Collections.Generic.List<TestCaseData>();
            var testData = new int[] { 3, 7, 1, 6, 5, 4 };
            var positionsToAdd = new int[] { 0, 1, 1, 3, 1, 2};
            foreach (var list in lists)
            {
                for (int i = 0; i < testData.Length; i++)
                {
                    list.Add(testData[i], positionsToAdd[i]);
                }
                result.Add(new TestCaseData(list));
            }
            return result;
        } 
    }

    private static bool ElementComparison(List<int> list, int[] array)
    {
        if (list.Size != array.Length)
        {
            return false;
        }
        for (int i = 0; i < array.Length; ++i)
        {
            if (list[i] != array[i])
            {
                return false;
            }
        }
        return true;
    }

    [TestCaseSource(nameof(Lists))]
    public void AddAndGetShouldWork(List<int> list)
    {
        const int listSize = 6;
        int[] expectedResult = new int[listSize] { 3, 5, 4, 1, 7, 6 };

        Assert.That(ElementComparison(list, expectedResult), Is.True);
    }

    [TestCaseSource(nameof(Lists))]
    public void RemoveShouldWork(List<int> list)
    {
        const int newListSize = 3;
        list.Remove(5);
        list.Remove(0);
        list.Remove(3);
        var expectedResult = new int[newListSize] { 5, 4, 1 };

        Assert.That(ElementComparison(list, expectedResult), Is.True);
    }

    [TestCaseSource(nameof(Lists))]
    public void SizeOfListShouldWork(List<int> list)
    {
        list.Remove(3);
        list.Remove(0);
        Assert.That(list.Size, Is.EqualTo(4));
    }

    [TestCaseSource(nameof(Lists))]
    public void ChangeValueShouldWork(List<int> list)
    {
        list.ChangeValue(8, 0);
        list.ChangeValue(3, 1);
        const int newListSize = 6;
        var expectedResult = new int[newListSize] { 8, 3, 4, 1, 7, 6 };
        Assert.That(ElementComparison(list, expectedResult), Is.True);
    }

    [TestCaseSource(nameof(Lists))]
    public void RemoveNonexistentElementShouldThrowException(List<int> list)
    {
        Assert.Multiple(() => 
        {
            Assert.Throws<InvalidOperationRemoveNonexistentElementException>(() => list.Remove(-1));
            Assert.Throws<InvalidOperationRemoveNonexistentElementException>(() => list.Remove(list.Size)); 
        });
    }

    [TestCaseSource(nameof(Lists))]
    public void ChangeValueNonexistentElementShouldThrowException(List<int> list)
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => list.ChangeValue(0, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.ChangeValue(0, list.Size));
        });
    }

    [TestCaseSource(nameof(Lists))]
    public void AddElementWithIndexOutOfRangeShouldThrowException(List<int> list)
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Add(0, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Add(0, list.Size + 1));
        });
    }
}
