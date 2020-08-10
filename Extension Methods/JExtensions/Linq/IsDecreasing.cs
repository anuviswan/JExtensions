using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace JExtensions.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Determines if the sequence is sorted in decreasing/descending order
        /// </summary>
        /// <typeparam name="TSource">The type of elements of source.</typeparam>
        /// <param name="data">The IEnumerable<typeparamref name="TSource"/> to check is sorted in decreasing/descending order.</param>
        /// <returns>true if the sequence is sorted in decreasing/descending order; otherwise false</returns>
        public static bool IsDecreasing<TSource>(this IEnumerable<TSource> data)
        {
            if (data.Any(x => x == null))
                throw new ArgumentNullException();
            return data.Pairwise((first, second) => Comparer.Default.Compare(first, second) > 0).All(b => b);
        }
    }
}
