using EmployeeApi.Common.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Common.Model.Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Job> Jobs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=EmployeeApi.db");
            SQLitePCL.Batteries.Init();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>().HasKey(a => a.Id);
            builder.Entity<Team>().HasKey(a => a.Id);
            builder.Entity<Job>().HasKey(a => a.Id);
            builder.Entity<Common.Model.Employee>().HasKey(a => a.Id);

            builder.Entity<Common.Model.Employee>().HasOne(a => a.Address);
            builder.Entity<Common.Model.Employee>().HasOne(a => a.Job);

            builder.Entity<Team>().HasMany(a => a.Employees).WithMany(e => e.Teams);

            base.OnModelCreating(builder);
        }

    }
}