using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateMath.Tests
{
    [TestClass]
    public class BiMonthlyIntervalUnitTests: Dates
    {
        /**** WARNING **
         * We are making assumptions here.
         * if the date is 1, move to 16th
         * if the date is 2-12, add 15
         * if the date is 13-15, move to last day of month
         * if the date is 16, move to 1st day of next month
         * if the date is 17-27, add month - 15
         * if the date is 28-31, move to 15th day of next month
        */


        [TestMethod]
        public void Test_BiMonthlyInterval_1()
        {
            // 2-16, 17-1
            var interval = Interval.Create(Period.BiMonthly, April1st, 1);
            AssertInterval(interval, Mar17th, April1st, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, April2nd, April16th, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, April17th, May1st, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, May2nd, May16th, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, May17th, Jun1st, Period.BiMonthly);
            
            interval = interval.Next();
            AssertInterval(interval, Jun2nd, Jun16th, Period.BiMonthly);
        }

        [TestMethod]
        public void Test_BiMonthlyInterval_2()
        {
            // 3-17, 18-2
            var interval = Interval.Create(Period.BiMonthly, April1st, 2);
            AssertInterval(interval, Mar18th, April2nd, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, April3rd, April17th, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, April18th, May2nd, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, May3rd, May17th, Period.BiMonthly);
        }


        [TestMethod]
        public void Test_BiMonthlyInterval_3()
        {
            //4-18, 19-3
            var interval = Interval.Create(Period.BiMonthly, April1st, 3);
            AssertInterval(interval, Mar19th, April3rd, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, April4th, April18th, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, April19th, May3rd, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, May4th, May18th, Period.BiMonthly);
        }

        [TestMethod]
        public void Test_BiMonthlyInterval_14()
        {
            //15- -1, 1-14
            var interval = Interval.Create(Period.BiMonthly, Feb14th, 14);
            AssertInterval(interval, Feb1st, Feb14th, Period.BiMonthly);
            
            interval = interval.Next();
            AssertInterval(interval, Feb15th, Feb28th, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, Mar1st, Mar14th, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, Mar15th, Mar31st, Period.BiMonthly);
        }

        [TestMethod]
        public void Test_BiMonthlyInterval_15()
        {
            // 16- -1, 1-15
            var interval = Interval.Create(Period.BiMonthly, Feb14th, 15);
            AssertInterval(interval, Feb1st, Feb15th, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, Feb16th, Feb28th, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, Mar1st, Mar15th, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, Mar16th, Mar31st, Period.BiMonthly);
        }

        [TestMethod]
        public void Test_BiMonthlyInterval_16()
        {
            // 17- 1, 2-16
            var interval = Interval.Create(Period.BiMonthly, Feb14th, 16);
            AssertInterval(interval, Feb2nd, Feb16th, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, Feb17th, Mar1st, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, Mar2nd, Mar16th, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, Mar17th, April1st, Period.BiMonthly);
        }

        [TestMethod]
        public void Test_BiMonthlyInterval_17()
        {
            // 3 - 17, 18 - 2
            var interval = Interval.Create(Period.BiMonthly, Feb14th, 17);
            AssertInterval(interval, Feb3rd, Feb17th, Period.BiMonthly);

            interval = interval.Next();

            AssertInterval(interval, Feb18th, Mar2nd, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, Mar3rd, Mar17th, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, Mar18th, April2nd, Period.BiMonthly);
        }

        [TestMethod]
        public void Test_BiMonthlyInterval_27()
        {
            // 13 - 27, 28 - 12
            var interval = Interval.Create(Period.BiMonthly, Feb14th, 27);
            AssertInterval(interval, Feb13th, Feb27th, Period.BiMonthly);
            
            interval = interval.Next();

            AssertInterval(interval, Feb28th, Mar12th, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, Mar13th, Mar27th, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, Mar28th, April12th, Period.BiMonthly);
        }

        [TestMethod]
        public void Test_BiMonthlyInterval_28()
        {
            var interval = Interval.Create(Period.BiMonthly, Feb16th, 28);
            AssertInterval(interval, Feb16th, Feb28th, Period.BiMonthly);

            interval = interval.Next();

            AssertInterval(interval, Mar1st, Mar15th, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, Mar16th, Mar31st, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, April1st, April15th, Period.BiMonthly);
        }

        [TestMethod]
        public void Test_BiMonthlyInterval_Minus1()
        {
            var interval = Interval.Create(Period.BiMonthly, Feb16th, -1);
            AssertInterval(interval, Feb16th, Feb28th, Period.BiMonthly);

            interval = interval.Next();

            AssertInterval(interval, Mar1st, Mar15th, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, Mar16th, Mar31st, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, April1st, April15th, Period.BiMonthly);

        }
    }
}