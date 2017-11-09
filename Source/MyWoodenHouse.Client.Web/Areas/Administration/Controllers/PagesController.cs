using AutoMapper;
using Bytes2you.Validation;
using MyWoodenHouse.Client.Web.App_Start;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
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
    public class PagesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IBaseGenericService<Page> pageService;

        //public PagesController()
        //{
        //    this.pageService = NinjectWebCommon.Kernel.Get<IBaseGenericService<Page>>();
        //    this.pageModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Page, PageCompleteVm>>();
        //}

        // TODO not used, because can not auto bind services in Ninject
        public PagesController(IMapper mapper, IBaseGenericService<Page> pageService)
        {
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();
            Guard.WhenArgument(pageService, nameof(pageService)).IsNull().Throw();

            this.mapper = mapper;
            this.pageService = pageService;
        }

        // GET: Administration/Pages
        [AuthorizeRoles(Consts.Role.Administrator, Consts.Role.Admin)]
        public ActionResult Index()
        {
            var pages = this.pageService.GetAll();
            var pagesComleteVm = pages.Select(x => this.mapper.Map<Page, PageCompleteVm>(x));

            return View(pagesComleteVm);
        }


        // GET: Administration/Pages/Create
        [AuthorizeRoles(Consts.Role.Administrator, Consts.Role.Admin)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Pages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name, Description, HtmlContent, LanguageCultureName")] PageCompleteVm pageComleteVm)
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
                var page = this.mapper.Map<PageCompleteVm, Page>(pageComleteVm);
                page.CreatedBy = User.Identity.Name;

                this.pageService.Insert(page);

                return RedirectToAction("Index");
            }

            return View(pageComleteVm);
        }

        // GET: Administration/Pages/Edit/5
        [AuthorizeRoles(Consts.Role.Administrator, Consts.Role.Admin)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var page = this.pageService.GetById(id);
            if (page == null)
            {
                return HttpNotFound();
            }

            var pageComleteVm = this.mapper.Map<Page, PageCompleteVm>(page);

            return View(pageComleteVm);
        }

        // POST: Administration/Pages/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Description, HtmlContent, LanguageCultureName")] PageCompleteVm pageComleteVm)
        {
            if (ModelState.IsValid)
            {
                var page = this.mapper.Map<PageCompleteVm, Page>(pageComleteVm);
                page.ModifiedBy = User.Identity.Name;

                this.pageService.Update(page);

                return RedirectToAction("Index");
            }
            return View(pageComleteVm);
        }

        // GET: Administration/Pages/Delete/5
        [AuthorizeRoles(Consts.Role.Administrator, Consts.Role.Admin)]
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

            var page = this.pageService.GetById(id);

            if (page == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Page", id);
                throw new ArgumentNullException(errorMessage);
            }

            var pageCompleteVm = this.mapper.Map<Page, PageCompleteVm>(page);

            return PartialView("_DeleteConfirm", pageCompleteVm);
        }
        
        // POST: Administration/Pages/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id, string username)
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

            this.pageService.Delete(id, username);

            return RedirectToAction("Index");
        }
    }
}
