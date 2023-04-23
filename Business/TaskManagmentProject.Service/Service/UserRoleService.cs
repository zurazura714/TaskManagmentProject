using TaskManagmentProject.Abstraction.IRepositories;
using TaskManagmentProject.Abstraction.IServices;
using TaskManagmentProject.Domain.Models;

namespace TaskManagmentProject.Service.Service
{
    public class UserRoleService : ServiceBase<UserRole, IUserRoleRepository>, IUserRoleService
    {
        public UserRoleService(IUnitOfWork context, IUserRoleRepository userRoleRepository) : base(context, userRoleRepository)
        {
        }
    }
}
