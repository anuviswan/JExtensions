using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Xunit;

namespace JExtensions.UnitTest.DateTimeTests
{
    public class DateTimeExtensionsTest
    {
        [Theory]
        [MemberData(nameof(IsWeekend_USCulture_TestData))]
        public void IsWeekend_USCulture(DateTime dateTime,bool expectedResult)
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            var result = dateTime.IsWeekend();
            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> IsWeekend_USCulture_TestData => new[] {
            new object[]{new DateTime(2020,8,9),true}, // Sunday
            new object[]{new DateTime(2020,8,7),false} // Friday
        };

        [Theory]
        [MemberData(nameof(IsWeekend_SaudiCulture_TestData))]
        public void IsWeekend_SaudiCulture(DateTime dateTime, bool expectedResult)
        {
            CultureInfo ci = new CultureInfo("ar-SA");
            Thread.CurrentThread.CurrentCulture = ci;
            var result = dateTime.IsWeekend();
            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> IsWeekend_SaudiCulture_TestData => new[] {
            new object[]{new DateTime(2020,8,9),false}, // Sunday
            new object[]{new DateTime(2020,8,7),true} // Friday
        };


    }

}
