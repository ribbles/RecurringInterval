using System;

namespace RecurringInterval
{
    internal class QuarterlyInterval : Interval
    {
        public QuarterlyInterval(DateTime startDate) : base(Period.Quarterly)
        {
            StartDate = startDate;
            int startDateDayOfQuarter = startDate.DayOfQuarter();
            var endDateAtEndOfQuarter = startDateDayOfQuarter == 1;

            

            if (endDateAtEndOfQuarter)
                EndDate = StartDate.EndOfQuarter();

            else
                EndDate = StartDate.AddMonths(3).AddDays(-1);

        }


        public override Interval Next()
        {
            return new QuarterlyInterval(NextStartDate());
        }

        private DateTime NextStartDate()
        {
            return EndDate.AddDays(1);
        }


    }
}
