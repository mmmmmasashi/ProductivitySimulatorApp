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
        private bool hasBug;
        public bool HasBug => hasBug;

        public FeatureTask(bool hasBug = false)
        {
            this.hasBug = hasBug;
        }

        public ITask Done(bool hasBug)
        {
            return new FeatureTask(hasBug);
        }
    }
}
