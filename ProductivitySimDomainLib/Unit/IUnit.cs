using ProductivitySimDomainLib.Output;
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
        /// <summary>
        /// ユニットにタスクを渡す
        /// </summary>
        /// <param name="task">処理対象のタスク</param>
        void Input(ITask task);

        /// <summary>
        /// 単位時間経過時のアウトプットを受け取る
        /// </summary>
        /// <returns>処理されたタスク</returns>
        List<IOutput> NextOutput();
    }
}
