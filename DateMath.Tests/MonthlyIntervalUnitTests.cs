using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateMath.Tests
{
    [TestClass]
    public class MonthlyIntervalUnitTests
    {
        private static readonly DateTime March2nd = new DateTime(2017, 3, 2);
        private static readonly DateTime March3rd = new DateTime(2017, 3, 3);
        private static readonly DateTime March30th = new DateTime(2017, 3, 30);
        private static readonly DateTime March31st = new DateTime(2017, 3, 31);
        private static readonly DateTime April1st = new DateTime(2017, 4, 1);
        private static readonly DateTime April2nd = new DateTime(2017, 4, 2);
        private static readonly DateTime April3rd = new DateTime(2017, 4, 3);
        private static readonly DateTime April29th = new DateTime(2017, 4, 29);
        private static readonly DateTime April30th = new DateTime(2017, 4, 30);
        private static readonly DateTime May1st = new DateTime(2017, 5, 1);
        private static readonly DateTime May2nd = new DateTime(2017, 5, 2);
        private static readonly DateTime May29th = new DateTime(2017, 5, 29);
        private static readonly DateTime May30th = new DateTime(2017, 5, 30);
        private static readonly DateTime May31st = new DateTime(2017, 5, 31);

        void AssertInterval(Interval interval, DateTime start, DateTime end, Period period)
        {
            Assert.IsNotNull(interval);
            Assert.AreEqual(period, interval.Period);
            Assert.AreEqual(start, interval.StartDate);
            Assert.AreEqual(end, interval.EndDate);
        }


        [TestMethod]
        public void Test_MonthlyInterval_LastDayOfMonth()
        {
            var interval = Interval.Create(Period.Monthly, April1st, -1);
            AssertInterval(interval, April1st, April30th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April2nd, -1);
            AssertInterval(interval, April1st, April30th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April29th, -1);
            AssertInterval(interval, April1st, April30th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April30th, -1);
            AssertInterval(interval, April1st, April30th, Period.Monthly);

            interval = interval.Next();
            AssertInterval(interval, May1st, May31st, Period.Monthly);
        }

        [TestMethod]
        public void Test_MonthlyInterval_1stDayOfMonth()
        {
            var interval = Interval.Create(Period.Monthly, April30th, 1);
            AssertInterval(interval, April2nd, May1st, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April2nd, 1);
            AssertInterval(interval, April2nd, May1st, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April29th, 1);
            AssertInterval(interval, April2nd, May1st, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April1st, 1);
            AssertInterval(interval, March2nd, April1st, Period.Monthly);

            interval = interval.Next();
            AssertInterval(interval, April2nd, May1st, Period.Monthly);
        }

        [TestMethod]
        public void Test_MonthlyInterval_2ndDayOfMonth()
        {
            var interval = Interval.Create(Period.Monthly, April30th, 2);
            AssertInterval(interval, April3rd, May2nd, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April2nd, 2);
            AssertInterval(interval, March3rd, April2nd, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April29th, 2);
            AssertInterval(interval, April3rd, May2nd, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April1st, 2);
            AssertInterval(interval, March3rd, April2nd, Period.Monthly);

            interval = interval.Next();
            AssertInterval(interval, April3rd, May2nd, Period.Monthly);
        }

        [TestMethod]
        public void Test_MonthlyInterval_31stDayOfMonth()
        {
            var interval = Interval.Create(Period.Monthly, April1st, 31);
            AssertInterval(interval, April1st, April30th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April2nd, 31);
            AssertInterval(interval, April1st, April30th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April29th, 31);
            AssertInterval(interval, April1st, April30th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April30th, 31);
            AssertInterval(interval, April1st, April30th, Period.Monthly);

            interval = interval.Next();
            AssertInterval(interval, May1st, May31st, Period.Monthly);
        }

        [TestMethod]
        public void Test_MonthlyInterval_30thDayOfMonth()
        {
            var interval = Interval.Create(Period.Monthly, April30th, 30);
            AssertInterval(interval, March31st, April30th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April2nd, 30);
            AssertInterval(interval, March31st, April30th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April29th, 30);
            AssertInterval(interval, March31st, April30th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, May1st, 30);
            AssertInterval(interval, May1st, May30th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April1st, 30);
            AssertInterval(interval, March31st, April30th, Period.Monthly);

            interval = interval.Next();
            AssertInterval(interval, May1st, May30th, Period.Monthly);
        }


        [TestMethod]
        public void Test_MonthlyInterval_29thDayOfMonth()
        {
            var interval = Interval.Create(Period.Monthly, April30th, 29);
            AssertInterval(interval, April30th, May29th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April2nd, 29);
            AssertInterval(interval, March30th, April29th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April29th, 29);
            AssertInterval(interval, March30th, April29th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, May1st, 29);
            AssertInterval(interval, April30th, May29th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April1st, 29);
            AssertInterval(interval, March30th, April29th, Period.Monthly);

            interval = interval.Next();
            AssertInterval(interval, April30th, May29th, Period.Monthly);
        }
    }
}