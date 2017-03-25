using MyWoodenHouse.Client.Web.App_Start;
using MyWoodenHouse.Client.Web.Factories.Contracts;
using MyWoodenHouse.Client.Web.ViewModels;
using MyWoodenHouse.Client.Web.ViewModels.Contracts;

using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Ef.Models;
using MyWoodenHouse.Ef.Models.Contracts;
using MyWoodenHouse.Pure.Models;
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
        private readonly ICategoryService categoryService;

        public CategoriesController()
        {
            this.MyWoodenHouseDbContext = NinjectWebCommon.Kernel.Get<IMyWoodenHouseDbContext>();
            this.CategoryServiceCrudOperatons = NinjectWebCommon.Kernel.Get<ICategoryServiceCrudOperatons>();
            this.EfDbContextSaveChanges = NinjectWebCommon.Kernel.Get<IEfDbContextSaveChanges>();
            this.MyViewModelsMapper = NinjectWebCommon.Kernel.Get<IMyViewModelsMapper>();
            this.categoryService = NinjectWebCommon.Kernel.Get<ICategoryService>();
        }

        protected IMyWoodenHouseDbContext MyWoodenHouseDbContext { get; private set; }

        protected ICategoryServiceCrudOperatons CategoryServiceCrudOperatons { get; private set; }

        protected IEfDbContextSaveChanges EfDbContextSaveChanges { get; private set; }

        protected IMyViewModelsMapper MyViewModelsMapper { get; private set; }

        // GET: Categories
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<CategoryModel> categoriesModel = this.categoryService.GetAllCategoriesSortedById();
            IEnumerable<CategoryMainViewModel> categoriesViewModel = categoriesModel.Select(c => this.MyViewModelsMapper.CategoryModel2CategoryViewModel(c));
            
            return View(categoriesViewModel);
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
        public ActionResult Create([Bind(Include = "Id, Name")] CategoryMainViewModel categoryMainViewModel)
        {
            // TODO optimise if possible
            if (ModelState["Id"] != null)
            {
                if (ModelState["Id"].Errors.Count > 0)
                {
                    ModelState["Id"].Errors.Clear();
                }
            }                        

            if (ModelState.IsValid)
            {
                CategoryModel categoryModel = this.MyViewModelsMapper.CategoryViewModel2CategoryModel(categoryMainViewModel);
                this.categoryService.InsertCategory(categoryModel);

                return RedirectToAction("Index");
            }

            return View(categoryMainViewModel);
        }

        // GET: Categories/Edit/5
        [HttpGet]
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    Category category = this.CategoryServiceCrudOperatons.SelectById(id);

        //    if (category == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    CategoryViewModel categoryViewModel = MyViewModelsMapper.CreateCategoryViewModel(category);

        //    return View(categoryViewModel);
        //}

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
        //public PartialViewResult ViewDeleteConfirm(int? id)
        //{
        //    if (id == null)
        //    {
        //        // TODO research if better whay could be used
        //        // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        // TODO extract constant
        //        throw new ArgumentNullException("The id of the item to be deleted can not be null.");
        //    }

        //    Category category = this.CategoryServiceCrudOperatons.SelectById(id);

        //    if (category == null)
        //    {
        //        //return HttpNotFound();
        //        // TODO extract constant
        //        string errorMessage = string.Format("Item to be deleted can not be found by the provided id = {0}", id);
        //        throw new ArgumentNullException(errorMessage);
        //    }
        //    CategoryViewModel categoryViewModel = MyMaper.CreateCategoryViewModel(category);

        //    return PartialView("_DeleteConfirm", categoryViewModel); 
        //}

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
