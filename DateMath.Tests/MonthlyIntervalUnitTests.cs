using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateMath.Tests
{
    [TestClass]
    public class MonthlyIntervalUnitTests : Dates
    {

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
            AssertInterval(interval, Mar2nd, April1st, Period.Monthly);

            interval = interval.Next();
            AssertInterval(interval, April2nd, May1st, Period.Monthly);
        }

        [TestMethod]
        public void Test_MonthlyInterval_2ndDayOfMonth()
        {
            var interval = Interval.Create(Period.Monthly, April30th, 2);
            AssertInterval(interval, April3rd, May2nd, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April2nd, 2);
            AssertInterval(interval, Mar3rd, April2nd, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April29th, 2);
            AssertInterval(interval, April3rd, May2nd, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April1st, 2);
            AssertInterval(interval, Mar3rd, April2nd, Period.Monthly);

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
            AssertInterval(interval, Mar31st, April30th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April2nd, 30);
            AssertInterval(interval, Mar31st, April30th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April29th, 30);
            AssertInterval(interval, Mar31st, April30th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, May1st, 30);
            AssertInterval(interval, May1st, May30th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April1st, 30);
            AssertInterval(interval, Mar31st, April30th, Period.Monthly);

            interval = interval.Next();
            AssertInterval(interval, May1st, May30th, Period.Monthly);
        }


        [TestMethod]
        public void Test_MonthlyInterval_29thDayOfMonth()
        {
            var interval = Interval.Create(Period.Monthly, April30th, 29);
            AssertInterval(interval, April30th, May29th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April2nd, 29);
            AssertInterval(interval, Mar30th, April29th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April29th, 29);
            AssertInterval(interval, Mar30th, April29th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, May1st, 29);
            AssertInterval(interval, April30th, May29th, Period.Monthly);

            interval = Interval.Create(Period.Monthly, April1st, 29);
            AssertInterval(interval, Mar30th, April29th, Period.Monthly);

            interval = interval.Next();
            AssertInterval(interval, April30th, May29th, Period.Monthly);
        }
    }
}