using InterView_Task.DTOs.Auth;
using InterView_Task.GeneralResponse;
using InterView_Task.Interfaces;
using InterView_Task.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InterView_Task.Repos
{
    public class AuthRepository : IAuth
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly dbContext _context;
        private readonly IConfiguration _config;
        public AuthRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            dbContext context,
            IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _config = config;
        }
        public async Task<IdentityResult> RegisterUserAsync(RegisterDto userFromConsumer)
        {
           
            var UserByEmail = await _userManager.FindByEmailAsync(userFromConsumer.Email);
            if (UserByEmail != null)
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "DuplicateEmail",
                    Description = "Email is already in use."
                });
            }

            
            var UserByUsername = await _userManager.FindByNameAsync(userFromConsumer.UserName.Replace(" ", ""));
            if (UserByUsername != null)
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "DuplicateUserName",
                    Description = "Username is already taken."
                });
            }

            // Create new user
            ApplicationUser user = new ApplicationUser
            {
                Email = userFromConsumer.Email,
                UserName = userFromConsumer.UserName.Replace(" ", "")
            };

            IdentityResult result = await _userManager.CreateAsync(user, userFromConsumer.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return result;
        }






        public async Task<LoginResponse> LoginUserAsync(LoginDto userFromConsumer)
        {
            var user = await _userManager.FindByNameAsync(userFromConsumer.UserName);
            if (user == null)
            {
                return new LoginResponse
                {
                    Success = false,
                    Errors = new[] { "Invalid Account" }
                };
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, userFromConsumer.Password);
            if (!passwordValid)
            {
                return new LoginResponse
                {
                    Success = false,
                    Errors = new[] { "Invalid Account" }
                };
            }

            
            string jti = Guid.NewGuid().ToString();
            var userRoles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, jti)
        };

            if (userRoles != null)
            {
                claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));
            }

            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var signingCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JWT:Iss"],
                audience: _config["JWT:Aud"],
                expires: DateTime.Now.AddHours(1),
                claims: claims,
                signingCredentials: signingCredentials
            );

            return new LoginResponse
            {
                Success = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiry = DateTime.Now.AddHours(1)
            };
        }


    }
}
