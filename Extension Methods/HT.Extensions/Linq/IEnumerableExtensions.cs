using MoreLinq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HT.Linq
{
    public static class IEnumerableExtensions
    {
        private static Random _randomGenerator = new Random();
        /// <summary>
        /// Verifies if the Collection is sorted in increasing order
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="data">Collection of objects that implement IComparable</param>
        /// <returns></returns>
        public static bool IsIncreasing<TSource>(this IEnumerable<TSource> data)
        {
            return data.Pairwise((first, second) => Comparer.Default.Compare(first, second) < 0).All(b => b);
        }

        /// <summary>
        /// Verifies if the Collection is sorted in increasing order
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="data">Collection of objects that implement IComparable</param>
        /// <returns></returns>
        public static bool IsDecreasing<TSource>(this IEnumerable<TSource> data)
        {
            return data.Pairwise((first, second) => Comparer.Default.Compare(first, second) > 0).All(b => b);
        }

        /// <summary>
        /// Verify that collection has elements sorted in alternating order
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="dataList"></param>
        /// <returns></returns>
        public static bool IsAlternating<TSource>(this IEnumerable<TSource> dataList)
        {
            return VerifyIfAlternating(dataList.ToList(), true) || VerifyIfAlternating(dataList.ToList(), false);
        }

        private static bool VerifyIfAlternating<TSource>(IList<TSource> data, bool toggle)
        {
            return data.Zip(data.Skip(1), (first, second) =>
            {
                toggle = !toggle;
                return Comparer.Default
                               .Compare(first, second) > 0 == toggle;})
                               .All(b => b);

        }

        /// <summary>
        /// Shuffle a collection
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="dataArray"></param>
        /// <param name="useDurstenfeldModification"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Shuffle<TSource>(this IEnumerable<TSource> dataArray)
        {
            var dataArrayList = dataArray.ToList();
            var returnValue = Enumerable.Empty<TSource>();
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
