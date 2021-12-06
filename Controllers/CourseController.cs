using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QLLopHocTrucTuyen.Models;
using QLLopHocTrucTuyen.Repositories;
using System.Net;
using System.Net.Http;
using System.Web;
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
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;
        public CourseController(ILogger<CourseController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public string Get()
        {
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


            return "I'm there";
        }

        [HttpGet("All")]
        [Authorize]
        public IEnumerable<Course> GetAll()
        {


            _logger.LogInformation("Course GetAll");
            return CourseRes.GetAll();
        }


        [HttpPost("Create")]
        // GET: CourseController/Create
        public bool Create(Course noti)
        {

            var JWToken = HttpContext.Session.GetString("JWToken");
            Console.WriteLine(JWToken);

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                if (identity.FindFirst("RoleName") != null)
                {
                    var role = identity.FindFirst("RoleName").Value;

                    if (role == "admin")
                    {

                        _logger.LogInformation("Course Create");
                        bool Course = CourseRes.Insert(noti);

                        return Course;
                    }
                }
            }

            return false;
        }

        [HttpPost("Update")]
        // GET: CourseController/Create
        public bool Update(Course noti)
        {

            var JWToken = HttpContext.Session.GetString("JWToken");
            Console.WriteLine(JWToken);

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                if (identity.FindFirst("RoleName") != null)
                {
                    var role = identity.FindFirst("RoleName").Value;

                    if (role == "admin")
                    {

                        _logger.LogInformation("Course Update");
                        bool Course = CourseRes.Update(noti);

                        return Course;
                    }
                }
            }

            return false;
        }

        [HttpGet("Delete")]
        // GET: CourseManagerController/Delete
        public bool Delete(int id)
        {
            var JWToken = HttpContext.Session.GetString("JWToken");
            Console.WriteLine(JWToken);

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                if (identity.FindFirst("RoleName") != null)
                {
                    var role = identity.FindFirst("RoleName").Value;

                    if (role == "admin")
                    {

                        _logger.LogInformation("Course Delete");
                        bool Course = CourseRes.Delete(id);

                        return Course;
                    }
                }
            }

            return false;
        }
    }
}