using System;

namespace RecurringInterval
{
    internal class WeeklyInterval : Interval
    {
        public WeeklyInterval(DateTime startDate) : base(Period.Weekly)
        {
            StartDate = startDate;
            EndDate = StartDate.AddDays(6);
        }

        public override Interval Next()
        {
            return new WeeklyInterval(NextStartDate());
        }

        private DateTime NextStartDate()
        {
            return EndDate.AddDays(1);
        }
        
    }
   
}