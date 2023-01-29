using Manager.API.Token;
using Manager.API.Utilities;
using Manager.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controller
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IConfiguration _configuration;

        public AuthController(ITokenGenerator tokenGenerator, IConfiguration configuration)
        {
            _tokenGenerator = tokenGenerator;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("api/v1/auth/login")]
        public IActionResult Login([FromBody] LoginViewModel login)
        {
            try
            {
                if (login.Login != _configuration["Jwt:Login"] || 
                login.Password != _configuration["Jwt:Password"])
                {
                    return StatusCode(401, Responses.UnauthorizedError);
                }

                return Ok(new ResultViewModel
                {
                    Success = true,
                    Message = "User authenticated successfully",
                    Data = new
                    {
                        Token = _tokenGenerator.GenerateToken(),
                        TokenExpiration = DateTime.UtcNow
                            .AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
                    }
                });
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApliccationError);
            }
        }
    }
}