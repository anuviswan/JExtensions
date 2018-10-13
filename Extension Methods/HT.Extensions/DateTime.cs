using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HT
{
    public static partial class Extensions
    {
        public static bool IsWeekend(this DateTime source)
        {
            var firstDayOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            var weekEnds = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().Where(x => x > firstDayOfWeek).OrderByDescending(x => x).DefaultIfEmpty().Take(2);
            var dayOfSelecteDate = source.DayOfWeek;
            return weekEnds.Contains(dayOfSelecteDate);
        }
    }
}
