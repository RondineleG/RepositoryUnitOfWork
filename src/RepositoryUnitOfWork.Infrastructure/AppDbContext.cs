using Microsoft.EntityFrameworkCore;
using RepositoryUnitOfWork.Domain.Departments;
using RepositoryUnitOfWork.Domain.Salaries;
using RepositoryUnitOfWork.Domain.Users;

namespace RepositoryUnitOfWork.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
