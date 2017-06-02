using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecurringInterval.Tests
{
    [TestClass]
    public class WeeklyIntervalUnitTests : Dates
    {


        [TestMethod]
        public void Test_WeeklyInterval_Sunday()
        {
            var factory = new IntervalFactory();
            var interval = factory.CreateFromEndDay(Period.Weekly, April2nd, (int)DayOfWeek.Sunday);
            AssertInterval(interval, Mar27th, April2nd, Period.Weekly);

            interval = factory.CreateFromEndDay(Period.Weekly, April1st, (int)DayOfWeek.Sunday);
            AssertInterval(interval, Mar27th, April2nd, Period.Weekly);

            interval = factory.CreateFromEndDay(Period.Weekly, Mar31st, (int)DayOfWeek.Sunday);
            AssertInterval(interval, Mar27th, April2nd, Period.Weekly);

            interval = factory.CreateFromEndDay(Period.Weekly, Mar30th, (int)DayOfWeek.Sunday);
            AssertInterval(interval, Mar27th, April2nd, Period.Weekly);

            interval = factory.CreateFromEndDay(Period.Weekly, Mar29th, (int)DayOfWeek.Sunday);
            AssertInterval(interval, Mar27th, April2nd, Period.Weekly);

            interval = factory.CreateFromEndDay(Period.Weekly, April3rd, (int)DayOfWeek.Sunday);
            AssertInterval(interval, April3rd, April9th, Period.Weekly);

            interval = factory.CreateFromEndDay(Period.Weekly, Mar28th, (int)DayOfWeek.Sunday);
            AssertInterval(interval, Mar27th, April2nd, Period.Weekly);

            interval = interval.Next();
            AssertInterval(interval, April3rd, April9th, Period.Weekly);
        }

        [TestMethod]
        public void Test_WeeklyInterval_Saturday()
        {
            var factory = new IntervalFactory();

            var interval = factory.CreateFromEndDay(Period.Weekly, April2nd, (int)DayOfWeek.Saturday);
            AssertInterval(interval, April2nd, April8th, Period.Weekly);

            interval = factory.CreateFromEndDay(Period.Weekly, April1st, (int)DayOfWeek.Saturday);
            AssertInterval(interval, Mar26th, April1st, Period.Weekly);

            interval = factory.CreateFromEndDay(Period.Weekly, Mar31st, (int)DayOfWeek.Saturday);
            AssertInterval(interval, Mar26th, April1st, Period.Weekly);

            interval = factory.CreateFromEndDay(Period.Weekly, Mar30th, (int)DayOfWeek.Saturday);
            AssertInterval(interval, Mar26th, April1st, Period.Weekly);

            interval = factory.CreateFromEndDay(Period.Weekly, Mar29th, (int)DayOfWeek.Saturday);
            AssertInterval(interval, Mar26th, April1st, Period.Weekly);

            interval = factory.CreateFromEndDay(Period.Weekly, April3rd, (int)DayOfWeek.Saturday);
            AssertInterval(interval, April2nd, April8th, Period.Weekly);

            interval = factory.CreateFromEndDay(Period.Weekly, Mar28th, (int)DayOfWeek.Saturday);
            AssertInterval(interval, Mar26th, April1st, Period.Weekly);

            interval = interval.Next();
            AssertInterval(interval, April2nd, April8th, Period.Weekly);
        }

        [TestMethod]
        public void Test_WeeklyInterval_SundayEnd()
        {
            var factory = new IntervalFactory();

            var result = factory.CreateFromEndDay(Period.Weekly, DateTime.UtcNow, (int)DayOfWeek.Sunday);

            // assert
            Assert.AreEqual(DayOfWeek.Monday, result.StartDate.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Monday, result.Next().StartDate.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Sunday, result.EndDate.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Sunday, result.Next().EndDate.DayOfWeek);
        }
        [TestMethod]
        public void Test_WeeklyInterval_SaturdayEnd()
        {
            var factory = new IntervalFactory();

            var result = factory.CreateFromEndDay(Period.Weekly, DateTime.UtcNow, (int)DayOfWeek.Saturday);

            // assert
            Assert.AreEqual(DayOfWeek.Sunday, result.StartDate.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Sunday, result.Next().StartDate.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Saturday, result.EndDate.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Saturday, result.Next().EndDate.DayOfWeek);
        }

    }
}