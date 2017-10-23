using AutoMapper;
using Bytes2you.Validation;
using MyWoodenHouse.Client.Web.ViewModels.Gallery;
using MyWoodenHouse.Constants;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Data.Services.Enums;
using MyWoodenHouse.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MyWoodenHouse.Client.Web.Controllers
{
    public class GalleryController : Controller
    {
        private const string PreviewId = "PreviewId";

        private readonly IMapper mapper;
        private readonly IBaseGenericService<Picture> pictureService;

        public GalleryController(IMapper mapper, IBaseGenericService<Picture> pictureService)
        {
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();
            Guard.WhenArgument(pictureService, nameof(pictureService)).IsNull().Throw();

            this.mapper = mapper;
            this.pictureService = pictureService;
        }

        // GET: /Pictures
        [HttpGet]
        public ActionResult Index()
        {
            var pictures = this.pictureService.GetAll();
            var picturesGalleryVm = pictures.Select(x => this.mapper.Map<Picture, PictureGalleryVm>(x)).ToList();

            // TODO extract to upper level and put to cash
            var appBaseUrl = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));

            var len = picturesGalleryVm.Count();
            for (int i = 0; i < len; i++)
            {
                var pictureGalleryVm = picturesGalleryVm[i];
                if (pictureGalleryVm.GetFrom == GetPictureContentFrom.LocalServerUrl)
                {
                    // TODO cash this path
                    var localServerPath = string.Empty;
                    if (String.IsNullOrEmpty(pictureGalleryVm.Url))
                    {
                        localServerPath = appBaseUrl + GlobalConsts.Image.Paths.LocalResource;
                        picturesGalleryVm[i].Url = localServerPath + GlobalConsts.Image.FileNames.NoImage;
                    }
                    else
                    {
                        localServerPath = appBaseUrl + GlobalConsts.Image.UploadConfiguration.ImageUploadPath;
                        picturesGalleryVm[i].Url = localServerPath + pictureGalleryVm.Url;
                    }
                }
            }

            TempData[PreviewId] = picturesGalleryVm[0].Id;

            return this.View(picturesGalleryVm[0]);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var picture = this.pictureService.GetById(id);
            if (picture == null)
            {
                //TODO validate
            }

            var pictureGalleryVmMapped = this.mapper.Map<Picture, PictureGalleryVm>(picture);

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("_PictureDetailPartial", pictureGalleryVmMapped);

            }

            return this.View(pictureGalleryVmMapped);
        }
        
        public PartialViewResult GetNextPicture()
        {
            var id = Convert.ToInt32(TempData[PreviewId]);
            var nextId = id + 1;

            var picture = this.pictureService.GetById(nextId);
            if (picture == null)
            {
                //TODO validate
            }

            var pictureGalleryVmMapped = this.mapper.Map<Picture, PictureGalleryVm>(picture);
            TempData[PreviewId] = pictureGalleryVmMapped.Id;

            // TODO extract to upper level and put to cash
            var appBaseUrl = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
            pictureGalleryVmMapped = this.UpdatePictureViewModelUrl(pictureGalleryVmMapped, appBaseUrl);
                                    
            return this.PartialView("_PictureDetailPartial", pictureGalleryVmMapped);
        }

        private PictureGalleryVm UpdatePictureViewModelUrl(PictureGalleryVm pictureVm, string appBaseUrl)
        {
            if (pictureVm.GetFrom == GetPictureContentFrom.LocalServerUrl)
            {
                // TODO cash this path
                var localServerPath = string.Empty;
                if (String.IsNullOrEmpty(pictureVm.Url))
                {
                    localServerPath = appBaseUrl + GlobalConsts.Image.Paths.LocalResource;
                    pictureVm.Url = localServerPath + GlobalConsts.Image.FileNames.NoImage;
                }
                else
                {
                    localServerPath = appBaseUrl + GlobalConsts.Image.UploadConfiguration.ImageUploadPath;
                    pictureVm.Url = localServerPath + pictureVm.Url;
                }                
            }

            return pictureVm;
        }
    }
}
