using MyWoodenHouse.Client.Web.App_Start;
using MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Buildings;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Materials;
using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Ef.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Controllers
{
    public class BuildingsController : Controller
    {
        private const string Categories = "Categories";
        private const string Products = "Products";
        private const string Materials = "Materials";

        private readonly ICategoryService categoryService;
        private readonly IBaseGenericService<Building> buildingService;
        private readonly IBaseGenericService<Product> productService;
        private readonly IBaseGenericService<Material> materialService;
        private readonly IBaseGenericService<Picture> pictureService;
        private readonly IGenericModelMapper<Material, MaterialCompleteViewModel> materialModelMapper;
        private readonly IGenericModelMapper<Building, BuildingCompleteViewModel> buildingModelMapper;

        //public AdminBuildingsController(IBaseGenericService<IBuilding> buildingService, IGenericModelMapper<IBuilding, IBuildingComleteViewModel> buildingModelMapper)
        public BuildingsController()
        {
            // Todo insert validation
            this.categoryService = NinjectWebCommon.Kernel.Get<ICategoryService>();
            this.buildingService = NinjectWebCommon.Kernel.Get<IBaseGenericService<Building>>();
            this.productService = NinjectWebCommon.Kernel.Get<IBaseGenericService<Product>>();
            this.materialService = NinjectWebCommon.Kernel.Get<IBaseGenericService<Material>>();
            this.pictureService = NinjectWebCommon.Kernel.Get<IBaseGenericService<Picture>>();

            this.materialModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Material, MaterialCompleteViewModel>>();
            this.buildingModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Building, BuildingCompleteViewModel>>();
        }

        // GET: Administration/AdminBuildings
        public ActionResult Index()
        {
            IEnumerable<Building> buildings = this.buildingService.GetAll();
            IEnumerable<BuildingCompleteViewModel> buildingsComleteViewModel = buildings.Select(x => this.buildingModelMapper.Model2ViewModel(x)).ToList();

            return View(buildingsComleteViewModel);
        }


        // GET: Administration/AdminBuildings/Create
        public ActionResult Create()
        {
            // Todo extract to factory
            var buildingCreateEditViewModel = new BuildingCreateEditViewModel(new BuildingCompleteViewModel());

            var categories = this.categoryService.GetAllCategoriesSortedByName();
            SelectList categoriesSelectList = new SelectList(categories, "Id", "Name");
            buildingCreateEditViewModel.CategoryList = categoriesSelectList;
            TempData[Categories] = categories.ToList();
            
            var products = this.productService.GetAll().OrderBy(p => p.Name);
            SelectList productSelectList = new SelectList(products, "Id", "Name");
            buildingCreateEditViewModel.ProductList = productSelectList;
            TempData[Products] = products.ToList();

            var materials = this.materialService.GetAll().OrderBy(m => m.Name);
            SelectList materialSelectList = new SelectList(materials, "Id", "Name");
            buildingCreateEditViewModel.MaterialList = materialSelectList;
            TempData[Materials] = materials.ToList();
            
            return View(buildingCreateEditViewModel);
        }

        // POST: Administration/AdminBuildings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "BuildingCompleteViewModel.Id, BuildingCompleteViewModel.Name, BuildingCompleteViewModel.Description, BuildingCompleteViewModel.UsableArea, BuildingCompleteViewModel.BuiltUpArea, BuildingCompleteViewModel.RoomsCount, BuildingCompleteViewModel.FloorsCount, BuildingCompleteViewModel.BathroomsCount, BuildingCompleteViewModel.CategoryId, BuildingCompleteViewModel.Category, BuildingCompleteViewModel.ProductId, BuildingCompleteViewModel.Product, BuildingCompleteViewModel.Materials, BuildingCompleteViewModel.Pictures")] BuildingCreateEditViewModel buildingCreateEditViewModel)
        public ActionResult Create(BuildingCreateEditViewModel buildingCreateEditViewModel)
        {
            BuildingCompleteViewModel buildingCompleteViewModel = new BuildingCompleteViewModel();
            buildingCompleteViewModel = buildingCreateEditViewModel.BuildingCompleteViewModel;

            //var allCategories = (List<Category>)TempData[Categories];
            //buildingCompleteViewModel.Category = allCategories.SingleOrDefault(c => c.Id == buildingCompleteViewModel.CategoryId);

            //var allProducts = (List<Product>)TempData[Products];
            //buildingCompleteViewModel.Product = allProducts.SingleOrDefault(p => p.Id == buildingCompleteViewModel.ProductId);

            //var allMaterials = (List<Material>)TempData[Materials];
            //buildingCompleteViewModel.Materials = allMaterials.Where(m => buildingCreateEditViewModel.SelectedMaterialIdList.Contains(m.Id)).ToList();

            
            // TODO optimize if possible
            var modelStateId = ModelState["BuildingCompleteViewModel.Id"];
            if (modelStateId != null)
            {
                if (modelStateId.Errors.Count > 0)
                {
                    modelStateId.Errors.Clear();
                }
            }

            if (ModelState.IsValid)
            {

                var building = this.buildingModelMapper.ViewModel2Model(buildingCompleteViewModel);

                // TODO think out how to make it better. 
                // Categories and Products should be present before inserting new building
                // Next lines could be transfered in the service layer
                var materials = new HashSet<Material>();
                foreach (var id in buildingCreateEditViewModel.SelectedMaterialIdList)
                {
                    var item = this.materialService.GetById(id);
                    materials.Add(item);
                }

                building.Materials = materials;
                // Transfer to the TempData or some model, or get from db?!
                building.Category = null;
                building.Product = null;

                this.buildingService.Insert(building);

                return RedirectToAction("Index");
            }

            return View(buildingCreateEditViewModel);
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
