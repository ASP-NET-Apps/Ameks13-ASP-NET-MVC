using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using MyWoodenHouse.Client.Web.App_Start;
using Ninject.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWeb), "Start")]

namespace MyWoodenHouse.Client.Web.App_Start
{

    public static class NinjectWeb 
    {
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
        }
    }
}
