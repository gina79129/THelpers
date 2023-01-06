using Microsoft.AspNetCore.Mvc;
using THelpers.Models;

namespace THelpers.Controllers
{
    public class ProductController : Controller
    {
        List<Product> products {get;} = new List<Product>
        {
            new Product {ProductId=1,Name="A"},
            new Product {ProductId=2,Name="B"},
            new Product {ProductId=3,Name="C"},
            new Product {ProductId=4,Name="D"},
            new Product {ProductId=5,Name="E"}
        };

        [Route("Product/{id:int}")]
        public IActionResult Details(int id)
        {
            ViewData["Referer"] = Request.Headers["Referer"].ToString();
            return View(products.FirstOrDefault(p=>p.ProductId==id));
        }

        [Route("product/Evals",Name ="ProductEvals")]
        public IActionResult Evalations(int id) =>View();

        [Route("Product/Avail",Name ="ProductAvailable")]
        public IActionResult Available(int Productid,bool available) => View();
    }
}