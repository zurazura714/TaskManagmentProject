using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;
using System.Security.Claims;
using TaskManagmentProject.Domain.Models;


public class UserManager
{

    public async void SignIn(HttpContext httpContext, AppUser user, IEnumerable<UserRole> userRole)
    {
        ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(user, userRole), CookieAuthenticationDefaults.AuthenticationScheme);
        ClaimsPrincipal principal = new ClaimsPrincipal(identity);

        await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
    }

    public async void SignOut(HttpContext httpContext)
    {
        await httpContext.SignOutAsync();
    }

    private IEnumerable<Claim> GetUserClaims(AppUser user, IEnumerable<UserRole> userRole)
    {
        List<Claim> claims = new List<Claim>();

        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
        if (user.IsAdmin)
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));

        claims.AddRange(this.GetUserRoleClaims(user, userRole));
        return claims;
    }
    private IEnumerable<Claim> GetUserRoleClaims(AppUser user, IEnumerable<UserRole> userRole)
    {
        List<Claim> claims = new List<Claim>();

        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        foreach (UserRole role in userRole)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.Role.ToString()));

        }
        return claims;
    }
}