using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AMQH
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            //System.Web.Mvc.ActionResult BookList(Int32)”的不可以为 null 的类型“System.Int32”的参数“id”，参数字典包含一个 null 项。可选参数必须为引用类型、可以为 null 的类型或声明为可选参数。
        }
    }
}
