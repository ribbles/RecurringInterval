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
            var interval = factory.CreateFromStartDate(Period.Weekly, Mar27th);
            AssertInterval(interval, Mar27th, April2nd, Period.Weekly);
            
            interval = factory.CreateFromStartDate(Period.Weekly, April3rd);
            AssertInterval(interval, April3rd, April9th, Period.Weekly);

            interval = factory.CreateFromStartDate(Period.Weekly, Mar27th);
            AssertInterval(interval, Mar27th, April2nd, Period.Weekly);

            interval = interval.Next();
            AssertInterval(interval, April3rd, April9th, Period.Weekly);
        }

        [TestMethod]
        public void Test_WeeklyInterval_Saturday()
        {
            var factory = new IntervalFactory();

            var interval = factory.CreateFromStartDate(Period.Weekly, April2nd);
            AssertInterval(interval, April2nd, April8th, Period.Weekly);

            interval = factory.CreateFromStartDate(Period.Weekly, Mar26th);
            AssertInterval(interval, Mar26th, April1st, Period.Weekly);

            interval = interval.Next();
            AssertInterval(interval, April2nd, April8th, Period.Weekly);
        }

        [TestMethod]
        public void Test_WeeklyInterval_SundayEnd()
        {
            var factory = new IntervalFactory();

            var result = factory.CreateFromStartDate(Period.Weekly, new DateTime(2017, 8, 7));

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

            var result = factory.CreateFromStartDate(Period.Weekly, new DateTime(2017, 8, 6));

            // assert
            Assert.AreEqual(DayOfWeek.Sunday, result.StartDate.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Sunday, result.Next().StartDate.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Saturday, result.EndDate.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Saturday, result.Next().EndDate.DayOfWeek);
        }

    }
}