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
    }
}
