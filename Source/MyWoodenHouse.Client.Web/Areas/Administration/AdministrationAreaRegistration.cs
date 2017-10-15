using MyWoodenHouse.Client.Web.App_Start;
using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;

namespace MyWoodenHouse.Client.Web.Areas.Administration
{
    [ExcludeFromCodeCoverage]
    public class AdministrationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.Routes.LowercaseUrls = true;
            context.MapRoute(
                name: "Administration_default",
                url: "Administration/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
                //constraints: new { controller = @"(Categories)" },
                //namespaces: new[] { "MyWoodenHouse.Client.Web.Areas.Administration.Controllers" }
            );
        }
    }
}