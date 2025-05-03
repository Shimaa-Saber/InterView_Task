using InterView_Task.DTOs.Auth;
using InterView_Task.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InterView_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _AuthRepository;
        public AuthController(IAuth authRepository)
        {
            _AuthRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(
      [FromForm] RegisterDto userFromConsumer
      )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _AuthRepository.RegisterUserAsync(userFromConsumer);

            if (result.Succeeded)
            {
                return Ok("Account Create Success");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return BadRequest(ModelState);
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(
      [FromForm] LoginDto userFromConsumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _AuthRepository.LoginUserAsync(userFromConsumer);

            if (result.Success)
            {
                return Ok(new
                {
                    expired = result.Expiry,
                    token = result.Token
                });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return BadRequest(ModelState);
        }


    }
}
