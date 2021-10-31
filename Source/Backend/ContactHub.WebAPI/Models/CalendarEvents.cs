using System;
using System.Collections.Generic;

namespace ContactHub.WebApi.Models
{
    public class CalendarEvents
    {
        public int Id { get; set; }
        public int CalendarEventTypeId { get; set; }
        public string EventName { get; set; }
        public bool AllDayEvent { get; set; }
        public DateTime StartDateTime { get; set; }
        public  DateTime EndDateTime { get; set; }
        public bool RepeatEvent { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual CalendarEventType CalendarEventType { get; set; }
        public virtual IList<CalendarEventType> CalendarEventTypes { get; set; }

    }
}
