using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentProject.Data.DBContext;
using TaskManagmentProject.Domain.Models;
using TaskManagmentProject.Service.Helper;

namespace TaskManagmentProject.Data.DataInit
{
    public static class DataInit
    {
        public static void AddData(IServiceProvider serviceScope)
        {
            //var context = serviceScope.GetRequiredService<TaskDBContext>();
            //context.Database.EnsureCreated();
            //if (!context.AppUsers.Any())
            //{
            //    AppUser user = new AppUser()
            //    {
            //        UserName = "Admin",
            //        Password = Cryptography.HmacSHA256("Admin", "Admin123"),
            //    };
            //    context.AppUsers.Add(user);
            //    context.SaveChangesAsync();
            //}
        }
    }
}
