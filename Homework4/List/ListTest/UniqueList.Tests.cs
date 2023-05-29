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
    public void TryingToAddAlreadyExistElementShouldThrowExceptionTest()
    {
        Assert.Throws<InvalidOperationElementAlreadyExistsException>(() => list.Add(1));
    }

    [Test]
    public void TryingToChangeValueToAlreadyExistShouldThrowExceptionTest()
    {
        Assert.Throws<InvalidOperationElementAlreadyExistsException>(() => list.ChangeValue(0, 5));
    }

    [Test]
    public void TryingToRemoveElementWhichNotExistInListShouldThrowExceptionTest()
    {
        Assert.Throws<InvalidOperationRemoveNonexistentElementException>(() => list.RemoveByValue(6));
    }
}
