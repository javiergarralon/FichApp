using FichApp.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichApp.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context) { }

        public DbSet<Timesheet> Timesheets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Timesheet>().HasData(
                new Timesheet { Id = 1, Checkin = DateTime.Now, Checkout = null, TimeSpent = new TimeSpan(0, 0, 0) },
                new Timesheet { Id = 2, Checkin = null, Checkout = DateTime.Now.AddHours(5).AddSeconds(23), TimeSpent = new TimeSpan(5, 0, 23) },
                new Timesheet { Id = 3, Checkin = DateTime.Now, Checkout = null, TimeSpent = new TimeSpan(5, 0, 23) }
                );
        }
    }
}
