using System;

namespace DateMath
{
    public abstract class Interval
    {
        protected Interval(Period period)
        {
            Period = period;
        }

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



        public static Interval Create(Period period, DateTime startDate, int endDay)
        {
            switch (period)
            {
                case Period.Monthly:
                    return new MonthlyInterval(startDate, endDay);

                case Period.Quarterly:
                    return new QuarterlyInterval(startDate, endDay);

                case Period.Weekly:
                    return new WeeklyInterval(startDate, endDay);

                default:
                    throw new NotImplementedException();
            }
        }

        public abstract Interval Next();

    }
}