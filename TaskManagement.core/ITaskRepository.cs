using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.core
{
    public interface ITaskRepository
    {
        void AddTask(Task task);
        void UpdateTask(Task task);
        void RemoveTask(Guid taskId);
        Task GetTaskById(Guid taskId);
        IEnumerable<Task> GetAllTasks();
        IEnumerable<Task> GetFilteredTasks(Func<Task, bool> predicate);
    }
}
