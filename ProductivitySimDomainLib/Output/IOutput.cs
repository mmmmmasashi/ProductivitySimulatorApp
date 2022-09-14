using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivitySimDomainLib.Output
{
    internal interface IOutput
    {
        bool HasBug { get; }
    }
}
