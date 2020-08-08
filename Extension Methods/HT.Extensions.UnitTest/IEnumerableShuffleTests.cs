using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HT.Extensions.UnitTest
{
    [TestClass()]
    public class IEnumerableShuffleTests
    {
        [TestMethod()]
        public void ShuffleTest_ForValidIntArray_ShouldReturnRandomizedArray()
        {
            var inputArray = Enumerable.Range(1, 100);
            var output= inputArray.Shuffle();
            CollectionAssert.AreNotEqual(inputArray.ToList(), output.ToList());
        }

        [TestMethod()]
        public void ShuffleTest_ForRandomArrayWithRepeatedNumbers_ShouldReturnRandomizedArray()
        {
            var inputArray = Enumerable.Range(1, 100).Concat(Enumerable.Range(1,10));
            var output = inputArray.Shuffle();
            CollectionAssert.AreNotEqual(inputArray.ToList(), output.ToList());
        }


        [TestMethod()]
        public void ShuffleTest_ForRandomArrayWithAllNumbersSame_ShouldReturnSameArray()
        {
            var inputArray = Enumerable.Repeat(1, 100);
            var output = inputArray.Shuffle();
            CollectionAssert.AreEqual(inputArray.ToList(), output.ToList());
        }

        [TestMethod()]
        public void ShuffleTest_ForSingleElementIntArray_ShouldReturnSameInt()
        {
            var inputArray = new[] { new Random().Next(1, 100) };
            var output = inputArray.Shuffle();
            CollectionAssert.AreEqual(inputArray.ToList(), output.ToList());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShuffleTest_ForNullParameter_ShouldThrowArguementNullException()
        {
            IList<int> inputArray = null;
            var output = inputArray.Shuffle();
        }


        [TestMethod()]
        public void ShuffleTest_EmptyCollection_ShouldReturnEmptyCollection()
        {
            var inputArray = Enumerable.Empty<int>();
            var output = inputArray.Shuffle();
            CollectionAssert.Equals(output, Enumerable.Empty<int>());
        }
    }
}