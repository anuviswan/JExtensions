using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JExtensions;
using JExtensions.UnitTest.TypeTests.MockData;
using Xunit;

namespace JExtensions.UnitTest.TypeTests
{
    public class GetDerievedTypesOfTests
    {
        [Theory]
        [MemberData(nameof(GetDerievedTypesOf_ValidScenario_TestData))]
        public void GetDerievedTypesOf_ValidScenario(Type source,IEnumerable<Type> expectedResult)
        {
            var expectedResultAsList = expectedResult.ToList();

            var result = source.GetDerievedTypesOf(this.GetType().Assembly);

            Assert.Equal(expectedResultAsList.Count, result.Count());
            foreach (var item in result)
                Assert.Contains(item, expectedResultAsList);
        }

        public static IEnumerable<object[]> GetDerievedTypesOf_ValidScenario_TestData => new[]
        {
            new object[]{typeof(BaseClass),new[] {typeof(DerievedA), typeof(DerievedB), typeof(DerievedC) } }
        };
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
