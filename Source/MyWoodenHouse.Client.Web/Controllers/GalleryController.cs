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
           
            return View(picturesGalleryVm[0]);
        }

        public PartialViewResult GetNextPicture(int id)
        {

            var nextId = id + 1;
            var picture = this.pictureService.GetById(nextId);
            if (picture == null)
            {
                //return HttpNotFound();
            }

            var pictureGalleryVmMapped = this.mapper.Map<Picture, PictureGalleryVm>(picture);

            return PartialView("_PictureNextPreviewPartial", pictureGalleryVmMapped);
        }
    }
}
