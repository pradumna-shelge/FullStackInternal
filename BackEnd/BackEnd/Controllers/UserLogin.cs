using BackEnd.DTO;
using BackEnd.Models;
using BackEnd.RepoPattren.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLogin : ControllerBase
    {
        private readonly IuserClass _user;
        private readonly IConfiguration _config;
        private readonly IuserRole _role;

        public UserLogin(IuserClass iuser,IConfiguration 
            configuration,IuserRole role)
        {
                _user = iuser;
            _config = configuration;
            _role = role;
        }


        [HttpPost("signIn")]

        public ActionResult Login(CurrenUser ob)
        {
            if(ob == null)
            {
                return BadRequest(string.Empty);
            }

            var user = _user.Get().FirstOrDefault(x=> x.UserId == ob.username && x.UserPassword == ob.password);
            if(user == null)
            {
                return NotFound();
            }
            string Role = _role.Get().FirstOrDefault(x=>x.RoleId == user.RoleId).RoleName;
            string name = user.UserId;
            string token = createToken(Role,name);

            var data = new
            {
                token = token,
                role = Role
            };
            return Ok(data);
        }


        private string createToken(string role,string name)
        {

            
            var sec = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:key").Value));

            var cre = new SigningCredentials(sec, SecurityAlgorithms.HmacSha256);

            var clames = new Claim[]
            {
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Role, role),
            };

            var token = new JwtSecurityToken(
                _config.GetSection("jwt:issuer").Value,
                _config.GetSection("jwt:aud").Value,
                clames,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: cre);
            var Token = new JwtSecurityTokenHandler().WriteToken(token);

            return Token;
        }
    }
}
