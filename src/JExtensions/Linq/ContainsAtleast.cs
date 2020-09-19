using System;
using System.Collections.Generic;
using System.Linq;

namespace JExtensions.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Determines if the collection containst atleast <paramref name="numberOfItems"/> elements
        /// </summary>
        /// <typeparam name="TSource">Types of elements in <code>source</code></typeparam>
        /// <param name="source">An <code>IEnumerable<TSource/></code> to check for number of elements</param>
        /// <param name="numberOfItems">Minimum number of elements the collection is expected to contain</param>
        /// <returns>Returns true if the collection contains atleast <paramref name="numberOfItems"/> elements.Otherwise false.</returns>
        public static bool ContainsAtleast<TSource>(this IEnumerable<TSource> source, int numberOfItems)
        {
            if (source is null) throw new ArgumentNullException();
            if (numberOfItems < 0) throw new ArgumentOutOfRangeException();

            return source.Count() >= numberOfItems;
        }
    }
}
