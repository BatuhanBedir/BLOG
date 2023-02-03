using Microsoft.AspNetCore.Mvc;

namespace BLOG.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
