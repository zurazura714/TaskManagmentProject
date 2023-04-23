using TaskManagmentProject.Abstraction.IRepositories;
using TaskManagmentProject.Domain.Models;

namespace TaskManagmentProject.Repository.Repositories
{
    public class UserRoleRepository : RepositoryBase<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IUnitOfWork context) : base(context)
        {
        }
    }
}
