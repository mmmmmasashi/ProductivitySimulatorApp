using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivitySimDomainLib.Output
{
    internal class FeatureOutput : IOutput
    {
        private bool hasBug;

        public FeatureOutput()
        {
        }

        public FeatureOutput(bool hasBug)
        {
            this.hasBug = hasBug;
        }

        public bool HasBug => hasBug;
    }
}
