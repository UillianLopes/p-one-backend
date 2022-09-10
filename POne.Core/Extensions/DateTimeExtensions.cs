using System;
using System.Collections.Generic;

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

        public static DateTime GetFristDayOfMonthThatIsThisDayOfWeek(this DateTime date, DayOfWeek dayOfWeek)
        {
            var desiredDayOfWeek = (int)dayOfWeek;
            var firstDayOfWeekInMonth = (int)date.Date.DayOfWeek;

            var monthDay = 1;

            if (desiredDayOfWeek > firstDayOfWeekInMonth)
                monthDay = 1 + (desiredDayOfWeek - firstDayOfWeekInMonth);
            else if (desiredDayOfWeek < firstDayOfWeekInMonth)
                monthDay = 7 + (desiredDayOfWeek - firstDayOfWeekInMonth) + 1;

            return new DateTime(date.Year, date.Month, monthDay);
        }


        public static IEnumerable<DateTime> GetASequenceOfMonthDaysBasedOnThisDayOfWeek(this DateTime date, DayOfWeek dayOfWeek, int ammount)
        {

            var monthDay = GetFristDayOfMonthThatIsThisDayOfWeek(date, dayOfWeek).Day;

            var year = date.Year;
            var month = date.Month;

            var lastDayOfMonth = DateTime.DaysInMonth(year, month);

            for (int i = 0; i < ammount; i++)
            {
                if (monthDay <= lastDayOfMonth)
                {
                    yield return new DateTime(year, month, monthDay);
                    monthDay += 7;
                    continue;
                }

                if (month < 12)
                    month++;
                else
                {
                    month = 1;
                    year++;
                }

                var previousLastDayOfMonth = lastDayOfMonth;
                lastDayOfMonth = DateTime.DaysInMonth(year, month);
                monthDay = (monthDay - previousLastDayOfMonth);

                yield return new DateTime(year, month, monthDay);
                monthDay += 7;
            }

        }

        public static IEnumerable<DateTime> GetDaysOfMonthBasedOnThisDayOfWeek(this DateTime date, DayOfWeek dayOfWeek)
        {
            var lastDayOfMonth = DateTime.DaysInMonth(date.Year, date.Month);
            var monthDay = GetFristDayOfMonthThatIsThisDayOfWeek(date, dayOfWeek).Day;

            do
            {
                yield return new DateTime(date.Year, date.Month, monthDay);
                monthDay += 7;
            } while (monthDay <= lastDayOfMonth);
        }
    }
}
