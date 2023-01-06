using Microsoft.AspNetCore.Mvc;

namespace THelpers.Areas.Blogs
{
    [Area("Blogs")]
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}