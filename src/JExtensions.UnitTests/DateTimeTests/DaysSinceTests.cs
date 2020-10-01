using System;
using System.Collections.Generic;
using Xunit;

namespace JExtensions.UnitTests.DateTimeTests
{
    public class DaysSinceTests
    {
        [Theory]
        [MemberData(nameof(DaysSince_ValidScenario_TestData))]
        public void DaysSince_ValidScenario(DateTime to,DateTime from,int expectedResult)
        {
            var result = to.DaysSince(from);
            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> DaysSince_ValidScenario_TestData => new[]
        {
            // positive cases
            new object[]{new DateTime(2020,8,20),new DateTime(2020,8,15),5},
            new object[]{new DateTime(2020,8,20,23,59,59),new DateTime(2020,8,15),5},
            new object[]{new DateTime(2020,8,20,23,59,58),new DateTime(2020,8,15,23,59,59),4},

            // Same Day cases
            new object[]{new DateTime(2020,8,20),new DateTime(2020,8,20),0},
            new object[]{new DateTime(2020,8,20,23,59,59),new DateTime(2020,8,20),0},
        };

        [Theory]
        [MemberData(nameof(DaysSince_InvalidScenario_TestData))]
        public void DaysSince_InvalidScenario(DateTime to, DateTime from)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => to.DaysSince(from));
        }

        public static IEnumerable<object[]> DaysSince_InvalidScenario_TestData => new[]
        {
            //negative cases
            new object[]{new DateTime(2020,8,20),new DateTime(2020,8,25)},
            new object[]{new DateTime(2020,8,20,23,59,59),new DateTime(2020,8,25)},
            new object[]{new DateTime(2020,8,20,23,59,59),new DateTime(2020,8,25,23,59,59)},
            new object[]{new DateTime(2020,8,20,23,59,58),new DateTime(2020,8,20,23,59,59)},
        };
    }
}
