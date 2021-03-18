using Microsoft.AspNetCore.Mvc;

namespace Leak.UI.MVC.Controllers
{
    public class CategoryController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
