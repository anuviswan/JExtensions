using JExtensions.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace JExtensions.UnitTest.Linq
{
    public class IEnumerableIsDecreasingTests
    {
        [Theory]
        [MemberData(nameof(IsDecreasing_ValidElementsTestData))]
        public void IsDecreasing_ValidElements<T>(IEnumerable<T> testData,bool expectedResult)
        {
            var result = testData.IsDecreasing();
            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> IsDecreasing_ValidElementsTestData => new[]
        {
            // Int Collection
            new object[] { new [] { 1, 2, 3, 4, 5 }, false }, 
            new object[] { new[] { 5,4,3,2,1 }, true },
            new object[] { new[] { 1,1,1,1,1 }, false },

            // Double Collection
            new object[] { new [] { 1D, 2D, 3D, 4D, 5D }, false }, 
            new object[] { new[] { 5D,4D,3D,2D,1D }, true },
            new object[] { new[] { 1D,1D,1D,1D,1D }, false },

            // Char Collection
            new object[] { new [] { 'a','b','c','d','e' }, false }, 
            new object[] { new [] { 'e','d','c','b','a' }, true }, 
            new object[] { new [] { 'a','a','a','a','a'}, false }, 
        };

        
        [Theory]
        [MemberData(nameof(IsDecreasing_NullItemInCollectionTestData))]
        public void IsDecreasing_NullItemInCollection<T>(IEnumerable<T?> testData) where T:struct
        {
            Assert.Throws<ArgumentNullException>(()=> testData.IsDecreasing());
        }

        public static IEnumerable<object[]> IsDecreasing_NullItemInCollectionTestData => new[]
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
