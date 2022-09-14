using ProductivitySimDomainLib.Output;
using ProductivitySimDomainLib.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivitySimDomainLib.Unit
{
    internal class DevTeam : IUnit
    {
        private Queue<ITask> _taskQueue;
        private readonly decimal _taskPerTime;
        private decimal _amountOfWip;//Work In Progress(仕掛かりタスク)の量
        private double failureRate;

        /// <summary>
        /// 開発チーム
        /// </summary>
        /// <param name="taskPerTime">単位時間あたりにこなせるタスクの量(=処理速度)</param>
        public DevTeam(decimal taskPerTime)
        {
            _amountOfWip = 0M;
            _taskQueue = new Queue<ITask>();
            _taskPerTime = taskPerTime;
        }

        public DevTeam(decimal taskPerTime, double failureRate) : this(taskPerTime)
        {
            this.failureRate = failureRate;
        }

        public void Input(ITask task)
        {
            _taskQueue.Enqueue(task);
        }

        public List<IOutput> NextOutput()
        {
            _amountOfWip += _taskPerTime;
            int outputCapability = CalculateOutputThisTime(_amountOfWip);
            _amountOfWip -= outputCapability;

            int outputThisTime = Math.Min(outputCapability, _taskQueue.Count);
            return Enumerable.Range(0, outputThisTime).Select(_ => _taskQueue.Dequeue().Done()).ToList();
        }

        private int CalculateOutputThisTime(decimal amountOfWip)
        {
            return (int)Math.Truncate(amountOfWip);
        }
    }
}
