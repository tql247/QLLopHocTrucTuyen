using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QLLopHocTrucTuyen.Models;
using System.Net;
using System.Net.Http;
using System.Web;
using QLLopHocTrucTuyen.Repositories;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;

namespace QLLopHocTrucTuyen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public IConfiguration _configuration;

        public AccountController(ILogger<AccountController> logger, IConfiguration config) 
        {  
            _logger = logger;
            _configuration = config;

        }

        [HttpGet]
        public string Get() {
            _logger.LogInformation("Index Action");
            return "Hello"; 
        }

        [HttpPost("Login")]
        public IActionResult Login(Account account) {
            _logger.LogInformation("Login");
            Account dbAccount = AccountRes.CheckAccount(account.Username, account.Password);

            if (dbAccount != null) {
                _logger.LogInformation(dbAccount.Username);
                _logger.LogInformation(dbAccount.RoleName);
                _logger.LogInformation(dbAccount.FullName);

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("RoleName", dbAccount.RoleName),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims,
                    expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                HttpContext.Session.SetString("JWToken", tokenString);
                
                return Ok(tokenString);
            }
            else
            {
                return Ok("Username or password is incorrect");
            }
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Ok("clear");
        }

        [HttpGet("All")]
        public IEnumerable<Account> GetAllAccount() {
            
            var JWToken = HttpContext.Session.GetString("JWToken");
            Console.WriteLine(JWToken);

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                if (identity.FindFirst("RoleName") != null) {
                    var role = identity.FindFirst("RoleName").Value;

                    if (role == "admin") {
                        return AccountRes.GetAll();
                    }
                }

            }

            return null; 
        }


        [HttpPost("Create")]
        // GET: AccountController/Create
        public bool Create(Account acc)
        {
            _logger.LogInformation("Account Create");
            bool Account = AccountRes.Insert(acc);

            return Account;
        }

        [HttpPost("Update")]
        // GET: AccountController/Create
        public bool Update(Account acc)
        {
            _logger.LogInformation("Account Update");
            bool Account = AccountRes.Update(acc);

            return Account;
        }

        [HttpGet("Delete")]
        // GET: AccountManagerController/Delete
        public bool Delete(int id)
        {
            _logger.LogInformation("Account Delete");
            bool Account = AccountRes.Delete(id);
            
            return Account;
        }

    }
}