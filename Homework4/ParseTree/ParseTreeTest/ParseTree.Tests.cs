namespace Trees.Test;

public class ParseTreeTests
{
    const double delta = 0.00001F;

    [TestCase("(* (+ 1 1) 2)", 4)]
    [TestCase("(/ (+ (* 7 4) (- 3 3)) (+ 1 (* 7 3)))", 1.27272F)]
    [TestCase("(- (/ (- (* (- 1 10) (/ 5 2)) (/ 100 5)) 10) 7)", -11.25F)]
    public void ExpressionShouldCalculateRightTest(string expression, double expectedResult)
    {
        var parseTree = new ParseTree(expression);
        var result = parseTree.Calculate();
        Assert.That(Math.Abs(result - expectedResult) < delta && parseTree.StringRepresentation == expression);
    }

    [TestCase("(/ 1 0)")]
    [TestCase("(+ (+ 9 4) (/ (* 4 5) (- 1 1)))")]
    public void DivisonByZeroShouldThrowExceptionTest(string expression)
    {
        var parseTree = new ParseTree(expression);
        Assert.Throws<DivideByZeroException>(() => parseTree.Calculate());
    }

    [TestCase("(+ 1 1")]
    [TestCase("(+ 1 1)  )")]
    [TestCase("(+ 1 (* (- 4 5) (* 1 2))")]
    public void WrongBalanceOfBracketsShouldThrowExceptionTest(string expression)
    {
        Assert.Throws<ArgumentException>(() => new ParseTree(expression));
    }

    [TestCase("(& 1 1)")]
    [TestCase("(+ a 1)")]
    [TestCase("(* (+ 1 1) (/ 0 f))")]
    public void UnexpectedSymbolInExpressionShouldThrowExceptionTest(string expression)
    {
        Assert.Throws<ArgumentException>(() => new ParseTree(expression));
    }

    [TestCase(" (+ 1 1)")]
    [TestCase("( + 1 1)")]
    [TestCase("(+  1 1)")]
    [TestCase("(+ 1  1)")]
    public void ExpressionsAreNotBasedOnATemplateShouldThrowExceptionTest(string expression)
    {
        Assert.Throws<ArgumentException>(() => new ParseTree(expression));
    }

    [TestCase("(+ 1")]
    [TestCase("(+ 1 )")]
    [TestCase("(* 1 ())")]
    [TestCase("(* (+ 1)")]
    public void IncompleteExpressionsShouldThrowExceptionTest(string expression)
    {
        Assert.Throws<ArgumentException>(() => new ParseTree(expression));
    }

    [Test]
    public void TryingToCreateParseTreeWithNullOrEmptyShouldThrowExceptionTest()
    {
        var emptyString = "";
        string? nullString = null;

        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentNullException>(() => new ParseTree(nullString!));
            Assert.Throws<ArgumentException>(() => new ParseTree(emptyString));
        });
    }
}