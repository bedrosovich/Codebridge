using Microsoft.AspNetCore.Mvc;


namespace Codebridge.Controllers
{
    [ApiController]
    [Route("")]
    public class InfoController : Controller
    {

        [HttpGet]
        [Route("ping")]
        public JsonResult Ping()
        {
            return new JsonResult("Dogs house service. Version 1.0.1");
        }
    }
}
