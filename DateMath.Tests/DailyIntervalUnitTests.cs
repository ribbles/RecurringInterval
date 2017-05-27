using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateMath.Tests
{
    [TestClass]
    public class DailyIntervalUnitTests
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
        public void Test_DailyInterval_OneDay()
        {
            var interval = Interval.Create(Period.Daily, April2nd, 1);
            AssertInterval(interval, April2nd, April2nd, Period.Daily);

            interval = interval.Next();
            AssertInterval(interval, April3rd, April3rd, Period.Daily);
        }

        [TestMethod]
        public void Test_DailyInterval_TwoDay()
        {
            var interval = Interval.Create(Period.Daily, March26th, 2);
            AssertInterval(interval, March26th, March27th, Period.Daily);

            interval = interval.Next();
            AssertInterval(interval, March28th, March29th, Period.Daily);
        }



    }
}