using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Lab_7.Models
{
    public class SportContext: DbContext
    {

        public DbSet<Group> Groups { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<TimeTable> Timetables { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTEPAD\\SQLEXPRESS;Database=sport_complex;Trusted_Connection=True;");
        }
    }
}
