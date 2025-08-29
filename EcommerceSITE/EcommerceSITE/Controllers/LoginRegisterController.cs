using EcommerceSITEDAL.DataAccess;
using EcommerceSITEDAL.Models.Entity;
using EcommerceSITEDAL.Models.ViewModel;
using EcommerceSITEDAL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace EcommerceSITE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginRegisterController : ControllerBase
    {

        private readonly IUserRepository _db;
        private readonly IConfiguration _config;
        public LoginRegisterController(IUserRepository db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {


            var hmac = new HMACSHA512();
            

            var user = new Users
            {
                Username= registerVM.Username,
                Email= registerVM.Email,
                PasswordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(registerVM.Password))),
                PasswordSalt = hmac.Key,
                Phone = registerVM.Phone,
                Address= registerVM.Address,
                Role = "Customer"

            };

            await _db.AddNewUser(user);

            return( Ok(registerVM));
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            try
            {
                var user = await _db.GetUserbyID(loginVM.Username);
                if (user == null)
                {
                    return Unauthorized("User not found");
                }
                var hmac = new HMACSHA512(user.PasswordSalt);

                var passwordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(loginVM.Password)));

                if (passwordHash != user.PasswordHash)
                {
                    return Unauthorized("Incorrect Password");


                }

                var token = GenerateToken(user);
                return Ok(token);
            }
            catch (Exception ex)
            {
                // Handle or log the error
                return StatusCode(500, "Something went wrong: " + ex.Message);
            }


        }

        [HttpGet("Profile")]
        [Authorize]
        public async Task<IActionResult> ProfilePage()
        {
            var usernameClaim = User.FindFirst(ClaimTypes.Name);
            string username = usernameClaim.Value;
            var user = await _db.GetUserbyID(username);
            return Ok(user);
        }


        private string GenerateToken(Users user)
        {
            var claims = new[] {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };



            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
             claims: claims,
              expires: DateTime.Now.AddHours(1),
            signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
