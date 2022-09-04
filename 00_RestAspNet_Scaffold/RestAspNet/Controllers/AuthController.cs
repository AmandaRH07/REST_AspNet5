using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAspNet.Data.Value_Object;
using RestAspNet.Services.Implementations;

namespace RestAspNet.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UserVO user)
        {
            if (user == null) return BadRequest("Invalid Client Request!");

            var token = _loginService.ValidateCredentials(user);
            if(token == null) return Unauthorized();

            return Ok(token);
        }

        [HttpPost]
        [Route("refreshToken")]
        public IActionResult Refresh([FromBody] TokenVO tokenVO)
        {
            if (tokenVO is null) return BadRequest("Invalid Client Request!");

            var token = _loginService.ValidateCredentials(tokenVO);
            if (token == null) BadRequest("Invalid Client Request!");

            return Ok(token);
        }

        [HttpGet]
        [Authorize("Bearer")]
        [Route("revoke")]
        public IActionResult Revoke()
        {
            var userName = User.Identity.Name;
            var result = _loginService.RevokeToken(userName);

            if (!result) BadRequest("Invalid Client Request!");

            return NoContent();
        }
    }
}
