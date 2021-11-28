using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace QLLopHocTrucTuyen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FirstController : ControllerBase
    {
        private readonly ILogger<FirstController> _logger;
        public FirstController(ILogger<FirstController> logger) 
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