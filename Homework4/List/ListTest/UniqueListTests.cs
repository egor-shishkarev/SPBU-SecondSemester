namespace Lists.Tests;

public class UniqueListTests
{
    UniqueList<int> list;

    [SetUp]
    public void Setup()
    {
        list = new UniqueList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);
    }

    [Test]
    public void TryingToAddAlreadyExistElementShouldThrowException()
    {
        Assert.Throws<InvalidOperationElementAlreadyExistException>(() => list.Add(1));
    }

    [Test]
    public void TryingToChangeValueToAlreadyExistShouldThrowException()
    {
        Assert.Throws<InvalidOperationElementAlreadyExistException>(() => list.ChangeValue(0, 5));
    }

    [Test]
    public void TryingToRemoveElementWhichNotExistInListShouldThrowException()
    {
        Assert.Throws<InvalidOperationRemoveNonexistentElementException>(() => list.RemoveByValue(6));
    }
}
