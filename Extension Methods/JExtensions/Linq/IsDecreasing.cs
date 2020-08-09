using MoreLinq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JExtensions.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Verifies if the Collection is sorted in increasing order
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="data">Collection of objects that implement IComparable</param>
        /// <returns></returns>
        public static bool IsDecreasing<TSource>(this IEnumerable<TSource> data)
        {
            if (data.Any(x => x == null))
                throw new ArgumentNullException();
            return data.Pairwise((first, second) => Comparer.Default.Compare(first, second) > 0).All(b => b);
        }
    }
}
