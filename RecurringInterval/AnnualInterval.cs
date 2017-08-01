using System;

namespace RecurringInterval
{
    public class AnnualInterval : Interval
    {
        public AnnualInterval(DateTime startDate) : base(Period.Annual)
        {
            StartDate = startDate;
            EndDate = NextStartDate().AddDays(-1);
        }

        public override Interval Next()
        {
            return new AnnualInterval(NextStartDate());
        }

        private DateTime NextStartDate()
        {
            return EndDate.AddYears(1);
        }
    }
}