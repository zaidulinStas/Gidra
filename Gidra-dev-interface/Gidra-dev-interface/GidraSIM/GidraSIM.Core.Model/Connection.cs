using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.Core.Model
{
    /// <summary>
    /// Класс соединения
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Очередь токенов
        /// </summary>
        public Queue<Token> Tokens { get; } = new Queue<Token>();

        /// <summary>
        /// Начало соединения
        /// </summary>
        public BaseProcedure Begin { get; set; }

        /// <summary>
        /// Конец соединения
        /// </summary>
        public BaseProcedure End { get; set; }
    }
}
