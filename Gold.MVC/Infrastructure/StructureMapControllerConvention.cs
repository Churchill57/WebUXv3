using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.Pipeline;
using StructureMap.TypeRules;

namespace Gold.MVC.Infrastructure
{
    public class StructureMapControllerConvention : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            if (type.CanBeCastTo(typeof(Controller)) && !type.IsAbstract)
            {
                registry.For(type).LifecycleIs(new UniquePerRequestLifecycle());
            }
        }
    }
}