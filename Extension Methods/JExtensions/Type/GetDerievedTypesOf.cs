using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace JExtensions
{
    public static partial class TypeExtensions
    {

        public static IEnumerable<Type> GetDerievedTypesOf(this Type source, Assembly assembly)
        {
            return new[] { source };
        }
    }
}
