using System.Web.Mvc;
using System.Web.Routing;
using SmartStore.Web.Framework.Routing;

namespace SmartStore.Plugin.SmartStoreAndMore
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("SmartStore.AndMore",
                 "Plugins/SmartStoreAndMore/{action}",
                 new { controller = "SmartStoreAndMore", action = "Configure" },
                 new[] { "SmartStore.SmartStoreAndMore.Controllers" }
            )
            .DataTokens["area"] = "SmartStore.AndMore";
        }

        public int Priority
        {
            get
            {
                return 0;
            }
        }
    }
}
