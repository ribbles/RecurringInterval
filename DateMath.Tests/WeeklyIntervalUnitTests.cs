using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateMath.Tests
{
    [TestClass]
    public class WeeklyIntervalUnitTests : Dates
    {


        [TestMethod]
        public void Test_MonthlyInterval_Sunday()
        {
            var interval = Interval.Create(Period.Weekly, April2nd, (int)DayOfWeek.Sunday);
            AssertInterval(interval, Mar27th, April2nd, Period.Weekly);

            interval = Interval.Create(Period.Weekly, April1st, (int)DayOfWeek.Sunday);
            AssertInterval(interval, Mar27th, April2nd, Period.Weekly);

            interval = Interval.Create(Period.Weekly, Mar31st, (int)DayOfWeek.Sunday);
            AssertInterval(interval, Mar27th, April2nd, Period.Weekly);

            interval = Interval.Create(Period.Weekly, Mar30th, (int)DayOfWeek.Sunday);
            AssertInterval(interval, Mar27th, April2nd, Period.Weekly);

            interval = Interval.Create(Period.Weekly, Mar29th, (int)DayOfWeek.Sunday);
            AssertInterval(interval, Mar27th, April2nd, Period.Weekly);

            interval = Interval.Create(Period.Weekly, April3rd, (int)DayOfWeek.Sunday);
            AssertInterval(interval, April3rd, April9th, Period.Weekly);
            
            interval = Interval.Create(Period.Weekly, Mar28th, (int)DayOfWeek.Sunday);
            AssertInterval(interval, Mar27th, April2nd, Period.Weekly);

            interval = interval.Next();
            AssertInterval(interval, April3rd, April9th, Period.Weekly);
        }

        [TestMethod]
        public void Test_MonthlyInterval_Saturday()
        {
            var interval = Interval.Create(Period.Weekly, April2nd, (int)DayOfWeek.Saturday);
            AssertInterval(interval, April2nd, April8th, Period.Weekly);

            interval = Interval.Create(Period.Weekly, April1st, (int)DayOfWeek.Saturday);
            AssertInterval(interval, Mar26th, April1st, Period.Weekly);

            interval = Interval.Create(Period.Weekly, Mar31st, (int)DayOfWeek.Saturday);
            AssertInterval(interval, Mar26th, April1st, Period.Weekly);

            interval = Interval.Create(Period.Weekly, Mar30th, (int)DayOfWeek.Saturday);
            AssertInterval(interval, Mar26th, April1st, Period.Weekly);

            interval = Interval.Create(Period.Weekly, Mar29th, (int)DayOfWeek.Saturday);
            AssertInterval(interval, Mar26th, April1st, Period.Weekly);

            interval = Interval.Create(Period.Weekly, April3rd, (int)DayOfWeek.Saturday);
            AssertInterval(interval, April2nd, April8th, Period.Weekly);

            interval = Interval.Create(Period.Weekly, Mar28th, (int)DayOfWeek.Saturday);
            AssertInterval(interval, Mar26th, April1st, Period.Weekly);

            interval = interval.Next();
            AssertInterval(interval, April2nd, April8th, Period.Weekly);
        }

    }
}