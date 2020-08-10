using JExtensions.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace JExtensions.UnitTest.Linq
{
    public class IEnumerableShuffleTests
    {
        [Theory]
        [MemberData(nameof(ShuffleTest_ValidScenario_TestData))]
        public void ShuffleTest_ValidScenario<T>(IEnumerable<T> source,bool isEqual)
        {
            var result = source.Shuffle();
            Assert.Equal(isEqual,result.SequenceEqual(source));
        }

        public static IEnumerable<object[]> ShuffleTest_ValidScenario_TestData => new []
        {
            new object[]{ new []{1,2,3,4,5},false},
            new object[]{ new []{5,3,7,9,2},false},
            new object[]{ new []{1,1,1,1,1},true},
            new object[]{ new []{1,2,3,1,2},false},

            new object[]{new [] {'a','b','c','d','e'},false},
            new object[]{new [] {'a','a','a','a','a'},true},
            new object[]{new [] {'a','b','c','a','b'},false},
        };
    }
}