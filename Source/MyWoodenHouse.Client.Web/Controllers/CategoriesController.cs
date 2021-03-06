﻿//using MyWoodenHouse.Client.Web.App_Start;
//using MyWoodenHouse.Client.Web.Factories.Contracts;
//using MyWoodenHouse.Client.Web.ViewModels;
//using MyWoodenHouse.Constants.Models;
//using MyWoodenHouse.Data.Services.Contracts;
//using MyWoodenHouse.Pure.Models;
//using Ninject;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Web.Mvc;

//namespace MyWoodenHouse.Client.Web.Controllers
//{
//    public class CategoriesController : Controller
//    {
//        private readonly ICategoryService categoryService;
//        private readonly IMyViewModelsMapper myViewModelsMapper;

//        public CategoriesController()
//        {
//            this.myViewModelsMapper = NinjectWebCommon.Kernel.Get<IMyViewModelsMapper>();
//            this.categoryService = NinjectWebCommon.Kernel.Get<ICategoryService>();
//        }

//        // GET: Categories
//        [HttpGet]
//        public ActionResult Index()
//        {
//            IEnumerable<CategoryModel> categoriesModel = this.categoryService.GetAllCategoriesSortedById();
//            IEnumerable<CategoryMainViewModel> categoriesViewModel = categoriesModel.Select(c => myViewModelsMapper.CategoryModel2CategoryViewModel(c));
            
//            return View(categoriesViewModel);
//        }

//        // GET: Categories/Create
//        [HttpGet]
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Categories/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id, Name")] CategoryMainViewModel categoryMainViewModel)
//        {
//            // TODO optimise if possible
//            if (ModelState["Id"] != null)
//            {
//                if (ModelState["Id"].Errors.Count > 0)
//                {
//                    ModelState["Id"].Errors.Clear();
//                }
//            }                        

//            if (ModelState.IsValid)
//            {
//                CategoryModel categoryModel = this.myViewModelsMapper.CategoryViewModel2CategoryModel(categoryMainViewModel);
//                this.categoryService.InsertCategory(categoryModel);

//                return RedirectToAction("Index");
//            }

//            return View(categoryMainViewModel);
//        }

//        // GET: Categories/Edit/5
//        [HttpGet]
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }

//            CategoryModel categoryModel = this.categoryService.GetCategoryById(id);
//            if (categoryModel == null)
//            {
//                return HttpNotFound();
//            }

//            CategoryMainViewModel categoryMainViewModel = this.myViewModelsMapper.CategoryModel2CategoryViewModel(categoryModel);

//            return View(categoryMainViewModel);
//        }

//        // POST: Categories/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,Name")] CategoryMainViewModel categoryMainViewModel)
//        {
//            if (ModelState.IsValid)
//            {
//                CategoryModel categoryModel = this.myViewModelsMapper.CategoryViewModel2CategoryModel(categoryMainViewModel);
//                this.categoryService.UpdateCategory(categoryModel);

//                return RedirectToAction("Index");
//            }
//            return View(categoryMainViewModel);
//        }

//        // GET: Categories/Delete/5
//        [HttpGet]
//        public PartialViewResult ViewDeleteConfirm(int? id)
//        {
//            if (id == null)
//            {
//                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter);
//                throw new ArgumentNullException(errorMessage);
//            }
//            if (id <= 0)
//            {
//                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter);
//                throw new ArgumentException(errorMessage);
//            }

//            CategoryModel categoryModel = this.categoryService.GetCategoryById(id);

//            if (categoryModel == null)
//            {
//                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Category", id);
//                throw new ArgumentNullException(errorMessage);
//            }
//            CategoryMainViewModel categoryMainViewModel = myViewModelsMapper.CategoryModel2CategoryViewModel(categoryModel);

//            return PartialView("_DeleteConfirm", categoryMainViewModel);
//        }

//        // POST: Categories/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int? id)
//        {
//            if (id == null)
//            {
//                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter);
//                throw new ArgumentNullException(errorMessage);
//            }
//            if (id <= 0)
//            {
//                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter);
//                throw new ArgumentException(errorMessage);
//            }

//            this.categoryService.DeleteCategoryById(id);

//            return RedirectToAction("Index");
//        }
//    }
//}
