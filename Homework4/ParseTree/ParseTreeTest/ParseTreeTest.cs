namespace Trees.Test;

public class ParseTreeTest
{
    const double delta = 0.00001F;

    [TestCase("(* (+ 1 1) 2)", 4)]
    [TestCase("(/ (+ (* 7 4) (- 3 3)) (+ 1 (* 7 3)))", 1.27272F)]
    public void ExpressionShouldCalculateRight(string expression, double expectedResult)
    {
        var parseTree = new ParseTree(expression);
        var result = parseTree.Calculate();
        Assert.That(Math.Abs(result - expectedResult) < delta && parseTree.StringRepresentation == expression);
    }

    [TestCase("(/ 1 0)")]
    [TestCase("(+ (+ 9 4) (/ (* 4 5) (- 1 1)))")]
    public void DivisonByZeroShouldThrowException(string expression)
    {
        var parseTree = new ParseTree(expression);
        Assert.Throws<DivideByZeroException>(() => parseTree.Calculate());
    }

    [TestCase("(+ 1 1")]
    [TestCase("(+ 1 1)  )")]
    [TestCase("(+ 1 (* (- 4 5) (* 1 2))")]
    public void WrongBalanceOfBracketsShouldThrowException(string expression)
    {
        Assert.Throws<ArgumentException>(() => new ParseTree(expression));
    }

    [TestCase("(& 1 1)")]
    [TestCase("(+ a 1)")]
    [TestCase("(* (+ 1 1) (/ 0 f))")]
    public void UnexpectedSymbolInExpressionShouldThrowException(string expression)
    {
        Assert.Throws<ArgumentException>(() => new ParseTree(expression));
    }

    [TestCase(" (+ 1 1)")]
    [TestCase("( + 1 1)")]
    [TestCase("(+  1 1)")]
    [TestCase("(+ 1  1)")]
    public void ExpressionsAreNotBasedOnATemplateShouldThrowException(string expression)
    {
        Assert.Throws<ArgumentException>(() => new ParseTree(expression));
    }

    [TestCase("(+ 1")]
    [TestCase("(+ 1 )")]
    [TestCase("(* 1 ())")]
    [TestCase("(* (+ 1)")]
    public void IncompleteExpressionsShouldThrowException(string expression)
    {
        Assert.Throws<ArgumentException>(() => new ParseTree(expression));
    }
}