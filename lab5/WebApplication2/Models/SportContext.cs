using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace Lab_1.Models
{
    public class SportContext: DbContext
    {
        public SportContext()
        {
        }

        public SportContext(DbContextOptions<SportContext> options): base (options)
        {

        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<TimeTable> Timetables { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("SQLConnection");

            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;
        }
    }
}
