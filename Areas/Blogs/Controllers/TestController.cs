using Microsoft.AspNetCore.Mvc;


namespace THelpers.Areas.Blogs
{
    [Area("Blogs")]
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

    }
}