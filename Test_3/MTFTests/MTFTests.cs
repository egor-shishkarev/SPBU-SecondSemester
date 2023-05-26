using MTF;

namespace MTFTests
{
    public class Tests
    {
        [TestCase("banana", new int[] { 1, 1, 13, 1, 1, 1 })]
        [TestCase("Ababa", new int[] { 26, 2, 2, 1, 1 })]
        [TestCase("ololo123,", new int[] { 14, 12, 1, 1, 1, 69, 70, 71, 67 })]
        public void EncodeShouldReturnExpectedResult(string inputString, int[] expectedResult)
        {

            Assert.That(MTFEncoding.Encode(inputString), Is.EqualTo(expectedResult));
        }

        [TestCase("·¿Ì¿Ì")]
        [TestCase("π")]
        public void UnexpectedSymbolShouldThrowException(string inputString)
        {
            Assert.Throws<ArgumentException>(() => MTFEncoding.Encode(inputString));
        }

        [Test]
        public void EmptyOrNullStringShouldThrowException()
        {
            string empty = "";
            string? nullString = null;
            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentNullException>(() => MTFEncoding.Encode(empty));
                Assert.Throws<ArgumentNullException>(() => MTFEncoding.Encode(nullString!));
            });
        } 
    }
}