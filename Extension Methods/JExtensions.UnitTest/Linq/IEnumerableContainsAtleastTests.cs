using JExtensions.Linq;
using System;
using System.Collections.Generic;
using Xunit;

namespace JExtensions.UnitTest.Linq
{
    public class IEnumerableContainsAtleastTests
    {
        [Theory]
        [MemberData(nameof(ContainsAtleast_ValidArguementsTestData))]
        public void ContainsAtleast_ValidArguements<T>(IEnumerable<T> source, int expectedCountOfItems, bool expectedResult)
        {
            var result = source.ContainsAtleast(expectedCountOfItems);
            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> ContainsAtleast_ValidArguementsTestData => new[]
        {
            new object[]{new object[] {1,2,3,4,5},5,true},
            new object[]{new object[] {1,2,3,4,5},6,false},
            new object[]{new object[] {1,2,3,4,5},4,true},

            new object[]{new object[] {'a','b','c','d','e'},5,true},
            new object[]{new object[] {'a','b','c','d','e'},6,false},
            new object[]{new object[] {'a','b','c','d','e'},4,true},
        };


        [Theory]
        [MemberData(nameof(ContainsAtleast_InvalidArguementsTestData))]
        public void ContainsAtleast_InvalidArguements<T>(IEnumerable<T> source, int expectedCountOfItems, Type expectedException)
        {
            Assert.Throws(expectedException, () => source.ContainsAtleast(expectedCountOfItems));
        }

        public static IEnumerable<object[]> ContainsAtleast_InvalidArguementsTestData => new[]
        {
            new object[]{null,5,typeof(ArgumentNullException)},
            new object[]{new object[] {1,2,3,4,5},-1,typeof(ArgumentOutOfRangeException)},
        };
    }
}
