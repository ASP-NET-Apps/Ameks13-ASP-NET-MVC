using MyWoodenHouse.Client.Web.App_Start;
using MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Buildings;
using MyWoodenHouse.Constants.Models;
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
    public class BuildingsController : Controller
    {
        private readonly IBaseGenericService<Building> buildingService;
        private readonly IBaseGenericService<Product> productService;
        private readonly ICategoryService categoryService; 
        private readonly IGenericModelMapper<Building, BuildingCompleteViewModel> buildingModelMapper;

        //public AdminBuildingsController(IBaseGenericService<IBuilding> buildingService, IGenericModelMapper<IBuilding, IBuildingComleteViewModel> buildingModelMapper)
        public BuildingsController()
        {
            // Todo insert validation
            this.buildingService = NinjectWebCommon.Kernel.Get<IBaseGenericService<Building>>();
            this.productService = NinjectWebCommon.Kernel.Get<IBaseGenericService<Product>>();
            this.categoryService = NinjectWebCommon.Kernel.Get<ICategoryService>();
            this.buildingModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Building, BuildingCompleteViewModel>>();
        }

        // GET: Administration/AdminBuildings
        public ActionResult Index()
        {
            IEnumerable<Building> buildings = this.buildingService.GetAll();
            IEnumerable<BuildingCompleteViewModel> buildingsComleteViewModel = buildings.Select(x => this.buildingModelMapper.Model2ViewModel(x));

            return View(buildingsComleteViewModel);
        }


        // GET: Administration/AdminBuildings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/AdminBuildings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name, Description, UsableArea, BuiltUpArea, RoomsCount, FloorsCount, BathroomsCount, CategoryId, Category, ProductId, Product, Materials, Pictures")] BuildingCompleteViewModel buildingComleteViewModel)
        {
            buildingComleteViewModel.ProductId = 1;
            var prodToAdd = this.productService.GetById(buildingComleteViewModel.ProductId);
            buildingComleteViewModel.Product = prodToAdd;

            buildingComleteViewModel.CategoryId = 1;
            var categoryToAdd = this.categoryService.GetCategoryById(buildingComleteViewModel.CategoryId);
            buildingComleteViewModel.Category = categoryToAdd;

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
                var building = this.buildingModelMapper.ViewModel2Model(buildingComleteViewModel);
                this.buildingService.Insert(building);

                return RedirectToAction("Index");
            }

            return View(buildingComleteViewModel);
        }

        // GET: Administration/AdminBuildings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var building = this.buildingService.GetById(id);
            if (building == null)
            {
                return HttpNotFound();
            }

            var buildingComleteViewModel = this.buildingModelMapper.Model2ViewModel(building);

            return View(buildingComleteViewModel);
        }

        // POST: Administration/AdminBuildings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Description, UsableArea, BuiltUpArea, RoomsCount, FloorsCount, BathroomsCount, CategoryId, Category, ProductId, Product, Materials, Pictures")] BuildingCompleteViewModel buildingComleteViewModel)
        {
            if (ModelState.IsValid)
            {
                var building = this.buildingModelMapper.ViewModel2Model(buildingComleteViewModel);
                this.buildingService.Update(building);

                return RedirectToAction("Index");
            }
            return View(buildingComleteViewModel);
        }

        // GET: Administration/AdminBuildings/Delete/5
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

            var building = this.buildingService.GetById(id);

            if (building == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Building", id);
                throw new ArgumentNullException(errorMessage);
            }
            var buildingComleteViewModel = this.buildingModelMapper.Model2ViewModel(building);

            return PartialView("_DeleteConfirm", buildingComleteViewModel);
        }


        // POST: Administration/AdminBuildings/Delete/5
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

            this.buildingService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
