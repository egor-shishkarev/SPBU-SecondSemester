namespace StackCalculatorClass.Tests;

public class StackTests
{
    private readonly float delta = 0.00001F;

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void PushAndPopShouldGiveSameResult()
    {
        var arrayStack = new ArrayStack();
        arrayStack.Push(1);
        arrayStack.Push(2);
        var listStack = new ListStack();
        listStack.Push(3);
        listStack.Push(4);  
        Assert.Multiple(() =>
        {
            Assert.That(Math.Abs(arrayStack.Pop() - 2) < delta);
            Assert.That(Math.Abs(arrayStack.Pop() - 1) < delta);
            Assert.That(Math.Abs(listStack.Pop() - 4) < delta);
            Assert.That(Math.Abs(listStack.Pop() - 3) < delta);
        });
    }

    [Test]
    public void IsEmptyShouldWork()
    {
        var arrayStack = new ArrayStack();
        var listStack = new ListStack();
        Assert.Multiple(() =>
        {
            Assert.That(arrayStack.IsEmpty(), Is.True);
            Assert.That(listStack.IsEmpty(), Is.True);
        });
    }

    [Test]
    public void PopFromEmptyStackShouldThrowException() 
    {
        var arrayStack = new ArrayStack();
        var listStack = new ListStack();
        Assert.Multiple(() =>
        {
            Assert.That(() => arrayStack.Pop(), Throws.Exception);
            Assert.That(() => listStack.Pop(), Throws.Exception);
        });
    }
}