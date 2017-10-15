using MyWoodenHouse.Client.Web.App_Start;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Pictures;
using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Contracts.Models;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Data.Services.Enums;
using MyWoodenHouse.Ef.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Controllers
{
    public class PicturesController : Controller
    {
        private readonly IBaseGenericService<IPicture> pictureService;
        private readonly IGenericModelMapper<IPicture, IPictureCompleteViewModel> pictureModelMapper;

        //public PicturesController()
        //{
        //    // Todo insert validation
        //    this.pictureService = NinjectWebCommon.Kernel.Get<IBaseGenericService<Picture>>();
        //    this.pictureModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Picture, PictureCompleteViewModel>>();
        //}

        public PicturesController(IBaseGenericService<IPicture> pictureService, IGenericModelMapper<IPicture, IPictureCompleteViewModel> pictureModelMapper)
        {
            this.pictureService = pictureService;
            this.pictureModelMapper = pictureModelMapper;
        }

        // GET: Administration/AdminPictures
        public ActionResult Index()
        {
            IEnumerable<IPicture> pictures = this.pictureService.GetAll();
            IEnumerable<IPictureCompleteViewModel> picturesComleteViewModel = pictures.Select(x => this.pictureModelMapper.Model2ViewModel(x));

            return View(picturesComleteViewModel);
        }


        // GET: Administration/AdminPictures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/AdminPictures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name, Url")] PictureCompleteViewModel pictureComleteViewModel)
        {
            // TODO refactor later and use the actual picture parameters
            pictureComleteViewModel.Width = 150;
            pictureComleteViewModel.Height = 100;

            // TODO refactor later and use picture url or content
            pictureComleteViewModel.FileContent = null;
            pictureComleteViewModel.GetFrom = GetPictureContentFrom.Url;

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
                var picture = this.pictureModelMapper.ViewModel2Model(pictureComleteViewModel);
                this.pictureService.Insert(picture);

                return RedirectToAction("Index");
            }

            return View(pictureComleteViewModel);
        }

        // GET: Administration/AdminPictures/Edit/5
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

            var pictureComleteViewModel = this.pictureModelMapper.Model2ViewModel(picture);

            return View(pictureComleteViewModel);
        }

        // POST: Administration/AdminPictures/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Url")] PictureCompleteViewModel pictureComleteViewModel)
        {
            if (ModelState.IsValid)
            {
                var picture = this.pictureModelMapper.ViewModel2Model(pictureComleteViewModel);
                this.pictureService.Update(picture);

                return RedirectToAction("Index");
            }
            return View(pictureComleteViewModel);
        }

        // GET: Administration/AdminPictures/Delete/5
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
            var pictureComleteViewModel = this.pictureModelMapper.Model2ViewModel(picture);

            return PartialView("_DeleteConfirm", pictureComleteViewModel);
        }


        // POST: Administration/AdminPictures/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
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

            this.pictureService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
