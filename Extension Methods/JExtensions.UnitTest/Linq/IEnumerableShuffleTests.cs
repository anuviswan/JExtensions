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
            new object[]{ Enumerable.Range(1,100),false},
            new object[]{ Enumerable.Repeat(1,100),false},
        };
    }
}