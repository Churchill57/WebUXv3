using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold.Core.Interfaces
{
    public interface IGoldServices
    {
        ITaskManager TaskManager { get; set; }
        IEntityContextManager EntityContextManager { get; set; }
    }
}
