using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StructureMap;

#region StructureMap
namespace Gold.MVC.Infrastructure
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        private readonly Func<IContainer> _containerFactory;

        public StructureMapDependencyResolver(Func<IContainer> containerFactory)
        {
            _containerFactory = containerFactory;
        }
        public object GetService(Type serviceType)
        {
            if (serviceType == null) return null;
            object service;
            var container = _containerFactory();
            if (serviceType.IsAbstract || serviceType.IsInterface)
            {
                service = container.TryGetInstance(serviceType);
            }
            else // concrete type
            {
                service = container.GetInstance(serviceType);
            }
            return service;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var container = _containerFactory();
            return container.GetAllInstances(serviceType).Cast<object>();
        }
    }
}
#endregion
