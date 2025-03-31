using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TaskManagement.core;


namespace TaskManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase // Change to ControllerBase for API controllers
    {
        private readonly TaskManager _taskManager;

        public TasksController(TaskManager taskManager)
        {
            _taskManager = taskManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskManagement.core.Task>> GetAllTasks() // Fully qualify Task
        {
            var tasks = _taskManager.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<TaskManagement.core.Task> GetTaskById(Guid id) // Fully qualify Task
        {
            var task = _taskManager.GetTaskById(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public ActionResult<TaskManagement.core.Task> CreateTask([FromBody] TaskManagement.core.Task task) // Fully qualify Task
        {
            var createdTask = _taskManager.CreateTask(task.Title, task.Description, task.DueDate, task.Priority);
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(Guid id, [FromBody] TaskManagement.core.Task task) // Fully qualify Task
        {
            try
            {
                _taskManager.UpdateTask(id, task.Title, task.Description, task.DueDate, task.Priority);
                return NoContent(); // 204 No Content
            }
            catch (InvalidOperationException)
            {
                return NotFound(); // 404 Not Found
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(Guid id)
        {
            _taskManager.DeleteTask(id);
            return NoContent(); // 204 No Content
        }
    }
}