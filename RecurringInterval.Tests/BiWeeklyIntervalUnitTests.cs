using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecurringInterval.Tests
{
    [TestClass]
    public class BiWeeklyIntervalUnitTests: Dates
    {

        [TestMethod]
        public void Test_BiWeeklyInterval()
        {
            var interval = Interval.Create(Period.BiWeekly, Mar26th);
            AssertInterval(interval, Mar26th, April8th, Period.BiWeekly, false);

            interval = interval.Next();
            AssertInterval(interval, April9th, April22nd, Period.BiWeekly, false);
        }
    }
}