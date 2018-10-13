using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HT.Extensions.UnitTest
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class DateTimeExtensionsTest
    {
        [TestMethod]
        public void IsWeekendWithUsCulture_ShouldReturnTrueForSunday()
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            var date = Enumerable.Range(1, 7).Select(x=>new DateTime(DateTime.Now.Year, DateTime.Now.Month, x))
                                             .Single(x =>x.DayOfWeek == DayOfWeek.Sunday);
            var result = date.IsWeekend();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsWeekendWithUsCulture_ShouldReturnFalseForFriday()
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            var date = Enumerable.Range(1, 7).Select(x => new DateTime(DateTime.Now.Year, DateTime.Now.Month, x))
                                             .Single(x => x.DayOfWeek == DayOfWeek.Friday);
            var result = date.IsWeekend();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsWeekendWithSaudiCulture_ShouldReturnTrueForFriday()
        {
            CultureInfo ci = new CultureInfo("ar-SA");
            Thread.CurrentThread.CurrentCulture = ci;
            var date = Enumerable.Range(1, 7).Select(x => new DateTime(DateTime.Now.Year, DateTime.Now.Month, x))
                                             .Single(x => x.DayOfWeek == DayOfWeek.Friday);
            var result = date.IsWeekend();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsWeekendWithSaudiCulture_ShouldReturnFalseForSunday()
        {
            CultureInfo ci = new CultureInfo("ar-SA");
            Thread.CurrentThread.CurrentCulture = ci;
            var date = Enumerable.Range(1, 7).Select(x => new DateTime(DateTime.Now.Year, DateTime.Now.Month, x))
                                             .Single(x => x.DayOfWeek == DayOfWeek.Sunday);
            var result = date.IsWeekend();
            Assert.IsFalse(result);
        }

    }
    
}
