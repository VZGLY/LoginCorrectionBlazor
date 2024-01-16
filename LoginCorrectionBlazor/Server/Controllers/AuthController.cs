using LoginCorrectionBlazor.Server.Context;
using LoginCorrectionBlazor.Shared.DTO;
using LoginCorrectionBlazor.Shared.Entities;
using LoginCorrectionBlazor.Shared.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace LoginCorrectionBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginForm form)
        {
            User? u = FakeDB.Users.Find(x  => x.Email.ToLower() == form.Email.ToLower());

            if (u is not null)
            {
                if (u.Password == form.Password) 
                {
                    Console.WriteLine("Success");

                    TokenDTO token = new TokenDTO();

                    token.Token = "Bearer " + u.Id;

                    return Ok(token);
                }
            }

            return BadRequest();
        }


        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterForm form)
        {
            User? u = FakeDB.Users.Find(x => x.Email == form.Email);

            if (u is null)
            {
                int NewId = FakeDB.Users.Max(x => x.Id) + 1;

                FakeDB.Users.Add(new User
                {
                    Id = NewId,
                    Email = form.Email,
                    Password = form.Password
                });

                return Ok();

            }

            return BadRequest();
        }

        [HttpPatch]
        [Route("password")]
        public IActionResult ChangePassword( ChangePasswordForm form)
        {

            string authorization = Request.Headers[HeaderNames.Authorization];

            if (string.IsNullOrEmpty(authorization))
            {
                return Unauthorized();
            }
            if (authorization.Split(' ').Length < 2)
            {
                return Unauthorized();
            }
            int UserID = Convert.ToInt32(authorization.Split(' ')[1]);

            User? u = FakeDB.Users.Find(x => x.Id == UserID);

            if (u is not null)
            {
                if (u.Password == form.OldPassword)
                {
                    u.Password = form.Password;
                    return Ok();
                }
            }

            return BadRequest();
        }

    }
}
