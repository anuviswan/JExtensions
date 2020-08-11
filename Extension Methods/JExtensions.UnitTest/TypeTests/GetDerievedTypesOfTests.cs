using JExtensions.UnitTest.TypeTests.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
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
            new object[]{typeof(BaseClass),new[] {typeof(DerievedA), typeof(DerievedB), typeof(DerievedC) } },
            new object[]{typeof(AbstractClass),new[] {typeof(DerievedD), typeof(DerievedE), typeof(DerievedF) } },
            new object[]{typeof(SealedClass),Enumerable.Empty<Type>()},
            new object[]{typeof(BaseInterface),new[]{ typeof(DerievedA), typeof(DerievedB), typeof(DerievedC), typeof(DerievedD), typeof(DerievedE), typeof(DerievedF) } },
        };

    }
}

namespace JExtensions.UnitTest.TypeTests.MockData
{

    public sealed class SealedClass { }

    public class BaseClass { }
    public class DerievedA :BaseClass,BaseInterface{ }
    public class DerievedB :BaseClass, BaseInterface { }
    public class DerievedC :DerievedA { }

    public abstract class AbstractClass { }
    public class DerievedD:AbstractClass, BaseInterface { }
    public class DerievedE : AbstractClass, BaseInterface { }
    public class DerievedF : DerievedD { }

    public interface BaseInterface { }

}
