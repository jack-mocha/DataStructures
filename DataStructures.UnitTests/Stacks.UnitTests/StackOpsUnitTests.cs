using DataStructures.Stacks;
using NUnit.Framework;

namespace DataStructures.UnitTests.Stacks.UnitTests
{
    public class StackOpsUnitTests
    {
        [Test]
        [TestCase(new int[] { 5, 1, 2, 3, 4 }, true)]
        [TestCase(new int[] { 5, 1, 2, 6, 3, 4 }, false)]
        [TestCase(new int[] { 3, 2, 1 }, true)]
        [TestCase(new int[] { 2, 3, 1 }, false)]
        [TestCase(new int[] { 4, 1, 2, 3 }, true)]
        public void IsStackSortable_WhenCalled_ReturnIsSortable(int[] input, bool expectedResult)
        {
            var e = new StackOps();

            var isSortable = e.IsStackSortable(input);
            var result = isSortable;

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
