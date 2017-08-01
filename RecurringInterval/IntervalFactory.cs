using System;


namespace RecurringInterval
{
    public class IntervalFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="period"></param>
        /// <param name="date">Any date between the first and last day of the interval</param>
        /// <param name="endDay">Last day of the period</param>
        /// <returns></returns>
        public Interval CreateFromEndDay(Period period, DateTime date, int endDay)
        {
            switch (period)
            {
                case Period.Monthly:
                    return new MonthlyInterval(date, endDay);

                case Period.Quarterly:
                    return new QuarterlyInterval(date, endDay);

                case Period.Weekly:
                    return new WeeklyInterval(date, endDay);

                case Period.Daily:
                    return new DailyInterval(date, endDay);

                case Period.BiWeekly:
                    return new BiWeeklyInterval(date);

                case Period.BiMonthly:
                    return new BiMonthlyInterval(date, endDay);

                case Period.Annual:
                    return new AnnualInterval(date, endDay);

                case Period.FourFourFive:
                    return new FourFourFiveInterval(date);

                case Period.FourFourFour:
                    return new FourFourFourInterval(date);

                default:
                    throw new NotImplementedException();
            }
        }
        public Interval CreateFromStartDate(Period period, DateTime startDate)
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
                    return new FourFourFiveInterval(startDate);

                case Period.FourFourFour:
                    return new FourFourFourInterval(startDate);

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
