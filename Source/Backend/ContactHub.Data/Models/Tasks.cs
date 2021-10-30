using System;
using System.Collections.Generic;

namespace ContactHub.Data.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public int TaskTypeId { get; set; }
        public string TaskName { get; set; }
        public DateTime TaskDueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public TaskType TaskType { get; set; }
        public virtual IList<TaskType> TaskTypes { get; set; }
    }
}
