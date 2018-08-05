using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT.Extensions.UnitTest
{
    public partial class IEnumerableTests
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
