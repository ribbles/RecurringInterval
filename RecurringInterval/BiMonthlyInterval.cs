using System;

namespace RecurringInterval
{
    internal class BiMonthlyInterval : Interval
    {
        /**** WARNING **
            * We are making assumptions here.
            * if the date is 1, move to 16th
            * if the date is 2-12, add 15
            * if the date is 13-15 move to last day of month
            * if the date is 15, move to last day of month
            * if the date is 16, move to 1st day of next month
            * if the date is 17-27, add month - 15
            * if the date is 28-31, move to 15th day of next month
        */


        public BiMonthlyInterval(DateTime startDate) : base(Period.BiMonthly)
        {
            StartDate = startDate;


            /**** WARNING **
             * We are making assumptions here.
             * if the date is 1, move to 16th
             * if the date is 2-12, add 15
             * if the date is 13 or 14, treat it as the 15th
             * if the date is 15, move to last day of month
             * if the date is 16, move to 1st day of next month
             * if the date is 17-27, add month - 15
             * if the date is 28-31, move to 15th day of next month
            */
            if (startDate.Day <= 12)
                EndDate = startDate.AddDays(14);

            else if (startDate.Day >= 13 && startDate.Day <= 15)
                EndDate = new DateTime(startDate.Year, startDate.Month, 1).AddMonths(1).AddDays(-2);

            else if (startDate.Day == 16)
                EndDate = new DateTime(startDate.Year, startDate.Month, 1).AddMonths(1).AddDays(-1);

            else if (startDate.Day >= 17 && startDate.Day <= 27)
                EndDate = startDate.AddMonths(1).AddDays(-16);

            else if (startDate.Day >= 28 && startDate.Day <= 31)
            {
                EndDate = startDate.AddMonths(1);
                EndDate = new DateTime(EndDate.Year, EndDate.Month, 14);
            }
        }
        
        public override Interval Next()
        {
            return new BiMonthlyInterval(NextStartDate());
        }

        private DateTime NextStartDate()
        {
            return EndDate.AddDays(1);
        }
    }
}