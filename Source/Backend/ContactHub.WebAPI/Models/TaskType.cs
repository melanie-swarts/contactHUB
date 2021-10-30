using System;

namespace ContactHub.Data.Models
{
    public class TaskType
    {
        public int Id { get; set; }
        public string TaskTypeName { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreatedAt { get; set; }

}
}
