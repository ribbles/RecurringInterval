using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateMath.Tests
{
    [TestClass]
    public class WeeklyIntervalUnitTests
    {
        private static readonly DateTime March26th = new DateTime(2017, 3, 26);
        private static readonly DateTime March27th = new DateTime(2017, 3, 27);
        private static readonly DateTime March28th = new DateTime(2017, 3, 28);
        private static readonly DateTime March29th = new DateTime(2017, 3, 29);
        private static readonly DateTime March30th = new DateTime(2017, 3, 30);
        private static readonly DateTime March31st = new DateTime(2017, 3, 31);
        private static readonly DateTime April1st = new DateTime(2017, 4, 1);
        private static readonly DateTime April2nd = new DateTime(2017, 4, 2);
        private static readonly DateTime April3rd = new DateTime(2017, 4, 3);
        private static readonly DateTime April8th = new DateTime(2017, 4, 8);
        private static readonly DateTime April9th = new DateTime(2017, 4, 9);

        void AssertInterval(Interval interval, DateTime start, DateTime end, Period period)
        {
            Assert.IsNotNull(interval);
            Assert.AreEqual(period, interval.Period);
            Assert.AreEqual(start, interval.StartDate);
            Assert.AreEqual(end, interval.EndDate);
        }


        [TestMethod]
        public void Test_MonthlyInterval_Sunday()
        {
            var interval = Interval.Create(Period.Weekly, April2nd, (int)DayOfWeek.Sunday);
            AssertInterval(interval, March27th, April2nd, Period.Weekly);

            interval = Interval.Create(Period.Weekly, April1st, (int)DayOfWeek.Sunday);
            AssertInterval(interval, March27th, April2nd, Period.Weekly);

            interval = Interval.Create(Period.Weekly, March31st, (int)DayOfWeek.Sunday);
            AssertInterval(interval, March27th, April2nd, Period.Weekly);

            interval = Interval.Create(Period.Weekly, March30th, (int)DayOfWeek.Sunday);
            AssertInterval(interval, March27th, April2nd, Period.Weekly);

            interval = Interval.Create(Period.Weekly, March29th, (int)DayOfWeek.Sunday);
            AssertInterval(interval, March27th, April2nd, Period.Weekly);

            interval = Interval.Create(Period.Weekly, April3rd, (int)DayOfWeek.Sunday);
            AssertInterval(interval, April3rd, April9th, Period.Weekly);
            
            interval = Interval.Create(Period.Weekly, March28th, (int)DayOfWeek.Sunday);
            AssertInterval(interval, March27th, April2nd, Period.Weekly);

            interval = interval.Next();
            AssertInterval(interval, April3rd, April9th, Period.Weekly);
        }

        [TestMethod]
        public void Test_MonthlyInterval_Saturday()
        {
            var interval = Interval.Create(Period.Weekly, April2nd, (int)DayOfWeek.Saturday);
            AssertInterval(interval, April2nd, April8th, Period.Weekly);

            interval = Interval.Create(Period.Weekly, April1st, (int)DayOfWeek.Saturday);
            AssertInterval(interval, March26th, April1st, Period.Weekly);

            interval = Interval.Create(Period.Weekly, March31st, (int)DayOfWeek.Saturday);
            AssertInterval(interval, March26th, April1st, Period.Weekly);

            interval = Interval.Create(Period.Weekly, March30th, (int)DayOfWeek.Saturday);
            AssertInterval(interval, March26th, April1st, Period.Weekly);

            interval = Interval.Create(Period.Weekly, March29th, (int)DayOfWeek.Saturday);
            AssertInterval(interval, March26th, April1st, Period.Weekly);

            interval = Interval.Create(Period.Weekly, April3rd, (int)DayOfWeek.Saturday);
            AssertInterval(interval, April2nd, April8th, Period.Weekly);

            interval = Interval.Create(Period.Weekly, March28th, (int)DayOfWeek.Saturday);
            AssertInterval(interval, March26th, April1st, Period.Weekly);

            interval = interval.Next();
            AssertInterval(interval, April2nd, April8th, Period.Weekly);
        }

    }
}