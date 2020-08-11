using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JExtensions;

namespace JExtensions.UnitTest.TypeTests
{
    public class GetDerievedTypesOfTests
    {
        public void GetDerievedTypesOf_ValidScenario(Type source,IEnumerable<Type> expectedResult)
        {
            var result = source.GetDerievedTypesOf(this.GetType().Assembly);
        }
    }
}

namespace JExtensions.UnitTest.TypeTests.MockData
{
    public class BaseClass { }
    public class DerievedA :BaseClass{ }
    public class DerievedB :BaseClass{ }
    public class DerievedC :DerievedA{ }

    public class AbstractClass { }
    public class DerievedD:AbstractClass{ }
    public class DerievedE : AbstractClass { }
    public class DerievedF : AbstractClass { }

}
