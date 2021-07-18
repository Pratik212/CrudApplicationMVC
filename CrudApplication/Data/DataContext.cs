using CrudApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Info> Infos { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Person> Persons { get; set; }

        public DbSet<Check>Checks { get; set; }
    }
}
