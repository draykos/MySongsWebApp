using Flurl.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MySongs.DAL.Models;
using MySongs.DAL.Students;
using MySongsApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MySongsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly SignInManager<ApplicationUser> signinManager;

        public AuthenticationController(IConfiguration configuration, SignInManager<ApplicationUser> signinManager)
        {
            this.configuration = configuration;
            this.signinManager = signinManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (model is null)
            {
                return BadRequest("Invalid user request!!!");
            }

            var result = await signinManager.PasswordSignInAsync(model.UserName, model.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await signinManager.UserManager.FindByNameAsync(model.UserName);
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JWT:Secret").Value));
                var issuer = configuration.GetSection("JWT:Issuer").Value ?? String.Empty;
                var audience = configuration.GetSection("JWT:Audience").Value ?? String.Empty;

                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);


                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature)
                };

                tokenDescriptor.Claims = new Dictionary<string, object>();
                tokenDescriptor.Claims.Add("key1", "my claim1");
                tokenDescriptor.Claims.Add("key2", "my claim2");
                tokenDescriptor.Claims.Add("key3", "my claim3");


                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                tokenHandler = new JwtSecurityTokenHandler();
                tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id),
                    }),
                    Expires = DateTime.UtcNow.AddDays(30),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature)
                };
                var refreshTokenString = new JwtSecurityTokenHandler().WriteToken(token);



                return Ok(new JWTTokenResponse { Token = tokenString, RefreshToken = refreshTokenString });
            }

            return Unauthorized();
        }
    }
}