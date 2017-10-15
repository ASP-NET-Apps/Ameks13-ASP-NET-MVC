using MyWoodenHouse.Client.Web.App_Start;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Categories;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Contracts.Models;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Ef.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IGenericModelMapper<ICategory, ICategoryCompleteViewModel> categoryModelMapper;

        public CategoriesController()
        {
            this.categoryService = NinjectWebCommon.Kernel.Get<ICategoryService>();
            this.categoryModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<ICategory, ICategoryCompleteViewModel>>();
            
        }

        //public CategoriesController(ICategoryService categoryService, IGenericModelMapper<ICategory, ICategoryCompleteViewModel> categoryModelMapper)
        //{
        //    this.categoryService = categoryService;
        //    this.categoryModelMapper = categoryModelMapper;
        //}

        // GET: Categories
        [HttpGet]
        public ActionResult Index()
        {
            //var categories = this.categoryService.GetAllCategoriesSortedById();
            ////var categoryComleteViewModel = categories.Select(x => this.categoryModelMapper.Model2ViewModel(x));
            //var categoryComleteViewModel = new CategoryCompleteViewModel();

            //return View(categoryComleteViewModel);
            return View();
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
        public ActionResult Create([Bind(Include = "Id, Name")] ICategoryCompleteViewModel categoryCompleteViewModel)
        {
            // TODO optimize if possible
            //if (ModelState["Id"] != null)
            //{
            //    if (ModelState["Id"].Errors.Count > 0)
            //    {
            //        ModelState["Id"].Errors.Clear();
            //    }
            //}                        

            //if (ModelState.IsValid)
            //{
            //    var category = this.categoryModelMapper.ViewModel2Model(categoryCompleteViewModel);
            //    this.categoryService.InsertCategory((Category)category);

            //    return RedirectToAction("Index");
            //}

            //return View(categoryCompleteViewModel);
            return View();
        }

        // GET: Categories/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //Category category = this.categoryService.GetCategoryById(id);
            //if (category == null)
            //{
            //    return HttpNotFound();
            //}

            //var categoryCompleteViewModel = this.categoryModelMapper.Model2ViewModel(category);

            //return View(categoryCompleteViewModel);
            return View();
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] CategoryCompleteViewModel categoryCompleteViewModel)
        {
            //if (ModelState.IsValid)
            //{
            //    var category = this.categoryModelMapper.ViewModel2Model(categoryCompleteViewModel);
            //    this.categoryService.UpdateCategory((Category)category);

            //    return RedirectToAction("Index");
            //}
            //return View(categoryCompleteViewModel);
            return View();
        }

        // GET: Categories/Delete/5
        [HttpGet]
        public PartialViewResult ViewDeleteConfirm(int? id)
        {
            //if (id == null)
            //{
            //    string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter);
            //    throw new ArgumentNullException(errorMessage);
            //}
            //if (id <= 0)
            //{
            //    string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter);
            //    throw new ArgumentException(errorMessage);
            //}

            //Category categoryModel = this.categoryService.GetCategoryById(id);

            //if (categoryModel == null)
            //{
            //    string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Category", id);
            //    throw new ArgumentNullException(errorMessage);
            //}
            //var categoryCompleteViewModel = categoryModelMapper.Model2ViewModel(categoryModel);

            //return PartialView("_DeleteConfirm", categoryCompleteViewModel);
            return PartialView();
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            //if (id == null)
            //{
            //    string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter);
            //    throw new ArgumentNullException(errorMessage);
            //}
            //if (id <= 0)
            //{
            //    string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter);
            //    throw new ArgumentException(errorMessage);
            //}

            //this.categoryService.DeleteCategoryById(id);

            return RedirectToAction("Index");
        }
    }
}
