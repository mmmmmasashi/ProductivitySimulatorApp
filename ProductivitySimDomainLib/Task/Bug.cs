using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivitySimDomainLib.Task
{
    internal class Bug : ITask
    {
        public bool HasBug => true;

        public ITask Done(bool hasBug)
        {
            throw new NotImplementedException();
        }
    }
}
