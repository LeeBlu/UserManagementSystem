using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystem.Model;

namespace UserManagementSystem.API.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed Employee Table
            modelBuilder.Entity<User>().HasData(new User
            {
                Id=1,
                SaIdNumber="10285239077",
                FirstName = "John",
                Surname = "Hastings",
                Address = "62 waterval street ",
                CellNumber = "012522015",
                ComplexName = "Sammy`s place",
                HouseNumber = "52A",
                PostalCode = 1458,
                
            });
        }
    }
}
