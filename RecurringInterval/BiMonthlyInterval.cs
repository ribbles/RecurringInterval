using System;

namespace RecurringInterval
{
    internal class BiMonthlyInterval : Interval
    {
        /**** WARNING **
            * We are making assumptions here.
            * if the date is 1, move to 16th
            * if the date is 2-12, add 15
            * if the date is 13-15 move to last day of month
            * if the date is 15, move to last day of month
            * if the date is 16, move to 1st day of next month
            * if the date is 17-27, add month - 15
            * if the date is 28-31, move to 15th day of next month
        */

        public BiMonthlyInterval(DateTime startDate) : this(startDate, startDate.Day - 1)
        {
        }

        public BiMonthlyInterval(DateTime startDate, int endDay) : base(Period.BiMonthly)
        {
            EndDay = endDay;

            if (EndDay == -1)
            {
                StrategyLastDayOfMonthAnd15th(startDate);
            }
            else if (EndDay == 1)
            {
                Strategy17To1And2To16(startDate);
            }
            else if (EndDay >= 2 && EndDay <= 12)
            {
                StrategyNextMonthMinus15(startDate, EndDay);
            }
            else if (EndDay >= 13 && EndDay <= 15)
            {
                StrategyLastDayOfMonthAnd15th(startDate, EndDay);
            }
            else if (EndDay == 16)
            {
                Strategy17To1And2To16(startDate);
            }
            else if (EndDay >= 17 && EndDay <= 27)
            {
                StrategyNextMonthMinus15(startDate, EndDay);
            }
            else
            {
                StrategyLastDayOfMonthAnd15th(startDate);
            }
        }

        private void Strategy17To1And2To16(DateTime startDate)
        {
            if (startDate.Day == 1)
            {
                EndDate = new DateTime(startDate.Year, startDate.Month, 1);
                StartDate = new DateTime(startDate.AddMonths(-1).Year, startDate.AddMonths(-1).Month, 17);
            }
            else if (startDate.Day <= 16)
            {
                EndDate = new DateTime(startDate.Year, startDate.Month, 16);
                StartDate = new DateTime(startDate.Year, startDate.Month, 2);
            }
            else
            {
                EndDate = new DateTime(startDate.AddMonths(1).Year, startDate.AddMonths(1).Month, 1);
                StartDate = new DateTime(startDate.Year, startDate.Month, 17);
            }
        }
        private void StrategyNextMonthMinus15(DateTime startDate, int endDay)
        {
            if (endDay > 15) endDay -= 15;
            if (startDate.Day <= endDay)
            {
                EndDate = new DateTime(startDate.Year, startDate.Month, endDay);
                StartDate = new DateTime(startDate.AddMonths(-1).Year, startDate.AddMonths(-1).Month, Math.Min(endDay + 16, DateTime.DaysInMonth(startDate.AddMonths(-1).Year, startDate.AddMonths(-1).Month)));
            }
            else if (startDate.Day <= endDay + 15)
            {
                EndDate = new DateTime(startDate.Year, startDate.Month, Math.Min(endDay + 15, DateTime.DaysInMonth(startDate.Year, startDate.Month)));
                StartDate = new DateTime(startDate.Year, startDate.Month, endDay + 1);
            }
            else
            {
                EndDate = new DateTime(startDate.AddMonths(1).Year, startDate.AddMonths(1).Month, endDay);
                StartDate = new DateTime(startDate.Year, startDate.Month, Math.Min(endDay + 16, DateTime.DaysInMonth(startDate.Year, startDate.Month)));
            }

        }

        private void StrategyLastDayOfMonthAnd15th(DateTime startDate, int endDate = 15)
        {
            if (startDate.Day <= endDate)
            {
                EndDate = new DateTime(startDate.Year, startDate.Month, endDate);
                StartDate = new DateTime(startDate.Year, startDate.Month, 1);
            }
            else
            {
                EndDate = new DateTime(startDate.Year, startDate.Month, DateTime.DaysInMonth(startDate.Year, startDate.Month));
                StartDate = new DateTime(startDate.Year, startDate.Month, endDate + 1);
            }
        }

        //static readonly Func<DateTime, DateTime> add15 = a => a.AddDays(15);
        //static readonly Func<DateTime, DateTime> sub15 = a => a.AddMonths(1).AddDays(-15);
        //static readonly Func<DateTime, DateTime> mov15 = a => new DateTime(a.AddMonths(1).Year, a.AddMonths(1).Month, 15);

        //static readonly IReadOnlyDictionary<int, Func<DateTime, DateTime>> dateMap = new ReadOnlyDictionary<int, Func<DateTime, DateTime>>(new Dictionary<int, Func<DateTime, DateTime>>
        //    {
        //        { 01, a => new DateTime(a.Year, a.Month,16) }, // move to 16th
        //        { 02, add15 }, // add 15
        //        { 03, add15 },
        //        { 04, add15 },
        //        { 05, add15 },
        //        { 06, add15 },
        //        { 07, add15 },
        //        { 08, add15 },
        //        { 09, add15 },
        //        { 10, add15 },
        //        { 11, add15 },
        //        { 12, add15 },
        //        { 13, add15  },
        //        { 14, a => new DateTime(a.Year, a.Month, DateTime.DaysInMonth(a.Year, a.Month)) }, // move to last day of month
        //        { 15, a => new DateTime(a.Year, a.Month, DateTime.DaysInMonth(a.Year, a.Month)) }, // move to last day of month
        //        { 16, a => new DateTime(a.AddMonths(1).Year, a.AddMonths(1).Month, 1) }, // 1st day of next month
        //        { 17, sub15 }, //add month - 15
        //        { 18, sub15 },
        //        { 19, sub15 },
        //        { 20, sub15 },
        //        { 21, sub15 },
        //        { 22, sub15 },
        //        { 23, sub15 },
        //        { 24, sub15 },
        //        { 25, sub15 },
        //        { 26, sub15 },
        //        { 27, sub15 },
        //        { 28, mov15 }, // move to 15th day of next month
        //        { 29, mov15 },
        //        { 30, mov15 },
        //        { 31, mov15 },
        //    });
        //public BiMonthlyInterval(DateTime startDate) : base(Period.BiMonthly)
        //{
        //    StartDate = startDate;
        //    var nextStartDate = dateMap[StartDate.Day](StartDate);
        //    EndDate = nextStartDate.AddDays(-1);
        //    EndDay = EndDate.Day == 1
        //        ? 1
        //        : StartDate.Day > EndDate.Day
        //            ? EndDate.Day
        //            : StartDate.Day - 1;
        //}

        public override Interval Next()
        {
            return new BiMonthlyInterval(NextStartDate(), EndDay);
        }

        private DateTime NextStartDate()
        {
            return EndDate.AddDays(1);
        }
    }
}