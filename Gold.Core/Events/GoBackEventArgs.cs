using Gold.Core.Components;
using Gold.Core.Interfaces;

namespace Gold.Core.Events
{
    public class GoBackEventArgs : ComponentEventArgs
    {
        public GoBackEventArgs(IComponent component) : base(component)
        {
        }
    }
}