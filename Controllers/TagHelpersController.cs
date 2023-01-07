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

        public IActionResult MultiSelect(){
            var model = new CountryGroupViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MultiSelect(CountryGroupViewModel countryVM){
            if(ModelState.IsValid){
                List<string> countries = new List<string>();
                countryVM.CountryCodes.ToList().ForEach((x)=>{
                    string countryName = countryVM.Countries.Where(c=>c.Value == x).Select(s=>s.Text).FirstOrDefault();
                    countries.Add(countryName);
                });
                var selectedCountries = countryVM.CountryCodes.Select(x=>countryVM.Countries.Where(c=>c.Value==x).FirstOrDefault()).Select(p=>p.Text).ToList();
                TempData["CountryList"] = countries;
                return RedirectToAction("DisplayCountries");
            }
            return View();
        }

        public IActionResult TextareaTagHelper(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TextareaTagHelper(FeedBackViewModel feedBackVM)
        {
            if(ModelState.IsValid){
                TempData["Email"] = feedBackVM.Email;
                TempData["Opinion"]=feedBackVM.Opinion;
                return RedirectToAction("DisplayOpinion");
            }
            return View();
        }

        public IActionResult ValidationTagHelper(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ValidationTagHelper(FeedBackViewModel feedBackVM){
            if(ModelState.IsValid)
            {
                TempData["Email"]=feedBackVM.Email;
                TempData["Opinion"]=feedBackVM.Opinion;
                return RedirectToAction("DisplayOpinion");
            }else{
                ModelState.AddModelError("ErrorReport","輸入的資料格式內容有誤!");
                int idx = 1;
                var errors = ModelState.Values.Select(err => err.Errors.FirstOrDefault().ErrorMessage).ToList();
                errors.ForEach((error)=>
                {
                    ModelState.AddModelError($"Error{idx++}",error + ", 請重新輸入正確格式!");
                });
            }
            return View();
        }

        public IActionResult CacheTagHelper(){
            return View();
        }
        public IActionResult DisplayOpinion(){
            if(TempData.Count==0){
                return Content("無任何資料");
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
        public IActionResult DisplayCountries(){
            if(!TempData.ContainsKey("CountryList")){
                return Content("必須提供List集合資料");
            }
            return View((string[])TempData["CountryList"]);
        }


        
    }
}