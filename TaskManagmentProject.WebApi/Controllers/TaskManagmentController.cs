using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagmentProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskManagmentController
    {
        [HttpGet(Name = "GetWeatherForecast"), Authorize]
        public IEnumerable<AppDomain> Get()
        {
            return null;
        }


    }
}
