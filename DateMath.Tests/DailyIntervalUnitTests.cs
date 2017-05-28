using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateMath.Tests
{
    [TestClass]
    public class DailyIntervalUnitTests : Dates
    {

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
            var interval = Interval.Create(Period.Daily, Mar26th, 2);
            AssertInterval(interval, Mar26th, Mar27th, Period.Daily, false);

            interval = interval.Next();
            AssertInterval(interval, Mar28th, Mar29th, Period.Daily, false);
        }



    }
}