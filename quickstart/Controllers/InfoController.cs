using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Quickstart.Controllers
{
    [Produces("application/json")]
    [Route("info")]
    public class InfoController : Controller
    {
        [HttpGet]
        public object Get()
        {
            return new
            {
                Name = "Imagine.Quickstart.API",
                ApiVersion = "v0.1"
            };
        }
    }
}