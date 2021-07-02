using DataStructures.Stacks;
using NUnit.Framework;

namespace DataStructures.UnitTests.Stacks.UnitTests
{
    public class ExpressionUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("(1 + 2)", true)]
        [TestCase("1 + 2", true)]
        [TestCase("(1 + 2", false)]
        [TestCase("((1 + 2)", false)]
        [TestCase(")1 + 2(", false)]
        [TestCase("(1 + 2]", false)]
        [TestCase("(1 + 2>", false)]
        [TestCase("(1 + 2}", false)]
        public void Test1(string input, bool expectedResult)
        {
            var e = new Expression();
            
            var result = e.IsBalanced(input);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}