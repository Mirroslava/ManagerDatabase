using System;
using Microsoft.EntityFrameworkCore;

namespace ManagerDatabase.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Manager> Managers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

