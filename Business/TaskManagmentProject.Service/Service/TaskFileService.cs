using TaskManagmentProject.Abstraction.IRepositories;
using TaskManagmentProject.Abstraction.IServices;
using TaskManagmentProject.Domain.Models;

namespace TaskManagmentProject.Service.Service
{
    public class TaskFileService : ServiceBase<TaskFile, ITaskFileRepository>, ITaskFileService
    {
        public TaskFileService(IUnitOfWork context, ITaskFileRepository taskFileRepository) : base(context, taskFileRepository)
        {
        }
    }
}
