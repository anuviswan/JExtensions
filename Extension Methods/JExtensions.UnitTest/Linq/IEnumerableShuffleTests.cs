using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace JExtensions.UnitTest.Linq
{
    public class IEnumerableShuffleTests
    {
        [Fact]
        public void ShuffleTest_ForValidIntArray_ShouldReturnRandomizedArray()
        {
            var inputArray = Enumerable.Range(1, 100);
            var output = inputArray.Shuffle();
            Assert.NotEqual(inputArray.ToList(), output.ToList());
        }

        [Fact]
        public void ShuffleTest_ForRandomArrayWithRepeatedNumbers_ShouldReturnRandomizedArray()
        {
            var inputArray = Enumerable.Range(1, 100).Concat(Enumerable.Range(1, 10));
            var output = inputArray.Shuffle();
            Assert.NotEqual(inputArray.ToList(), output.ToList());
        }


        [Fact]
        public void ShuffleTest_ForRandomArrayWithAllNumbersSame_ShouldReturnSameArray()
        {
            var inputArray = Enumerable.Repeat(1, 100);
            var output = inputArray.Shuffle();
            Assert.Equal(inputArray.ToList(), output.ToList());
        }

        [Fact]
        public void ShuffleTest_ForSingleElementIntArray_ShouldReturnSameInt()
        {
            var inputArray = new[] { new Random().Next(1, 100) };
            var output = inputArray.Shuffle();
            Assert.Equal(inputArray.ToList(), output.ToList());
        }

        [Fact]
        public void ShuffleTest_ForNullParameter_ShouldThrowArguementNullException()
        {
            IList<int> inputArray = null;
            Assert.Throws<ArgumentNullException>(()=>inputArray.Shuffle());
        }


        [Fact]
        public void ShuffleTest_EmptyCollection_ShouldReturnEmptyCollection()
        {
            var inputArray = Enumerable.Empty<int>();
            var output = inputArray.Shuffle();
            Assert.Equal(output, Enumerable.Empty<int>());
        }
    }
}