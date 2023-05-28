namespace Calculator.Tests;

public class CalculatorTests
{
    readonly CalculatorLogic calculatorLogic = new();

    private readonly float delta = 0.0001f;
    private void AddExpressionInCalculator(string expression)
    {
        foreach (var symbol in expression)
        {
            calculatorLogic.AddElement(symbol);
        }
    }

    [TearDown]
    public void TearDown()
    {
        calculatorLogic.ClearDisplay();
    }

    [Test]
    public void CalculatorWithoutInputInformationShouldDisplayZero()
    {
        Assert.That(calculatorLogic.DisplayNumber, Is.EqualTo("0"));
    }

    [Test]
    public void NumberWhichAddToCalculatorShouldDisplay()
    {
        calculatorLogic.AddElement('3');

        Assert.That(calculatorLogic.DisplayNumber, Is.EqualTo("3"));
    }

    [TestCase("1+1+", "2")]
    [TestCase("1+5-3/3=", "1")]
    [TestCase("100/2*5=", "250")]
    public void SimpleExpressionsShouldReturnExpectedResult(string expression, string result)
    {
        AddExpressionInCalculator(expression);

        Assert.That(calculatorLogic.DisplayNumber, Is.EqualTo(result));
    }

    [TestCase("1/0=")]
    [TestCase("1-1/0=")]
    public void DivisionByZeroShouldReturnErrorOnDisplay(string expression)
    {
        AddExpressionInCalculator(expression);

        Assert.That(calculatorLogic.DisplayNumber, Is.EqualTo("Error"));
    }

    [TestCase("1+1=====", "6")]
    [TestCase("1*1=====", "1")]
    [TestCase("1+======", "7")]
    public void MultipleOperationShouldReturnExpectedResult(string expression, string result)
    {
        AddExpressionInCalculator(expression);

        Assert.That(calculatorLogic.DisplayNumber, Is.EqualTo(result));
    }

    [TestCase("0,85+0,15=", 1f)]
    public void OperationWithFloatNumbersShouldReturnExpectedResult(string expression, float result)
    {
        AddExpressionInCalculator(expression);
        float.TryParse(calculatorLogic.DisplayNumber, out float number);

        Assert.That(Math.Abs(number - result), Is.LessThan(delta));
    }
}