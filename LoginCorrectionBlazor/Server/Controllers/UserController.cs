using LoginCorrectionBlazor.Server.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginCorrectionBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(FakeDB.Users);
        }

    }
}
