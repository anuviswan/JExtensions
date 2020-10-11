using System;
using System.Collections.Generic;
using Xunit;

namespace JExtensions.UnitTests.GenericTests
{
    public class ApplyTests
    {
        [Theory]
        [MemberData(nameof(ApplyTest_TestData))]
        public void ApplyTest<T>(T source,List<Action<T>> actions,T expectedResult)
        {
            source.Apply(actions.ToArray());

            Assert.Equal(expectedResult, source);
        }

        public static IEnumerable<object[]> ApplyTest_TestData => new[] 
        {
            new object[]{ new User { Name="Jia",Age=0 }, new List<Action<User>>{ x=> x.Age = 4, x=>x.Name = "Jia Anu" }, new User{ Name="Jia Anu",Age=4} },
            new object[]{ new User { Name="Naina Anu",Age=2 }, new List<Action<User>>{ x=> x.Age = 0 }, new User{ Name="Naina Anu",Age=0} },
        };

        private class User
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public override bool Equals(object obj)
            {
                var otherUser = obj as User;
                return otherUser.Name.Equals(Name) && otherUser.Age == Age;
            }
        }
    }
}
