using System;


namespace RecurringInterval
{
    public class IntervalFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="period"></param>
        /// <param name="startDate">The first date</param>
        /// <param name="firstStartDate">IOnly required for 4-4-5 calendar</param>
        /// <returns></returns>
        public Interval CreateFromStartDate(Period period, DateTime startDate, DateTime? firstStartDate = null)
        {
            switch (period)
            {
                case Period.Monthly:
                    return new MonthlyInterval(startDate);

                case Period.Quarterly:
                    return new QuarterlyInterval(startDate);

                case Period.Weekly:
                    return new WeeklyInterval(startDate);

                case Period.Daily:
                    return new DailyInterval(startDate);

                case Period.BiWeekly:
                    return new BiWeeklyInterval(startDate);

                case Period.BiMonthly:
                    return new BiMonthlyInterval(startDate);

                case Period.Annual:
                    return new AnnualInterval(startDate);

                case Period.FourFourFive:
                    if (firstStartDate == null)
                        throw new ArgumentNullException(nameof(firstStartDate));

                    return new FourFourFiveInterval(startDate, firstStartDate.Value);

                case Period.FourFourFour:
                    return new FourFourFourInterval(startDate);

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
