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
using System.Web.Helpers;
using MyWoodenHouse.Models;
using MyWoodenHouse.Factories.Contracts;
using MyWoodenHouse.Models.Contracts;
using MyWoodenHouse.Factories;

namespace MyWoodenHouse.Controllers
{
    public class CategoriesController : Controller
    {
        public CategoriesController()
        {
            this.MyWoodenHouseDbContext = NinjectWebCommon.Kernel.Get<IMyWoodenHouseDbContext>();
            this.CategoryServiceCrudOperatons = NinjectWebCommon.Kernel.Get<ICategoryServiceCrudOperatons>();
            this.MyMaper = new MyMapper();
        }

        protected IMyWoodenHouseDbContext MyWoodenHouseDbContext { get; private set; }

        protected ICategoryServiceCrudOperatons CategoryServiceCrudOperatons { get; private set; }

        protected MyMapper MyMaper { get; private set; }

        // GET: Categories
        [HttpGet]
        public ActionResult Index()
        {
            IList<Category> allCategories = this.CategoryServiceCrudOperatons.Select().ToList();
            IList<ICategoryVM> allCategoriesVm = new List<ICategoryVM>();

            foreach (Category category in allCategories)
            {
                var c = MyMaper.CreateCategoryVM(category);
                allCategoriesVm.Add(c);
            }
            
            return View(allCategoriesVm);
        }

        // GET: Categories/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name")] Category category)
        {
            // TODO optimise if possible
            ModelState["Id"].Errors.Clear();

            if (ModelState.IsValid)
            {
                this.CategoryServiceCrudOperatons.Insert(category);
                this.CategoryServiceCrudOperatons.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        [HttpGet]
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
        public PartialViewResult ViewDeleteConfirm(int? id)
        {
            if (id == null)
            {
                // TODO research if better whay could be used
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                // TODO extract constant
                throw new ArgumentNullException("Item to delete id can not be null.");
            }

            Category category = this.CategoryServiceCrudOperatons.SelectById(id);

            if (category == null)
            {
                //return HttpNotFound();
                // TODO extract constant
                string errorMessage = string.Format("Item to delete can not be found by id = {0}", id);
                throw new ArgumentNullException(errorMessage);
            }

            return PartialView("_DeleteConfirm", category); 
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

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
