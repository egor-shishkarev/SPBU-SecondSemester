namespace SparseVector.Tests;

public class SparceVectorTests
{
    [Test]
    public void CreateSparceVectorWithNullsArrayMustBeNull()
    {
        var vector = new SparceVector();

        Assert.That(vector.IsNull(), Is.True);
    }

    [Test] 
    public void CreateSparceVectorShouldReturnExpectedResult()
    {
        int[] arrayOfInts = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 3, 0, 0, 0, 7, 0, 4, 0, 0, 0 };
        var vector = new SparceVector(arrayOfInts);

        Assert.Multiple(() =>
        {
            Assert.That(vector[0], Is.EqualTo(1));
            Assert.That(vector[10], Is.EqualTo(5));
            Assert.That(vector[11], Is.EqualTo(3));
            Assert.That(vector[15], Is.EqualTo(7));
            Assert.That(vector[17], Is.EqualTo(4));
        });
    }

    [Test]
    public void TryToChange 
}