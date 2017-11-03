using System.Collections.Generic;
using System.ComponentModel;
using Gold.Core.Interfaces;

namespace Gold.Core.Interfaces
{
    public interface IComponent
    {
        int TaskId { get; set; }
        string ClientRef { get; set; }
    }
}