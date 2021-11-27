using DataStructures.HashTables;
using NUnit.Framework;
using System;

namespace DataStructures.UnitTests.HashTables.UnitTests
{
    public class SetUnitTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new int[] { 11, 1, 13, 21, 3, 7 }, new int[] { 11, 3, 7, 1 }, true)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 4 }, true)]
        [TestCase(new int[] { 10, 5, 2, 23, 19 }, new int[] { 19, 5, 3 }, false)]
        public void IsSubSet_CompareTwoArrays_ReturnIsSubSet(int[] arr1, int[] arr2, bool expectedResult)
        {
            var set = new Set();

            var result = set.IsSubSet(arr1, arr2);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}