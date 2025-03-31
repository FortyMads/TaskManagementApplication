using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.core
{
    public class Task
    {
        public Guid Id { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public TaskPriority Priority { get; set; }
        public bool IsCompleted { get; private set; }


        public Task(string title, string description, DateTime dueDate, TaskPriority priority)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            IsCompleted = false;
        }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }

        public void MarkAsIncomplete()
        {
            IsCompleted = false;
        }
    }
}
