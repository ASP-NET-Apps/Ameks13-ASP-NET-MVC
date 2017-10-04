﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Controllers
{
    public class HomeController : Controller
    {
        // GET: Administration/Home
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Error()
        {
            return this.View("Error");
        }

        public ViewResult NotFound()
        {
            return this.View("NotFound");
        }
    }
}