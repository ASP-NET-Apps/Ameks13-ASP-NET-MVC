using AutoMapper;
using Bytes2you.Validation;
using MyWoodenHouse.Client.Web.App_Start;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels;
using MyWoodenHouse.Client.Web.CustomAttributes;
using MyWoodenHouse.Common;
using MyWoodenHouse.Constants;
using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Data.Services.Enums;
using MyWoodenHouse.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;



namespace MyWoodenHouse.Client.Web.Areas.Administration.Controllers
{
    

    public class PicturesController : Controller
    {
        // TODO extract to config
        private const string ImageUploadPath = "/Assets/Upload/Images/";

        private readonly IMapper mapper;
        private readonly IBaseGenericService<Picture> pictureService;
        private string dirPath;

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
        [HttpGet]
        [AuthorizeRoles(Consts.Role.Administrator, Consts.Role.Admin)]
        public ActionResult Create()
        {
            var pictureCreateEditVm = new PictureCreateEditVm(new PictureCompleteVm());

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "File", Value = "1", Selected = true });
            selectListItems.Add(new SelectListItem() { Text = "Url", Value = "2", Selected = false });

            pictureCreateEditVm.UploadSourcesList = new SelectList(selectListItems, "Value", "Text");

            return View(pictureCreateEditVm);
        }

        // POST: Administration/Pictures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id, Name, Url")] PictureCompleteVm pictureComleteVm)
        public ActionResult Create(HttpPostedFileBase httpPostedFileBase, PictureCreateEditVm pictureCreateEditVm)
        {

            if (pictureCreateEditVm.SelectedUploadSource == 1)
            {
                bool isImage = true;
                string uploadedWithfileName = string.Empty;
                var fileUploadHelper = new FileUploadHelper(httpPostedFileBase, ImageUploadConfiguration.AllowedPictureExtensions, ImageUploadConfiguration.MaxSizeInBytes, isImage);
                try
                {
                    fileUploadHelper.ValidateFile();

                    var path = Path.Combine(Server.MapPath("~" + ImageUploadPath), httpPostedFileBase.FileName);

                    string folderPath = Server.MapPath("~" + ImageUploadPath);
                    uploadedWithfileName = fileUploadHelper.UploadFileToLocalServer(folderPath);
                }
                catch
                {
                    ViewBag.errorMessage = "error";
                }

                var imageDimensions = fileUploadHelper.GetImageDimension();
                pictureCreateEditVm.PictureCompleteVm.Width = imageDimensions.Item1;
                pictureCreateEditVm.PictureCompleteVm.Height = imageDimensions.Item2;
                pictureCreateEditVm.PictureCompleteVm.GetFrom = GetPictureContentFrom.LocalServerUrl;
                pictureCreateEditVm.PictureCompleteVm.Url = uploadedWithfileName;
            }
            else
            {
                pictureCreateEditVm.PictureCompleteVm.GetFrom = GetPictureContentFrom.WebServerUrl;

            }

            pictureCreateEditVm.PictureCompleteVm.FileContent = null;

            // TODO optimize if possible
            var modelStateId = ModelState["PictureCompleteVm.Id"];
            if (modelStateId != null)
            {
                if (modelStateId.Errors.Count > 0)
                {
                    modelStateId.Errors.Clear();
                }
            }

            if (ModelState.IsValid)
            {
                var picture = this.mapper.Map<PictureCompleteVm, Picture>(pictureCreateEditVm.PictureCompleteVm);
                picture.CreatedBy = User.Identity.Name;

                this.pictureService.Insert(picture);

                return RedirectToAction("Index");
            }

            return View(pictureCreateEditVm);
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
