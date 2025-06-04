using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Models

{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

    }
}
