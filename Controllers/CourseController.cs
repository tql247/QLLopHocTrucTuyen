using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QLLopHocTrucTuyen.Models;
using QLLopHocTrucTuyen.Repositories;

namespace QLLopHocTrucTuyen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class   CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;  
        public   CourseController(ILogger<CourseController> logger) 
        {  
            _logger = logger;
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


            return "I'm there"; 
        }
        
        [HttpGet("All")]
        public IEnumerable<Course> GetAll() {
            _logger.LogInformation("Course GetAll");
            return CourseRes.GetAll(); 
        }


        [HttpPost("Create")]
        // GET: CourseController/Create
        public bool Create(Course noti)
        {
            _logger.LogInformation("Course Create");
            bool Course = CourseRes.Insert(noti);

            return Course;
        }

        [HttpPost("Update")]
        // GET: CourseController/Create
        public bool Update(Course noti)
        {
            _logger.LogInformation("Course Update");
            bool Course = CourseRes.Update(noti);

            return Course;
        }

        [HttpGet("Delete")]
        // GET: CourseManagerController/Delete
        public bool Delete(int id)
        {
            _logger.LogInformation("Course Delete");
            bool Course = CourseRes.Delete(id);
            
            return Course;
        }
    }
}