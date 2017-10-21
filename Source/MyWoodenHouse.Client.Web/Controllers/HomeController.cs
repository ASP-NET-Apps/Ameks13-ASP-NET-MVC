using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MyWoodenHouse.Data.Provider;
using MyWoodenHouse.Data.Services;
using MyWoodenHouse.Default.Auth.Managers;
using MyWoodenHouse.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWoodenHouse.Client.Web.Controllers
{
    public class HomeController : Controller
    {
        // TODO temp placed here.Testing User properties...
        private bool hasAdminRole = false;

        public HomeController()
        {
        }

        public ActionResult Index()
        {
            // TODO temp placed here. Testing User properties...
            if (User != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var userId = User.Identity.GetUserId();
                    var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    var roles = userManager.GetRoles(userId);
                    hasAdminRole = roles.Contains("Admin");
                }
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "You can contact AMEKS using:";

            return View();
        }
    }
}