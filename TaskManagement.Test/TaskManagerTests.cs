using TaskManagement.core;
using Xunit;

namespace TaskManagement.Tests
{
    public class TaskManagerTests
    {
        private ITaskRepository _repository;
        private TaskManager _taskManager;

        public TaskManagerTests()
        {
            _repository = new InMemoryTaskRepository();
            _taskManager = new TaskManager(_repository);
        }

        [Fact]
        public void CreateTask_ShouldAddTaskToRepository()
        {
            // Arrange
            var title = "Test Task";
            var description = "Test Description";
            var dueDate = DateTime.Now.AddDays(1);
            var priority = TaskPriority.Medium;

            // Act
            var task = _taskManager.CreateTask(title, description, dueDate, priority);

            // Assert
            Assert.NotNull(task);
            Assert.Equal(title, task.Title);
            Assert.Equal(description, task.Description);
            Assert.Equal(dueDate, task.DueDate);
            Assert.Equal(priority, task.Priority);
            Assert.False(task.IsCompleted);
        }

        [Fact]
        public void CompleteTask_ShouldMarkTaskAsCompleted()
        {
            // Arrange
            var task = _taskManager.CreateTask(
                "Test Task",
                "Test Description",
                DateTime.Now.AddDays(1),
                TaskPriority.Medium
            );

            // Act
            _taskManager.CompleteTask(task.Id);

            // Assert
            var completedTask = _repository.GetTaskById(task.Id);
            Assert.True(completedTask.IsCompleted);
        }

        [Fact]
        public void GetPendingTasks_ShouldReturnOnlyIncompleteTasks()
        {
            // Arrange
            var task1 = _taskManager.CreateTask(
                "Pending Task 1",
                "Description 1",
                DateTime.Now.AddDays(1),
                TaskPriority.Low
            );
            var task2 = _taskManager.CreateTask(
                "Pending Task 2",
                "Description 2",
                DateTime.Now.AddDays(2),
                TaskPriority.Medium
            );
            _taskManager.CompleteTask(task2.Id);

            // Act
            var pendingTasks = _taskManager.GetPendingTasks();

            // Assert
            Assert.Single(pendingTasks); 
            Assert.Equal(task1.Id, pendingTasks.First().Id);
        }
    }
}