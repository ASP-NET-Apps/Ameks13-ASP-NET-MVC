﻿using MyWoodenHouse.Client.Web.App_Start;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Materials;
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
    public class MaterialsController : Controller
    {
        private readonly IBaseGenericService<Material> materialService;
        private readonly IGenericModelMapper<Material, MaterialCompleteVm> materialModelMapper;

        public MaterialsController()
        {
            this.materialService = NinjectWebCommon.Kernel.Get<IBaseGenericService<Material>>();
            this.materialModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Material, MaterialCompleteVm>>();
        }

        // TODO not used, because can not auto bind services in Ninject
        public MaterialsController(IBaseGenericService<Material> materialService, IGenericModelMapper<Material, MaterialCompleteVm> materialModelMapper)
        {
            // Todo insert validation
            this.materialService = materialService;
            this.materialModelMapper = materialModelMapper;
        }

        // GET: Administration/Materials
        //[Authorize(Roles = "Admin")]
        [AuthorizeRoles(Consts.Role.Administrator,Consts.Role.Admin)]
        public ActionResult Index()
        {
            var materials = this.materialService.GetAll();
            var materialsComleteViewModel = materials.Select(x => this.materialModelMapper.Model2ViewModel(x));

            return View(materialsComleteViewModel);
            //return View();
        }


        // GET: Administration/Materials/Create
        [AuthorizeRoles(Consts.Role.Administrator, Consts.Role.Admin)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Materials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name, Description")] MaterialCompleteVm materialComleteViewModel)
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
                var material = this.materialModelMapper.ViewModel2Model(materialComleteViewModel);
                this.materialService.Insert(material);

                return RedirectToAction("Index");
            }

            return View(materialComleteViewModel);
            //return View();
        }

        // GET: Administration/Materials/Edit/5
        [AuthorizeRoles(Consts.Role.Administrator, Consts.Role.Admin)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var material = this.materialService.GetById(id);
            if (material == null)
            {
                return HttpNotFound();
            }

            var materialComleteViewModel = this.materialModelMapper.Model2ViewModel(material);

            return View(materialComleteViewModel);
            //return View();
        }

        // POST: Administration/Materials/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Description")] MaterialCompleteVm materialComleteViewModel)
        {
            if (ModelState.IsValid)
            {
                var material = this.materialModelMapper.ViewModel2Model(materialComleteViewModel);
                this.materialService.Update(material);

                return RedirectToAction("Index");
            }
            return View(materialComleteViewModel);
            //return View();
        }

        // GET: Administration/Materials/Delete/5
        [HttpGet]
        [AuthorizeRoles(Consts.Role.Administrator, Consts.Role.Admin)]
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

            var material = this.materialService.GetById(id);

            if (material == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Material", id);
                throw new ArgumentNullException(errorMessage);
            }
            var materialComleteViewModel = this.materialModelMapper.Model2ViewModel(material);

            return PartialView("_DeleteConfirm", materialComleteViewModel);
            //return PartialView();
        }


        // POST: Administration/Materials/Delete/5
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

            this.materialService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
