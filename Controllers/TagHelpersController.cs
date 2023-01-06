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

                return RedirectToAction("RegisterResult");
            }

            return View(registerVM);
        }

        public IActionResult RegisterResult(){
            if(!(TempData.ContainsKey("Email") && TempData.ContainsKey("Password"))){
                return Content("無任何資料");
            }
            return View();
        }

        public IActionResult SelectTagHelper(){
            var model = new CountryViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectTagHelper(CountryViewModel countryVM){
            if(ModelState.IsValid){
                string countryCode = countryVM.Country;
                string country = countryVM.Countries.Where(c=>c.Value == countryCode).Select(x=>x.Text).FirstOrDefault();
                return RedirectToAction("DisplayCountry",new{Country=country});
            }
            return View(countryVM);
        }


        public IActionResult SelectEnum(){
            var model = new CountryEnumViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectEnum(int EnumerateCountry)
        {
            if(ModelState.IsValid){
                return RedirectToAction("DisplayCountry",new{Country = (CountryEnum)EnumerateCountry});
            }
            return View();
        }

        public IActionResult SelectOptionGroup(){
            var model = new CountryGroupViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectOptionGroup(CountryGroupViewModel countryVM){
            if(ModelState.IsValid){
                var country= countryVM.Countries.Where(c=>c.Value==countryVM.Country).Select(x=>x.Text).FirstOrDefault();
                return RedirectToAction("DisplayCountry", new {Country = country});
            }
            return View();
        }


        
        public IActionResult DisplayCountry(string country){
            if(string.IsNullOrEmpty(country)){
                return Content("必須提供Country參數!");
            }
            ViewData["Country"] = country;
            return View();
        }


        
    }
}