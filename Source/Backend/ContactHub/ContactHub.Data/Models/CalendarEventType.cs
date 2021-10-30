using System;

namespace ContactHub.Data.Models
{
    public class CalendarEventType
    {
        public int Id { get; set; }
        public string EventTypeName { get; set; }
        public int EventTypeColorId { get; set; }
        public virtual CalendarEventTypeColor CalendarEventTypeColor { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
