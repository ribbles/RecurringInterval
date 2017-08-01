using System;

namespace RecurringInterval
{
    internal class DailyInterval : Interval
    {
        public DailyInterval(DateTime startDate) : base(Period.Daily)
        {
            StartDate = startDate;
            EndDate = StartDate;
        }

        public override Interval Next()
        {
            return new DailyInterval(NextStartDate());
        }

        private DateTime NextStartDate()
        {
            return EndDate.AddDays(1);
        }
    }
   
}