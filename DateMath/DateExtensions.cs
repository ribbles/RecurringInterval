using System;

namespace DateMath
{
    public static class DateExtensions
    {

        public static int DayOfQuarter(this DateTime value)
        {
            DateTime quarter;

            if (value.Month >= 10)
                quarter = new DateTime(value.Year, 10, 1);
            else if (value.Month >= 7)
                quarter = new DateTime(value.Year, 7, 1);
            else if (value.Month >= 4)
                quarter = new DateTime(value.Year, 4, 1);
            else
                quarter = new DateTime(value.Year, 1, 1);

            var span = value.Subtract(quarter);
            return (int)span.TotalDays + 1;
        }

        public static int DaysInQuarter(this DateTime value)
        {
            if (value >= new DateTime(value.Year, 7, 1)) return 92;
            if (value >= new DateTime(value.Year, 4, 1)) return 91;
            return DateTime.IsLeapYear(value.Year) ? 91 : 90;
        }
        public static DateTime StartOfQuarter(this DateTime value)
        {
            if (value >= new DateTime(value.Year, 10, 1)) return new DateTime(value.Year, 10, 1);
            if (value >= new DateTime(value.Year, 7, 1)) return new DateTime(value.Year, 7, 1);
            if (value >= new DateTime(value.Year, 4, 1)) return new DateTime(value.Year, 4, 1);
            return new DateTime(value.Year, 1, 1);
        }
        public static DateTime EndOfQuarter(this DateTime value)
        {
            if (value >= new DateTime(value.Year, 10, 1)) return new DateTime(value.Year, 12, 31);
            if (value >= new DateTime(value.Year, 7, 1)) return new DateTime(value.Year, 9, 30);
            if (value >= new DateTime(value.Year, 4, 1)) return new DateTime(value.Year, 6, 30);
            return new DateTime(value.Year, 3, 31);
        }

    }
}