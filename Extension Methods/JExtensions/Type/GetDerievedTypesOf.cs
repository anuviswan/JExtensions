using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JExtensions
{
    public static partial class TypeExtensions
    {

        public static IEnumerable<Type> GetDerievedTypesOf(this Type source, Assembly assembly)
        {
            return assembly.GetTypes().Where(x => source.IsAssignableFrom(x) && x!=source);
        }
    }
}
