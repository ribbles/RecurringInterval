using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecurringInterval.Tests
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
            var interval = Interval.Create(Period.BiMonthly, Mar17th);
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
            var interval = Interval.Create(Period.BiMonthly, Mar18th);
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
            var interval = Interval.Create(Period.BiMonthly, Mar19th);
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
            var interval = Interval.Create(Period.BiMonthly, Feb1st);
            AssertInterval(interval, Feb1st, Feb15th, Period.BiMonthly);
            
            interval = interval.Next();
            AssertInterval(interval, Feb16th, Feb28th, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, Mar1st, Mar15th, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, Mar16th, Mar31st, Period.BiMonthly);
        }

        [TestMethod]
        public void Test_BiMonthlyInterval_15()
        {
            // 16- -1, 1-15
            var interval = Interval.Create(Period.BiMonthly, Feb1st);
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
            var interval = Interval.Create(Period.BiMonthly, Feb2nd);
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
            var interval = Interval.Create(Period.BiMonthly, Feb3rd);
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
            var interval = Interval.Create(Period.BiMonthly, Feb13th);
            AssertInterval(interval, Feb13th, Feb27th, Period.BiMonthly);
            
            interval = interval.Next();

            AssertInterval(interval, Feb28th, Mar14th, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, Mar15th, Mar30th, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, Mar31st, April14th, Period.BiMonthly);
        }

        [TestMethod]
        public void Test_BiMonthlyInterval_28()
        {
            var interval = Interval.Create(Period.BiMonthly, Feb16th);
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
            var interval = Interval.Create(Period.BiMonthly, Feb16th);
            AssertInterval(interval, Feb16th, Feb28th, Period.BiMonthly);

            interval = interval.Next();

            AssertInterval(interval, Mar1st, Mar15th, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, Mar16th, Mar31st, Period.BiMonthly);

            interval = interval.Next();
            AssertInterval(interval, April1st, April15th, Period.BiMonthly);

        }


        [TestMethod]
        public void Test_BiMonthlyInterval_StartDate()
        {
            var factory = new IntervalFactory();
            var startDate = Jan1st;
            var interval = factory.CreateFromStartDate(Period.BiMonthly, startDate);
            AssertInterval(interval, startDate, startDate.AddDays(14), Period.BiMonthly);

            startDate = startDate.AddDays(1);
            interval = factory.CreateFromStartDate(Period.BiMonthly, startDate);
            AssertInterval(interval, startDate, startDate.AddDays(14), Period.BiMonthly);

            startDate = startDate.AddDays(1);
            interval = factory.CreateFromStartDate(Period.BiMonthly, startDate);
            AssertInterval(interval, startDate, startDate.AddDays(14), Period.BiMonthly);

            startDate = startDate.AddDays(1);
            interval = factory.CreateFromStartDate(Period.BiMonthly, startDate);
            AssertInterval(interval, startDate, startDate.AddDays(14), Period.BiMonthly);

            startDate = startDate.AddDays(1);
            interval = factory.CreateFromStartDate(Period.BiMonthly, startDate);
            AssertInterval(interval, startDate, startDate.AddDays(14), Period.BiMonthly);

            startDate = startDate.AddDays(1);
            interval = factory.CreateFromStartDate(Period.BiMonthly, startDate);
            AssertInterval(interval, startDate, startDate.AddDays(14), Period.BiMonthly);

            startDate = startDate.AddDays(1);
            interval = factory.CreateFromStartDate(Period.BiMonthly, startDate);
            AssertInterval(interval, startDate, startDate.AddDays(14), Period.BiMonthly);

            startDate = startDate.AddDays(1);
            interval = factory.CreateFromStartDate(Period.BiMonthly, startDate);
            AssertInterval(interval, startDate, startDate.AddDays(14), Period.BiMonthly);

            startDate = startDate.AddDays(1);
            interval = factory.CreateFromStartDate(Period.BiMonthly, startDate);
            AssertInterval(interval, startDate, startDate.AddDays(14), Period.BiMonthly);

            startDate = startDate.AddDays(1);
            interval = factory.CreateFromStartDate(Period.BiMonthly, startDate);
            AssertInterval(interval, startDate, startDate.AddDays(14), Period.BiMonthly);

            startDate = startDate.AddDays(1);
            interval = factory.CreateFromStartDate(Period.BiMonthly, startDate);
            AssertInterval(interval, startDate, startDate.AddDays(14), Period.BiMonthly);

            startDate = startDate.AddDays(1);
            interval = factory.CreateFromStartDate(Period.BiMonthly, startDate);
            AssertInterval(interval, startDate, startDate.AddDays(14), Period.BiMonthly);

            startDate = startDate.AddDays(1);
            interval = factory.CreateFromStartDate(Period.BiMonthly, startDate);
            AssertInterval(interval, startDate, startDate.AddDays(17), Period.BiMonthly);

            startDate = startDate.AddDays(1);
            interval = factory.CreateFromStartDate(Period.BiMonthly, startDate);
            AssertInterval(interval, startDate, startDate.AddDays(16), Period.BiMonthly);

            startDate = startDate.AddDays(1);
            interval = factory.CreateFromStartDate(Period.BiMonthly, startDate);
            AssertInterval(interval, startDate, startDate.AddDays(15), Period.BiMonthly);
        }
    }
}