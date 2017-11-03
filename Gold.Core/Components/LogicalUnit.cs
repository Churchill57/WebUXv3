using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Gold.Core.Attributes;
using Gold.Core.Events;
using Gold.Core.Interfaces;

namespace Gold.Core.Components
{
    public abstract class LogicalUnit : ILogicalUnit
    {
        public IGoldServices GoldServices { get; internal set; }

        public abstract IComponent GetNextComponent(IComponentEventArgs componentEventArgs);

        public int TaskId { get; set; }
        public string ClientRef { get; set; }
    }

    //public abstract class AbstractLogicalUnitV2 : ILogicalUnit
    //{
    //    protected readonly IGoldServices GoldServices;
    //    protected AbstractLogicalUnitV2(IGoldServices goldServices)
    //    {
    //        GoldServices = goldServices;
    //    }

    //    public abstract IComponent GetNextComponent(IComponentEventArgs componentEventArgs);

    //    public int TaskId { get; set; }
    //    public string ClientRef { get; set; }
    //}

}
