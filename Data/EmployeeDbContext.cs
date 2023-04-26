﻿using Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<Employees> Employees { get; set; }
    }
}
