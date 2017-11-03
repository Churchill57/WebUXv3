using Gold.Core.Components;
using Gold.Core.Interfaces;

namespace Gold.Core.Events
{
    public class ComponentCompletedEventArgs : ComponentEventArgs
    {
        public ComponentCompletedEventArgs(IComponent component) : base(component)
        {
        }
    }
}