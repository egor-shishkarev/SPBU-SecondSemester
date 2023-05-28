namespace LZW.Tests;

public class Tests
{
    [TestCase("..\\..\\..\\..\\LZWTests\\TestFiles\\example.txt")]
    [TestCase("..\\..\\..\\..\\LZWTests\\TestFiles\\Program.exe")]
    [TestCase("..\\..\\..\\..\\LZWTests\\TestFiles\\tihiy-don.txt")]
    public void CompressAndDecompressShouldBeTheSame(string filePath)
    {
        var originalBytes = File.ReadAllBytes(filePath);
        Archiver.Compress(filePath);
        Archiver.Decompress(filePath + ".zipped");
        var newBytes = File.ReadAllBytes(filePath);

        Assert.That(originalBytes, Is.EqualTo(newBytes));
    }

    [Test]
    public void TryingToCompressFileThatDoesNotExistShouldThrowArgumentException()
    {
        Assert.That(() => Archiver.Compress("..\\..\\..\\..\\LZWTests\\TestFiles\\DoesNotExist.txt"), Throws.ArgumentException);
    }

    [Test]
    public void TryingToDecompressFileThatDoesNotExistShouldThrowArgumentException()
    {
        Assert.That(() => Archiver.Decompress("..\\..\\..\\..\\LZWTests\\TestFiles\\DoesNotExist.txt"), Throws.ArgumentException);
    }

    [Test]
    public void TryingToCompressEmptyFileShouldThrowArgumentException()
    {
        Assert.That(() => Archiver.Compress("..\\..\\..\\..\\LZWTests\\TestFiles\\empty.txt"), Throws.ArgumentException);
    }

    [Test]
    public void TryingToDecompressEmptyFileShouldThrowArgumentException()
    {
        Assert.That(() => Archiver.Decompress("..\\..\\..\\..\\LZWTests\\TestFiles\\empty.txt"), Throws.ArgumentException);
    }
}