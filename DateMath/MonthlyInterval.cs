using System;

namespace DateMath
{
    internal class MonthlyInterval : Interval
    {
        public int EndDay { get; }

        public MonthlyInterval(DateTime startDate, int endDay) : base(Period.Monthly)
        {
            var endDateAtEndOfMonth = false;

            EndDay = endDay;
            if (EndDay == -1 || EndDay > 30)
                endDateAtEndOfMonth = true;

            if (endDateAtEndOfMonth)
                EndDate = new DateTime(startDate.Year, startDate.Month, DateTime.DaysInMonth(startDate.Year, startDate.Month));
            else
            {
                var tmp = (endDay < startDate.Day)
                    ? startDate.AddMonths(1)
                    : startDate;

                EndDate = new DateTime(tmp.Year, tmp.Month, Math.Min(endDay, DateTime.DaysInMonth(tmp.Year, tmp.Month)));
            }
            if (!endDateAtEndOfMonth)
                StartDate = EndDate.AddMonths(-1).AddDays(1);
            else
                StartDate = EndDate.AddDays(1).AddMonths(-1);

        }

        public override Interval Next()
        {
            return new MonthlyInterval(NextStartDate(), EndDay);
        }

        private DateTime NextStartDate()
        {
            return EndDate.AddDays(1);
        }


        //public MonthlyInterval(DateTime? startDate, DateTime? endDate) : base()
        //{
        //    if (startDate == null && endDate == null) throw new ArgumentNullException(nameof(startDate));
        //    Period = Period.Monthly;

        //    if (startDate != null && endDate != null)
        //    {
        //        StartDate = startDate.Value;
        //        EndDate = endDate.Value;
        //        return;
        //    }
        //    if (startDate != null)
        //    {
        //        StartDate = startDate.Value;
        //        EndDate = StartDate.AddMonths(1).AddDays(-1);
        //        if (DateTime.DaysInMonth(StartDate.Year, StartDate.Month) == StartDate.Day)
        //            EndDate = new DateTime(EndDate.Year, EndDate.Month, DateTime.DaysInMonth(EndDate.Year, EndDate.Month)).AddDays(-1);
        //        return;
        //    }

        //    EndDate = endDate.Value;
        //    StartDate = EndDate.AddDays(1).AddMonths(-1);
        //    if (DateTime.DaysInMonth(EndDate.Year, EndDate.Month) == EndDate.Day)
        //        StartDate = new DateTime(EndDate.Year, EndDate.Month, 1);
        //}
    }

    //internal class MonthlyInterval : Interval
    //{
    //    public int EndDay { get; }

    //    public MonthlyInterval(DateTime startDate, int endDay) : base(Period.Monthly)
    //    {
    //        var endDateAtEndOfMonth = false;

    //        EndDay = endDay;
    //        if (EndDay == -1 || EndDay > 30)
    //            endDateAtEndOfMonth = true;

    //        if (endDateAtEndOfMonth)
    //            EndDate = new DateTime(startDate.Year, startDate.Month, DateTime.DaysInMonth(startDate.Year, startDate.Month));
    //        else
    //        {
    //            var tmp = (endDay < startDate.Day)
    //                ? startDate.AddMonths(1)
    //                : startDate;

    //            EndDate = new DateTime(tmp.Year, tmp.Month, Math.Min(endDay, DateTime.DaysInMonth(tmp.Year, tmp.Month)));
    //        }
    //        if (!endDateAtEndOfMonth)
    //            StartDate = EndDate.AddMonths(-1).AddDays(1);
    //        else
    //            StartDate = EndDate.AddDays(1).AddMonths(-1);

    //    }

    //    public override Interval Next()
    //    {
    //        return new MonthlyInterval(NextStartDate(), EndDay);
    //    }

    //    private DateTime NextStartDate()
    //    {
    //        return EndDate.AddDays(1);
    //    }


    //    //public MonthlyInterval(DateTime? startDate, DateTime? endDate) : base()
    //    //{
    //    //    if (startDate == null && endDate == null) throw new ArgumentNullException(nameof(startDate));
    //    //    Period = Period.Monthly;

    //    //    if (startDate != null && endDate != null)
    //    //    {
    //    //        StartDate = startDate.Value;
    //    //        EndDate = endDate.Value;
    //    //        return;
    //    //    }
    //    //    if (startDate != null)
    //    //    {
    //    //        StartDate = startDate.Value;
    //    //        EndDate = StartDate.AddMonths(1).AddDays(-1);
    //    //        if (DateTime.DaysInMonth(StartDate.Year, StartDate.Month) == StartDate.Day)
    //    //            EndDate = new DateTime(EndDate.Year, EndDate.Month, DateTime.DaysInMonth(EndDate.Year, EndDate.Month)).AddDays(-1);
    //    //        return;
    //    //    }

    //    //    EndDate = endDate.Value;
    //    //    StartDate = EndDate.AddDays(1).AddMonths(-1);
    //    //    if (DateTime.DaysInMonth(EndDate.Year, EndDate.Month) == EndDate.Day)
    //    //        StartDate = new DateTime(EndDate.Year, EndDate.Month, 1);
    //    //}
    //}
}