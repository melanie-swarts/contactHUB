using ContactHub.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactHub.WebAPI.Mappers
{
    public class CalendarMapper
    {
        public static CalendarEventType MapForCreate(CalendarEventType eventType)
        {
            return new CalendarEventType
            {
                EventTypeName = eventType.EventTypeName,
                Enabled = eventType.Enabled,
                Color = MapEventTypeColor(eventType.Color),
                CreatedAt = DateTime.Now
            };
        }

        public static CalendarEventTypeColor MapEventTypeColor(CalendarEventTypeColor eventTypeColor)
        {
            return new CalendarEventTypeColor
            {
                Color = eventTypeColor.Color,
                ColorHex = eventTypeColor.ColorHex,
                Name = eventTypeColor.Name
            };
        }

    }
}
