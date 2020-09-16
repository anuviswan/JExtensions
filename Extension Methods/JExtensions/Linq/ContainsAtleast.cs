using System;
using System.Collections.Generic;
using System.Linq;

namespace JExtensions.Linq
{
    public static partial class EnumerableExtensions
    {
        public static bool ContainsAtleast<TSource>(this IEnumerable<TSource> source, int numberOfItems)
        {
            if (source is null) throw new ArgumentNullException();
            if (numberOfItems < 0) throw new ArgumentOutOfRangeException();

            return source.Count() >= numberOfItems;
        }
    }
}
