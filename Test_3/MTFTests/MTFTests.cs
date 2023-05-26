using MTF;

namespace MTFTests
{
    public class Tests
    {
        [TestCase("banana")]
        [TestCase("Ababa")]
        public void EncodeShouldReturnExpectedResult(string inputString)
        {
            var expectedResult = new int[] { 1, 1, 13, 1, 1, 1 };

            Assert.That(MTFEncoding.Encode(inputString), Is.EqualTo(expectedResult));
        }
    }
}