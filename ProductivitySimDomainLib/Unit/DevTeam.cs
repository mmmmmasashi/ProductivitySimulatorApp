using ProductivitySimDomainLib.Task;
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
        private readonly Random _random;
        private decimal _amountOfWip;//Work In Progress(仕掛かりタスク)の量
        private double _failureRate;

        /// <summary>
        /// 開発チーム
        /// </summary>
        /// <param name="taskPerTime">単位時間あたりにこなせるタスクの量(=処理速度)</param>
        public DevTeam(decimal taskPerTime, double failureRate)
        {
            if (taskPerTime < 0) throw new ArgumentOutOfRangeException();
            if (failureRate < 0 || 1.0f < failureRate) throw new ArgumentOutOfRangeException();

            _amountOfWip = 0M;
            _taskQueue = new Queue<ITask>();
            _taskPerTime = taskPerTime;
            _failureRate = failureRate;
            _random = new Random();
        }

        public void Input(ITask task)
        {
            _taskQueue.Enqueue(task);
        }

        public List<ITask> NextOutput()
        {
            _amountOfWip += _taskPerTime;
            int outputCapability = CalculateOutputThisTime(_amountOfWip);
            _amountOfWip -= outputCapability;

            int outputThisTime = Math.Min(outputCapability, _taskQueue.Count);

            var outputs = new List<ITask>();
            Enumerable.Range(0, outputThisTime).ToList().ForEach(_ =>
            {
                var task = _taskQueue.Dequeue();
                outputs.Add(task.Done(false));

                bool hasFailure = _random.NextDouble() < _failureRate;
                if (hasFailure)
                {
                    outputs.Add(new Bug());
                }
            });
            return outputs;
        }

        private int CalculateOutputThisTime(decimal amountOfWip)
        {
            return (int)Math.Truncate(amountOfWip);
        }
    }
}
