namespace SparseVector.Tests;

public class SparceVectorTests
{
    public static bool CompareValues(int[] arrayOfInts, SparceVector vector)
    {
        for (int i = 0; i < arrayOfInts.Length; ++i)
        {
            if (vector[i] != arrayOfInts[i])
            {
                return false;
            }
        }
        return true;
    }


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

        Assert.That(CompareValues(arrayOfInts, vector), Is.True);
    }


    [Test]
    public void ChangeElementWithNegativeIndexShouldThrowException()
    {
        var vector = new SparceVector();

        Assert.Throws<ArgumentOutOfRangeException>(() => vector[-1] = 5);
    }

    [Test]
    public void ChangeValueShouldReturnExpectedResult()
    {
        int[] arrayOfInts = new int[] { 0, 0, 1, 0, 0, 5, 0, 0 };
        var vector = new SparceVector(arrayOfInts);
        vector[1] = 2;
        vector[2] = 0;
        vector[3] = 6;
        vector[5] = 0;
        int[] changedArray = new int[] { 0, 2, 0, 6, 0, 0, 0, 0 };
        Assert.That(CompareValues(changedArray, vector), Is.True);
    }

    [Test]
    public void AdditionShouldWorkCorrectly()
    {
        var vector1 = new SparceVector(new int[] { 0, 1, 5, 2, 100, 0, 0, 0, 0, 0, 0 });
        var vector2 = new SparceVector(new int[] );
    }
}