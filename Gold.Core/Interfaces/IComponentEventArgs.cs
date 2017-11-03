using Gold.Core.Components;
using Gold.Core.Interfaces;

namespace Gold.Core.Interfaces

{
    public interface IComponentEventArgs
    {
        IComponent Component { get; set; }
        bool Handled { get; set; }
    }
}