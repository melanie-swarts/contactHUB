using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactHub.WebApi.Models
{
    public class CalendarEventType
    {
        public int Id { get; set; }
        public string EventTypeName { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual CalendarEventTypeColor Color { get; set; }
    }
}
