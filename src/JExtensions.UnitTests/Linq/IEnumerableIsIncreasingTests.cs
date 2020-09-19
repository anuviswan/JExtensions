using JExtensions.Linq;
using System;
using System.Collections.Generic;
using Xunit;

namespace JExtensions.UnitTest.Linq
{
    public class IEnumerableIncreasingTests
    {

        [Theory]
        [MemberData(nameof(IsIncreasing_ValidElementsTestData))]
        public void IsIncreasing_ValidElements<T>(IEnumerable<T> testData, bool expectedResult)
        {
            var result = testData.IsIncreasing();
            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> IsIncreasing_ValidElementsTestData => new[]
        {
            // Int Collection
            new object[] { new [] { 1, 2, 3, 4, 5 }, true },
            new object[] { new[] { 5,4,3,2,1 }, false },
            new object[] { new[] { 1,1,1,1,1 }, false },

            // Double Collection
            new object[] { new [] { 1D, 2D, 3D, 4D, 5D }, true },
            new object[] { new[] { 5D,4D,3D,2D,1D }, false },
            new object[] { new[] { 1D,1D,1D,1D,1D }, false },

            // Char Collection
            new object[] { new [] { 'a','b','c','d','e' }, true},
            new object[] { new [] { 'e','d','c','b','a' }, false },
            new object[] { new [] { 'a','a','a','a','a'}, false },
        };


        [Theory]
        [MemberData(nameof(IsIncreasing_NullItemInCollectionTestData))]
        public void IsIncreasing_NullItemInCollection<T>(IEnumerable<T?> testData) where T : struct
        {
            Assert.Throws<ArgumentNullException>(() => testData.IsIncreasing());
        }

        public static IEnumerable<object[]> IsIncreasing_NullItemInCollectionTestData => new[]
        {
            // Int Collection
            new object[] { new int?[] { 1, 2, null, 4, 5 } },

            // Double Collection
            new object[] { new double?[] { 1D, 2D, null, 4D, 5D }},
           
            // Char Collection
            new object[] { new char?[] { 'a','b',null,'d','e' } },

        };
    }
}
