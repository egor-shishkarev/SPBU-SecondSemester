namespace Calculator.Tests;

public class CalculatorLogicTests
{
    private readonly CalculatorLogic calculatorLogic = new();

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
    public void CalculatorWithoutInputInformationShouldDisplayZeroTest()
    {
        Assert.That(calculatorLogic.DisplayNumber, Is.EqualTo("0"));
    }

    [Test]
    public void NumberWhichAddToCalculatorShouldDisplayTest()
    {
        calculatorLogic.AddElement('3');

        Assert.That(calculatorLogic.DisplayNumber, Is.EqualTo("3"));
    }

    [TestCase("1+1+", "2")]
    [TestCase("1+5-3/3=", "1")]
    [TestCase("100/2*5=", "250")]
    public void SimpleExpressionsShouldReturnExpectedResultTest(string expression, string result)
    {
        AddExpressionInCalculator(expression);

        Assert.That(calculatorLogic.DisplayNumber, Is.EqualTo(result));
    }

    [TestCase("1/0=")]
    [TestCase("1-1/0=")]
    public void DivisionByZeroShouldReturnErrorOnDisplayTest(string expression)
    {
        AddExpressionInCalculator(expression);

        Assert.That(calculatorLogic.DisplayNumber, Is.EqualTo("Error"));
    }

    [TestCase("1+1=====", "6")]
    [TestCase("1*1=====", "1")]
    [TestCase("1+======", "7")]
    public void MultipleOperationShouldReturnExpectedResultTest(string expression, string result)
    {
        AddExpressionInCalculator(expression);

        Assert.That(calculatorLogic.DisplayNumber, Is.EqualTo(result));
    }
}