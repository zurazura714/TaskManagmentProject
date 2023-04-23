using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentProject.Abstraction.IRepositories;
using TaskManagmentProject.Domain.Models;
using TaskManagmentProject.Service.Helper;

namespace TaskManagmentProject.Data.DBContext
{
    public class TaskDBContext : DbContext, IUnitOfWork
    {
        public DbSet<TaskDomain> TaskDomains { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<TaskFile> TaskFiles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public TaskDBContext(DbContextOptions<TaskDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskDomain>()
                .HasOne<AppUser>(t => t.AssignedUser)
                .WithMany(u => u.AssignedTasks)
                .HasForeignKey(t => t.AssignedUserId)
                .OnDelete(DeleteBehavior.Restrict);
            //Seed DB
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    Id = 1,
                    UserName = "User1",
                    Password = Cryptography.HmacSHA256("User1", "User1"),
                    IsAdmin = true
                },
                new AppUser()
                {
                    Id = 2,
                    UserName = "User2",
                    Password = Cryptography.HmacSHA256("User2", "User2"),
                    IsAdmin = false
                });
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole()
                {
                    ID = 1,
                    UserID = 1,
                    Role = UserRoleEnum.Create
                },
                new UserRole()
                {
                    ID = 2,
                    UserID = 1,
                    Role = UserRoleEnum.Update
                },
                new UserRole()
                {
                    ID = 3,
                    UserID = 1,
                    Role = UserRoleEnum.Delete
                },
                new UserRole()
                {
                    ID = 4,
                    UserID = 1,
                    Role = UserRoleEnum.View
                });
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
