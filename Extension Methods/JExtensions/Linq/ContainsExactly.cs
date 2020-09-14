using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JExtensions.Linq
{
    public static partial class EnumerableExtensions
    {
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
