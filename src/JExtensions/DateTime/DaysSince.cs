using System;

namespace JExtensions
{
    public static partial class DateTimeExtensions
    {
        /// <summary>
        /// Computes the number of whole days that has passed since <paramref name="fromDate"/>
        /// </summary>
        /// <param name="source">Date till which the calculation would be considered</param>
        /// <param name="fromDate">Date from which the calculation would be considered</param>
        /// <returns>Whole number indicating number of days passed since the <paramref name="fromDate"/></returns>
        public static int DaysSince(this DateTime source, DateTime fromDate)
        {
            if (fromDate > source) throw new ArgumentOutOfRangeException("From Date should be less than To Date");
            return source.Subtract(fromDate).Days;
        }
    }
}
