using TaskManagement.core;
using System;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        // Create repository and task manager
        ITaskRepository repository = new InMemoryTaskRepository();
        TaskManager taskManager = new TaskManager(repository);

        while (true)
        {
            Console.WriteLine("\nTask Management Application");
            Console.WriteLine("0. View a Specific Task");
            Console.WriteLine("1. Add New Task");
            Console.WriteLine("2. List All Tasks");
            Console.WriteLine("3. List Pending Tasks");
            Console.WriteLine("4. Complete a Task");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    ViewSpecificTask(taskManager);
                    break;
                case "1":
                    AddNewTask(taskManager);
                    break;
                case "2":
                    ListAllTasks(taskManager);
                    break;
                case "3":
                    ListPendingTasks(taskManager);
                    break;
                case "4":
                    CompleteTask(taskManager);
                    break;
                case "5":
                    Console.Write("Are you sure you want to exit? (y/n): ");
                    if (Console.ReadLine().Trim().ToLower() == "y")
                    {
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void ViewSpecificTask(TaskManager taskManager)
    {
        Console.Write("Enter Task ID to view: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid taskId))
        {
            var task = taskManager.GetTaskById(taskId);
            if (task != null)
            {
                Console.WriteLine($"ID: {task.Id}");
                Console.WriteLine($"Title: {task.Title}");
                Console.WriteLine($"Description: {task.Description}");
                Console.WriteLine($"Due Date: {task.DueDate}");
                Console.WriteLine($"Priority: {task.Priority}");
                Console.WriteLine($"Status: {(task.IsCompleted ? "Completed" : "Pending")}");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid Task ID.");
        }
    }

    static void AddNewTask(TaskManager taskManager)
    {
        Console.Write("Enter Task Title: ");
        string title = Console.ReadLine();
        while (!InputValidator.ValidateTitle(title))
        {
            Console.Write("Invalid title. Please enter a valid title (max 100 characters): ");
            title = Console.ReadLine();
        }

        Console.Write("Enter Task Description: ");
        string description = Console.ReadLine();
        while (!InputValidator.ValidateDescription(description))
        {
            Console.Write("Invalid description. Please enter a valid description (max 500 characters): ");
            description = Console.ReadLine();
        }

        Console.Write("Enter Due Date (yyyy-MM-dd): ");
        DateTime dueDate;
        while (!InputValidator.ValidateDueDate(Console.ReadLine(), out dueDate))
        {
            Console.Write("Invalid date. Please enter a valid due date (must be in the future): ");
        }

        Console.WriteLine("Select Priority:");
        Console.WriteLine("0. Low");
        Console.WriteLine("1. Medium");
        Console.WriteLine("2. High");
        Console.WriteLine("3. Urgent");
        Console.Write("Enter Priority Number: ");
        TaskPriority priority;
        while (!InputValidator.ValidatePriority(Console.ReadLine(), out priority))
        {
            Console.Write("Invalid priority. Please enter a valid priority number: ");
        }

        taskManager.CreateTask(title, description, dueDate, priority);
        Console.WriteLine("Task added successfully!");
    }

    static void ListAllTasks(TaskManager taskManager)
    {
        var tasks = taskManager.GetAllTasks();
        if (!tasks.Any())
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        foreach (var task in tasks)
        {
            Console.WriteLine($"ID: {task.Id}");
            Console.WriteLine($"Title: {task.Title}");
            Console.WriteLine($"Description: {task.Description}");
            Console.WriteLine($"Due Date: {task.DueDate}");
            Console.WriteLine($"Priority: {task.Priority}");
            Console.WriteLine($"Status: {(task.IsCompleted ? "Completed" : "Pending")}");
            Console.WriteLine("-------------------");
        }
    }

    static void ListPendingTasks(TaskManager taskManager)
    {
        var pendingTasks = taskManager.GetPendingTasks();
        if (!pendingTasks.Any())
        {
            Console.WriteLine("No pending tasks found.");
            return;
        }

        foreach (var task in pendingTasks)
        {
            Console.WriteLine($"ID: {task.Id}");
            Console.WriteLine($"Title: {task.Title}");
            Console.WriteLine($"Due Date: {task.DueDate}");
            Console.WriteLine($"Priority: {task.Priority}");
            Console.WriteLine("-------------------");
        }
    }

    static void CompleteTask(TaskManager taskManager)
    {
        Console.Write("Enter Task ID to mark as complete: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid taskId))
        {
            try
            {
                taskManager.CompleteTask(taskId);
                Console.WriteLine("Task marked as completed.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Invalid Task ID.");
        }
    }
}