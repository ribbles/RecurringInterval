using System;

namespace RecurringInterval
{
    internal class BiWeeklyInterval : Interval
    {
        public BiWeeklyInterval(DateTime startDate) : base(Period.BiWeekly)
        {
            StartDate = startDate;
            EndDate = startDate.AddDays(13);
            EndDay = 14;
        }

        public override Interval Next()
        {
            return new BiWeeklyInterval(NextStartDate());
        }

        private DateTime NextStartDate()
        {
            return EndDate.AddDays(1);
        }
        
    }
   
}