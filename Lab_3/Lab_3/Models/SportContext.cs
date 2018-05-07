using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Lab_3.Models
{
    public class SportContext: DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<TimeTable> Timetables { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public SportContext(DbContextOptions<SportContext> options)
            : base(options)
        {
        }
    }
}
