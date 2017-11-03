using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using StructureMap;
using StructureMap.Graph;

namespace Gold.MVC.Infrastructure
{
    internal class StructureMapBootstrapper
    {
        private static readonly Lazy<Container> ContainerBuilder =
            new Lazy<Container>(GetContainer, LazyThreadSafetyMode.ExecutionAndPublication);

        public static IContainer Container => ContainerBuilder.Value;

        private static Container GetContainer()
        {
            var container = new Container();
            container.Configure(config =>
            {
                config.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions(); // ISomeType --> SomeType
                    scan.With(new StructureMapControllerConvention());
                });

            });
            return container;
        }
    }
}