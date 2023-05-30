namespace MapFilterFold.Tests;

public class MapFilterFoldTests
{

    [Test]
    public void MapWithIntFunctionShouldReturnExpectedResultsTest()
    {
        var listOfElements = new List<int> { 1, 2, 3 };
        var function = (int x) => x * 2;
        var expectedResult = new List<int> { 2, 4, 6 };

        Assert.That(CustomMethods.Map(listOfElements, function), Is.EqualTo(expectedResult));
    }

    [Test]
    public void MapWithStringFunctionShoulfReturnExpectedResultTest()
    {
        var listOfElements = new List<int> { 1, 2, 3 };
        var function = (int x) => x.ToString() + "0" + x.ToString();
        var expectedResult = new List<string> { "101", "202", "303" };

        Assert.That(CustomMethods.Map(listOfElements, function), Is.EqualTo(expectedResult));
    }

    [Test]
    public void MapWithEmptyListShouldReturnEmptyListTest()
    {
        var listOfElements = new List<int>();
        var function = (int x) => x + 1;

        Assert.That(CustomMethods.Map(listOfElements, function), Is.EqualTo(new List<int>()));
    }

    [Test]
    public void MapWithNullListShouldThrowArgumentNullExceptionTest()
    {
        List<int>? listOfElements = null;
        var function = (int x) => x + 1;

        Assert.Throws<ArgumentNullException>(() => CustomMethods.Map(listOfElements!, function));
    }

    [Test]
    public void MapWithNullFunctionShouldThrowArgumentNullExceptionTest()
    {
        var listOfElements = new List<int>() { 1, 2, 3 };
        Func<int, int>? function = null;

        Assert.Throws<ArgumentNullException>(() => CustomMethods.Map(listOfElements, function!));
    }

    [Test]
    public void FilterWithIntFunctionShouldReturnExpectedResultTest()
    {
        var listOfElements = new List<int> { 4, -4, 2, 0, -5, -1 };
        var function = (int x) => x > 0;
        var expectedResult = new List<int> { 4, 2 };

        Assert.That(CustomMethods.Filter(listOfElements, function), Is.EqualTo(expectedResult));
    }

    [Test]
    public void FilterWithStringFunctionShouldReturnExpectedResultTest()
    {
        var listOfElements = new List<string> { "Hello", "World", "!", "False", "True" };
        var function = (string x) => x.Contains('l');
        var expectedResult = new List<string> { "Hello", "World", "False" };

        Assert.That(CustomMethods.Filter(listOfElements, function), Is.EqualTo(expectedResult));
    }

    [Test]
    public void FilterWithEmptyListShouldReturnEmptyListTest()
    {
        var listOfElements = new List<int>();
        var function = (int x) => x % 7 == 0;

        Assert.That(CustomMethods.Filter(listOfElements, function), Is.EqualTo(new List<int>()));
    }


    [Test]
    public void FilterWithNullListShouldThrowArgumentNullExceptionTest()
    {
        List<int>? listOfElements = null;
        var function = (int x) => x % 7 == 0;

        Assert.Throws<ArgumentNullException>(() => CustomMethods.Filter(listOfElements!, function));
    }

    [Test]
    public void FilterWithNullFunctionShouldThrowArgumentNullExceptionTest()
    {
        var listOfElements = new List<int>() { 1, 2, 3 };
        Func<int, bool>? function = null;

        Assert.Throws<ArgumentNullException>(() => CustomMethods.Filter(listOfElements, function!));
    }

    [Test]
    public void FoldWithIntFunctionShouldReturnExpectedResultTest()
    {
        var listOfElements = new List<int> { 1, 2, 3, 4, 5, 6};
        var accumulator = 1;
        var function = (int acc, int x) => acc * x; 
        var expectedResult = 720;

        Assert.That(CustomMethods.Fold(listOfElements, accumulator, function), Is.EqualTo(expectedResult));
    }

    [Test]
    public void FoldWithStringFunctionShouldReturnExpectedResultTest()
    {
        var listOfElements = new List<string> { "He", "llo", " " , "Wor", "l", "d!" };
        var accumulator = "";
        var function = (string acc, string x) => acc + x;
        var expectedResult = "Hello World!";

        Assert.That(CustomMethods.Fold(listOfElements, accumulator, function), Is.EqualTo(expectedResult));
    }

    [Test]
    public void FoldWithEmptyListShouldReturnAccumulatorValueTest()
    {
        var listOfElements = new List<int>();
        var accumulator = 2;
        var function = (int acc, int x) => acc + x;

        Assert.That(CustomMethods.Fold(listOfElements, accumulator, function), Is.EqualTo(accumulator));
    }

    [Test]
    public void FoldWithNullListShouldThrowArgumentNullExceptionTest()
    {
        List<int>? listOfElements = null;
        var accumulator = 2;
        var function = (int acc, int x) => acc + x;

        Assert.Throws<ArgumentNullException>(() => CustomMethods.Fold(listOfElements!, accumulator, function));
    }

    [Test]
    public void FoldWithNullFunctionShouldThrowArgumentNullExceptionTest()
    {
        var listOfElements = new List<int>() { 1, 2, 3 };
        var accumulator = 2;
        Func<int, int, int>? function = null;

        Assert.Throws<ArgumentNullException>(() => CustomMethods.Fold(listOfElements, accumulator, function!));
    }
}