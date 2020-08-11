using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace JExtensions
{
    public static partial class TypeExtensions
    {

        public static IEnumerable<Type> GetDerievedTypesOf(this Type source, Assembly assembly)
        {
            return assembly.GetTypes().Where(x => x.IsAssignableFrom(source));
        }
    }
}
