using Microsoft.EntityFrameworkCore;
using TaskList.Api.Models;

namespace TaskList.Api.Data
{
    public class TaskListDbContext : DbContext
    {
        public TaskListDbContext(DbContextOptions<TaskListDbContext> options) : base(options) { }

        public DbSet<MyTask> MyTasks { get; set; }
    }
}
