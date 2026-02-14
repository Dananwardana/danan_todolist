using Microsoft.EntityFrameworkCore;
using Danan_TodoList.Models;

namespace Danan_TodoList.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Todo> Todos => Set<Todo>();
    }
}