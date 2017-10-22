using AutoMapper;
using Bytes2you.Validation;
using MyWoodenHouse.Client.Web.App_Start;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels;
using MyWoodenHouse.Client.Web.CustomAttributes;
using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Models;
using Ninject;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IBaseGenericService<Category> categoryService;

        //public CategoriesController()
        //{
        //    this.mapper = NinjectWebCommon.Kernel.Get<IMapper>();
        //    this.categoryService = NinjectWebCommon.Kernel.Get<IBaseGenericService<Category>>();
        //}

        public CategoriesController(IMapper mapper, IBaseGenericService<Category> categoryService)
        {
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();
            Guard.WhenArgument(categoryService, nameof(categoryService)).IsNull().Throw();

            this.mapper = mapper;
            this.categoryService = categoryService;
        }

        // GET: Categories
        [HttpGet]
        [AuthorizeRoles(Consts.Role.Administrator, Consts.Role.Admin)]
        public ActionResult Index()
        {
            var categories = this.categoryService.GetAll();
            var categoryCompleteVm = categories.Select(x => this.mapper.Map<Category, CategoryCompleteVm>(x));

            return View(categoryCompleteVm);
        }

        // GET: Categories/Create
        [HttpGet]
        [AuthorizeRoles(Consts.Role.Administrator, Consts.Role.Admin)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name")] CategoryCompleteVm categoryCompleteVm)
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
                var category = this.mapper.Map<CategoryCompleteVm, Category>(categoryCompleteVm);
                category.CreatedBy = User.Identity.Name;

                this.categoryService.Insert(category);

                return RedirectToAction("Index");
            }

            return View(categoryCompleteVm);
        }

        // GET: Categories/Edit/5
        [HttpGet]
        [AuthorizeRoles(Consts.Role.Administrator, Consts.Role.Admin)]
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

            var categoryCompleteVm = this.mapper.Map<Category, CategoryCompleteVm>(category);

            // TODO send to cash
            ViewData["Category"] = categoryCompleteVm;
            TempData["Category"] = categoryCompleteVm;

            return View(categoryCompleteVm);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] CategoryCompleteVm categoryCompleteVm)
        {
            if (ModelState.IsValid)
            {
                // TODO get from cash
                var categoryViewData = ViewData["Category"];
                var categoryTempData = TempData["Category"];

                var category = this.mapper.Map<CategoryCompleteVm, Category>(categoryCompleteVm);
                category.ModifiedBy = User.Identity.Name;

                this.categoryService.Update(category);

                return RedirectToAction("Index");
            }
            return View(categoryCompleteVm);
        }

        // GET: Categories/Delete/5
        [HttpGet]
        [AuthorizeRoles(Consts.Role.Administrator, Consts.Role.Admin)]
        public PartialViewResult ViewDeleteConfirm(int? id)
        {
            // TODO use Guard
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

            var categoryCompleteVm = this.mapper.Map<Category, CategoryCompleteVm>(category);

            return PartialView("_DeleteConfirm", categoryCompleteVm);
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

            this.categoryService.Delete(id, User.Identity.Name);

            return RedirectToAction("Index");
        }
    }
}
