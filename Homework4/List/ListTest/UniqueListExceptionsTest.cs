namespace Lists.Test;

public class UniqueListExceptionsTest
{
    public static IEnumerable<TestCaseData> List
    {
        get
        {
            var list = new UniqueList<int>();
            list.Add(0, 0);
            list.Add(1, 1);
            list.Add(2, 2);
            list.Add(3, 3);
            yield return new TestCaseData(list);
        }
    }

    [TestCaseSource(nameof(List))]
    public void AddAlreadyExistElementShouldThrowException(List<int> list)
    {
        Assert.Throws<InvalidOperationElementAlreadyExistException>(() => list.Add(0, 4));
    }

    [TestCaseSource(nameof(List))]
    public void ChangeToAlreadyExistElementShouldThrowException(List<int> list)
    {
        Assert.Throws<InvalidOperationElementAlreadyExistException>(() => list.ChangeValue(0, 1));
    }
}
