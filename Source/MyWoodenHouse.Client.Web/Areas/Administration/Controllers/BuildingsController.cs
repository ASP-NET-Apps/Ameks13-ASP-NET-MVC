using MyWoodenHouse.Client.Web.App_Start;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Buildings;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using MyWoodenHouse.Client.Web.CustomAttributes;
using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Models;
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
        // This private constants are used private only to set name when transferring objects via TempData
        private const string Categories = "Categories";
        private const string Products = "Products";
        private const string Materials = "Materials";
        private const string Pictures = "Pictures";
        
        private readonly IBaseGenericService<Building> buildingService;
        private readonly IBaseGenericService<Category> categoryService;
        private readonly IBaseGenericService<Product> productService;
        private readonly IBaseGenericService<Material> materialService;
        private readonly IBaseGenericService<Picture> pictureService;
        private readonly IGenericModelMapper<Building, BuildingCompleteVm> buildingModelMapper;

        public BuildingsController()
        {
            this.categoryService = NinjectWebCommon.Kernel.Get<IBaseGenericService<Category>>();
            this.buildingService = NinjectWebCommon.Kernel.Get<IBaseGenericService<Building>>();
            this.productService = NinjectWebCommon.Kernel.Get<IBaseGenericService<Product>>();
            this.materialService = NinjectWebCommon.Kernel.Get<IBaseGenericService<Material>>();
            this.pictureService = NinjectWebCommon.Kernel.Get<IBaseGenericService<Picture>>();

            // TODO binding not working
            this.buildingModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Building, BuildingCompleteVm>>();
            //this.buildingModelMapper = new BuildingModelMapper();
        }

        // TODO not used, because can not auto bind services in Ninject
        public BuildingsController(IBaseGenericService<Building> buildingService,
            IBaseGenericService<Category> categoryService, 
            IBaseGenericService<Product> productService, 
            IBaseGenericService<Material> materialService, 
            IBaseGenericService<Picture> pictureService,
            IGenericModelMapper<Building, BuildingCompleteVm> buildingModelMapper)
        {
            // Todo insert validation
            this.buildingService = buildingService;
            this.categoryService = categoryService;
            this.productService = productService;
            this.materialService = materialService;
            this.pictureService = pictureService;

            this.buildingModelMapper = buildingModelMapper;
        }

        // GET: Administration/AdminBuildings
        [AuthorizeRoles(Consts.Role.Administrator, Consts.Role.Admin)]
        public ActionResult Index()
        {
            // TODO used for testing and debug
            //var buildingsComleteViewModel = new List<BuildingCompleteVm>();
            //var buildings = this.buildingService.GetAll();
            //foreach(var building in buildings)
            //{
            //    var bcvm = this.buildingModelMapper.Model2ViewModel(building);
            //    buildingsComleteViewModel.Add(bcvm);
            //}

            var buildings = this.buildingService.GetAll();
            var buildingsComleteViewModel = buildings.Select(x => this.buildingModelMapper.Model2ViewModel(x));

            return View(buildingsComleteViewModel);
        }

        // GET: Administration/AdminBuildings/Create
        [AuthorizeRoles(Consts.Role.Administrator, Consts.Role.Admin)]
        public ActionResult Create()
        {
            // Todo extract to factory
            var buildingCreateEditVm = new BuildingCreateEditVm(new BuildingCompleteVm());

            // TODO Use TempData transferring later
            //var categories = this.categoryService.GetAllCategoriesSortedByName();
            //SelectList categoriesSelectList = new SelectList(categories, "Id", "Name");
            //buildingCreateEditVm.CategoryList = categoriesSelectList;
            //TempData[Categories] = categories.ToList();

            // TODO Use TempData transferring later
            //var products = this.productService.GetAll().OrderBy(p => p.Name);
            //SelectList productSelectList = new SelectList(products, "Id", "Name");
            //buildingCreateEditVm.ProductList = productSelectList;
            //TempData[Products] = products.ToList();

            // TODO Use TempData transferring later
            //var materials = this.materialService.GetAll().OrderBy(m => m.Name);
            //SelectList materialSelectList = new SelectList(materials, "Id", "Name");
            //buildingCreateEditVm.MaterialList = materialSelectList;
            //TempData[Materials] = materials.ToList();

            // TODO Use TempData transferring later
            //var pictures = this.pictureService.GetAll().OrderBy(m => m.Id);
            //SelectList pictureSelectList = new SelectList(pictures, "Id", "Url");
            //buildingCreateEditVm.PictureList = pictureSelectList;
            //TempData[Materials] = pictures.ToList();

            buildingCreateEditVm.CategoryList = this.CategorySelectListPreparer();
            buildingCreateEditVm.ProductList = this.ProductSelectListPreparer();
            buildingCreateEditVm.MaterialList = this.MaterialSelectListPreparer();
            buildingCreateEditVm.PictureList = this.PictureSelectListPreparer();

            return View(buildingCreateEditVm);
        }

        // POST: Administration/AdminBuildings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "BuildingCompleteVm.Id, BuildingCompleteVm.Name, BuildingCompleteVm.Description, BuildingCompleteVm.UsableArea, BuildingCompleteVm.BuiltUpArea, BuildingCompleteVm.RoomsCount, BuildingCompleteVm.FloorsCount, BuildingCompleteVm.BathroomsCount, BuildingCompleteVm.CategoryId, BuildingCompleteVm.Category, BuildingCompleteVm.ProductId, BuildingCompleteVm.Product, BuildingCompleteVm.Materials, BuildingCompleteVm.Pictures")] BuildingCreateEditVm buildingCreateEditVm)
        public ActionResult Create(BuildingCreateEditVm buildingCreateEditVm)
        {
            IBuildingCompleteVm buildingCompleteVm = new BuildingCompleteVm();
            buildingCompleteVm = buildingCreateEditVm.BuildingCompleteVm;

            //var allCategories = (List<Category>)TempData[Categories];
            //buildingCompleteVm.Category = allCategories.SingleOrDefault(c => c.Id == buildingCompleteVm.CategoryId);

            //var allProducts = (List<Product>)TempData[Products];
            //buildingCompleteVm.Product = allProducts.SingleOrDefault(p => p.Id == buildingCompleteVm.ProductId);

            //var allMaterials = (List<Material>)TempData[Materials];
            //buildingCompleteVm.Materials = allMaterials.Where(m => buildingCreateEditVm.SelectedMaterialIdList.Contains(m.Id)).ToList();

            
            // TODO optimize if possible
            var modelStateId = ModelState["BuildingCompleteVm.Id"];
            if (modelStateId != null)
            {
                if (modelStateId.Errors.Count > 0)
                {
                    modelStateId.Errors.Clear();
                }
            }

            if (ModelState.IsValid)
            {

                var building = this.buildingModelMapper.ViewModel2Model((BuildingCompleteVm)buildingCompleteVm);

                // TODO think out how to make it better. Probably using TempData transferring objects
                // Categories and Products should be present before inserting new building
                // Next lines could be transfered in the service layer
                //var materials = new HashSet<Material>();
                //foreach (var id in buildingCreateEditVm.SelectedMaterialIdList)
                //{
                //    var item = this.materialService.GetById(id);
                //    materials.Add(item);
                //}

                //// TODO think out how to make it better. 
                
                //// Next lines could be transfered in the service layer
                //var pictures = new HashSet<Picture>();
                //foreach (var id in buildingCreateEditVm.SelectedPictureIdList)
                //{
                //    var item = this.pictureService.GetById(id);
                //    pictures.Add(item);
                //}

                // TODO Refactoring with better practice 
                // Categories and Products should be present before inserting new building?!
                // Transfer to the TempData or some model, or get from db?!
                building.Category = this.FromViewResolver<Category>();
                building.Product = this.FromViewResolver<Product>();
                building.Materials = this.SelectedMaterialListResolver(buildingCreateEditVm.SelectedMaterialIdList);
                building.Pictures = this.SelectedPictureListResolver(buildingCreateEditVm.SelectedPictureIdList);

                this.buildingService.Insert(building);

                return RedirectToAction("Index");
            }

            return View(buildingCreateEditVm);
        }

        // GET: Administration/AdminBuildings/Edit/5
        [AuthorizeRoles(Consts.Role.Administrator, Consts.Role.Admin)]
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

            var buildingCompleteVm = this.buildingModelMapper.Model2ViewModel((Building)building);
            var buildingCreateEditVm = new BuildingCreateEditVm(buildingCompleteVm);

            buildingCreateEditVm.CategoryList = this.CategorySelectListPreparer();
            buildingCreateEditVm.ProductList = this.ProductSelectListPreparer();
            buildingCreateEditVm.MaterialList = this.MaterialSelectListPreparer();
            buildingCreateEditVm.PictureList = this.PictureSelectListPreparer();

            return View(buildingCreateEditVm);
        }

        // POST: Administration/AdminBuildings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id, Name, Description, UsableArea, BuiltUpArea, RoomsCount, FloorsCount, BathroomsCount, CategoryId, Category, ProductId, Product, Materials, Pictures")] BuildingCompleteVm buildingComleteViewModel)
        public ActionResult Edit(BuildingCreateEditVm buildingCreateEditVm)
        {
            var buildingCompleteVm = new BuildingCompleteVm();
            buildingCompleteVm = buildingCreateEditVm.BuildingCompleteVm;

            if (ModelState.IsValid)
            {
                var building = this.buildingModelMapper.ViewModel2Model(buildingCompleteVm);
                this.buildingService.Update(building);

                return RedirectToAction("Index");
            }

            return View(buildingCreateEditVm);
        }

        // GET: Administration/AdminBuildings/Delete/5
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

            this.buildingService.Delete(id, username);

            return RedirectToAction("Index");
        }

        // TODO refactoring but ?! no better idea, because those are three different actions
        private SelectList CategorySelectListPreparer()
        {
            // TODO Method not visible fix
            var categories = this.categoryService.GetAll().OrderBy(c => c.Name);
            if (categories == null)
            {
                // TODO Throw or return
                //return HttpNotFound();
            }
            SelectList selectListToReturn = new SelectList(categories, "Id", "Name");
            TempData[Categories] = categories.ToList();

            return selectListToReturn;
        }

        // TODO refactoring but ?! no better idea, because those are three different actions
        private SelectList ProductSelectListPreparer()
        {
            var products = this.productService.GetAll().OrderBy(p => p.Name);
            if (products == null)
            {
                // TODO Throw or return
                //return HttpNotFound();
            }
            SelectList selectListToReturn = new SelectList(products, "Id", "Name");
            TempData[Products] = products.ToList();

            return selectListToReturn;
        }

        // TODO refactoring but ?! no better idea, because those are three different actions
        private SelectList MaterialSelectListPreparer()
        {
            var materials = this.materialService.GetAll().OrderBy(m => m.Name);
            if (materials == null)
            {
                // TODO Throw or return
                //return HttpNotFound();
            }
            SelectList selectListToReturn = new SelectList(materials, "Id", "Name");
            TempData[Materials] = materials.ToList();

            return selectListToReturn;
        }

        // TODO refactoring but ?! no better idea, because those are three different actions
        private SelectList PictureSelectListPreparer()
        {
            var pictures = this.pictureService.GetAll().OrderBy(m => m.Id);
            if (pictures == null)
            {
                // TODO Throw or return
                //return HttpNotFound();
            }
            SelectList selectListToReturn = new SelectList(pictures, "Id", "Url");
            TempData[Materials] = pictures.ToList();

            return selectListToReturn;
        }
        
        // TODO think out how to make it better. 
        // Categories and Products should be present before inserting new building
        private T FromViewResolver<T>() where T : class
        {
            T modelToReturn = null;

            return modelToReturn;
        }

        // TODO think out how to make it better. 
        private ICollection<Material> SelectedMaterialListResolver(IEnumerable<int> selectedMaterialIdList)
        {
            var modelListToReturn = new HashSet<Material>(); ;

            if (selectedMaterialIdList != null)
            {
                foreach (var id in selectedMaterialIdList)
                {
                    var item = this.materialService.GetById(id);
                    if (item == null)
                    {
                        // TODO Throw or return
                        //return HttpNotFound();
                    }

                    modelListToReturn.Add((Material)item);
                }
            }

            return modelListToReturn;
        }

        // TODO think out how to make it better. 
        private ICollection<Picture> SelectedPictureListResolver(IEnumerable<int> selectedPictureIdList)
        {
            var modelListToReturn = new HashSet<Picture>(); ;

            if(selectedPictureIdList != null)
            {
                foreach (var id in selectedPictureIdList)
                {
                    var item = this.pictureService.GetById(id);
                    if (item == null)
                    {
                        // TODO Throw or return
                        //return HttpNotFound();
                    }

                    modelListToReturn.Add((Picture)item);
                }
            }
            
            return modelListToReturn;
        }

    }
}
