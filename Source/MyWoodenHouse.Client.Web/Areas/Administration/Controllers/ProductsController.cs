using MyWoodenHouse.Client.Web.App_Start;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Products;
using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Contracts.Models;
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
    public class ProductsController : Controller
    {
        private readonly IBaseGenericService<IProduct> productService;
        private readonly IGenericModelMapper<IProduct, IProductCompleteViewModel> productModelMapper;

        //public ProductsController()
        //{
        //    // Todo insert validation
        //    this.productService = NinjectWebCommon.Kernel.Get<IBaseGenericService<Product>>();
        //    this.productModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Product, ProductCompleteViewModel>>();
        //}

        public ProductsController(IBaseGenericService<IProduct> productService, IGenericModelMapper<IProduct, IProductCompleteViewModel> productModelMapper)
        {
            this.productService = productService;
            this.productModelMapper = productModelMapper;
        }

        // GET: Administration/Products
        public ActionResult Index()
        {
            IEnumerable<IProduct> products = this.productService.GetAll();
            IEnumerable<IProductCompleteViewModel> productsComleteViewModel = products.Select(x => this.productModelMapper.Model2ViewModel(x));

            return View(productsComleteViewModel);
        }


        // GET: Administration/Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name, Description")] ProductCompleteViewModel productComleteViewModel)
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
                var product = this.productModelMapper.ViewModel2Model(productComleteViewModel);
                this.productService.Insert(product);

                return RedirectToAction("Index");
            }

            return View(productComleteViewModel);
        }

        // GET: Administration/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = this.productService.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var productComleteViewModel = this.productModelMapper.Model2ViewModel(product);

            return View(productComleteViewModel);
        }

        // POST: Administration/Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Description")] ProductCompleteViewModel productComleteViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = this.productModelMapper.ViewModel2Model(productComleteViewModel);
                this.productService.Update(product);

                return RedirectToAction("Index");
            }
            return View(productComleteViewModel);
        }

        // GET: Administration/Products/Delete/5
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

            var product = this.productService.GetById(id);

            if (product == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Product", id);
                throw new ArgumentNullException(errorMessage);
            }
            var productComleteViewModel = this.productModelMapper.Model2ViewModel(product);

            return PartialView("_DeleteConfirm", productComleteViewModel);
        }
        
        // POST: Administration/Products/Delete/5
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

            this.productService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
