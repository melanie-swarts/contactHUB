using System;

namespace ContactHub.Data.Models
{
    public class SystemUser
    {
        public int Id { get; set; }
        public string AspNetUserId { get; set; }
        public byte[] ProfilePhoto { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryContactNumber { get; set; }
        public string MobileNumber { get; set; }
        public string HomeNumber { get; set; }
        public string WorkNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
