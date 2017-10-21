using AutoMapper;
using Bytes2you.Validation;
using MyWoodenHouse.Client.Web.App_Start;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels;
using MyWoodenHouse.Client.Web.CustomAttributes;
using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Data.Services.Enums;
using MyWoodenHouse.Models;
using Ninject;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Controllers
{
    public class PicturesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IBaseGenericService<Picture> pictureService;

        //public PicturesController()
        //{
        //    this.mapper = NinjectWebCommon.Kernel.Get<IMapper>();
        //    this.pictureService = NinjectWebCommon.Kernel.Get<IBaseGenericService<Picture>>();
        //}

        public PicturesController(IMapper mapper, IBaseGenericService<Picture> pictureService)
        {
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();
            Guard.WhenArgument(pictureService, nameof(pictureService)).IsNull().Throw();

            this.mapper = mapper;
            this.pictureService = pictureService;
        }

        // GET: Administration/Pictures
        [AuthorizeRoles(Consts.Role.Administrator, Consts.Role.Admin)]
        public ActionResult Index()
        {
            var pictures = this.pictureService.GetAll();
            var picturesCompleteVm = pictures.Select(x => this.mapper.Map<Picture, PictureCompleteVm>(x));

            return View(picturesCompleteVm);
        }

        // GET: Administration/Pictures/Create
        [AuthorizeRoles(Consts.Role.Administrator, Consts.Role.Admin)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Pictures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name, Url")] PictureCompleteVm pictureComleteVm)
        {
            // TODO refactoring later and use the actual picture parameters
            pictureComleteVm.Width = 150;
            pictureComleteVm.Height = 100;

            // TODO refactoring later and use picture url or content
            pictureComleteVm.FileContent = null;
            pictureComleteVm.GetFrom = GetPictureContentFrom.Url;

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
                var picture = this.mapper.Map<PictureCompleteVm, Picture>(pictureComleteVm);
                picture.CreatedBy = User.Identity.Name;

                this.pictureService.Insert(picture);

                return RedirectToAction("Index");
            }

            return View(pictureComleteVm);
        }

        // GET: Administration/Pictures/Edit/5
        [AuthorizeRoles(Consts.Role.Administrator, Consts.Role.Admin)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var picture = this.pictureService.GetById(id);
            if (picture == null)
            {
                return HttpNotFound();
            }

            var pictureCompleteVm = this.mapper.Map<Picture, PictureCompleteVm>(picture);

            return View(pictureCompleteVm);
        }

        // POST: Administration/Pictures/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Url")] PictureCompleteVm pictureComleteVm)
        {
            if (ModelState.IsValid)
            {
                var picture = this.mapper.Map<PictureCompleteVm, Picture>(pictureComleteVm);
                picture.ModifiedBy = User.Identity.Name;

                this.pictureService.Update(picture);

                return RedirectToAction("Index");
            }
            return View(pictureComleteVm);
        }

        // GET: Administration/Pictures/Delete/5
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

            var picture = this.pictureService.GetById(id);

            if (picture == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Picture", id);
                throw new ArgumentNullException(errorMessage);
            }

            var pictureCompleteVm = this.mapper.Map<Picture, PictureCompleteVm>(picture);

            return PartialView("_DeleteConfirm", pictureCompleteVm);
        }


        // POST: Administration/Pictures/Delete/5
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

            this.pictureService.Delete(id, username);

            return RedirectToAction("Index");
        }
    }
}
