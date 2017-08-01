using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecurringInterval.Tests
{
    [TestClass]
    public class FourFourFourUnitTests: Dates
    {
        [TestMethod]
        public void Test_FourFourFourInterval()
        {
            var interval = Interval.Create(Period.FourFourFour, new DateTime(2017, 7, 1), 0);
            AssertInterval(interval, new DateTime(2017, 7, 1), new DateTime(2017, 7, 28), Period.FourFourFour, false);

            interval = interval.Next();
            AssertInterval(interval, new DateTime(2017, 7, 29), new DateTime(2017, 8, 25), Period.FourFourFour, false);

        }
    }
}
