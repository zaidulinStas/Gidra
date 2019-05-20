using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.Core.Model
{
    /// <summary>
    /// Класс процесса
    /// </summary>
    public class Process : BaseProcedure
    {
        /// <summary>
        /// Список процедур
        /// </summary>
        public IList<IProcedure> Procedures { get; set; } = new List<IProcedure>();

        /// <summary>
        /// Начальная процедура
        /// </summary>
        public IProcedure StartProcedure { get; set; }

        /// <summary>
        /// Конечная процедура
        /// </summary>
        public IProcedure EndProcedure { get; set; }


        /// <summary>
        /// Функция, вызывающаяся при начале моделирования 
        /// </summary>
        protected override bool OnStartModeling()
        {
            var newToken = new Token();

            foreach (var input in StartProcedure.Inputs)
            {
                input.Tokens.Enqueue(newToken);
            }

            return true;
        }

        /// <summary>
        /// Обновление моделирования процедуры
        /// </summary>
        protected override bool OnUpdateModeling(double curTime)
        {
            foreach (var procedure in Procedures)
            {
                procedure.Update(curTime);
            }

            return !EndProcedure.Outputs.Any(x => x.Tokens.Any());
        }

        /// <summary>
        /// Функция, вызывающаяся при окончании моделирования 
        /// </summary>
        protected override bool OnEndModeling()
        {
            foreach (var output in EndProcedure.Outputs)
            {
                output.Tokens.Dequeue();
            }

            return true;
        }
    }
}
