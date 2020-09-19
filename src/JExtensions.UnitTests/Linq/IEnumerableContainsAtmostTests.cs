using JExtensions.Linq;
using System;
using System.Collections.Generic;
using Xunit;

namespace JExtensions.UnitTest.Linq
{
    public class IEnumerableContainsAtmostTests
    {
        [Theory]
        [MemberData(nameof(ContainsAtmost_ValidArguementsTestData))]
        public void ContainsAtmost_ValidArguements<T>(IEnumerable<T> source, int expectedCountOfItems, bool expectedResult)
        {
            var result = source.ContainsAtmost(expectedCountOfItems);
            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> ContainsAtmost_ValidArguementsTestData => new[]
        {
            new object[]{new object[] {1,2,3,4,5},5,true},
            new object[]{new object[] {1,2,3,4,5},6,true},
            new object[]{new object[] {1,2,3,4,5},4,false},

            new object[]{new object[] {'a','b','c','d','e'},5,true},
            new object[]{new object[] {'a','b','c','d','e'},6,true},
            new object[]{new object[] {'a','b','c','d','e'},4,false},
        };


        [Theory]
        [MemberData(nameof(ContainsAtmost_InvalidArguementsTestData))]
        public void ContainsAtleast_InvalidArguements<T>(IEnumerable<T> source, int expectedCountOfItems, Type expectedException)
        {
            Assert.Throws(expectedException, () => source.ContainsAtmost(expectedCountOfItems));
        }

        public static IEnumerable<object[]> ContainsAtmost_InvalidArguementsTestData => new[]
        {
            new object[]{null,5,typeof(ArgumentNullException)},
            new object[]{new object[] {1,2,3,4,5},-1,typeof(ArgumentOutOfRangeException)},
        };
    }
}
