using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecurringInterval.Tests
{
    [TestClass]
    public class QuarterlyIntervalUnitTests : Dates
    {


        [TestMethod]
        public void Test_QuarterlyInterval_LastDayOfQuarter()
        {
            var interval = Interval.Create(Period.Quarterly, April30th, -1);
            AssertInterval(interval, April1st, Jun30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, Jun30th, -1);
            AssertInterval(interval, April1st, Jun30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April2nd, -1);
            AssertInterval(interval, April1st, Jun30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April29th, -1);
            AssertInterval(interval, April1st, Jun30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, Jan2nd, -1);
            AssertInterval(interval, Jan1st, Mar31st, Period.Quarterly);

            interval = interval.Next();
            AssertInterval(interval, April1st, Jun30th, Period.Quarterly);
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
            AssertInterval(interval, Mar31st, Jun28th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, Jun30th, 89);
            AssertInterval(interval, Jun29th, Sept27th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April2nd, 89);
            AssertInterval(interval, Mar31st, Jun28th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April29th, 89);
            AssertInterval(interval, Mar31st, Jun28th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, Jan2nd, 89);
            AssertInterval(interval, Dec29th2016, Mar30th, Period.Quarterly);

            interval = interval.Next();
            AssertInterval(interval, Mar31st, Jun28th, Period.Quarterly);
        }

        [TestMethod]
        public void Test_QuarterlyInterval_90thDayOfQuarter()
        {
            var interval = Interval.Create(Period.Quarterly, April30th, 90);
            AssertInterval(interval, April1st, Jun30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, Jun30th, 90);
            AssertInterval(interval, April1st, Jun30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April2nd, 90);
            AssertInterval(interval, April1st, Jun30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April29th, 90);
            AssertInterval(interval, April1st, Jun30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, Jan2nd, 90);
            AssertInterval(interval, Jan1st, Mar31st, Period.Quarterly);

            interval = interval.Next();
            AssertInterval(interval, April1st, Jun30th, Period.Quarterly);
        }
    }
}
