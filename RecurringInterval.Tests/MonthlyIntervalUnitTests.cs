using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecurringInterval.Tests
{
    [TestClass]
    public class MonthlyIntervalUnitTests : Dates
    {

        [TestMethod]
        public void Test_MonthlyInterval_LastDayOfMonth()
        {
            var interval = Interval.Create(Period.Monthly, April1st);
            AssertInterval(interval, April1st, April30th, Period.Monthly);

            interval = interval.Next();
            AssertInterval(interval, May1st, May31st, Period.Monthly);
        }

        [TestMethod]
        public void Test_MonthlyInterval_1stDayOfMonth()
        {
            var interval = Interval.Create(Period.Monthly, April2nd);
            AssertInterval(interval, April2nd, May1st, Period.Monthly);

            interval = Interval.Create(Period.Monthly, Mar2nd);
            AssertInterval(interval, Mar2nd, April1st, Period.Monthly);

            interval = interval.Next();
            AssertInterval(interval, April2nd, May1st, Period.Monthly);
        }

        [TestMethod]
        public void Test_MonthlyInterval_2ndDayOfMonth()
        {
            var interval = Interval.Create(Period.Monthly, April3rd);
            AssertInterval(interval, April3rd, May2nd, Period.Monthly);

            interval = Interval.Create(Period.Monthly, Mar3rd);
            AssertInterval(interval, Mar3rd, April2nd, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April3rd);
            AssertInterval(interval, April3rd, May2nd, Period.Monthly);

            interval = Interval.Create(Period.Monthly, Mar3rd);
            AssertInterval(interval, Mar3rd, April2nd, Period.Monthly);

            interval = interval.Next();
            AssertInterval(interval, April3rd, May2nd, Period.Monthly);
        }

        [TestMethod]
        public void Test_MonthlyInterval_31stDayOfMonth()
        {
            var interval = Interval.Create(Period.Monthly, April1st);
            AssertInterval(interval, April1st, April30th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April1st);
            AssertInterval(interval, April1st, April30th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April1st);
            AssertInterval(interval, April1st, April30th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April1st);
            AssertInterval(interval, April1st, April30th, Period.Monthly);

            interval = interval.Next();
            AssertInterval(interval, May1st, May31st, Period.Monthly);
        }

        [TestMethod]
        public void Test_MonthlyInterval_30thDayOfMonth()
        {
            var interval = Interval.Create(Period.Monthly, Mar31st);
            AssertInterval(interval, Mar31st, April29th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, May1st);
            AssertInterval(interval, May1st, May31st, Period.Monthly);
        }


        [TestMethod]
        public void Test_MonthlyInterval_29thDayOfMonth()
        {
            var interval = Interval.Create(Period.Monthly, April30th);
            AssertInterval(interval, April30th, May29th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, Mar30th);
            AssertInterval(interval, Mar30th, April29th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, Mar30th);
            AssertInterval(interval, Mar30th, April29th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April30th);
            AssertInterval(interval, April30th, May29th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, Mar30th);
            AssertInterval(interval, Mar30th, April29th, Period.Monthly);

            interval = interval.Next();
            AssertInterval(interval, April30th, May29th, Period.Monthly);
        }
    }
}