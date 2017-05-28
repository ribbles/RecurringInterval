using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateMath.Tests
{
    public abstract class Dates
    {
        protected static readonly DateTime Dec29th2016 = new DateTime(2016, 12, 29);
        protected static readonly DateTime Feb14th2016 = new DateTime(2016, 2, 14);
        protected static readonly DateTime Feb15th2016 = new DateTime(2016, 2, 15);
        protected static readonly DateTime Feb28th2016 = new DateTime(2016, 2, 28);
        protected static readonly DateTime Feb29th2016 = new DateTime(2016, 2, 29);
        protected static readonly DateTime Jan30th2016 = new DateTime(2016, 1, 30);
        protected static readonly DateTime Mar1st2016 = new DateTime(2016, 3, 1);
        protected static readonly DateTime Mar14th2016 = new DateTime(2016, 3, 14);

        
        protected static readonly DateTime Feb1st = new DateTime(2017, 2, 1);
        protected static readonly DateTime Feb2nd = new DateTime(2017, 2, 2);
        protected static readonly DateTime Feb14th = new DateTime(2017, 2, 14);
        protected static readonly DateTime Feb15th = new DateTime(2017, 2, 15);
        protected static readonly DateTime Feb17th = new DateTime(2017, 2, 17);
        protected static readonly DateTime Feb28th = new DateTime(2017, 2, 28);
        protected static readonly DateTime Mar1st = new DateTime(2017, 3, 1);
        protected static readonly DateTime Mar14th = new DateTime(2017, 3, 14);
        protected static readonly DateTime Mar15th = new DateTime(2017, 3, 15);
        protected static readonly DateTime Feb16th = new DateTime(2017, 2, 16);
        protected static readonly DateTime Mar16th = new DateTime(2017, 3, 16);
        protected static readonly DateTime April15th = new DateTime(2017, 4, 15);
        protected static readonly DateTime April16th = new DateTime(2017, 4, 16);
        protected static readonly DateTime April17th = new DateTime(2017, 4, 17);
        protected static readonly DateTime April18th = new DateTime(2017, 4, 18);
        protected static readonly DateTime April19th = new DateTime(2017, 4, 19);
        protected static readonly DateTime April1st = new DateTime(2017, 4, 1);
        protected static readonly DateTime April22nd = new DateTime(2017, 4, 22);
        protected static readonly DateTime April29th = new DateTime(2017, 4, 29);
        protected static readonly DateTime April2nd = new DateTime(2017, 4, 2);
        protected static readonly DateTime April30th = new DateTime(2017, 4, 30);
        protected static readonly DateTime April3rd = new DateTime(2017, 4, 3);
        protected static readonly DateTime April4th = new DateTime(2017, 4, 4);
        protected static readonly DateTime April8th = new DateTime(2017, 4, 8);
        protected static readonly DateTime April9th = new DateTime(2017, 4, 9);
        protected static readonly DateTime Jan1st = new DateTime(2017, 1, 1);
        protected static readonly DateTime Jan2nd = new DateTime(2017, 1, 2);
        protected static readonly DateTime Jan31st = new DateTime(2017, 1, 31);
        protected static readonly DateTime Jan3rd = new DateTime(2017, 1, 3);
        protected static readonly DateTime July1st = new DateTime(2017, 7, 1);
        protected static readonly DateTime July2nd = new DateTime(2017, 7, 2);
        protected static readonly DateTime July30th = new DateTime(2017, 7, 30);
        protected static readonly DateTime July31st = new DateTime(2017, 7, 31);
        protected static readonly DateTime Jun16th = new DateTime(2017, 6, 16);
        protected static readonly DateTime Jun1st = new DateTime(2017, 6, 1);
        protected static readonly DateTime Jun2nd = new DateTime(2017, 6, 2);
        protected static readonly DateTime Jun28th = new DateTime(2017, 6, 28);
        protected static readonly DateTime Jun29th = new DateTime(2017, 6, 29);
        protected static readonly DateTime Jun30th = new DateTime(2017, 6, 30);
        protected static readonly DateTime Mar17th = new DateTime(2017, 3, 17);
        protected static readonly DateTime Mar18th = new DateTime(2017, 3, 18);
        protected static readonly DateTime Mar19th = new DateTime(2017, 3, 19);
        protected static readonly DateTime Mar26th = new DateTime(2017, 3, 26);
        protected static readonly DateTime Mar27th = new DateTime(2017, 3, 27);
        protected static readonly DateTime Mar28th = new DateTime(2017, 3, 28);
        protected static readonly DateTime Mar29th = new DateTime(2017, 3, 29);
        protected static readonly DateTime Mar2nd = new DateTime(2017, 3, 2);
        protected static readonly DateTime Mar30th = new DateTime(2017, 3, 30);
        protected static readonly DateTime Mar31st = new DateTime(2017, 3, 31);
        protected static readonly DateTime Mar3rd = new DateTime(2017, 3, 3);
        protected static readonly DateTime May15th = new DateTime(2017, 5, 15);
        protected static readonly DateTime May16th = new DateTime(2017, 5, 16);
        protected static readonly DateTime May17th = new DateTime(2017, 5, 17);
        protected static readonly DateTime May18th = new DateTime(2017, 5, 18);
        protected static readonly DateTime May1st = new DateTime(2017, 5, 1);
        protected static readonly DateTime May29th = new DateTime(2017, 5, 29);
        protected static readonly DateTime May2nd = new DateTime(2017, 5, 2);
        protected static readonly DateTime May30th = new DateTime(2017, 5, 30);
        protected static readonly DateTime May31st = new DateTime(2017, 5, 31);
        protected static readonly DateTime May3rd = new DateTime(2017, 5, 3);
        protected static readonly DateTime May4th = new DateTime(2017, 5, 4);
        protected static readonly DateTime Oct30th = new DateTime(2017, 10, 30);
        protected static readonly DateTime Sept27th = new DateTime(2017, 9, 27);
        protected static readonly DateTime Feb3rd = new DateTime(2017, 2, 3);
        protected static readonly DateTime Feb18th = new DateTime(2017, 2, 18);
        protected static readonly DateTime Feb19th = new DateTime(2017, 2, 19);
        protected static readonly DateTime Feb13th = new DateTime(2017, 2, 13);
        protected static readonly DateTime Feb27th = new DateTime(2017, 2, 27);
        protected static readonly DateTime Mar12th = new DateTime(2017, 3, 12);
        protected static readonly DateTime Mar13th = new DateTime(2017, 3, 13);
        protected static readonly DateTime April12th = new DateTime(2017, 4, 12);
        protected static readonly DateTime April14th = new DateTime(2017, 4, 14);
        
        protected void AssertInterval(Interval interval, DateTime start, DateTime end, Period period, bool assertAllStartDates = true)
        {
            Assert.IsNotNull(interval);
            Assert.AreEqual(period, interval.Period);
            Assert.AreEqual(start, interval.StartDate);
            Assert.AreEqual(end, interval.EndDate);

            // assert for any start date in range
            if (assertAllStartDates)
                AssertForAllDates(interval);
        }

        void AssertForAllDates(Interval template)
        {
            // assert for any start date in range
            for (var i = 1; i <= template.EndDate.Subtract(template.StartDate).TotalDays; i++)
            {
                try
                {
                AssertInterval(Interval.Create(template.Period, template.StartDate.AddDays(i), template.EndDay), template.StartDate, template.EndDate, template.Period, false);

                }
                catch (Exception ex)
                {
                    throw new AssertFailedException($"Failed with start:{template.StartDate.AddDays(i).ToShortDateString()} end:{template.EndDate.ToShortDateString()} day:{template.EndDay}:\n{ex.Message}", ex);
                }

            }
        }
    }
}
