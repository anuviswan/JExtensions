using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HT.Extensions.UnitTest
{
    [TestClass]
    public class IEnumerableIncreasingTests
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


        [TestMethod]
        public void IsIncreasing_TestWithIncreasingCharCollection_ReturnTrue()
        {
            var collection = new[] { 'a', 'b','c','d','e','f' };
            var result = collection.IsIncreasing();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsIncreasing_TestWithNonIncreasingCharCollection_ReturnFalse()
        {
            var collection = new[] { 'a', 'c', 'b',  'e', 'd', 'f' };
            var result = collection.IsIncreasing();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsIncreasing_TestWithEqualValueCharCollection_ReturnFalse()
        {
            var collection = new[] { 'a','a','a','a' };
            var result = collection.IsIncreasing();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsIncreasing_TestWithDecreasingCharCollection_ReturnFalse()
        {
            var collection = new[] { 'f','e','d','c','b','a' };
            var result = collection.IsIncreasing();
            Assert.IsFalse(result);
        }
    }
}
