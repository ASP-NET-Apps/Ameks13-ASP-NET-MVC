using MyWoodenHouse.Client.Web.App_Start;
using MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Contracts.Models;
using MyWoodenHouse.Data.Services.Contracts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Controllers
{
    public class AdminMaterialsController : Controller
    {
        private readonly IBaseGenericService<IMaterial> materialService;
        private readonly IGenericModelMapper<IMaterial, IMaterialComleteViewModel> materialModelMapper;

        //public AdminMaterialsController(IBaseGenericService<IMaterial> materialService, IGenericModelMapper<IMaterial, IMaterialComleteViewModel> materialModelMapper)
        public AdminMaterialsController()
        {
            // Todo insert validation
            this.materialService = NinjectWebCommon.Kernel.Get<IBaseGenericService<IMaterial>>();
            this.materialModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<IMaterial, IMaterialComleteViewModel>>();
        }

        // GET: Administration/AdminMaterials
        public ActionResult Index()
        {
            IEnumerable<IMaterial> materilas = this.materialService.GetAll();
            IEnumerable<IMaterialComleteViewModel> materialsComleteViewModel = materilas.Select(x => this.materialModelMapper.Model2ViewModel(x));

            return View(materialsComleteViewModel);
        }


        // GET: Administration/AdminMaterials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/AdminMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name")] IMaterialComleteViewModel materialComleteViewModel)
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
                IMaterial material = this.materialModelMapper.ViewModel2Model(materialComleteViewModel);
                this.materialService.Insert(material);

                return RedirectToAction("Index");
            }

            return View(materialComleteViewModel);
        }

        // GET: Administration/AdminMaterials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IMaterial material = this.materialService.GetById(id);
            if (material == null)
            {
                return HttpNotFound();
            }

            IMaterialComleteViewModel materialComleteViewModel = this.materialModelMapper.Model2ViewModel(material);

            return View(materialComleteViewModel);
        }

        // POST: Administration/AdminMaterials/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name")] IMaterialComleteViewModel materialComleteViewModel)
        {
            if (ModelState.IsValid)
            {
                IMaterial material = this.materialModelMapper.ViewModel2Model(materialComleteViewModel);
                this.materialService.Update(material);

                return RedirectToAction("Index");
            }
            return View(materialComleteViewModel);
        }

        // GET: Administration/AdminMaterials/Delete/5
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

            IMaterial material = this.materialService.GetById(id);

            if (material == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Material", id);
                throw new ArgumentNullException(errorMessage);
            }
            IMaterialComleteViewModel materialComleteViewModel = this.materialModelMapper.Model2ViewModel(material);

            return PartialView("_DeleteConfirm", materialComleteViewModel);
        }


        // POST: Administration/AdminMaterials/Delete/5
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
