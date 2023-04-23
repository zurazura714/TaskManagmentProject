using TaskManagmentProject.Common.DTOS;
using TaskManagmentProject.Domain.Models;

namespace TaskManagmentProject.Abstraction.IServices
{
    public interface IUserService : IServiceBase<AppUser>
    {
        AppUser GetUser(LoginDTO login);
    }
}
