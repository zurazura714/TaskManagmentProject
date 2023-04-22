using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskManagmentProject.Repository.Repositories.TaskRepository;
using TaskManagmentProject.Abstraction.IRepositories;
using TaskManagmentProject.Domain.Models;

namespace TaskManagmentProject.Repository.Repositories
{
    public class TaskRepository : RepositoryBase<TaskDomain>, ITaskRepository
    {
        public TaskRepository(IUnitOfWork context) : base(context)
        {
        }
    }
}
