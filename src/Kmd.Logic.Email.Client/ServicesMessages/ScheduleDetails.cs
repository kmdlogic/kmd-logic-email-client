using System;
using System.Collections.Generic;
using System.Text;

namespace Kmd.Logic.Email.Client.ServicesMessages
{
    public class ScheduleDetails
    {
        public ScheduleDetails(ScheduleTimeDetails fromDateTime, ScheduleTimeDetails toDateTime)
        {
            this.FromDateTime = fromDateTime;
            this.ToDateTime = toDateTime;
        }

        public ScheduleTimeDetails FromDateTime { get; }

        public ScheduleTimeDetails ToDateTime { get; }
    }
}
