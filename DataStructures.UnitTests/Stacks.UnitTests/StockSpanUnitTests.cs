using DataStructures.Stacks;
using NUnit.Framework;

namespace DataStructures.UnitTests.Stacks.UnitTests
{
    public class StockSpanUnitTests
    {
        [Test]
        [TestCase(new int[] { 4,5,2,25 }, "[5, 25, 25, -1]")]
        [TestCase(new int[] { 13,7,6,12 }, "[-1, 12, 12, -1]")]
        public void NextGreaterElement_WhenCalled_ReturnNextGreaterElements(int[] input, string expectedResult)
        {
            var e = new StockSpan();

            var elements = e.NextGreaterElement(input);
            var result = e.Print(elements);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(new int[] { 4, 5, 2, 25 }, "[5, 25, 25, -1]")]
        [TestCase(new int[] { 13, 7, 6, 12 }, "[-1, 12, 12, -1]")]
        public void NextGreaterElementUsingStackReverseTraversal_WhenCalled_ReturnNextGreaterElements(int[] input, string expectedResult)
        {
            var e = new StockSpan();

            var elements = e.NextGreaterElementUsingStackReverseTraversal(input);
            var result = e.Print(elements);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(new int[] { 1, 1, 1, 2, 2, 2, 2, 11, 3, 3 }, "[2, 2, 2, -1, -1, -1, -1, 3, -1, -1]")]
        [TestCase(new int[] { 1, 1, 2, 3, 4, 2, 1 }, "[-1, -1, 1, 2, 2, 1, -1]")]
        public void NextGreaterFrequency_WhenCalled_ReturnNextGreaterFrequency(int[] input, string expectedResult)
        {
            var e = new StockSpan();

            var elements = e.NextGreaterFrequency(input);
            var result = e.Print(elements);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
