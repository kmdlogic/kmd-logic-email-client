using System;
using System.Collections.Generic;
using System.Text;

namespace Kmd.Logic.Email.Client.ServicesMessages
{
    public class ScheduleTimeDetails
    {
        public ScheduleTimeDetails(int year, int day, int month, int hour, int minute)
        {
            this.Year = year;
            this.Day = day;
            this.Month = month;
            this.Hour = hour;
            this.Minute = minute;
        }

        public int Year { get; }

        public int Day { get; }

        public int Month { get; }

        public int Hour { get; }

        public int Minute { get; }
    }
}
