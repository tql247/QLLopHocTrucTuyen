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
    public class   NotificationController : ControllerBase
    {
        private readonly ILogger<NotificationController> _logger;  
        public   NotificationController(ILogger<NotificationController> logger) 
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
        public IEnumerable<Notification> GetAll() {
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


            return NotificationRes.GetAll(); 
        }


        [HttpPost("Create")]
        // GET: NotificationController/Create
        public bool Create(Notification noti)
        {
            _logger.LogInformation("Notification Create");
            bool Notification = NotificationRes.Insert(noti);

            return Notification;
        }

        [HttpGet("Delete")]
        // GET: NotificationManagerController/Delete
        public bool Delete(int id)
        {
            _logger.LogInformation("Notification Create");
            bool Notification = NotificationRes.Delete(id);
            
            return Notification;
        }
    }
}