using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateMath.Tests
{
    [TestClass]
    public class QuarterlyIntervalUnitTests
    {


        private static readonly DateTime Dec29th = new DateTime(2016, 12, 29);
        private static readonly DateTime Jan1st = new DateTime(2017, 1, 1);
        private static readonly DateTime Jan2nd = new DateTime(2017, 1, 2);
        private static readonly DateTime Jan3rd = new DateTime(2017, 1, 3);
        private static readonly DateTime Jan31st = new DateTime(2017, 1, 31);
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
        private static readonly DateTime June28th = new DateTime(2017, 6, 28);
        private static readonly DateTime June29th = new DateTime(2017, 6, 29);
        private static readonly DateTime June30th = new DateTime(2017, 6, 30);
        private static readonly DateTime July1st = new DateTime(2017, 7, 1);
        private static readonly DateTime July2nd = new DateTime(2017, 7, 2);
        private static readonly DateTime July30th = new DateTime(2017, 7, 30);
        private static readonly DateTime July31st = new DateTime(2017, 7, 31);
        private static readonly DateTime August30th = new DateTime(2017, 8, 30);
        private static readonly DateTime Sept27th = new DateTime(2017, 9, 27);
        private static readonly DateTime Oct30th = new DateTime(2017, 10, 30);


        void AssertInterval(Interval interval, DateTime start, DateTime end, Period period)
        {
            Assert.IsNotNull(interval);
            Assert.AreEqual(period, interval.Period);
            Assert.AreEqual(start, interval.StartDate);
            Assert.AreEqual(end, interval.EndDate);
        }


        [TestMethod]
        public void Test_QuarterlyInterval_LastDayOfQuarter()
        {
            var interval = Interval.Create(Period.Quarterly, April30th, -1);
            AssertInterval(interval, April1st, June30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, June30th, -1);
            AssertInterval(interval, April1st, June30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April2nd, -1);
            AssertInterval(interval, April1st, June30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April29th, -1);
            AssertInterval(interval, April1st, June30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, Jan2nd, -1);
            AssertInterval(interval, Jan1st, March31st, Period.Quarterly);

            interval = interval.Next();
            AssertInterval(interval, April1st, June30th, Period.Quarterly);
        }

        [TestMethod]
        public void Test_QuarterlyInterval_1stDayOfQuarter()
        {
            var interval = Interval.Create(Period.Quarterly, April30th, 1);
            AssertInterval(interval, April2nd, July1st, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April2nd, 1);
            AssertInterval(interval, April2nd, July1st, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April29th, 1);
            AssertInterval(interval, April2nd, July1st, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April1st, 1);
            AssertInterval(interval, Jan2nd, April1st, Period.Quarterly);

            interval = interval.Next();
            AssertInterval(interval, April2nd, July1st, Period.Quarterly);
        }

        [TestMethod]
        public void Test_QuarterlyInterval_2ndDayOfQuarter()
        {
            var interval = Interval.Create(Period.Quarterly, April30th, 2);
            AssertInterval(interval, April3rd, July2nd, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April2nd, 2);
            AssertInterval(interval, Jan3rd, April2nd, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April29th, 2);
            AssertInterval(interval, April3rd, July2nd, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April1st, 2);
            AssertInterval(interval, Jan3rd, April2nd, Period.Quarterly);

            interval = interval.Next();
            AssertInterval(interval, April3rd, July2nd, Period.Quarterly);
        }

        [TestMethod]
        public void Test_QuarterlyInterval_30thDayOfQuarter()
        {
            var interval = Interval.Create(Period.Quarterly, April30th, 30);
            AssertInterval(interval, Jan31st, April30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April2nd, 30);
            AssertInterval(interval, Jan31st, April30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April29th, 30);
            AssertInterval(interval, Jan31st, April30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, May1st, 30);
            AssertInterval(interval, May1st, July30th, Period.Quarterly);

            interval = interval.Next();
            AssertInterval(interval, July31st, Oct30th, Period.Quarterly);
        }



        [TestMethod]
        public void Test_QuarterlyInterval_89thDayOfQuarter()
        {
            var interval = Interval.Create(Period.Quarterly, April30th, 89);
            AssertInterval(interval, March31st, June28th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, June30th, 89);
            AssertInterval(interval, June29th, Sept27th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April2nd, 89);
            AssertInterval(interval, March31st, June28th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April29th, 89);
            AssertInterval(interval, March31st, June28th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, Jan2nd, 89);
            AssertInterval(interval, Dec29th, March30th, Period.Quarterly);

            interval = interval.Next();
            AssertInterval(interval, March31st, June28th, Period.Quarterly);
        }

        [TestMethod]
        public void Test_QuarterlyInterval_90thDayOfQuarter()
        {
            var interval = Interval.Create(Period.Quarterly, April30th, 90);
            AssertInterval(interval, April1st, June30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, June30th, 90);
            AssertInterval(interval, April1st, June30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April2nd, 90);
            AssertInterval(interval, April1st, June30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April29th, 90);
            AssertInterval(interval, April1st, June30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, Jan2nd, 90);
            AssertInterval(interval, Jan1st, March31st, Period.Quarterly);

            interval = interval.Next();
            AssertInterval(interval, April1st, June30th, Period.Quarterly);
        }
    }
}
