using System;

namespace DateMath
{
    internal class DailyInterval : Interval
    {

        public DailyInterval(DateTime startDate, int endDay) : base(Period.Daily)
        {
            if (endDay <= 0) endDay = 1;

            EndDay = endDay;
            StartDate = startDate;
            EndDate = StartDate.AddDays(EndDay - 1);
        }

        public override Interval Next()
        {
            return new DailyInterval(NextStartDate(), EndDay);
        }

        private DateTime NextStartDate()
        {
            return EndDate.AddDays(1);
        }
    }
   
}