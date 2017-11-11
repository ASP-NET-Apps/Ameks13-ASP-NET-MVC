using AutoMapper;
using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MyWoodenHouse.Data.Provider;
using MyWoodenHouse.Data.Services;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Default.Auth.Managers;
using MyWoodenHouse.Models;
using MyWoodenHouse.ViewModels.Page;
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

        private readonly IMapper mapper;
        private readonly IBaseGenericService<Page> pageService;

        public HomeController(IMapper mapper, IBaseGenericService<Page> pageService)
        {
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();
            Guard.WhenArgument(pageService, nameof(pageService)).IsNull().Throw();

            this.mapper = mapper;
            this.pageService = pageService;
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

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "You can contact AMEKS using:";

        //    return View();
        //}

        public ActionResult Contact()
        {
            var pageId = 1;
            var page = this.pageService.GetById(pageId);
            if (page == null)
            {
                //TODO validate
            }

            var pageVm = this.mapper.Map<Page, PageVm>(page);
            //TempData[PreviewId] = pictureGalleryVmMapped.Id;

            //// TODO extract to upper level and put to cash
            //var appBaseUrl = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
            //pictureGalleryVmMapped = this.UpdatePictureViewModelUrl(pictureGalleryVmMapped, appBaseUrl);

            return this.View(pageVm);
        }

        public ActionResult CKFinder()
        {
            ViewBag.Message = "Welcome to CKFinder!";
            return View();
        }
    }
}