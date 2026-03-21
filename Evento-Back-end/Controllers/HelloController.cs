using Microsoft.AspNetCore.Mvc;

namespace Evento_Back_end.Controllers
{
    [ApiController]
    [Route("api/hello")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public string GetHello()
        {
            return "Hello";
        }
    }
}
