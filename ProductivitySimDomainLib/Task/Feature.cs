using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivitySimDomainLib.Task
{
    /// <summary>
    /// 完成済みの機能
    /// </summary>
    internal class Feature : ITask
    {
        public ITask Done()
        {
            throw new NotImplementedException();
        }
    }
}
