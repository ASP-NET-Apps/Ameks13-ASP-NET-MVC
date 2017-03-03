using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyWoodenHouse.Data.Models;
using MyWoodenHouse.Data.Provider;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.App_Start;
using Ninject;
using MyWoodenHouse.Data.Services.Contracts;

namespace MyWoodenHouse.Controllers
{
    public class CategoriesController : Controller
    {
        public CategoriesController()
        {
            this.MyWoodenHouseDbContext = NinjectWebCommon.Kernel.Get<IMyWoodenHouseDbContext>();
            this.CategoryServiceCrudOperatons = NinjectWebCommon.Kernel.Get<ICategoryServiceCrudOperatons>();
        }

        protected IMyWoodenHouseDbContext MyWoodenHouseDbContext { get; private set; }

        protected ICategoryServiceCrudOperatons CategoryServiceCrudOperatons { get; private set; }

        // GET: Categories
        public ActionResult Index()
        {
            IList<Category> allCategories = this.CategoryServiceCrudOperatons.Select().ToList();

            return View(allCategories);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = this.CategoryServiceCrudOperatons.SelectById(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                this.CategoryServiceCrudOperatons.Insert(category);
                this.CategoryServiceCrudOperatons.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = this.CategoryServiceCrudOperatons.SelectById(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                this.CategoryServiceCrudOperatons.Update(category);
                this.CategoryServiceCrudOperatons.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = this.CategoryServiceCrudOperatons.SelectById(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.CategoryServiceCrudOperatons.Delete(id);
            this.CategoryServiceCrudOperatons.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.MyWoodenHouseDbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
