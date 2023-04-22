using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentProject.Abstraction.IRepositories;
using TaskManagmentProject.Domain.Models;

namespace TaskManagmentProject.Data.DBContext
{
    public class TaskDBContext : DbContext, IUnitOfWork
    {
        public DbSet<TaskDomain> TaskDomains { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<TaskFile> TaskFiles { get; set; }

        public TaskDBContext(DbContextOptions<TaskDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskDomain>()
                .HasOne<AppUser>(t => t.AssignedUser)
                .WithMany(u => u.AssignedTasks)
                .HasForeignKey(t => t.AssignedUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public void Commit()
        {
            SaveChanges();
        }

        public void Rollback()
        {
            Rollback();
        }
    }
}
