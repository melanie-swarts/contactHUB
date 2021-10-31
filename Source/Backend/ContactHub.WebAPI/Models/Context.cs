using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ContactHub.WebApi.Models
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
        public DbSet<AspNetUser> AspNetUser { get; set; }
        public DbSet<CalendarEvents> CalendarEvents { get; set; }
        public DbSet<CalendarEventType> CalendarEventType { get; set; }
        public DbSet<CalendarEventTypeColor> CalendarEventTypeColor { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<SystemUser> SystemUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ContactHub;Trusted_Connection=True;");
            }
        }
    }
}
