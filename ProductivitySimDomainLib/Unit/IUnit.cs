using ProductivitySimDomainLib.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivitySimDomainLib.Unit
{
    internal interface IUnit
    {
        void Input(ITask task);
        List<ITask> NextOutput();
    }
}
