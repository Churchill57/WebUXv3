using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Gold.MVC.Infrastructure;
using StructureMap;
using StructureMap.Graph;

namespace Gold.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {

        #region StructureMap

        // Here we are using a StructureMap nested container to implement the container per request pattern.
        // This is particularly important for Entity Framework db contexts.
        // StructureMap nested containers differ from regular containers in a couple of key ways...
        // 1 Creates transient objects which are singleton within the scope of the nested container.
        //   Also uses any singleton from a parent container (if there is one) rather than create its own singleton.
        // 2 Disposes objects recursively.

        // WARNING
        // MVC doesn't allow a single instance of a controller to be reused (even for child requests) in a single http request,
        // so controllers should not be part of a container per request pattern. See StructureMapControllerConvention class.

        // We are hanging the StructureMap container off the current Http context.
        public IContainer Container
        {
            get => (IContainer) HttpContext.Current.Items["_Container"];
            set => HttpContext.Current.Items["_Container"] = value;
        }

        private IContainer CreateStructureMapNestedContainer()
        {
            return StructureMapBootstrapper.Container.GetNestedContainer();
        }

        private void DisposeStructureMapNestedContainer()
        {
            Container.Dispose();
            Container = null;
        }

        protected void Application_BeginRequest()
        {
            Container = CreateStructureMapNestedContainer();
        }

        protected void Application_EndRequest()
        {
            DisposeStructureMapNestedContainer();
        }

        #endregion

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            #region StructureMap
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(() => Container ?? StructureMapBootstrapper.Container));
            #endregion
        }
    }
}
