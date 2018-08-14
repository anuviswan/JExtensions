using Microsoft.VisualStudio.TestTools.UnitTesting;
using HT.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT.Extensions.UnitTest
{
    [TestClass()]
    public class IEnumerableShuffleTests
    {
        [TestMethod()]
        public void ShuffleTest_ValidIntArray_ShouldReturnRandomizedArray()
        {
            var inputArray = Enumerable.Range(1, 100);
            var output= inputArray.Shuffle();
            CollectionAssert.AreNotEqual(inputArray.ToList(), output.ToList());
        }

        [TestMethod()]
        public void ShuffleTest_EqualIntArray_ShouldReturnSameArray()
        {
            var inputArray = Enumerable.Repeat(1, 100);
            var output = inputArray.Shuffle();
            CollectionAssert.AreEqual(inputArray.ToList(), output.ToList());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShuffleTest_NullParameter_ShouldThrowArguementNullException()
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