using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Context
{
    public interface IApplicationContext
    {
        DbSet<Employee> Employees { get; set; }
        Task<int> SaveChanges();
    }
}