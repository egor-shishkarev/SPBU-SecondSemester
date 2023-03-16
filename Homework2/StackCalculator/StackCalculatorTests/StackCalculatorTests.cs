namespace StackCalculatorClass.Tests;

public class Tests
{

    private readonly float delta = 0.00001F;

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ExpressionShouldCalculateRight()
    {
        var arrayStack = new ArrayStack();
        var listStack = new ListStack();
        var stackCalculatorByArray = new StackCalculator(arrayStack);
        var stackCalculatorByList = new StackCalculator(listStack);
        var expression = "1 2 + 3 *";

        Assert.Multiple(() =>
        {
            Assert.That(Math.Abs(stackCalculatorByArray.CalculateExpression(expression).result - 9) < delta);
            Assert.That(Math.Abs(stackCalculatorByList.CalculateExpression(expression).result - 9) < delta);
        });
    }

    [Test] 
    public void ExpressionWithDivisionByZeroShouldReturnFalseArgument()
    {
        var arrayStack = new ArrayStack();
        var listStack = new ListStack();
        var stackCalculatorByArray = new StackCalculator(arrayStack);
        var stackCalculatorByList = new StackCalculator(listStack);
        var expression = "1 0 /";

        Assert.Multiple(() =>
        {
            Assert.That(stackCalculatorByArray.CalculateExpression(expression).notDivisionByZero, Is.False);
            Assert.That(stackCalculatorByList.CalculateExpression(expression).notDivisionByZero, Is.False);
        });
    }

    [Test] 
    public void IncorrectExpressionShouldThrowException()
    {
        var arrayStack = new ArrayStack();
        var listStack = new ListStack();
        var stackCalculatorByArray = new StackCalculator(arrayStack);
        var stackCalculatorByList = new StackCalculator(listStack);
        var expression = "1 +";

        Assert.Multiple(() =>
        {
            Assert.That(() => stackCalculatorByArray.CalculateExpression(expression), Throws.Exception);
            Assert.That(() => stackCalculatorByList.CalculateExpression(expression), Throws.Exception);
        });
    }

    [Test]
    public void UnexpectedSymbolInExpressionShouldThrowException()
    {
        var arrayStack = new ArrayStack();
        var listStack = new ListStack();
        var stackCalculatorByArray = new StackCalculator(arrayStack);
        var stackCalculatorByList = new StackCalculator(listStack);
        var expression = "A 2 +";

        Assert.Multiple(() =>
        {
            Assert.That(() => stackCalculatorByArray.CalculateExpression(expression), Throws.Exception);
            Assert.That(() => stackCalculatorByList.CalculateExpression(expression), Throws.Exception);
        });
    }
}