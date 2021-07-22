using DataStructures.Stacks;
using NUnit.Framework;
using System;

namespace DataStructures.UnitTests.Stacks.UnitTests
{
    public class DoubleStackUnitTests
    {
        private DoubleStackArray stk;

        [SetUp]
        public void Setup()
        {
            stk = new DoubleStackArray(4);
        }

        [Test]
        [TestCase(new int[] { 1, 2 }, "[1, 2], [1, 2]")]
        public void Push1Push2_FillTheArray_ReturnAllContent(int[] items, string expectedResult)
        {
            foreach (var i in items)
                stk.Push1(i);

            foreach (var i in items)
                stk.Push2(i);

            var result = stk.ToString();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Push1Push2_WhenStk1OverlapWithStk2_ThrowsStackOverflowException()
        {
            stk.Push1(1);
            stk.Push1(2);
            stk.Push2(1);
            stk.Push2(2);

            Assert.That(() => stk.Push1(3), Throws.TypeOf<StackOverflowException>());
        }
    }
}