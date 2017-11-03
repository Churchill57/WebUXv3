using Gold.Core.Events;
using Gold.Core.Interfaces;

namespace Gold.Core.Interfaces
{
    public interface ILogicalUnit : IComponent
    {
        IComponent GetNextComponent(IComponentEventArgs componentEventArgs);
    }

    //public interface ILogicalUnit
    //{
    //    int TaskId { get; set; }
    //    string ClientRef { get; set; }
    //    IComponent GetNextComponent(IComponentEventArgs componentEventArgs);
    //}

    //public interface ILogicalUnit : IComponent
    //{
    //    IComponent GetNextComponent(IComponentEventArgs componentEventArgs);
    //}
}