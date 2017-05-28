using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateMath
{
    internal class QuarterlyInterval : Interval
    {
        public QuarterlyInterval(DateTime startDate, int endDay) : base(Period.Quarterly)
        {
            var endDateAtEndOfQuarter = false;

            EndDay = endDay;
            if (EndDay == -1 || EndDay >= 90)
                endDateAtEndOfQuarter = true;

            int startDateDayOfQuarter = startDate.DayOfQuarter();

            if (endDateAtEndOfQuarter)
                StartDate = startDate.StartOfQuarter();

            else if (endDay < startDateDayOfQuarter)// past this quarter, move to next
                StartDate = startDate.AddDays(1 + endDay - startDateDayOfQuarter);

            else
                StartDate = startDate.AddDays(-1 - startDateDayOfQuarter).StartOfQuarter().AddDays(endDay);

            if (endDateAtEndOfQuarter)
                EndDate = StartDate.EndOfQuarter();
            else
                EndDate = StartDate.EndOfQuarter().AddDays(endDay);

        }


        public override Interval Next()
        {
            return new QuarterlyInterval(NextStartDate(), EndDay);
        }

        private DateTime NextStartDate()
        {
            return EndDate.AddDays(1);
        }


    }
}
