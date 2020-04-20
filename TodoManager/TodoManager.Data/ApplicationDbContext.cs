using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TodoManager.Common;
using TodoManager.Data.Models;

namespace TodoManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GlobalConstants.ConnectionStrings.Default);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
