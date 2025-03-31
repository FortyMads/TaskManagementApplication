using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.core
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<Task> _tasks = new List<Task>();

        public void AddTask(Task task)
        {
            _tasks.Add(task);
        }

        public void UpdateTask(Task task)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existingTask != null)
            {
                _tasks.Remove(existingTask);
                _tasks.Add(task);
            }
        }

        public void RemoveTask(Guid taskId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId); 
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }

        public Task GetTaskById(Guid taskId)
        {
            return _tasks.FirstOrDefault(t => t.Id == taskId);
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return _tasks.ToList();
        }

        public IEnumerable<Task> GetFilteredTasks(Func<Task, bool> predicate)
        {
            return _tasks.Where(predicate);
        }
    }
}
