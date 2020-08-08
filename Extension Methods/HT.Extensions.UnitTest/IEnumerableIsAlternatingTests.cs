﻿using HT.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HT.Extensions.UnitTest
{
    [TestClass]
    public class IEnumerableAlternatingTests
    {
        [TestMethod]
        public void IsAlternating_TestWithIncreasingDoubleCollection_ReturnFalse()
        {
            var collection = new[] { 1, 2, 3, 4, 5, 6 };
            var result = collection.IsAlternating();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsAlternating_TestWithAlternatingDoubleCollection_ReturnTrue()
        {
            var collection = new[] { 1, 3, 2, 6, 1, 6 };
            var result = collection.IsAlternating();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsAlternating_TestWithEqualValueDoubleCollection_ReturnFalse()
        {
            var collection = new[] { 1, 1, 1, 1, 1, 1, 1 };
            var result = collection.IsAlternating();
            Assert.IsFalse(result);
        }
    }
}
