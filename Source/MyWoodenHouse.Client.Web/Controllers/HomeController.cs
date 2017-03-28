using MyWoodenHouse.Data.Provider;
using MyWoodenHouse.Data.Services;
using MyWoodenHouse.Ef.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MyWoodenHouse.Client.Web.Controllers
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

            //var context = new MyWoodenHouseDbContext();
            //var categoryService = new Ca(context);

            //IList<Category> categories = categoryService.Select().ToList();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}