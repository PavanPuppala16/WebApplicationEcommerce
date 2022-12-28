using Microsoft.AspNetCore.Mvc;
using WebApplicationEcommerce.Models;
using WebApplicationEcommerce.Data;

namespace WebApplicationEcommerce.Controllers
{
    public class ProductController : Controller
    {
     
            public IActionResult Index()
            {
                ProductModel productModel = new ProductModel();
                ViewBag.products = productModel.findAll();
                return View();
            }

        public IActionResult CalDate()
        {
           
            return View(File_bl.Method());
        }
        }
    }
