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
            var interval = Interval.Create(Period.Quarterly, April1st);
            AssertInterval(interval, April1st, Jun30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April1st);
            AssertInterval(interval, April1st, Jun30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April1st);
            AssertInterval(interval, April1st, Jun30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April1st);
            AssertInterval(interval, April1st, Jun30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, Jan1st);
            AssertInterval(interval, Jan1st, Mar31st, Period.Quarterly);

            interval = interval.Next();
            AssertInterval(interval, April1st, Jun30th, Period.Quarterly);
        }

        [TestMethod]
        public void Test_QuarterlyInterval_1stDayOfQuarter()
        {
            var interval = Interval.Create(Period.Quarterly, April2nd);
            AssertInterval(interval, April2nd, July1st, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April2nd);
            AssertInterval(interval, April2nd, July1st, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April2nd);
            AssertInterval(interval, April2nd, July1st, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, Jan2nd);
            AssertInterval(interval, Jan2nd, April1st, Period.Quarterly);

            interval = interval.Next();
            AssertInterval(interval, April2nd, July1st, Period.Quarterly);
        }

        [TestMethod]
        public void Test_QuarterlyInterval_2ndDayOfQuarter()
        {
            var interval = Interval.Create(Period.Quarterly, April3rd);
            AssertInterval(interval, April3rd, July2nd, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, Jan3rd);
            AssertInterval(interval, Jan3rd, April2nd, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April3rd);
            AssertInterval(interval, April3rd, July2nd, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, Jan3rd);
            AssertInterval(interval, Jan3rd, April2nd, Period.Quarterly);

            interval = interval.Next();
            AssertInterval(interval, April3rd, July2nd, Period.Quarterly);
        }

        [TestMethod]
        public void Test_QuarterlyInterval_30thDayOfQuarter()
        {
            var interval = Interval.Create(Period.Quarterly, Jan31st);
            AssertInterval(interval, Jan31st, April29th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, May1st);
            AssertInterval(interval, May1st, July31st, Period.Quarterly);
        }



        [TestMethod]
        public void Test_QuarterlyInterval_89thDayOfQuarter()
        {
            var interval = Interval.Create(Period.Quarterly, Mar31st);
            AssertInterval(interval, Mar31st, Jun29th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, Dec29th2016);
            AssertInterval(interval, Dec29th2016, Mar28th, Period.Quarterly);

            interval = interval.Next();
            AssertInterval(interval, Mar29th, Jun28th, Period.Quarterly);
        }

        [TestMethod]
        public void Test_QuarterlyInterval_90thDayOfQuarter()
        {
            var interval = Interval.Create(Period.Quarterly, April1st);
            AssertInterval(interval, April1st, Jun30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April1st);
            AssertInterval(interval, April1st, Jun30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April1st);
            AssertInterval(interval, April1st, Jun30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, April1st);
            AssertInterval(interval, April1st, Jun30th, Period.Quarterly);

            interval = Interval.Create(Period.Quarterly, Jan1st);
            AssertInterval(interval, Jan1st, Mar31st, Period.Quarterly);

            interval = interval.Next();
            AssertInterval(interval, April1st, Jun30th, Period.Quarterly);
        }
    }
}
