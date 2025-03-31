# Task Management Application

This is a robust, modular, and well-designed task management system built with C# that demonstrates proper object-oriented design principles and clean architecture.

## Repository

This project is hosted on GitHub:
[https://github.com/FortyMads/TaskManagementApplication](https://github.com/FortyMads/TaskManagementApplication)

## Features

- **Task Management**
  - Create tasks with title, description, due date, and priority levels
  - Update existing task details
  - Mark tasks as completed
  - Remove tasks
  - Filter tasks by status, priority, or due date

- **Architecture**
  - Clean separation of concerns
  - Well-defined interfaces
  - Dependency injection
  - Repository pattern implementation
  - Comprehensive unit tests

## Solution Structure

The solution consists of four projects:

- **TaskManagement.Core**
  - Contains domain models, interfaces, and core business logic
  - Includes the Task class, ITaskRepository interface, and TaskManager service

- **TaskManagement.Application**
  - Console application for user interaction
  - Demonstrates task management functionality

- **TaskManagement.Api**
  - RESTful API for programmatic access to task functionality
  - Enables integration with other systems

- **TaskManagement.Tests**
  - Unit tests for core functionality
  - Ensures code quality and functionality

## Getting Started

### Prerequisites

- .NET 5.0 or higher
- Visual Studio 2019 or higher (or any compatible IDE)

### Installation

1. Clone the repository:
   ```
   git clone https://github.com/FortyMads/TaskManagementApplication.git
   ```

2. Open the solution file in Visual Studio:
   ```
   TaskManagement.sln
   ```

3. Build the solution:
   ```
   dotnet build
   ```

4. Run the application:
   ```
   dotnet run --project TaskManagement.Application
   ```

### Running the API

1. Set the API project as the startup project in Visual Studio

2. Run the project:
   ```
   dotnet run --project TaskManagement.Api
   ```

3. Access the API at:
   ```
   https://localhost:5001/api/tasks
   ```

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET    | /api/tasks | Get all tasks |
| GET    | /api/tasks/{id} | Get a specific task |
| GET    | /api/tasks/status/{isCompleted} | Get tasks by completion status |
| GET    | /api/tasks/priority/{priority} | Get tasks by priority level |
| POST   | /api/tasks | Create a new task |
| PUT    | /api/tasks/{id} | Update an existing task |
| PUT    | /api/tasks/{id}/complete | Mark a task as complete |
| DELETE | /api/tasks/{id} | Delete a task |

## Design Patterns & OOP Principles

### Repository Pattern
The application implements the repository pattern to abstract data access:
- `ITaskRepository` interface defines data access operations
- `InMemoryTaskRepository` provides an in-memory implementation
- Easy to swap implementations without affecting business logic

### Dependency Injection
- Components depend on abstractions, not concrete implementations
- Dependencies are injected via constructors
- Facilitates unit testing and improves flexibility

### OOP Principles
- **Encapsulation**: Data and methods are properly encapsulated
- **Abstraction**: Interfaces abstract away implementation details
- **Single Responsibility**: Each class has a clear, focused purpose
- **Open/Closed**: Classes are open for extension but closed for modification

## Data Structures

The application uses appropriate data structures for task management:
- `List<Task>` for in-memory storage with efficient add/remove operations
- `IEnumerable<Task>` for query results with deferred execution
- LINQ for efficient filtering and querying


## Contributing

1. Fork the repository from [https://github.com/FortyMads/TaskManagementApplication](https://github.com/FortyMads/TaskManagementApplication)
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

- This project was created as a demonstration of C# object-oriented design principles
- Inspired by real-world task management needs
