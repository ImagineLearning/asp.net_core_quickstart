using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Quickstart.Controllers
{
    [Produces("application/json")]
    [Route("")]
    public class DefaultController : Controller
    {
        [HttpGet]
        public object Get()
        {
            return new
            {
                Status = "Up",
            };
        }
    }
}