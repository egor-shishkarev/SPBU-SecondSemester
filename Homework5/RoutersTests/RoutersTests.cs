namespace Routers.Tests;

using static Routers.RoutersTopology;
public class RoutersTests
{
    [TestCase("WithoutColon.txt")]
    [TestCase("WithoutComma.txt")]
    [TestCase("WithoutParenthesis.txt")]
    [TestCase("WithoutSpaceAfterColon.txt")]
    [TestCase("WithoutSpaceAfterComma.txt")]
    [TestCase("WithoutSpaceAfterRouterName.txt")]
    [TestCase("WithUnnecessarySpaceInBandwidth.txt")]
    public void WrongExpressionsInConnectionsShouldThrowException(string filePath)
    {
        var path = "../../../TestFiles/" + filePath;
        var output = path[..path.IndexOf('.')] + "Result.txt";
        
        Assert.Throws<WrongExpressionException>(() => CreateOptimalConfiguration(File.ReadAllLines(path), output));
    }

    [Test]
    public void DisconnectedGraphShouldThrowException()
    {
        Assert.Throws<DisconnectedGraphException>(() => CreateOptimalConfiguration(File.ReadAllLines("../../../TestFiles/DisconnectedGraph.txt"), "../../../TestFiles/DisconnectedGraphResult.txt"));
    }

    [TestCase("RightConnection.txt", "RightConnectionResult.txt")]
    [TestCase("ComplicatedConnection.txt", "ComplicatedConnectionResult.txt")]
    public void CreateOptimalConfigurstionShouldCreateExpectedResults(string inputFile, string outputFile)
    {
        var inputPath = "../../../TestFiles/" + inputFile;
        var outputPath = "../../../TestFiles/" + outputFile;
        CreateOptimalConfiguration(File.ReadAllLines(inputPath), inputPath[..inputPath.IndexOf('.')] + "Res.txt");

        Assert.That(File.ReadAllBytes(outputPath), Is.EqualTo(File.ReadAllBytes(inputPath[..inputPath.IndexOf('.')] + "Res.txt")));
    }
}