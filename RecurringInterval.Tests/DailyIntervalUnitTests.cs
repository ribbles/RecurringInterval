using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecurringInterval.Tests
{
    [TestClass]
    public class DailyIntervalUnitTests : Dates
    {

        [TestMethod]
        public void Test_DailyInterval_OneDay()
        {
            var interval = Interval.Create(Period.Daily, April2nd);
            AssertInterval(interval, April2nd, April2nd, Period.Daily);

            interval = interval.Next();
            AssertInterval(interval, April3rd, April3rd, Period.Daily);
        }
        



    }
}