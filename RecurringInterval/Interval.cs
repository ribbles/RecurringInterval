using System;

namespace RecurringInterval
{
    public abstract class Interval
    {
        protected Interval(Period period)
        {
            Period = period;
        }

        public int TotalDays => (int)EndDate.Subtract(StartDate).TotalDays + 1;
        public int EndDay { get; protected set; }

        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public Period Period { get; }


        //    public bool TryGetPeriod(DateTime startDate, DateTime endDate, out Period period)
        //    {
        //        var span = (long)endDate.Subtract(startDate).TotalDays;

        //        if (span == 365 || span == 366)
        //            period = Period.Annual;

        //        else if (span >= 90 && span <= 92)
        //            period = Period.Quarterly;

        //        else if (span >= 28 && span <= 31)
        //            period = Period.Monthly;

        //        else if (span >= 15 && span <= 17)
        //            period = Period.BiMonthly;

        //        else if (span == 14)
        //            period = Period.BiWeekly;

        //        else if (span == 7)
        //            period = Period.Weekly;

        //        else if (span == 1)
        //            period = Period.Daily;

        //        else
        //        {
        //            period = 0;
        //            return false;
        //        }
        //        return true;
        //    }

        static readonly IntervalFactory factory = new IntervalFactory();


        public static Interval Create(Period period, DateTime startDate, int endDay)
        {
            return factory.CreateFromEndDay(period, startDate, endDay);
        }

        public abstract Interval Next();

    }
}