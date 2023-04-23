using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Security.Claims;
using TaskManagmentProject.Abstraction.IServices;
using TaskManagmentProject.Common.DTOS;
using TaskManagmentProject.Domain.Models;
using TaskManagmentProject.Service.Service;

namespace TaskManagmentProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;
        private readonly IMapper _mapper;
        UserManager _userManager;


        public AuthController(IUserService userService, IMapper mapper,
            IUserRoleService userRoleService, UserManager userManager)
        {
            _userRoleService = userRoleService;
            _userService = userService;
            _userManager = userManager;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginDTO model)
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
                return Ok("You are already Authorized!");

            var user = _userService.GetUser(model);

            if (user != null)
            {
                var userRoles = _userRoleService.Set().Where(a => a.UserID == user.Id);
                _userManager.SignIn(this.HttpContext, user, userRoles);
                return Ok();
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("LogOut")]
        public IActionResult LogOuts()
        {
            _userManager.SignOut(this.HttpContext);
            return Ok();
        }
    }
}