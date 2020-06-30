using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShoppingStore.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "ProductsList", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Default2",
               url: "WP/{controller}/{action}/{page}",
               defaults: new { controller = "Product", action = "ProductsList" },
               constraints: new { page = @"\d+" }
           );

            routes.MapRoute(
                name: "CategoryRoute",
                url: "C/{controller}/{action}/{category}",
                defaults: new { controller = "Product", action = "ProductsListByCategory", page = 1 }
                );
        }
    }
}
