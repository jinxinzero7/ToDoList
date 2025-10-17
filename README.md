# ToDo API

Minimal REST API for task management built with ASP.NET Core and Entity Framework.

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![EF Core](https://img.shields.io/badge/EF_Core-CC2927?style=for-the-badge&logo=dotnet&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-003B57?style=for-the-badge&logo=sqlite&logoColor=white)

## API Endpoints

| Method | Endpoint | Description | Body |
|--------|----------|-------------|------|
| `GET` | `GET /ToDo/GetTasks` | Retrieve all tasks | - |
| `GET` | `GET /ToDo/{id}` | Get task by ID | - |
| `POST` | `POST /ToDo/AddTask` | Create new task | `"string"` |
| `PUT` | `PUT /ToDo/{id}` | Update task | `"string"` |
| `DELETE` | `DELETE /ToDo/{id}` | Delete task | - |

## Model

```csharp
public class ToDoItem
{
    public Guid Id { get; set; }
    public string Text { get; set; }
}
```
