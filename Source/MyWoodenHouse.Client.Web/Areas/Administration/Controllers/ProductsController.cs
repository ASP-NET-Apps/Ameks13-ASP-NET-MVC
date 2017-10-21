using AutoMapper;
using Bytes2you.Validation;
using MyWoodenHouse.Client.Web.App_Start;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels;
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
    public class ProductsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IBaseGenericService<Product> productService;

        //public ProductsController()
        //{
        //    this.productService = NinjectWebCommon.Kernel.Get<IBaseGenericService<Product>>();
        //    this.productModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Product, ProductCompleteVm>>();
        //}

        // TODO not used, because can not auto bind services in Ninject
        public ProductsController(IMapper mapper, IBaseGenericService<Product> productService)
        {
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();
            Guard.WhenArgument(productService, nameof(productService)).IsNull().Throw();

            this.mapper = mapper;
            this.productService = productService;
        }

        // GET: Administration/Products
        [AuthorizeRoles(Consts.Role.Administrator, Consts.Role.Admin)]
        public ActionResult Index()
        {
            var products = this.productService.GetAll();
            var productsComleteVm = products.Select(x => this.mapper.Map<Product, ProductCompleteVm>(x));

            return View(productsComleteVm);
        }


        // GET: Administration/Products/Create
        [AuthorizeRoles(Consts.Role.Administrator, Consts.Role.Admin)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name, Description")] ProductCompleteVm productComleteVm)
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
                var product = this.mapper.Map<ProductCompleteVm, Product>(productComleteVm);
                product.CreatedBy = User.Identity.Name;

                this.productService.Insert(product);

                return RedirectToAction("Index");
            }

            return View(productComleteVm);
        }

        // GET: Administration/Products/Edit/5
        [AuthorizeRoles(Consts.Role.Administrator, Consts.Role.Admin)]
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

            var productComleteVm = this.mapper.Map<Product, ProductCompleteVm>(product);

            return View(productComleteVm);
        }

        // POST: Administration/Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Description")] ProductCompleteVm productComleteVm)
        {
            if (ModelState.IsValid)
            {
                var product = this.mapper.Map<ProductCompleteVm, Product>(productComleteVm);
                product.ModifiedBy = User.Identity.Name;

                this.productService.Update(product);

                return RedirectToAction("Index");
            }
            return View(productComleteVm);
        }

        // GET: Administration/Products/Delete/5
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

            var product = this.productService.GetById(id);

            if (product == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Product", id);
                throw new ArgumentNullException(errorMessage);
            }

            var productCompleteVm = this.mapper.Map<Product, ProductCompleteVm>(product);

            return PartialView("_DeleteConfirm", productCompleteVm);
        }
        
        // POST: Administration/Products/Delete/5
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

            this.productService.Delete(id, username);

            return RedirectToAction("Index");
        }
    }
}
