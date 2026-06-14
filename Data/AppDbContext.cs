using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TaskManagerApp.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // This line = "create a TaskItems table in the database"
        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
