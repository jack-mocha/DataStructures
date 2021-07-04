using DataStructures.Stacks;
using NUnit.Framework;

namespace DataStructures.UnitTests.Stacks.UnitTests
{
    public class StackArrayUnitTests
    {
        private StackArray stk;

        [SetUp]
        public void Setup()
        {
            stk = new StackArray(3);
        }

        [Test]
        [TestCase(new int[] { 1 }, "[1]")]
        [TestCase(new int[] { 1, 2, 3, 4 }, "[1, 2, 3, 4]")]
        public void Push_WhenCalled_PushItemToStack(int[] items, string expectedResult)
        {
            foreach (var i in items)
                stk.Push(i);

            var result = stk.ToString();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { }, "[1, 2]")]
        [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { }, "[]")]
        [TestCase(new int[] { 1, 2, 3, 4 }, 3, new int[] { 5 }, "[1, 5]")]
        public void Pop_WhenCalled_PopItemFromStack(int[] items, int timesToPop, int[] secondWavePush, string expectedResult)
        {
            foreach (var i in items)
                stk.Push(i);

            for (int i = 0; i < timesToPop; i++)
                stk.Pop();

            foreach (var i in secondWavePush)
                stk.Push(i);

            var result = stk.ToString();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3 }, 4)]
        public void Pop_WhenStackIsEmpty_ThrowInvalidOperationException(int[] items, int timesToPop)
        {
            foreach (var i in items)
                stk.Push(i);

            for (int i = 0; i < timesToPop - 1; i++)
                stk.Pop();


            Assert.That(() => stk.Pop(), Throws.InvalidOperationException);
        }
    }
}
