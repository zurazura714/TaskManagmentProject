using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentProject.Domain.Models;

namespace TaskManagmentProject.Abstraction.IRepositories
{
    public interface ITaskRepository : IRepositoryBase<TaskDomain>
    {
    }
}