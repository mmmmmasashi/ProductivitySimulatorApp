﻿using ProductivitySimDomainLib.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivitySimDomainLib.Task
{
    internal class FeatureTask : ITask
    {
        public IOutput Done()
        {
            return new FeatureOutput();
        }
    }
}
