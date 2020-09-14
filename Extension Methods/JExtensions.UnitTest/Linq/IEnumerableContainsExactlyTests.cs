using JExtensions.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JExtensions.UnitTest.Linq
{
    public class IEnumerableContainsExactlyTests
    {
        [Theory]
        [MemberData(nameof(ContainsExactly_ValidArguementsTestData))]
        public void ContainsExactly_ValidArguements<T>(IEnumerable<T> source,int expectedCountOfItems,bool expectedResult)
        {
            var result = source.ContainsExactly(expectedCountOfItems);
            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> ContainsExactly_ValidArguementsTestData => new[]
        {
            new object[]{new object[] {1,2,3,4,5},5,true},
            new object[]{new object[] {1,2,3,4,5},6,false},
            new object[]{new object[] {1,2,3,4,5},4,false},

            new object[]{new object[] {'a','b','c','d','e'},5,true},
            new object[]{new object[] {'a','b','c','d','e'},6,false},
            new object[]{new object[] {'a','b','c','d','e'},4,false},
        };


        [Theory]
        [MemberData(nameof(ContainsExactly_InvalidArguementsTestData))]
        public void ContainsExactly_InvalidArguements<T>(IEnumerable<T> source, int expectedCountOfItems,Type expectedException)
        {
            Assert.Throws(expectedException, () => source.ContainsExactly(expectedCountOfItems));
        }

        public static IEnumerable<object[]> ContainsExactly_InvalidArguementsTestData => new[]
        {
            new object[]{null,5,typeof(ArgumentNullException)},
            new object[]{new object[] {1,2,3,4,5},-1,typeof(ArgumentOutOfRangeException)},
        };
    }
}
