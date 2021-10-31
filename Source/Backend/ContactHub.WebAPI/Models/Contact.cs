using System;

namespace ContactHub.WebApi.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public byte[] Photo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryContactNumber { get; set; }
        public string MobileNumber { get; set; }
        public string WorkNumber { get; set; }
        public string HomeNumber { get; set; }
        public string emailAddress { get; set; }
        public string Address { get; set; }
        public DateTime? Birthdy { get; set; }
        public int BirthdayCalendarEventId { get; set; }
        public string Website { get; set; }
        public DateTime LastViewed { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual CalendarEvents ContactBirthdayEvent { get; set; }

    }
}
