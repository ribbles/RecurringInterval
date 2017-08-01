using System;

namespace RecurringInterval
{
    internal class MonthlyInterval : Interval
    {
        public MonthlyInterval(DateTime startDate) : base(Period.Monthly)
        {
            StartDate = startDate;

            if (startDate.Day == 1)
            {
                EndDate = new DateTime(startDate.Year, startDate.Month, DateTime.DaysInMonth(startDate.Year, startDate.Month));
            }
            else
                EndDate = startDate.AddMonths(1).AddDays(-1);
        }
        
        public override Interval Next()
        {
            return new MonthlyInterval(NextStartDate());
        }

        private DateTime NextStartDate()
        {
            return EndDate.AddDays(1);
        }
        
    }

}