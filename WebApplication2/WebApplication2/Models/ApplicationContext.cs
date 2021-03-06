﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab_1.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public ApplicationContext()
        {

        }
    }
}
