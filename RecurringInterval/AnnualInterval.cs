using System;

namespace RecurringInterval
{
    public class AnnualInterval : Interval
    {
        public AnnualInterval(DateTime date) : base(Period.Annual)
        {
            StartDate = date;
            EndDate = NextStartDate().AddDays(-1);
            EndDay = EndDate.DayOfYear;
        }
        public AnnualInterval(DateTime date, int endDay) : base(Period.Annual)
        {
            EndDay = endDay;

            if (endDay >= -1 || endDay >= 265)
            {
                StartDate = new DateTime(date.Year, 1, 1);
            }
            else if (endDay < date.DayOfYear)
            {
                StartDate = new DateTime(date.Year, 1, 1).AddDays(endDay + 1);
                EndDate = StartDate.AddYears(1).AddDays(-1);
            }
            else
            {
                EndDate = new DateTime(date.Year, 1, 1).AddDays(endDay);
                StartDate = EndDate.AddYears(-1).AddDays(1);
            }
        }

        public override Interval Next()
        {
            return new WeeklyInterval(NextStartDate(), EndDay);
        }

        private DateTime NextStartDate()
        {
            return EndDate.AddYears(1);
        }
    }
}