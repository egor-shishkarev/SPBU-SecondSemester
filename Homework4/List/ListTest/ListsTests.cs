﻿namespace Lists.Tests;

public class ListsTests
{
    public static IEnumerable<TestCaseData> Lists
    {
        get
        {
            var list = new List<int>();
            var uniqueList = new UniqueList<int>();

            var lists = new List<int>[] { list, uniqueList };

            var output = new System.Collections.Generic.List<TestCaseData>();

            foreach (var item in lists)
            {
                for (int i = 0; i < 6; ++i)
                {
                    item.Add(i);
                }
                output.Add(new TestCaseData(item));
            }
            return output;
        }
    }

    private static bool IsEqual(int[] arrayOfElements, List<int> list)
    {
        if (arrayOfElements.Length != list.Count)
        {
            return false;
        }
        for (int i = 0; i < list.Count; ++i)
        {
            if (arrayOfElements[i] != list[i])
            {
                return false;
            }
        }
        return true;
    }

    [TestCaseSource(nameof(Lists))]
    public void AddNewElementToListShouldWork(List<int> list)
    {
        list.Add(10);
        list.Add(7);
        var expectedResult = new int[] { 0, 1, 2, 3, 4, 5, 10, 7 };

        Assert.That(IsEqual(expectedResult, list));
    }

    [TestCaseSource(nameof(Lists))]
    public void AddNewElementByIndexShouldWork(List<int> list)
    {
        list.Add(0, 10);
        list.Add(3, 7);
        var expectedResult = new int[] { 10, 0, 1, 7, 2, 3, 4, 5 };

        Assert.That(IsEqual(expectedResult, list));
    }

    [TestCaseSource(nameof(Lists))]
    public void ChangeElementShouldWork(List<int> list)
    {
        list[0] = 10;
        list.ChangeValue(1, 7);
        var expectedResult = new int[] { 10, 7, 2, 3, 4, 5 };

        Assert.That(IsEqual(expectedResult, list));
    }

    [TestCaseSource(nameof(Lists))]
    public void RemoveByIndexShouldWork(List<int> list)
    {
        list.RemoveByIndex(0);
        list.RemoveByIndex(list.Count - 1);
        var expectedResult = new int[] { 1, 2, 3, 4 };

        Assert.That(IsEqual(expectedResult, list));
    }

    [TestCaseSource(nameof(Lists))]
    public void ContainsShouldWork(List<int> list)
    {
        Assert.Multiple(() =>
        {
            Assert.That(list.Contains(0), Is.True);
            Assert.That(list.Contains(6), Is.False);
        });
    }

    [TestCaseSource(nameof(Lists))] 
    public void TryingToAddNewELementByIndexOutOfRangeShouldThrowException(List<int> list)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => list.Add(7, 10));
    }

    [TestCaseSource(nameof(Lists))]
    public void TryingToRemoveElementByIndexOutOfRangeShouldThrowException(List<int> list)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveByIndex(6));
    }

    [TestCaseSource(nameof(Lists))]
    public void TryingToChangeElementByIndexOutOfRangeShouldThrowException(List<int> list)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => list.ChangeValue(6, 10));
    }
}