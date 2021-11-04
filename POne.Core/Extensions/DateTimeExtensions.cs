using System;

namespace POne.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime GoToLastDayOfMonth(this DateTime dateTime) => new(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month), 23, 59, 59);

        public static DateTime GoToThatDay(this DateTime dateTime, int day)
        {
            var lastDayOfMonth = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);

            return new(dateTime.Year, dateTime.Month, day < lastDayOfMonth ? day : lastDayOfMonth, 23, 59, 59);
        }
    }
}
