using TaskManagmentProject.Abstraction.IRepositories;
using TaskManagmentProject.Abstraction.IServices;
using TaskManagmentProject.Common.DTOS;
using TaskManagmentProject.Domain.Models;
using TaskManagmentProject.Service.Helper;

namespace TaskManagmentProject.Service.Service
{
    public class UserService : ServiceBase<AppUser, IUserRepository>, IUserService
    {
        public UserService(IUnitOfWork context, IUserRepository userRepository) : base(context, userRepository)
        { }

        public AppUser GetUser(LoginDTO login)
        {
            var user = Set().Where(x => x.UserName == login.UserName &&
                                        x.Password == Cryptography.HmacSHA256(login.UserName, login.Password)).SingleOrDefault();
            if (user != null)
            {
                return user;
            }
            return null;
        }
    }
}
