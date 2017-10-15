using Microsoft.AspNet.Identity.Owin;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using MyWoodenHouse.Client.Web.App_Start;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Buildings;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Categories;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Materials;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Pictures;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.PriceCategories;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Prices;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Products;
using MyWoodenHouse.Client.Web.MyMappers;
using MyWoodenHouse.Client.Web.MyMappers.Contracts;
using MyWoodenHouse.Contracts.Models;
using MyWoodenHouse.Data.Provider;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Provider.Operations;
using MyWoodenHouse.Data.Provider.Operations.Contracts;
using MyWoodenHouse.Data.Services;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Default.Auth.Contracts;
using MyWoodenHouse.Default.Auth.Managers;
using MyWoodenHouse.Ef.Models;
using Ninject;
using Ninject.Web.Common;
using Ninject.Extensions.Conventions;
//using Ninject.Web.Mvc.FilterBindingSyntax;
using System;
using System.Data.Entity;
using System.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace MyWoodenHouse.Client.Web.App_Start
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        public static IKernel CreateKernel()
        {
            Kernel = new StandardKernel();
            try
            {
                Kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                Kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(Kernel);
                return Kernel;
            }
            catch
            {
                Kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Expose the kernal to be used in other project classes.
        /// </summary>
        /// <returns>The created kernel.</returns>
        public static IKernel Kernel { get; private set; }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(x =>
            {
                x.FromThisAssembly()
                 .SelectAllClasses()
                 .BindDefaultInterface();
            });

            // TODO, automatically binding is not working, manually binded below
            kernel.Bind(x =>
            {
                x.FromAssemblyContaining(typeof(IDataService))
                 .SelectAllClasses()
                 .BindDefaultInterface();
            });

            // Data DbContext
            kernel.Bind(typeof(DbContext), typeof(MyWoodenHouseDbContext)).To<MyWoodenHouseDbContext>().InRequestScope();
            kernel.Bind<IEfDbContextSaveChanges>().To<EfDbContextSaveChanges>();

            // Data Repository
            kernel.Bind(typeof(IEfCrudOperatons<>)).To(typeof(EfCrudOperatons<>));
            kernel.Bind<IBuildingCrudOperations>().To<BuildingCrudOperations>();
            
            // Auth services
            kernel.Bind<ISignInService>().ToMethod(_ => HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>());
            kernel.Bind<IUserService>().ToMethod(_ => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>());

            // Data services   
            kernel.Bind(typeof(IBaseGenericService<Category>)).To<CategoryService>();
            kernel.Bind(typeof(IBaseGenericService<Material>)).To<MaterialService>();
            kernel.Bind(typeof(IBaseGenericService<Picture>)).To<PictureService>();
            //kernel.Bind<IBaseGenericService<Product>>().To<ProductService>();
            //kernel.Bind<IBaseGenericService<Building>>().To<BuildingService>();

            // My view model mappers
            kernel.Bind<IGenericModelMapper<Category, CategoryCompleteViewModel>>().To<CategoryModelMapper>().InSingletonScope();
            kernel.Bind<IGenericModelMapper<Material, MaterialCompleteViewModel>>().To<MaterialModelMapper>().InSingletonScope();
            kernel.Bind<IGenericModelMapper<Picture, PictureCompleteViewModel>>().To<PictureModelMapper>().InSingletonScope();
            //kernel.Bind<IGenericModelMapper<Price, PriceCompleteViewModel>>().To<PriceModelMapper>().InSingletonScope();
            //kernel.Bind<IGenericModelMapper<PriceCategory, PriceCategoryCompleteViewModel>>().To<PriceCategoryMapper>().InSingletonScope();
            //kernel.Bind<IGenericModelMapper<Product, ProductCompleteViewModel>>().To<ProductModelMapper>().InSingletonScope();
            //kernel.Bind<IGenericModelMapper<Building, BuildingCompleteViewModel>>().To<BuildingModelMapper>().InSingletonScope();

        }
    }
}
