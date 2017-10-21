using System;
using System.Web;

using Microsoft.Web.Infrastructure.DynamicModuleHelper;

using Ninject;
using Ninject.Web.Common;
using Ninject.Extensions.Conventions;
using MyWoodenHouse.Data.Provider.Operations.Contracts;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Provider.Operations;
using MyWoodenHouse.Data.Provider;
using System.Data.Entity;
using MyWoodenHouse.Default.Auth.Managers;
using MyWoodenHouse.Default.Auth.Contracts;
using MyWoodenHouse.Models;
using MyWoodenHouse.Data.Services;
using MyWoodenHouse.Data.Services.Contracts;
using Microsoft.AspNet.Identity.Owin;
using AutoMapper;
using MyWoodenHouse.Client.Web.Infrastructure;
using System.Reflection;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MyWoodenHouse.Client.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MyWoodenHouse.Client.Web.App_Start.NinjectWebCommon), "Stop")]

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
        private static IKernel CreateKernel()
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

            // Data DbContext
            kernel.Bind(typeof(DbContext), typeof(MyWoodenHouseDbContext)).To<MyWoodenHouseDbContext>().InRequestScope();
            kernel.Bind<IEfDbContextSaveChanges>().To<EfDbContextSaveChanges>();

            // Data Repository
            kernel.Bind(typeof(IEfCrudOperatons<>)).To(typeof(EfCrudOperatons<>));
            kernel.Bind<IBuildingCrudOperations>().To<BuildingCrudOperations>();

            // Auth services
            kernel.Bind<ISignInService>().ToMethod(_ => HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>());
            kernel.Bind<IUserService>().ToMethod(_ => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>());

            // Mappers
            //kernel.Bind<IMapper>().To<Mapper>();
            var myAssembly = Assembly.GetExecutingAssembly();
            kernel.Bind<IMapper>()
                .ToMethod(context =>
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        //cfg.AddProfile<MappingProfile>();
                        cfg.AddProfiles(myAssembly);
                        // tell automapper to use ninject when creating value converters and resolvers
                        cfg.ConstructServicesUsing(t => kernel.Get(t));
                    });
                    return config.CreateMapper();
                }).InSingletonScope();

            // Data services   
            kernel.Bind(typeof(IBaseGenericService<Category>)).To<CategoryService>();
            kernel.Bind(typeof(IBaseGenericService<Material>)).To<MaterialService>();
            kernel.Bind(typeof(IBaseGenericService<Picture>)).To<PictureService>();
            kernel.Bind(typeof(IBaseGenericService<Product>)).To<ProductService>();
            kernel.Bind<IBaseGenericService<Building>>().To<BuildingService>();

        }
    }
}
