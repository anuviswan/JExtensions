using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JExtensions
{
    public static partial class TypeExtensions
    {
        /// <summary>
        /// Retrieves a sequence of Types which implements/derieves from the given source type
        /// </summary>
        /// <param name="source">Source Type</param>
        /// <returns>A sequence of Types defined in the same assembly as the source and which is inherited/derieved from the source</returns>
        public static IEnumerable<Type> GetDerievedTypesOf(this Type source) => source.GetDerievedTypesOf(source.Assembly);

        /// <summary>
        /// Retrieves a sequence of Types which implements/derieves from the given source type
        /// </summary>
        /// <param name="source">Source Type</param>
        /// <param name="assembly">Assembly to search</param>
        /// <returns>A sequence of Types defined in the specified assembly as the source and which is inherited/derieved from the source</returns>
        public static IEnumerable<Type> GetDerievedTypesOf(this Type source, Assembly assembly)
        {
            return assembly.GetTypes().Where(x => source.IsAssignableFrom(x) && x!=source);
        }
    }
}
