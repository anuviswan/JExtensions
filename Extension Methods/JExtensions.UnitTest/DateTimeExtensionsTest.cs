using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using Xunit;

namespace JExtensions.UnitTest
{
    public class DateTimeExtensionsTest
    {
        [Fact]
        public void IsWeekendWithUsCulture_ShouldReturnTrueForSunday()
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            var date = Enumerable.Range(1, 7).Select(x=>new DateTime(DateTime.Now.Year, DateTime.Now.Month, x))
                                             .Single(x =>x.DayOfWeek == DayOfWeek.Sunday);
            var result = date.IsWeekend();
            Assert.True(result);
        }

        [Fact]
        public void IsWeekendWithUsCulture_ShouldReturnFalseForFriday()
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            var date = Enumerable.Range(1, 7).Select(x => new DateTime(DateTime.Now.Year, DateTime.Now.Month, x))
                                             .Single(x => x.DayOfWeek == DayOfWeek.Friday);
            var result = date.IsWeekend();
            Assert.False(result);
        }

        [Fact]
        public void IsWeekendWithSaudiCulture_ShouldReturnTrueForFriday()
        {
            CultureInfo ci = new CultureInfo("ar-SA");
            Thread.CurrentThread.CurrentCulture = ci;
            var date = Enumerable.Range(1, 7).Select(x => new DateTime(DateTime.Now.Year, DateTime.Now.Month, x))
                                             .Single(x => x.DayOfWeek == DayOfWeek.Friday);
            var result = date.IsWeekend();
            Assert.True(result);
        }

        [Fact]
        public void IsWeekendWithSaudiCulture_ShouldReturnFalseForSunday()
        {
            CultureInfo ci = new CultureInfo("ar-SA");
            Thread.CurrentThread.CurrentCulture = ci;
            var date = Enumerable.Range(1, 7).Select(x => new DateTime(DateTime.Now.Year, DateTime.Now.Month, x))
                                             .Single(x => x.DayOfWeek == DayOfWeek.Sunday);
            var result = date.IsWeekend();
            Assert.False(result);
        }

    }
    
}
