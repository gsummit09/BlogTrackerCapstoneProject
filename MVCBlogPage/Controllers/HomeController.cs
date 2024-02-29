using MVCBlogPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlogPage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View(new AdminInfo());
        }
        [HttpPost]
        public ActionResult AdminLogin(AdminInfo sign) 
        {
            if(ModelState.IsValid)
            {
                if((sign.EmailId == "sumit@gmail.com") && (sign.Password == "sumu@998"))
                {
                    Session["UserId"] = Guid.NewGuid();
                    return RedirectToAction("EmployeeList","AdminInfoes");
                }
                else
                {
                    ModelState.AddModelError("", "Either UserName or Password Incorrect!!!");
                    return View(sign);
                }
            }
            else
            {
                return View(sign);
            }
        }
        [HttpGet]
        public ActionResult EmpLogin()
        {
            return View(new EmoInfo());
        }
        public ActionResult EmpLogin(EmoInfo sign)
        {
            if(ModelState.IsValid)
            {
                if((sign.EmailId == "sumu@gmail.com") && (sign.PassCode ==9988))
                {
                    Session["UserId"] = Guid.NewGuid();
                    return RedirectToAction("SaveBlog", "EmoInfoes");
                }
                else
                {
                    ModelState.AddModelError("", "Either Username or Password Incorrect!!!");
                    return View(sign);
                }
            }
            else
            {
                return View(sign);
            }
        }
    }
}