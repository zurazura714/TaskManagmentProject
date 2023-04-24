using TaskManagmentProject.Abstraction.IRepositories;
using TaskManagmentProject.Domain.Models;

namespace TaskManagmentProject.Repository.Repositories
{
    public class TaskFileRepository : RepositoryBase<TaskFile>, ITaskFileRepository
    {
        public TaskFileRepository(IUnitOfWork context) : base(context)
        {
        }
    }
}
