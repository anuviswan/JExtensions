using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT.Extensions
{
    public static class IEnumerable
    {
        /// <summary>
        /// Verifies if the Collection is sorted in increasing order
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="data">Collection of objects that implement IComparable</param>
        /// <returns></returns>
        public static bool IsIncreasing<TSource>(this IEnumerable<TSource> data)
        {
            return data.Zip(data.Skip(1), (first, second) => Comparer.Default.Compare(first, second) < 0).All(b => b);
        }

        /// <summary>
        /// Verifies if the Collection is sorted in increasing order
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="data">Collection of objects that implement IComparable</param>
        /// <returns></returns>
        public static bool IsDecreasing<TSource>(this IEnumerable<TSource> data)
        {
            return data.Zip(data.Skip(1), (first, second) => Comparer.Default.Compare(first, second) > 0).All(b => b);
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
    }
}
