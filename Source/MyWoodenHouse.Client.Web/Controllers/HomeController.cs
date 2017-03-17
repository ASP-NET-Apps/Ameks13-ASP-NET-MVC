using MyWoodenHouse.Data.Models;
using MyWoodenHouse.Data.Provider;
using MyWoodenHouse.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWoodenHouse.Controllers
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

            var context = new MyWoodenHouseDbContext();
            var categoryService = new CategoryServiceCrudOperatons(context);

            IList<Category> categories = categoryService.Get().ToList();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}