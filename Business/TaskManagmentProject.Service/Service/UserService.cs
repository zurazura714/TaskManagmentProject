using TaskManagmentProject.Abstraction.IRepositories;
using TaskManagmentProject.Abstraction.IServices;
using TaskManagmentProject.Domain.Models;

namespace TaskManagmentProject.Service.Service
{
    public class UserService : ServiceBase<AppUser, IUserRepository>, IUserService
    {
        public UserService(IUnitOfWork context, IUserRepository userRepository) : base(context, userRepository)
        {
        }
    }
}
