using LoginAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<UserLogin> UserLogins { get; set; }

        public DbSet<Register> UserRegister { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLogin>().HasNoKey();
            
        }
    }
}
