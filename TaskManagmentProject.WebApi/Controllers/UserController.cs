using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagmentProject.Abstraction.IServices;
using TaskManagmentProject.Common.DTOS;
using TaskManagmentProject.Domain.Models;
using TaskManagmentProject.Service.Helper;

namespace TaskManagmentProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;
        private readonly IMapper _mapper;


        public UserController(IUserService userService, IMapper mapper,
            IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("AssignUserToRole")]
        public ActionResult AssignUserToRole(AssignUserRolesDTO assignUserRolesDTO)
        {
            var user = _userService.Fetch(assignUserRolesDTO.UserID);
            if (user == null)
            {
                return NotFound();
            }
            var userRoles = _userRoleService.Set().Where(a => a.UserID == user.Id);
            foreach (var userRole in userRoles)
            {
                _userRoleService.Delete(userRole.ID);
            }
            foreach (var role in assignUserRolesDTO.Roles)
            {
                _userRoleService.Save(new UserRole
                {
                    UserID = user.Id,
                    Role = (UserRoleEnum)role
                });
            }
            return NoContent();
        }


        [HttpPost("CreateUser")]
        public ActionResult CreateUser(LoginDTO login)
        {
            var user = _userService.Set()
                .Where(a => a.UserName == login.UserName).SingleOrDefault();
            if (user != null)
            {
                return BadRequest("Username Already Exists!");
            }
            var newUser = new AppUser
            {
                UserName = login.UserName,
                Password = Cryptography.HmacSHA256(login.UserName, login.Password),
            };
            _userService.Save(newUser);
            _userRoleService.Save(new UserRole { UserID = newUser.Id, Role = UserRoleEnum.View });
            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = _userService.Fetch(id);
            if (user == null)
            {
                return NotFound();
            }
            _userService.Delete(id);
            return NoContent();
        }
    }
}