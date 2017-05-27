using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateMath.Tests
{
    [TestClass]
    public class BiWeeklyIntervalUnitTests
    {
        private static readonly DateTime March26th = new DateTime(2017, 3, 26);
        private static readonly DateTime April8th = new DateTime(2017, 4, 8);
        private static readonly DateTime April9th = new DateTime(2017, 4, 9);
        private static readonly DateTime April22nd = new DateTime(2017, 4, 22);

        void AssertInterval(Interval interval, DateTime start, DateTime end, Period period)
        {
            Assert.IsNotNull(interval);
            Assert.AreEqual(period, interval.Period);
            Assert.AreEqual(start, interval.StartDate);
            Assert.AreEqual(end, interval.EndDate);
        }


        [TestMethod]
        public void Test_BiWeeklyInterval()
        {
            var interval = Interval.Create(Period.BiWeekly, March26th, 0);
            AssertInterval(interval, March26th, April8th, Period.BiWeekly);

            interval = interval.Next();
            AssertInterval(interval, April9th, April22nd, Period.BiWeekly);
        }
    }
}