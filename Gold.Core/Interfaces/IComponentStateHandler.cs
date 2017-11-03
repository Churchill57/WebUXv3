using System.Collections.Generic;
using System.Reflection;

namespace Gold.Core.Interfaces
{
    public interface IComponentStateHandler
    {
        void GetState(object obj, IComponentState state);
        void SetState(IComponentState state, object obj);

        IEnumerable<PropertyInfo> GetStatePropertyInfo(object obj);
    }
}