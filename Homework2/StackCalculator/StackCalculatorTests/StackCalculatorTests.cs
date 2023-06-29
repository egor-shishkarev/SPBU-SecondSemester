using System.Runtime.CompilerServices;

namespace StackCalculatorClass.Tests;

public class Tests
{

    private readonly float delta = 0.00001F;

    [SetUp]
    public void Setup()
    {
    }

    private static IEnumerable<TestCaseData> StackCalculators
        => new TestCaseData[]
    {
            new TestCaseData(new StackCalculator(new ArrayStack())),
            new TestCaseData(new StackCalculator(new ListStack())),
    };

    [TestCaseSource(nameof(StackCalculators))]
    public void ExpressionShouldCalculateRight(StackCalculator stackCalculator)
    {
        var expression = "1 2 + 3 *";

        Assert.That(Math.Abs(stackCalculator.CalculateExpression(expression).result - 9), Is.LessThan(delta));
    }

    [TestCaseSource(nameof(StackCalculators))]
    public void ExpressionWithDivisionByZeroShouldReturnFalseArgument(StackCalculator stackCalculator)
    {
        var expression = "1 2 + 0 /";

        Assert.That(stackCalculator.CalculateExpression(expression).notDivisionByZero, Is.False);
    }

    [TestCaseSource(nameof(StackCalculators))]
    public void IncorrectExpressionShouldThrowException(StackCalculator stackCalculator)
    {
        var expression = "1 +";

        Assert.That(() => stackCalculator.CalculateExpression(expression), Throws.InvalidOperationException);
    }

    [TestCaseSource(nameof(StackCalculators))]
    public void UnexpectedSymbolInExpressionShouldThrowException(StackCalculator stackCalculator)
    {
        var expression = "A 2 +";

        Assert.That(() => stackCalculator.CalculateExpression(expression), Throws.ArgumentException);
    }

    [TestCaseSource(nameof(StackCalculators))]
    public void NullStringShouldThrowException(StackCalculator stackCalculator)
    {
        string? expression = null;

        Assert.That(() => stackCalculator.CalculateExpression(expression!), Throws.ArgumentNullException);
    }

    [TestCaseSource(nameof(StackCalculators))]
    public void EmptyStringShouldThrowException(StackCalculator stackCalculator)
    {
        string? expression = string.Empty;

        Assert.That(() => stackCalculator.CalculateExpression(expression), Throws.ArgumentException);
    }
}