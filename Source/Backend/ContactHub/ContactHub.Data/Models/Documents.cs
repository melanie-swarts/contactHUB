using System;

namespace ContactHub.Data.Models
{
    public class Documents
    {
        public int Id { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
