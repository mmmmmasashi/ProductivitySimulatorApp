using ProductivitySimDomainLib.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivitySimDomainLib.Task
{
    internal class FeatureTask : ITask
    {
        public ITask Done()
        {
            return new FeatureTask();
        }
    }
}
