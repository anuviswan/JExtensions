using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT.Extensions.UnitTest
{
    [TestClass]
    public class IEnumerableIsIncreasing
    {
        [TestMethod]
        public void IsIncreasing_TestWithIncreasingDoubleCollection_ReturnTrue()
        {
            var collection = new[] { 1, 2, 3, 4, 5, 6 };
            var result = collection.IsIncreasing();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsIncreasing_TestWithNonIncreasingDoubleCollection_ReturnFalse()
        {
            var collection = new[] { 1, 3, 2, 6, 1, 6 };
            var result = collection.IsIncreasing();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsIncreasing_TestWithEqualValueDoubleCollection_ReturnFalse()
        {
            var collection = new[] { 1,1,1,1,1,1,1 };
            var result = collection.IsIncreasing();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsIncreasing_TestWithDecreasingDoubleCollection_ReturnFalse()
        {
            var collection = new[] { 6,5,4,3,2,1 };
            var result = collection.IsIncreasing();
            Assert.IsFalse(result);
        }
    }
}
