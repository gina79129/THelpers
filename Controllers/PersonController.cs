using Microsoft.AspNetCore.Mvc;

namespace THelpers.Controllers
{
    public class PersonController : Controller
    {

        public IActionResult PostData()
        {
            return View();
        }

        [Route("Person/Post",Name="PersonalData")]
        public IActionResult PostalData()
        {
            return View();
        }
        public IActionResult QueryPersonalData()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult UserInformation()
        {
            return View();
        }
    }
}