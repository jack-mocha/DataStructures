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
        public void IsBalanced_WhenCalled_ReturnIsBalanced(string input, bool expectedResult)
        {
            var e = new Expression();
            
            var result = e.IsBalanced(input);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("a+b*(c^d-e)^(f+g*h)-i", "abcd^e-fgh*+^*+i-")]
        public void InfixToPostfix_WhenCalled_ReturnPostfix(string input, string expectedResult)
        {
            var e = new Expression();

            var result = e.InfixToPostfix(input);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("*+AB-CD", "((A+B)*(C-D))")]
        [TestCase("*-A/BC-/AKL", "((A-(B/C))*((A/K)-L))")]
        public void PrefixToInfix_WhenCalled_ReturnInfix(string input, string expectedResult)
        {
            var e = new Expression();

            var result = e.PrefixToInfix(input);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("*+AB-CD", "AB+CD-*")]
        [TestCase("*-A/BC-/AKL", "ABC/-AK/L-*")]
        public void PrefixToPostfix_WhenCalled_ReturnPostfix(string input, string expectedResult)
        {
            var e = new Expression();

            var result = e.PrefixToPostfix(input);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("AB+CD-*", "*+AB-CD")]
        [TestCase("ABC/-AK/L-*", "*-A/BC-/AKL")]
        public void PostfixToPrefix_WhenCalled_ReturnPrefix(string input, string expectedResult)
        {
            var e = new Expression();

            var result = e.PostfixToPrefix(input);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("abc++", "(a+(b+c))")]
        [TestCase("ab*c+", "((a*b)+c)")]
        public void PostfixToInfix_WhenCalled_ReturnInfix(string input, string expectedResult)
        {
            var e = new Expression();

            var result = e.PostfixToInfix(input);

            Assert.That(result, Is.EqualTo(expectedResult));
        }


        [Test]
        [TestCase("A*B+C/D", "+*AB/CD")]
        [TestCase("(A-B/C)*(A/K-L)", "*-A/BC-/AKL")]
        [TestCase("(A-B^C)*(A/K-L)", "*-A^BC-/AKL")]
        public void InfixToPrefix_WhenCalled_ReturnPrefix(string input, string expectedResult)
        {
            var e = new Expression();

            var result = e.InfixToPrefix(input);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}