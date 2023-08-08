using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Data.Mappings;
using TasksAPI.Domain.Models;
using Task = TasksAPI.Domain.Models.Task;

namespace TasksAPI.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }

        public DbSet<Task>? Task { get; set; }
        public DbSet<User>? User { get; set; }
    }
}
