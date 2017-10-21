using AutoMapper;
using Bytes2you.Validation;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels;
using MyWoodenHouse.Client.Web.CustomAttributes;
using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Controllers
{
    public class MaterialsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IBaseGenericService<Material> materialService;

        //public MaterialsController()
        //{
        //    this.materialService = NinjectWebCommon.Kernel.Get<IBaseGenericService<Material>>();
        //    this.materialModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Material, MaterialCompleteVm>>();
        //}

        // TODO not used, because can not auto bind services in Ninject
        public MaterialsController(IMapper mapper, IBaseGenericService<Material> materialService)
        {
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();
            Guard.WhenArgument(materialService, nameof(materialService)).IsNull().Throw();

            this.mapper = mapper;
            this.materialService = materialService;
        }

        // GET: Administration/Materials
        //[Authorize(Roles = "Admin")]
        [AuthorizeRoles(Consts.Role.Administrator,Consts.Role.Admin)]
        public ActionResult Index()
        {
            var materials = this.materialService.GetAll();
            var materialCompleteVm = materials.Select(x => this.mapper.Map<Material, MaterialCompleteVm>(x));

            return View(materialCompleteVm);
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
        public ActionResult Create([Bind(Include = "Id, Name, Description")] MaterialCompleteVm materialComleteVm)
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
                var material = this.mapper.Map<MaterialCompleteVm, Material>(materialComleteVm);
                material.CreatedBy = User.Identity.Name;

                this.materialService.Insert(material);

                return RedirectToAction("Index");
            }

            return View(materialComleteVm);
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

            var materialComleteVm = this.mapper.Map<Material, MaterialCompleteVm>(material);

            return View(materialComleteVm);
        }

        // POST: Administration/Materials/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Description")] MaterialCompleteVm materialComleteVm)
        {
            if (ModelState.IsValid)
            {
                var material = this.mapper.Map<MaterialCompleteVm, Material>(materialComleteVm);
                material.ModifiedBy = User.Identity.Name;

                this.materialService.Update(material);

                return RedirectToAction("Index");
            }

            return View(materialComleteVm);
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

            var materialComleteVm = this.mapper.Map<Material, MaterialCompleteVm>(material);

            return PartialView("_DeleteConfirm", materialComleteVm);
        }


        // POST: Administration/Materials/Delete/5
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

            this.materialService.Delete(id, User.Identity.Name);

            return RedirectToAction("Index");
        }
    }
}
