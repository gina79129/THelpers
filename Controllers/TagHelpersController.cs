using Microsoft.AspNetCore.Mvc;
using THelpers.Models;
using THelpers.ViewModels;

namespace THelpers.Controllers
{
    public class TagHelpersController : Controller
    {

        List<Product> products {get;} = new List<Product>
        {
            new Product {ProductId=1,Name="A"},
            new Product {ProductId=2,Name="B"},
            new Product {ProductId=3,Name="C"},
            new Product {ProductId=4,Name="D"},
            new Product {ProductId=5,Name="E"}
        };
        public IActionResult AnchorTagHelper()
        {

            return View(products.FirstOrDefault());
        }

        public IActionResult FormTagHelper()
        {
            return View();
        }
        public IActionResult FormActionTagHelper()
        {
            return View();
        }
        public IActionResult InputTagHelper()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InputTagHelper([Bind("Email, Password, ConfirmPassword")] RegisterViewModel registerVM)
        {
            if(ModelState.IsValid){
                TempData["Email"] = registerVM.Email;
                TempData["Password"] = registerVM.Password;
            }

            return View(registerVM);
        }

        public IActionResult RegisterResult(){
            if(!(TempData.ContainsKey("Email") && TempData.ContainsKey("Password"))){
                return Content("無任何資料");
            }
            return View();
        }

    }
}