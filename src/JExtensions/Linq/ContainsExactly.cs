﻿using System;
using System.Collections.Generic;

namespace JExtensions.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Determines if the sequences contains exactly n elements as specified by the <paramref name="numberOfItems"/> parameter
        /// </summary>
        /// <typeparam name="TSource">Types of elements in <code>source</code></typeparam>
        /// <param name="source">An <code>IEnumerable<TSource></code> to check for number of elements</param>
        /// <param name="numberOfItems">Expected number of elements</param>
        /// <returns>Returns true if the number of elements matches of the <paramref name="numberOfItems"/>.Otherwise false.</returns>
        public static bool ContainsExactly<TSource>(this IEnumerable<TSource> source,int numberOfItems)
        {
            if(source is null) throw new ArgumentNullException();
            if (numberOfItems < 0) throw new ArgumentOutOfRangeException();

            return _();

            bool _(){

                var count = 0;
                foreach(var item in source)
                {
                    count++;
                    if (count > numberOfItems) return false;
                }

                return (count == numberOfItems);
            };
        }
    }
}
