using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace JExtensions
{
    public static partial class DateTimeExtensions
    {
        /// <summary>
        /// Determines whether the given Date falls on a Weeekend.
        /// </summary>
        /// <param name="source">Date to check</param>
        /// <returns>true if the source falls on a weekend, otherwise false</returns>
        public static bool IsWeekend(this DateTime source)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            var firstDayOfWeek = currentCulture.DateTimeFormat.FirstDayOfWeek;
            var weekends = currentCulture.Name switch
            {
                "en-US" => GetUsWeekends(), 
                _=> GetDefaultWeekends(firstDayOfWeek)
            };

            var dayOfSelecteDate = source.DayOfWeek;
            return weekends.Contains(dayOfSelecteDate);
        }

        private static IEnumerable<DayOfWeek> GetDefaultWeekends(DayOfWeek firstDayOfWeek) 
        { 
            return Enum.GetValues(typeof(DayOfWeek))
                .Cast<DayOfWeek>()
                .Where(x => x > firstDayOfWeek)
                .OrderByDescending(x => x)
                .DefaultIfEmpty()
                .Take(2);
        }

        private static IEnumerable<DayOfWeek> GetUsWeekends() => new[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
        
    }
}
