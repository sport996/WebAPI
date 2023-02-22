using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options)
        { }
        public DbSet<Employee> Employees { get; set; }
        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

    }
}
