using System;

namespace RecurringInterval
{
    public class FourFourFiveInterval : Interval
    {
        public DateTime FirstStartDate { get; protected set; }
        const int DaysInPeriod = (4 * 4 * 5) * 7;
        const int EndOfFourFour = (4 * 4) * 7;

        public FourFourFiveInterval(DateTime startDate, DateTime firstStartDate) : base(Period.FourFourFive)
        {
            FirstStartDate = firstStartDate;
            StartDate = startDate;
            EndDate = IsFiveWeekMonth(startDate)
                ? startDate.AddDays(5 * 7 - 1)
                : startDate.AddDays(4 * 7 - 1);
        }

        private bool IsFiveWeekMonth(DateTime date)
        {
            DateTime start = FirstStartDate;
            DateTime end = FirstStartDate;

            do
            {
                start = start.AddDays(DaysInPeriod);
                end = end.AddDays(DaysInPeriod);
            }
            while (end < date);

            return end.Subtract(start).TotalDays > EndOfFourFour;
        }

        public override Interval Next()
        {
            return new FourFourFiveInterval(EndDate.AddDays(1), FirstStartDate);
        }
    }
}