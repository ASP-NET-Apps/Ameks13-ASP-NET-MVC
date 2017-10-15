﻿using MyWoodenHouse.Client.Web.App_Start;
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
        private readonly IBaseGenericService<Picture> pictureService;
        private readonly IGenericModelMapper<Picture, PictureCompleteViewModel> pictureModelMapper;

        public PicturesController()
        {
            this.pictureService = NinjectWebCommon.Kernel.Get<IBaseGenericService<Picture>>();
            this.pictureModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Picture, PictureCompleteViewModel>>();
        }

        // TODO not used, because can not auto bind services in Ninject
        public PicturesController(IBaseGenericService<Picture> pictureService, IGenericModelMapper<Picture, PictureCompleteViewModel> pictureModelMapper)
        {
            // Todo insert validation
            this.pictureService = pictureService;
            this.pictureModelMapper = pictureModelMapper;
        }

        // GET: Administration/Pictures
        public ActionResult Index()
        {
            var pictures = this.pictureService.GetAll();
            var picturesComleteViewModel = pictures.Select(x => this.pictureModelMapper.Model2ViewModel(x));

            return View(picturesComleteViewModel);
        }
        
        // GET: Administration/Pictures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Pictures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name, Url")] PictureCompleteViewModel pictureComleteViewModel)
        {
            // TODO refactoring later and use the actual picture parameters
            pictureComleteViewModel.Width = 150;
            pictureComleteViewModel.Height = 100;

            // TODO refactoring later and use picture url or content
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

        // GET: Administration/Pictures/Edit/5
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

        // POST: Administration/Pictures/Edit/5
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

        // GET: Administration/Pictures/Delete/5
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


        // POST: Administration/Pictures/Delete/5
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
