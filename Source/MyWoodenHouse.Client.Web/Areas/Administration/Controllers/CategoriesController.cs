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
        private readonly IBaseGenericService<Category> categoryService;
        private readonly IGenericModelMapper<Category, CategoryCompleteViewModel> categoryModelMapper;

        public CategoriesController()
        {
            this.categoryService = NinjectWebCommon.Kernel.Get<IBaseGenericService<Category>>();
            this.categoryModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Category, CategoryCompleteViewModel>>();
        }

        // TODO not used, because can not auto bind services in Ninject
        public CategoriesController(IBaseGenericService<Category> categoryService, IGenericModelMapper<Category, CategoryCompleteViewModel> categoryModelMapper)
        {
            this.categoryService = categoryService;
            this.categoryModelMapper = categoryModelMapper;
        }

        // GET: Categories
        [HttpGet]
        public ActionResult Index()
        {
            var categories = this.categoryService.GetAll();
            var categoryCompleteViewModel = categories.Select(x => this.categoryModelMapper.Model2ViewModel(x));

            return View(categoryCompleteViewModel);
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
        public ActionResult Create([Bind(Include = "Id, Name")] CategoryCompleteViewModel categoryCompleteViewModel)
        {
            // TODO optimize if possible
            if (ModelState["Id"] != null)
            {
                if (ModelState["Id"].Errors.Count > 0)
                {
                    ModelState["Id"].Errors.Clear();
                }
            }

            if (ModelState.IsValid)
            {
                var category = this.categoryModelMapper.ViewModel2Model(categoryCompleteViewModel);
                this.categoryService.Insert((Category)category);

                return RedirectToAction("Index");
            }

            return View(categoryCompleteViewModel);
        }

        // GET: Categories/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var category = this.categoryService.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            var categoryCompleteViewModel = this.categoryModelMapper.Model2ViewModel(category);

            return View(categoryCompleteViewModel);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] CategoryCompleteViewModel categoryCompleteViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = this.categoryModelMapper.ViewModel2Model(categoryCompleteViewModel);
                this.categoryService.Update((Category)category);

                return RedirectToAction("Index");
            }
            return View(categoryCompleteViewModel);
        }

        // GET: Categories/Delete/5
        [HttpGet]
        public PartialViewResult ViewDeleteConfirm(int? id)
        {
            if (id == null)
            {
                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter);
                throw new ArgumentNullException(errorMessage);
            }
            if (id <= 0)
            {
                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter);
                throw new ArgumentException(errorMessage);
            }

            var category = this.categoryService.GetById(id);

            if (category == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Category", id);
                throw new ArgumentNullException(errorMessage);
            }
            var categoryCompleteViewModel = categoryModelMapper.Model2ViewModel(category);

            return PartialView("_DeleteConfirm", categoryCompleteViewModel);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter);
                throw new ArgumentNullException(errorMessage);
            }
            if (id <= 0)
            {
                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter);
                throw new ArgumentException(errorMessage);
            }

            this.categoryService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
