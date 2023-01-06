using Microsoft.AspNetCore.Mvc;

namespace THelpers.Controllers
{
    public class BuiltInTagHelpersController : Controller
    {

        public IActionResult RegisterResult()
        {
            return View();
        }
    }
}