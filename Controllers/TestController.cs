using Microsoft.AspNetCore.Mvc;

namespace THelpers.Controllers
{
    public class TestController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}