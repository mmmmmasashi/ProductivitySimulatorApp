using ProductivitySimDomainLib.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivitySimDomainLib.Task
{
    internal interface ITask
    {
        ITask Done(bool hasBug);
        bool HasBug { get; }
    }
}
