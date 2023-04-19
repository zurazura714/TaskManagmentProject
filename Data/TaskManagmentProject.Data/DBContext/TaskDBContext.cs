using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentProject.Models.Models;

namespace TaskManagmentProject.Data.DBContext
{
    public class TaskDBContext : DbContext
    {
        public TaskDBContext(DbContextOptions<TaskDBContext> options) : base(options)
        {
        }

        public DbSet<TaskDomain> Tasks { get; set; }
        public DbSet<TaskFile> TaskFiles { get; set; }
    }
}
