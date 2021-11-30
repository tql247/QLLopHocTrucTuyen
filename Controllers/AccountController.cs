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
            // this.HttpContext
            // this.Request
            // this.Response
            // this.RouteData
            // this.User
            // this.ModelState
            // this.ViewData
            // this.ViewBag
            // this.Url
            // this.TempData
            _logger.LogInformation("Index Action");


            return "Hello"; 
        }

        [HttpGet("All")]
        public IEnumerable<Account> GetAllAccount() {
            // this.HttpContext
            // this.Request
            // this.Response
            // this.RouteData
            // this.User
            // this.ModelState
            // this.ViewData
            // this.ViewBag
            // this.Url
            // this.TempData
            _logger.LogInformation("Index Action");
            // Account account = new Account();
            // account.FullName = "Linh";

            // List<Account> lstResult = new List<Account>();

            // lstResult.Add(account);

            return AccountRes.GetAll(); 
        }

        [HttpPost("Login")]
        public IActionResult Login(Account account) {
            _logger.LogInformation("Login");

            Account dbAccount = AccountRes.CheckAccount(account.Username, account.Password);
            string role = "";
            if (dbAccount != null) {
                _logger.LogInformation(dbAccount.RoleName);
                role = dbAccount.RoleName;
            }

            if (account.Username == "admin" && account.Password == "123456")
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("RoleName", role),
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

        // public IActionResult Wibu() {
        //     string filePath = Path.Combine(Startup.ContentRootPath, "Files", "wibu.jpg");
        //     var bytes = System.IO.File.ReadAllBytes(filePath);

        //     return File(bytes, "image/jpg");
        // }

        // public IActionResult JSONVALUE() {
        //     return Json(
        //         new {
        //             a= 1,
        //             b=2
        //         }
        //     );
        // }

        // public IActionResult Privacy ()
        // {
        //     var url = Url.Action("Privacy", "Home");
        //     return LocalRedirect(url);
        // }

        // public IActionResult HelloView(string username) 
        // {
        //     if (string.IsNullOrEmpty(username))
        //         username = "Guest";

        //     return View("/Pages/Razor.cshtml", username);
        // }

        // [TempData]
        // public string StatusMessage { get; set; }

        // public IActionResult ViewProduct(int? id)
        // {
        //     // return View(product);

        //     // this.ViewData["product"] = product;


        //     // return View("ViewProduct2");
        //     return View("ViewProduct3");
            
        //     // return Content($"ID = {id}");
        // }


    }

        // Kiểu trả về                 | Phương thức
        // ------------------------------------------------
        // ContentResult               | Content()
        // EmptyResult                 | new EmptyResult()
        // FileResult                  | File()
        // ForbidResult                | Forbid()
        // JsonResult                  | Json()
        // LocalRedirectResult         | LocalRedirect()
        // RedirectResult              | Redirect()
        // RedirectToActionResult      | RedirectToAction()
        // RedirectToPageResult        | RedirectToRoute()
        // RedirectToRouteResult       | RedirectToPage()
        // PartialViewResult           | PartialView()
        // ViewComponentResult         | ViewComponent()
        // StatusCodeResult            | StatusCode()
        // ViewResult                  | View()
}