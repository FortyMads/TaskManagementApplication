using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.core
{
    public class TaskManager
    {
        private readonly ITaskRepository _taskRepository;

        public TaskManager(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task CreateTask(string title, string description, DateTime dueDate, TaskPriority priority)
        {
            var task = new Task(title, description, dueDate, priority);
            _taskRepository.AddTask(task);
            return task;
        }

        public void UpdateTask(Guid taskId, string title = null, string description = null,
                                DateTime? dueDate = null, TaskPriority? priority = null)
        {
            var task = _taskRepository.GetTaskById(taskId);
            if (task == null)
            {
                throw new InvalidOperationException("Task not found.");
            }

            task.Title = title ?? task.Title;
            task.Description = description ?? task.Description;
            task.DueDate = dueDate ?? task.DueDate;
            task.Priority = priority ?? task.Priority;

            _taskRepository.UpdateTask(task);
        }

        public void CompleteTask(Guid taskId)
        {
            var task = _taskRepository.GetTaskById(taskId);
            if (task == null)
            {
                throw new InvalidOperationException("Task not found.");
            }

            task.MarkAsCompleted();
            _taskRepository.UpdateTask(task);
        }

        public void UncompleteTask(Guid taskId)
        {
            var task = _taskRepository.GetTaskById(taskId);
            if (task == null)
            {
                throw new InvalidOperationException("Task not found.");
            }

            task.MarkAsIncomplete();
            _taskRepository.UpdateTask(task);
        }


        public Task GetTaskById(Guid taskId)
        {
            return _taskRepository.GetTaskById(taskId);
        }

        public void DeleteTask(Guid taskId)
        {
            _taskRepository.RemoveTask(taskId);
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return _taskRepository.GetAllTasks();
        }

        public IEnumerable<Task> GetPendingTasks()
        {
            return _taskRepository.GetFilteredTasks(t => !t.IsCompleted);
        }

        public IEnumerable<Task> GetCompletedTasks()
        {
            return _taskRepository.GetFilteredTasks(t => t.IsCompleted);
        }

        public IEnumerable<Task> GetTasksByPriority(TaskPriority priority)
        {
            return _taskRepository.GetFilteredTasks(t => t.Priority == priority);
        }

        public IEnumerable<Task> GetOverdueTasks()
        {
            return _taskRepository.GetFilteredTasks(t => !t.IsCompleted && t.DueDate < DateTime.Now);
        }
    }
}