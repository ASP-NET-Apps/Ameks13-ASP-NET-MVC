using MyWoodenHouse.Client.Web.App_Start;
using MyWoodenHouse.Client.Web.Factories.Contracts;
using MyWoodenHouse.Client.Web.ViewModels;
using MyWoodenHouse.Client.Web.ViewModels.Contracts;
using MyWoodenHouse.Data.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services.Contracts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MyWoodenHouse.Client.Web.Controllers
{
    public class CategoriesController : Controller
    {
        public CategoriesController()
        {
            this.MyWoodenHouseDbContext = NinjectWebCommon.Kernel.Get<IMyWoodenHouseDbContext>();
            this.CategoryServiceCrudOperatons = NinjectWebCommon.Kernel.Get<ICategoryServiceCrudOperatons>();
            this.EfDbContextSaveChanges = NinjectWebCommon.Kernel.Get<IEfDbContextSaveChanges>();
            this.MyMaper = NinjectWebCommon.Kernel.Get<IMyMapper>();
        }

        protected IMyWoodenHouseDbContext MyWoodenHouseDbContext { get; private set; }

        protected ICategoryServiceCrudOperatons CategoryServiceCrudOperatons { get; private set; }

        protected IEfDbContextSaveChanges EfDbContextSaveChanges { get; private set; }

        protected IMyMapper MyMaper { get; private set; }

        // GET: Categories
        [HttpGet]
        public ActionResult Index()
        {
            IList<Category> allCategories = this.CategoryServiceCrudOperatons.Select().ToList();
            IList<CategoryViewModel> allCategoriesViewModel = new List<CategoryViewModel>();

            foreach (Category category in allCategories)
            {
                var c = MyMaper.CreateCategoryViewModel(category);
                allCategoriesViewModel.Add(c);
            }
            
            return View(allCategoriesViewModel);
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
                this.EfDbContextSaveChanges.SaveChanges();

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
                this.EfDbContextSaveChanges.SaveChanges();

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
            this.EfDbContextSaveChanges.SaveChanges();

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
