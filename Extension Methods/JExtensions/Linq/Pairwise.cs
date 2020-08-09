using System;
using System.Collections.Generic;

namespace JExtensions.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Pairwise implementation - currently taken from MoreLinq. Should rewrite this.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="resultSelector"></param>
        /// <returns></returns>
        internal static IEnumerable<TResult> Pairwise<TSource,TResult>(this IEnumerable<TSource> source, Func<TSource, TSource, TResult> resultSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

            return _(); IEnumerable<TResult> _()
            {
                using var e = source.GetEnumerator();

                if (!e.MoveNext())
                    yield break;

                var previous = e.Current;
                while (e.MoveNext())
                {
                    yield return resultSelector(previous, e.Current);
                    previous = e.Current;
                }
            }
        }
    }
}
