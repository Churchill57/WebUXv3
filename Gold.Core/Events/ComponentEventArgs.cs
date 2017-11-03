using System;
using Gold.Core.Components;
using Gold.Core.Interfaces;

namespace Gold.Core.Events
{
    public class ComponentEventArgs : EventArgs, IComponentEventArgs
    {
        public IComponent Component { get; set; }
        public bool Handled { get; set; }

        public ComponentEventArgs(IComponent component)
        {
            Component = component;
            Handled = false;
        }
    }
}