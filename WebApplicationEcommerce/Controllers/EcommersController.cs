using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationEcommerce.Data;
using WebApplicationEcommerce.Models;

namespace WebApplicationEcommerce.Controllers
{
    public class EcommersController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterForm obj)
        {
            ViewBag.Message = "formsubmitted";
            if (ModelState.IsValid)
            {
                bool res = StdLogic.Insertdata(obj);

                if (res == true)
                {

                    return RedirectToAction("Login");
                }
                else
                {
                    return View(obj);
                }
            }
            else
            {
                return View(obj);
            }
        }
      
        public IActionResult LoginForm()
        {
            return View();
        }
        public IActionResult Form1()
        {
            return View();
        }
        public IActionResult LoginForm2()
        {
            return View();
        }

        public IActionResult View()
        {
            return View();
        }
    }
}
