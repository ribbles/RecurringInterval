using System;

namespace RecurringInterval
{
    public class FourFourFourInterval : Interval
    {
        public FourFourFourInterval(DateTime startDate) : base(Period.FourFourFour)
        {
            StartDate = startDate;
            EndDate = startDate.AddDays(4 * 7 - 1);
        }

        public override Interval Next()
        {
            return new FourFourFourInterval(EndDate.AddDays(1));
        }
    }
}