using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Gold.Core.Attributes;
using Gold.Core.Interfaces;

namespace Gold.Core.Components
{
    public class ComponentStateHandler : IComponentStateHandler
    {
        public void GetState(object obj, IComponentState state)
        {
            foreach (var propertyInfo in GetStatePropertyInfo(obj))
            {
                if (state.ContainsKey(propertyInfo.Name))
                {
                    state[propertyInfo.Name] = propertyInfo.GetValue(obj);
                }
                else
                {
                    state.Add(propertyInfo.Name, propertyInfo.GetValue(obj));
                }
            }
        }

        public void SetState(IComponentState state, object obj)
        {
            foreach (var propertyInfo in GetStatePropertyInfo(obj))
            {
                if (!state.ContainsKey(propertyInfo.Name)) continue;
                var propertyType = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                propertyInfo.SetValue(this, Convert.ChangeType(state[propertyInfo.Name], propertyType), null);
            }
        }

        public IEnumerable<PropertyInfo> GetStatePropertyInfo(object obj)
        {
            return
                from propInfo in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                let attr = propInfo.GetCustomAttributes(typeof(ComponentStateAttribute), true)
                where attr.Length > 0
                select propInfo;
        }

    }
}
