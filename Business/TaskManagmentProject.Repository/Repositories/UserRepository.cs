using TaskManagmentProject.Abstraction.IRepositories;
using TaskManagmentProject.Domain.Models;

namespace TaskManagmentProject.Repository.Repositories
{
    public class UserRepository : RepositoryBase<AppUser>, IUserRepository
    {
        public UserRepository(IUnitOfWork context) : base(context)
        {
        }
    }
}
