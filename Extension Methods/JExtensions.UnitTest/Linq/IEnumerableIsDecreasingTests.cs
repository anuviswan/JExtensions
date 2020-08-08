using JExtensions.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace JExtensions.UnitTest.Linq
{
    public class IEnumerableIsDecreasingTests
    {
        [Theory]
        [MemberData(nameof(ValidElementsTestData))]
        public void IsDecreasing_ValidElements(IEnumerable<int> testData,bool expectedResult)
        {
            var result = testData.IsDecreasing();
            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> ValidElementsTestData
        {
            get
            {
                yield return new object[] { new[] { 1, 2, 3, 4, 5 }, true };
            }
        }
       

        [Fact]
        public void IsDecreasing_TestWithIncreasingDoubleCollection_ReturnFalse()
        {
            var collection = new[] { 1, 2, 3, 4, 5, 6 };
            var result = collection.IsDecreasing();
            Assert.False(result);
        }

        [Fact]
        public void IsDecreasing_TestWithNonIncreasingDoubleCollection_ReturnFalse()
        {
            var collection = new[] { 1, 3, 2, 6, 1, 6 };
            var result = collection.IsDecreasing();
            Assert.False(result);
        }

        [Fact]
        public void IsDecreasing_TestWithEqualValueDoubleCollection_ReturnFalse()
        {
            var collection = new[] { 1, 1, 1, 1, 1, 1, 1 };
            var result = collection.IsDecreasing();
            Assert.False(result);
        }

        [Fact]
        public void IsDecreasing_TestWithDecreasingDoubleCollection_ReturnTrue()
        {
            var collection = new[] { 6, 5, 4, 3, 2, 1 };
            var result = collection.IsDecreasing();
            Assert.True(result);
        }


        [Fact]
        public void IsDecreasing_TestWithIncreasingCharCollection_ReturnFalse()
        {
            var collection = new[] { 'a', 'b', 'c', 'd', 'e', 'f' };
            var result = collection.IsDecreasing();
            Assert.False(result);
        }

        [Fact]
        public void IsDecreasing_TestWithNonIncreasingCharCollection_ReturnFalse()
        {
            var collection = new[] { 'a', 'c', 'b', 'e', 'd', 'f' };
            var result = collection.IsDecreasing();
            Assert.False(result);
        }

        [Fact]
        public void IsDecreasing_TestWithEqualValueCharCollection_ReturnFalse()
        {
            var collection = new[] { 'a', 'a', 'a', 'a' };
            var result = collection.IsDecreasing();
            Assert.False(result);
        }

        [Fact]
        public void IsDecreasing_TestWithDecreasingCharCollection_ReturnTrue()
        {
            var collection = new[] { 'f', 'e', 'd', 'c', 'b', 'a' };
            var result = collection.IsDecreasing();
            Assert.True(result);
        }
    }
}
