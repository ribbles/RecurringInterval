using System;

namespace RecurringInterval
{
    public class FourFourFourInterval : Interval
    {
        public FourFourFourInterval(DateTime date) : base(Period.FourFourFour)
        {
            StartDate = date;
            EndDay = ((4 + 4 + 4) * 7) - 1;
            EndDate = date.AddDays(EndDay);
        }

        public override Interval Next()
        {
            return new FourFourFourInterval(EndDate.AddDays(1));
        }
    }
}