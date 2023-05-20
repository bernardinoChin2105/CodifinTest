using Microsoft.AspNetCore.Mvc;

namespace CodifinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "WELCOME";
        }
    }
}
