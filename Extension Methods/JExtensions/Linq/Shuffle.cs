using System;
using System.Collections.Generic;
using System.Linq;

namespace JExtensions.Linq
{
    public static partial class EnumerableExtensions
    {
        private static Random _randomGenerator = new Random();

        /// <summary>
        /// Shuffle a collection
        /// </summary>
        /// <typeparam name="TSource">The type of elements of source.</typeparam>
        /// <param name="dataArray">The IEnumerable<typeparamref name="TSource"/> which needs to be shuffled</param>
        /// <returns>A sequence of elements correspond to those of input sequenced in random order</returns>
        public static IEnumerable<TSource> Shuffle<TSource>(this IEnumerable<TSource> dataArray)
        {
            var dataArrayList = dataArray.ToList();
            for (int index = dataArrayList.Count()-1; index > 0; index--)
            {
                var randomKey = _randomGenerator.Next(1, index);
                var temp = dataArrayList[randomKey];
                dataArrayList[randomKey] = dataArrayList[dataArray.Count() - 1];
                dataArrayList[dataArray.Count() - 1] = temp;
            }
            return dataArrayList;
        }
    }
}
