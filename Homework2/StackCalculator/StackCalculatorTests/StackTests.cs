namespace StackCalculatorClass.Tests;

public class StackTests
{
    private readonly float delta = 0.00001F;

    [SetUp]
    public void Setup()
    {
    }

    private static IEnumerable <TestCaseData> Stacks
        => new TestCaseData[]
    {
        new TestCaseData(new ArrayStack()),
        new TestCaseData(new ListStack()),
    };

    [TestCaseSource(nameof(Stacks))]  
    public void PushAndPopShouldGiveSameResult(IStack stack)
    {
        stack.Push(1);
        stack.Push(2); 
        Assert.That(Math.Abs(stack.Pop() - 2), Is.LessThan(delta));

    }

    [TestCaseSource(nameof(Stacks))]
    public void IsEmptyShouldWork(IStack stack)
    {
        Assert.That(stack.IsEmpty(), Is.True);
    }

    [TestCaseSource(nameof(Stacks))]
    public void PopFromEmptyStackShouldThrowException(IStack stack) 
    {
        Assert.That(stack.Pop, Throws.InvalidOperationException);
    }
}