using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentProject.Abstraction.IRepositories;
using TaskManagmentProject.Abstraction.IServices;
using TaskManagmentProject.Domain.Models;

namespace TaskManagmentProject.Service.Service
{
    public class TaskService : ServiceBase<TaskDomain, ITaskRepository>, ITaskService
    {
        public TaskService(IUnitOfWork context, ITaskRepository taskRepository) : base(context, taskRepository)
        {
        }
    }
}
