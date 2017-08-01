using System;

namespace RecurringInterval
{
    public class FourFourFiveInterval : Interval
    {
        public FourFourFiveInterval(DateTime date) : base(Period.FourFourFive)
        {
            StartDate = date;
            EndDay = ((4 + 4 + 5) * 7) - 1;
            EndDate = date.AddDays(EndDay);
        }

        public override Interval Next()
        {
            return new FourFourFiveInterval(EndDate.AddDays(1));
        }
    }
}