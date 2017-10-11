using MyWoodenHouse.Client.Web.App_Start;
using MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Categories;
using MyWoodenHouse.Constants.Models;
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
    public class AdminCategoriesController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IMyAdminViewModelsMapper myAdminViewModelsMapper;

        public AdminCategoriesController()
        {
            this.myAdminViewModelsMapper = NinjectWebCommon.Kernel.Get<IMyAdminViewModelsMapper>();
            this.categoryService = NinjectWebCommon.Kernel.Get<ICategoryService>();
        }

        // GET: Categories
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Category> categories = this.categoryService.GetAllCategoriesSortedById();
            IEnumerable<AdminCategoryMainViewModel> categoriesViewModel = categories.Select(c => myAdminViewModelsMapper.Category2AdminCategoryViewModel(c));
            
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
        public ActionResult Create([Bind(Include = "Id, Name")] AdminCategoryMainViewModel adminCategoryMainViewModel)
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
                Category categoryModel = this.myAdminViewModelsMapper.AdminCategoryViewModel2Category(adminCategoryMainViewModel);
                this.categoryService.InsertCategory(categoryModel);

                return RedirectToAction("Index");
            }

            return View(adminCategoryMainViewModel);
        }

        // GET: Categories/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category categoryModel = this.categoryService.GetCategoryById(id);
            if (categoryModel == null)
            {
                return HttpNotFound();
            }

            AdminCategoryMainViewModel adminCategoryMainViewModel = this.myAdminViewModelsMapper.Category2AdminCategoryViewModel(categoryModel);

            return View(adminCategoryMainViewModel);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] AdminCategoryMainViewModel adminCategoryMainViewModel)
        {
            if (ModelState.IsValid)
            {
                Category categoryModel = this.myAdminViewModelsMapper.AdminCategoryViewModel2Category(adminCategoryMainViewModel);
                this.categoryService.UpdateCategory(categoryModel);

                return RedirectToAction("Index");
            }
            return View(adminCategoryMainViewModel);
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

            Category categoryModel = this.categoryService.GetCategoryById(id);

            if (categoryModel == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Category", id);
                throw new ArgumentNullException(errorMessage);
            }
            AdminCategoryMainViewModel adminCategoryMainViewModel = myAdminViewModelsMapper.Category2AdminCategoryViewModel(categoryModel);

            return PartialView("_DeleteConfirm", adminCategoryMainViewModel);
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

            this.categoryService.DeleteCategoryById(id);

            return RedirectToAction("Index");
        }
    }
}
